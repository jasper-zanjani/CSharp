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
      worker.DoWork(2, WorkType.Golf);

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
