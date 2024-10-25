using System;

namespace HomeWork16092024.Animal;

public class Giraffe : Animal
{
    public Giraffe(string name, int age, string species) : base(name, age, species)
    {

    }

    public override void MakeSound()
    {
        System.Console.WriteLine($"{Name} adlı Zürafa ses çıkardı");
    }
}
