using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
  public class StarshipMission
  {
    public event EventHandler<MissionStatusReportEventArgs> MissionStatusReport;
    public event EventHandler MissionCompleted;

    public void StartMission(int distance, MissionType workType)
    {
      for (int i = 0; i < distance; i++)
      {
        System.Threading.Thread.Sleep(500);
        OnMissionStatusReport(distance - i, workType);
      }
      OnMissionCompleted();
    }

    protected virtual void OnMissionStatusReport(int distance, MissionType missionType)
    {
      Console.WriteLine($"{missionType} mission status report: {distance} from objective!");
      var del = MissionStatusReport as EventHandler<MissionStatusReportEventArgs>;
      if (del != null)
      {
        del(this, new MissionStatusReportEventArgs(distance, missionType));
      }
    }

    protected virtual void OnMissionCompleted()
    {
      Console.WriteLine("Arrived at objective! Mission complete!");
      var del = MissionCompleted as EventHandler;
      if (del != null)
      {
        del(this, EventArgs.Empty);
      }
    }
  }
}
