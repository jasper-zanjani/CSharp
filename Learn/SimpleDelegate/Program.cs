using System;

namespace SimpleDelegate
{
  delegate void OnEvent();

  class Program
  {

    static void Main(string[] args)
    {
      //OnEvent handler = new OnEvent(DelegateImplementation);
      OnEvent handler = () => Console.WriteLine("Implementing delegate");
      handler();

    }

    static void DelegateImplementation()
    {
      Console.WriteLine("Implementing delegate");
    }
  }
}
