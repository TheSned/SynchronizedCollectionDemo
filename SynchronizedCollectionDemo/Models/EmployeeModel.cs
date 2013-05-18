using System.Collections.ObjectModel;

namespace SynchronizedCollectionDemo.Models
{
  class EmployeeModel
  {
    public EmployeeModel()
    {
      this.Hobbies = new ObservableCollection<HobbyModel>();
    }

    public string Name { get; set; }
    public int? Age { get; set; }

    public ObservableCollection<HobbyModel> Hobbies { get; private set; }
  }
}
