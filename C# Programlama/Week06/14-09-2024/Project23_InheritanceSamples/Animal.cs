using System;

namespace Project23_InheritanceSamples;

public class Animal
{
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name  { get; set; }
    public int Age { get; set; }

    public virtual void MakeSound() //virtual : methoda yazılırsa istenilirse geçerli / geçersiz kılınabildiğini göstermek için kullanılır
    {
        Console.WriteLine($"{Name} ses çıkardı");
    }

}
