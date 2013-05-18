
using SynchronizedCollectionDemo.Models;

namespace SynchronizedCollectionDemo.ViewModels
{
  class StoreViewModel : ViewModelBase<StoreModel>
  {
    public StoreViewModel(StoreModel model) : base(model)
    {
      this.Employees = new SynchronizedObservableCollection<EmployeeViewModel, EmployeeModel>(model.Employees, employeeModel => new EmployeeViewModel(employeeModel));
    }
    public SynchronizedObservableCollection<EmployeeViewModel, EmployeeModel> Employees { get; private set; }

    public string HeaderText { get { return string.Format("Name: {0} Manager: {1}", Model.StoreName, Model.ManagerName); } }
  }
}
