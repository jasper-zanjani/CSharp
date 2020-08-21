using System;
using System.Collections.Generic;

namespace StarshipRedAlert
{

  class Program
  {
    static void Main(string[] args)
    {
      var Enterprise = new Starship("Enterprise");
      Enterprise.TriggerRedAlert();
    }

    public class Starship
    {
      event EventHandler RedAlert;

      public Starship(string name)
      {
        string Name = name;
        RedAlert += ToBattlestations;
        RedAlert += ShieldsUp;
      }
      public void TriggerRedAlert()
      {
        RedAlert(this, EventArgs.Empty);
      }
      public void ToBattlestations(object sender, EventArgs e)
      {
        Console.WriteLine("All hands to battlestations!");
      }

      public void ShieldsUp(object sender, EventArgs e)
      {
        Console.WriteLine("Shields to full power!");
      }
    }
  }
}