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
      var worker = new Worker();
      worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
      {
        Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
      };
      worker.WorkCompleted += delegate (object sender, EventArgs e)
      {
        Console.WriteLine("Worker is done");
      };
      worker.DoWork(8, WorkType.GenerateReports);

      Console.Read();
    }
  }

  public enum WorkType
  {
    GoToMeetings,
    Golf,
    GenerateReports
  }
}
