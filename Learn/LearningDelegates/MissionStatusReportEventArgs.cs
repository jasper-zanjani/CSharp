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
}
