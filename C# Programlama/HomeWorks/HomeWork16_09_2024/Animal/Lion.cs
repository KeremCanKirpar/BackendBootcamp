using System;

namespace HomeWork16092024.Animal;

public class Lion : Animal
{
    public Lion(string name, int age, string species) : base(name, age, species)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine($"{Name} kükreme sesi çıkardı");
    }
}
