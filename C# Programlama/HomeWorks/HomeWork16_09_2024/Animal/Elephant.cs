using System;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork16092024.Animal;

public class Elephant : Animal
{
    public Elephant(string name, int age, string species) : base(name, age, species)
    {
    }

    public override void MakeSound()
    {
        System.Console.WriteLine($"{Name} Boruu sesi çıkardı ");
    }
}
