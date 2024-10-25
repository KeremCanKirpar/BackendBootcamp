using System;

namespace HomeWork16092024.EğitimKurumu;

public class Student : Person
{
    public Student(string name, int age, int kaçıncıSınıf) : base(name, age)
    {
        KaçıncıSınıf = kaçıncıSınıf;
    }

    public int KaçıncıSınıf { get; set; }

    public override void AttendClass()
    {
        base.AttendClass();
        System.Console.WriteLine($"Sınıf Seviyesi: {KaçıncıSınıf}\n Öğrencimiz Derse Katılım Sağlamıştır. :)");
    }

}
