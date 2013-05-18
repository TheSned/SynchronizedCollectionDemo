using SynchronizedCollectionDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SynchronizedCollectionDemo.Helpers
{
  class SampleData
  {
    public static ObservableCollection<StoreModel> GetSampleData()
    {
      return new ObservableCollection<StoreModel>
        {
          new StoreModel
            {
              StoreName = "Hobby Lobby",
              ManagerName = "Phil Haack",
              Employees =
                {
                  new EmployeeModel
                    {
                      Name = "Phil Haack",
                      Age = 35,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Programming"},
                          new HobbyModel {HobbyName = "Speaking"}
                        }
                    },
                  new EmployeeModel
                    {
                      Name = "Scott Hanselman",
                      Age = 49,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Legos"},
                          new HobbyModel {HobbyName = "Star Wars"},
                          new HobbyModel {HobbyName = "Raspberry Pi"}
                        }
                    },
                  new EmployeeModel
                    {
                      Name = "Scott Guthrie",
                      Age = 55,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Speaking"},
                          new HobbyModel {HobbyName = "Making fun of Hanselman"}
                        }
                    },
                }
            },
          new StoreModel
            {
              StoreName = "Michael's",
              ManagerName = "Tim Cook",
              Employees =
                {
                  new EmployeeModel
                    {
                      Name = "Tim Cook",
                      Age = 61,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Making lots of money"},
                          new HobbyModel {HobbyName = "Keeping secrets"}
                        }
                    },
                  new EmployeeModel
                    {
                      Name = "Johny Ive",
                      Age = 42,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Drawing on Napkins"},
                          new HobbyModel {HobbyName = "Being Knighted"},
                          new HobbyModel {HobbyName = "Filming new iPhone intro videos"}
                        }
                    },
                  new EmployeeModel
                    {
                      Name = "Loren Brichter",
                      Age = 38,
                      Hobbies =
                        {
                          new HobbyModel {HobbyName = "Playing Letterpress"}
                        }
                    },
                }
            }
        };
    }

    private static readonly List<string> StoreNames = new List<string>
      {
        "Hobby Lobby",
        "Michael's",
        "Hobbytown USA",
        "The Hobby Shoppe",
        "Microsoft",
        "Apple"
      };

    private static readonly List<string> ManagerNames = new List<string>
      {
        "Jimmy Smith",
        "Brandon Selfling",
        "Todd Holmes",
        "Katy Rose",
        "Nicholas Parish",
        "Harold Buchanan"
      };

    private static readonly List<string> EmployeeNames = new List<string>
      {
        "Scott Hanselman",
        "Scott Guthrie",
        "Phil Haack",
        "Johny Ive",
        "Loren Brichter",
        "Tim Cook"
      };

    private static readonly List<string> HobbyNames = new List<string>
      {
        "Kite Flying",
        "Model Cars",
        "Model Trains",
        "RC Helicopters",
        "Stamp Collecting",
        "Coding",
      };

    private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

    public static StoreModel GetRandomStore()
    {
      var managerIndex = Random.Next(0, ManagerNames.Count);
      var storeNameIndex = Random.Next(0, StoreNames.Count);
      return new StoreModel {StoreName = StoreNames[storeNameIndex], ManagerName = ManagerNames[managerIndex]};
    }

    public static EmployeeModel GetRandomEmployee()
    {
      var nameIndex = Random.Next(0, EmployeeNames.Count);
      var age = Random.Next(17, 66);
      return new EmployeeModel {Name = EmployeeNames[nameIndex], Age = age};
    }

    public static HobbyModel GetRandomHobby()
    {
      var hobbyIndex = Random.Next(0, HobbyNames.Count);
      return new HobbyModel {HobbyName = HobbyNames[hobbyIndex]};
    }
  }
}
