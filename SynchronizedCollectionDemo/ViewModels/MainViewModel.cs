using GalaSoft.MvvmLight.Command;
using SynchronizedCollectionDemo.Helpers;
using SynchronizedCollectionDemo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SynchronizedCollectionDemo.ViewModels
{
  class MainViewModel
  {
    public MainViewModel()
    {
      this.StoreModels = SampleData.GetSampleData();
      this.Stores = new SynchronizedObservableCollection<StoreViewModel, StoreModel>(this.StoreModels, model => new StoreViewModel(model));
      this.AddEmployeeCommand = new RelayCommand(ExecuteAddEmployeeCommand);
      this.AddHobbyCommand = new RelayCommand(ExecuteAddHobbyCommand);
      this.AddStoreCommand = new RelayCommand(ExecuteAddStoreCommand);
      this.ClearEmployeesCommand = new RelayCommand(ExecuteClearEmployeesCommand);
      this.ClearHobbiesCommand = new RelayCommand(ExecuteClearHobbiesCommand);
      this.ClearStoresCommand = new RelayCommand(ExecuteClearStoreCommand);
      this.RemoveEmployeeCommand = new RelayCommand(ExecuteRemoveEmployeeCommand);
      this.RemoveHobbyCommand = new RelayCommand(ExecuteRemoveHobbyCommand);
      this.RemoveStoreCommand = new RelayCommand(ExecuteRemoveStoreCommand);
      this.MoveEmployeeDownCommand = new RelayCommand(ExecuteMoveEmployeeDownCommand);
      this.MoveHobbyDownCommand = new RelayCommand(ExecuteMoveHobbyDownCommand);
      this.MoveStoreDownCommand = new RelayCommand(ExecuteMoveStoreDownCommand);
    }

    public ObservableCollection<StoreModel> StoreModels { get; set; }

    private void ExecuteMoveStoreDownCommand()
    {
      if (this.StoreModels.Count == 0) return;
      this.StoreModels.Move(this.StoreModels.Count - 1, 0);
    }

    private void ExecuteMoveHobbyDownCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      var employee = store.Employees[0];
      if (employee.Hobbies.Count == 0) return;
      employee.Hobbies.Move(employee.Hobbies.Count - 1, 0);
    }

    private void ExecuteMoveEmployeeDownCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      store.Employees.Move(store.Employees.Count - 1, 0);
    }

    private void ExecuteRemoveStoreCommand()
    {
      if (this.StoreModels.Count == 0) return;
      this.StoreModels.RemoveAt(0);
    }

    private void ExecuteRemoveHobbyCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      var employee = store.Employees[0];
      if (employee.Hobbies.Count == 0) return;
      employee.Hobbies.RemoveAt(0);
    }

    private void ExecuteRemoveEmployeeCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      store.Employees.RemoveAt(0);
    }

    private void ExecuteClearStoreCommand()
    {
      if (this.StoreModels.Count == 0) return;
      this.StoreModels.Clear();
    }

    private void ExecuteClearHobbiesCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      var employee = store.Employees[0];
      if (employee.Hobbies.Count == 0) return;
      employee.Hobbies.Clear();
    }

    private void ExecuteClearEmployeesCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      store.Employees.Clear();
    }

    private void ExecuteAddStoreCommand()
    {
      this.StoreModels.Add(SampleData.GetRandomStore());
    }

    private void ExecuteAddHobbyCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      if (store.Employees.Count == 0) return;
      var employee = store.Employees[0];
      employee.Hobbies.Add(SampleData.GetRandomHobby());
    }

    private void ExecuteAddEmployeeCommand()
    {
      if (this.StoreModels.Count == 0) return;
      var store = this.StoreModels[0];
      store.Employees.Add(SampleData.GetRandomEmployee());
    }

    public ObservableCollection<StoreModel> Models { get; set; }
    public SynchronizedObservableCollection<StoreViewModel, StoreModel> Stores { get; private set; }

    public ICommand AddStoreCommand { get; set; }
    public ICommand AddEmployeeCommand { get; set; }
    public ICommand AddHobbyCommand { get; set; }
    public ICommand RemoveStoreCommand { get; set; }
    public ICommand RemoveEmployeeCommand { get; set; }
    public ICommand RemoveHobbyCommand { get; set; }
    public ICommand MoveStoreDownCommand { get; set; }
    public ICommand MoveEmployeeDownCommand { get; set; }
    public ICommand MoveHobbyDownCommand { get; set; }
    public ICommand ClearStoresCommand { get; set; }
    public ICommand ClearEmployeesCommand { get; set; }
    public ICommand ClearHobbiesCommand { get; set; }
  }
}
