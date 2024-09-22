using System;

namespace Zoological_Application;

public class Elephant : Animal
{
    public Elephant (string name, int age, string species) :base (name, age, species)
    {

    }
    public override void MakeSound()
    {
        base.MakeSound();
        System.Console.WriteLine("Borazan Sesi");
    }
}
