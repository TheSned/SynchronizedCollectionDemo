
using SynchronizedCollectionDemo.Helpers;

namespace SynchronizedCollectionDemo.ViewModels
{
  class ViewModelBase<TModel>
  {
    public ViewModelBase(TModel model)
    {
      this.Model = model;
    }

    public ViewModelBase()
    {
    }

    public TModel Model { get; set; }
  }

  class WeakReferenceViewModelBase<TModel>
  {
    private WeakReference<TModel> modelReference;

    public WeakReferenceViewModelBase()
    { }

    public WeakReferenceViewModelBase(TModel model)
    {
      this.Model = model;
    }

    public TModel Model
    {
      get { return modelReference.IsAlive ? this.modelReference.Target : default(TModel); }
      set { this.modelReference = new WeakReference<TModel>(value); }
    }
  }
}
