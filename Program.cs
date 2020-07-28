using System;

namespace csharp {
  class Program {
    static void Main(string[] args) {
      //helloworld();
      newcar();
    }
    static void helloworld() {
      Console.WriteLine("Hello World");
    }
    // static void trydate() {
    //   Console.WriteLine("Write a date (MM/DD/YYYY):");
    //   DateTime date = DateTime.Parse(Console.ReadLine());
    //   Console.WriteLine("Parsed date: {0}",date.ToString());
    // }
    // static void getname() {
    //   Console.WriteLine("What's your name?");
    //   string name = Console.ReadLine();
    //   Console.WriteLine("Hello, {0}!",name);
    // }
    // static void getage() {
    //   Console.WriteLine("How old are you?");
    //   int age = int.Parse(Console.ReadLine());
    //   age += 1;
    //   Console.WriteLine("Next year you'll be {0} years old",age.ToString());
    //   age += 1;
    //   Console.WriteLine("and the year after you'll be {0}}!",age.ToString());
    // } 
    // static void getsign() {
    //   enum Sign {
    //     AQUARIUS
    //     ARIES,
    //     CANCER,
    //     CAPRICORN,
    //     GEMINI,
    //     LEO,
    //     LIBRA,
    //     PISCES,
    //     SAGITTARIUS
    //     SCORPIO,
    //     TAURUS
    //     VIRGO
    //   }
    //   Console.WriteLine("What month were you born (01-12):");
    //   month = Console.ReadLine();
    //   Console.WriteLine("What day were you born (01-31):");
    //   day = Console.ReadLine();
    //   # sign = ...
    //   Console.WriteLine("Your sign is {0}!",sign);
    // }
    static void newcar() {
      Car myCar = new Car();
      myCar.Make = "Oldsmobile";
      myCar.Model = "Cutlass Supreme";
      myCar.Color = "Silver";
      myCar.Year = 1986;
      Console.WriteLine("{0} {1} {2} {3}", myCar.Year, myCar.Color, myCar.Make, myCar.Model);
    }
    class Car {
      public string Make {get; set;}
      public string Model {get; set;}
      public string Color {get; set;}
      public int Year {get; set;}
    }
} }
