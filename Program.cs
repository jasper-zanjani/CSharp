using System;

namespace csharp {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("What's your name?");
      string name = Console.ReadLine();
      Console.WriteLine("Hello, {0}!",name);
      Console.WriteLine("How old are you?");
      int age = int.Parse(Console.ReadLine());
      age += 1;
      Console.WriteLine("Next year you'll be {0} years old",age);
      age += 1;
      Console.WriteLine("and the year after you'll be {0}}!",age);
} } }
