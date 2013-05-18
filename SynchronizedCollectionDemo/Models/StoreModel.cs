using System.Collections.ObjectModel;

namespace SynchronizedCollectionDemo.Models
{
  class StoreModel
  {
    public StoreModel()
    {
      this.Employees = new ObservableCollection<EmployeeModel>();
    }

    public string StoreName { get; set; }
    public string ManagerName { get; set; }

    public ObservableCollection<EmployeeModel> Employees { get; private set; } 
  }
}
