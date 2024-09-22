using System;

namespace Zoological_Application;

public class Lion : Animal
{
    public Lion(string name, int age, string species) : base(name, age, species)
    {
        MakeSound();
    }
    public override void MakeSound()
    {
        base.MakeSound();
        Console.WriteLine($"Kükreme Sesi");
    }
}
