using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;

namespace SynchronizedCollectionDemo
{
  public class SynchronizedObservableCollection<TOuter, TInner> : IEnumerable<TOuter>, INotifyCollectionChanged, IWeakEventListener
  {
    private Func<TInner, TOuter> Projection { get; set; }
    private ObservableCollection<TOuter> OuterCollection { get; set; }

    public SynchronizedObservableCollection(ObservableCollection<TInner> innerCollection, Func<TInner, TOuter> projection)
    {
      this.Projection = projection;
      this.OuterCollection = new ObservableCollection<TOuter>();

      ResetCollection(innerCollection);
      CollectionChangedEventManager.AddListener(innerCollection, this);
    }

    public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
    {
      if (managerType != typeof(CollectionChangedEventManager)) return false;

      var args = e as NotifyCollectionChangedEventArgs;
      if (args == null) return false;

      lock (((ICollection)this.OuterCollection).SyncRoot)
      {
        switch (args.Action)
        {
          case NotifyCollectionChangedAction.Add:
            {
              Debug.Assert(args.NewItems.Count == 1);
              var newItem = this.Projection((TInner)args.NewItems[0]);
              this.OuterCollection.Insert(args.NewStartingIndex, newItem);
            }
            break;
          case NotifyCollectionChangedAction.Remove:
            Debug.Assert(args.OldItems.Count == 1);
            this.OuterCollection.RemoveAt(args.OldStartingIndex);
            break;
          case NotifyCollectionChangedAction.Replace:
            {
              Debug.Assert(args.OldItems.Count == 1);
              this.OuterCollection.RemoveAt(args.OldStartingIndex);
              Debug.Assert(args.NewItems.Count == 1);
              var newItem = this.Projection((TInner)args.NewItems[0]);
              this.OuterCollection.Insert(args.NewStartingIndex, newItem);
            }
            break;
          case NotifyCollectionChangedAction.Move:
            Debug.Assert(args.OldItems.Count == 1);
            this.OuterCollection.Move(args.OldStartingIndex, args.NewStartingIndex);
            break;
          case NotifyCollectionChangedAction.Reset:
            ResetCollection(sender as ObservableCollection<TInner>);
            break;
        }
      }
      return true;
    }


    private void ResetCollection(Collection<TInner> innerCollection)
    {
      this.OuterCollection.Clear();
      lock (((ICollection)innerCollection).SyncRoot)
      {
        foreach (var item in innerCollection)
        {
          this.OuterCollection.Add(this.Projection(item));
        }
      }
    }

    public IEnumerator<TOuter> GetEnumerator()
    {
      return this.OuterCollection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged
    {
      add { this.OuterCollection.CollectionChanged += value; }
      remove { this.OuterCollection.CollectionChanged -= value; }
    }
  }
}