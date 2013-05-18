
using SynchronizedCollectionDemo.Models;

namespace SynchronizedCollectionDemo.ViewModels
{
  class EmployeeViewModel : WeakReferenceViewModelBase<EmployeeModel>
  {
    public EmployeeViewModel(EmployeeModel model) : base(model)
    {
      this.Hobbies = new SynchronizedObservableCollection<HobbyViewModel, HobbyModel>(model.Hobbies, hobbyModel => new HobbyViewModel(hobbyModel));
    }

    public SynchronizedObservableCollection<HobbyViewModel,HobbyModel> Hobbies { get; private set; }

    public string HeaderText { get { return string.Format("Name: {0} Age: {1}", Model.Name, Model.Age); } }
  }
}
