using System;

namespace SimpleEvent
{
  class Program
  {
    static void Main(string[] args)
    {
      SimpleEvent eventTrigger = new SimpleEvent();
      
      Console.WriteLine("Triggering event with no subscribers");
      //eventTrigger.Event(eventTrigger, EventArgs.Empty);
      eventTrigger.EventTrigger();

      eventTrigger.Event += new EventHandler(EventSubscriber);

      // Using delegate inference
      //eventTrigger.Event += EventSubscriber;

      Console.WriteLine("Triggering event with the EventSubscriber subscribed");
      //eventTrigger.Event(eventTrigger, EventArgs.Empty);
      eventTrigger.EventTrigger();

      eventTrigger.AddEventSubscriber();

      Console.WriteLine("Triggering event with two events subscribed");
      //eventTrigger.Event(eventTrigger, EventArgs.Empty);
      eventTrigger.EventTrigger();

    }

    static void EventSubscriber(object sender, EventArgs e)
    {
      Console.WriteLine("External event subscriber");
    }

    public class SimpleEvent
    {
      public event EventHandler Event;

      public void AddEventSubscriber()
      {
        // Using delegate inference
        //Event += OnEvent;
        Event += new EventHandler(OnEvent);
      }

      public void EventTrigger()
      {
        if (Event != null) Event(this, EventArgs.Empty);
      }

      protected virtual void OnEvent(object s, EventArgs e)
      {
        Console.WriteLine("Internal event subscriber");

        // This syntax accesses the event delegate directly 
        // https://app.pluralsight.com/course-player?clipId=b0933c46-6864-468e-b645-22d439bf91c6 
        // 1:45
        //var newEvent = Event as EventHandler;
        //newEvent?.Invoke(this, EventArgs.Empty);

        //Event?.Invoke(this, EventArgs.Empty);
        //if (Event != null) Event(this, EventArgs.Empty);
      }

    }
  }
}
