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
      enterpriseMission.MissionStatusReport += new EventHandler<MissionStatusReportEventArgs>(FirstContact);

      enterpriseMission.StartMission(2, MissionType.Exploration);

      Console.Read();
    }

    static void FirstContact(int distance, MissionType missiontype)
    {
      Console.WriteLine("Making first contact!");
    }
  }

  public enum MissionType
  {
    Exploration, Investigation, Intercept
  }
}
