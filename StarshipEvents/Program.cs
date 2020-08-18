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
      new StarshipMission("Antares");
      new StarshipMission("Sirius");
    }
  }

  public class StarshipMission
  {
    public string Destination;
    public Status Status;

    public StarshipMission(string destination)
    {
      Destination = destination;
      Status = Status.Good;

      Random randint = new Random();
      int distance = randint.Next(3, 9);

      UnderwayStatusReportHandler UnderwayMissionLog = new UnderwayStatusReportHandler(SimpleUnderwayStatusReport);
      StatusReportHandler StoppedMissionLog = new StatusReportHandler(SimpleStatusReport);
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
      StoppedMissionLog(Status);
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
      Console.WriteLine(message);
    }

    void SimpleUnderwayStatusReport(Status status, int distance)
    {
      System.Threading.Thread.Sleep(status == Status.Good ? 300 : 600);
      Console.WriteLine($"Underway...{distance} light-years to go..");
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
