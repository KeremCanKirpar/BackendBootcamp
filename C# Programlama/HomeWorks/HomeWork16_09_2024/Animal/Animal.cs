using System;

namespace HomeWork16092024.Animal;

public class Animal
{
    public Animal(string name, int age, string species)
    {
        Name = name;
        Age = age;
        Species = species;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} Ses Çıkarıyor!!");
    }
}
