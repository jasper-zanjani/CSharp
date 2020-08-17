using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
