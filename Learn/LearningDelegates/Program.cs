using System;

namespace DelegatesAndEvents
{
  public class MissionStatusReportEventArgs : EventArgs
  {
    public int Distance;
    public MissionType MissionType;

    public MissionStatusReportEventArgs(int distance, MissionType missionType)
    {
      Distance = distance;
      MissionType = missionType;
    }

    public int Hours { get; set; }
    public MissionType WorkType { get; set; }
  }

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
