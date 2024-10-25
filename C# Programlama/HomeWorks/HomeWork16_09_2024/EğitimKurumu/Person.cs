using System;

namespace HomeWork16092024.EğitimKurumu;

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void AttendClass()
    {
        System.Console.WriteLine($"Ad: {Name}\nYaş: {Age}");
    }

}
