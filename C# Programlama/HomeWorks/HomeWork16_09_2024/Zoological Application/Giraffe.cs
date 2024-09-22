using System;

namespace Zoological_Application;

public class Giraffe : Animal
{
        public Giraffe(string name, int age, string species) : base (name, age, species)
        {
            
        }
    public override void MakeSound()
    {
        base.MakeSound();
        System.Console.WriteLine("Zürafa Sesi");
    }
}
