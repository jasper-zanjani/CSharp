using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
  class Program
  {
    static void Main(string[] args)
    {
      var enterpriseMission = new StarshipMission();
      enterpriseMission.StartMission(2, MissionType.Exploration);

      Console.Read();
    }

  }

  public enum MissionType
  {
    Exploration, Investigation, Intercept
  }
}
