
using SynchronizedCollectionDemo.Models;

namespace SynchronizedCollectionDemo.ViewModels
{
  class HobbyViewModel : WeakReferenceViewModelBase<HobbyModel>
  {
    public HobbyViewModel(HobbyModel model) : base(model)
     {
      
    }
  }
}
