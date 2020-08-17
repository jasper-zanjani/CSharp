using System;

namespace LearningDelegates
{
  public enum WorkType { Golf, Meeting, Report }
  public delegate void WorkPerformedHandler(int hours, WorkType workType);

  class Program
  {
    static void WorkPerformed1( int hours, WorkType workType)
    {
      Console.WriteLine("WorkPerformed1 called");
    }

    static void WorkPerformed2(int hours, WorkType workType)
    {
      Console.WriteLine("WorkPerformed2 called");
    }

    static void Main(string[] args)
    {
      WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
      WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

      del1(1, WorkType.Golf);
      del2(2, WorkType.Report);
    }
  }
}
