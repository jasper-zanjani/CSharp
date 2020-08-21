using System;
using System.Net.Http;

namespace StarshipEvents
{
  public enum Race { Klingons, Romulans, Borg, Humans }
  public enum Status { Good, Damaged, Distress, Destroyed }



  public delegate void StatusReportHandler(Status s);
  public delegate void UnderwayStatusReportHandler(Status s, int d);
  public delegate void BattleReportHandler(Status s, Race e, int n);

  class Program
  {
    static void Main(string[] args)
    {
      new StarshipMission("Sirius");
    }
  }

  public class StarshipMission
  {
    public string Destination;
    public Status Status;

    public event StatusReportHandler StatusReportEvent;

    public StarshipMission(string destination)
    {
      StatusReportEvent += SimpleStatusReport;

      Destination = destination;
      Status = Status.Good;

      Random randint = new Random();
      int distance = randint.Next(3, 9);

      // Basic status report using delegate implementation
      //StatusReportHandler StoppedMissionLog = new StatusReportHandler(SimpleStatusReport);

      UnderwayStatusReportHandler UnderwayMissionLog = new UnderwayStatusReportHandler(SimpleUnderwayStatusReport);
      BattleReportHandler BattleMissionLog = new BattleReportHandler(SimpleBattleReportHandler);

      Console.WriteLine($"Plotting course to {destination}, {distance} light-years away!");


      for (int i = 0; i < distance; i++)
      {
        if (randint.Next(0, 9) > 6)
        {
          BattleMissionLog(Status, Race.Klingons, randint.Next(1, 3));
          switch (Status)
          {
            case Status.Good:
              Status = Status.Damaged;
              break;
            case Status.Damaged:
              Status = Status.Distress;
              break;
            default:
              Status = Status.Destroyed;
              break;
          }
        }
        else
        {
          UnderwayMissionLog(Status, distance - i);
        }
      }
      StatusReportEvent(Status);
      //StatusReportEventHandler(Status, 3);
      //StoppedMissionLog(Status);
    }

    protected virtual void StatusReportEventHandler(Status s, int _)
    {
      // Basic status report using event implementation
      StatusReportEvent(s);

      //var Log = StatusReportEvent as StatusReportHandler;

      //if (Log != null)
      //{
      //  Log(s);
      //}
      //SimpleStatusReport(s);
    }

    void SimpleStatusReport(Status s)
    {
      string message;
      switch (s)
      {
        case Status.Good:
          message = "All systems go!";
          break;
        case Status.Damaged:
          message = "In need of repairs...";
          break;
        case Status.Distress:
          message = "Mayday! In urgent need of assistance!";
          break;
        default:
          message = "[CONTACT LOST]";
          break;
      }
      Console.WriteLine($"STATUS REPORT: {message}");
    }

    void SimpleUnderwayStatusReport(Status status, int distance)
    {
      System.Threading.Thread.Sleep(status == Status.Good ? 300 : 600);
      Console.WriteLine($"UNDERWAY: {distance} light-years remaining...");
    }

    public void OnMissionComplete()
    {
      Console.WriteLine("Mission Complete!");
    }

    void SimpleBattleReportHandler(Status s, Race e, int n)
    {
      Console.WriteLine($"{n} contacts detected! We have engaged the {e}!");
    }
  }
}
