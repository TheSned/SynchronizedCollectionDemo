using System;

namespace SynchronizedCollectionDemo.Helpers
{
  public class WeakReference<T> : WeakReference
  {
    public WeakReference(T target)
      : base(target)
    {

    }

    public new T Target
    {
      get { return (T)base.Target; }
      set { base.Target = value; }
    }
  }
}