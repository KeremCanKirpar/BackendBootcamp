using System;

namespace HomeWork16092024.EğitimKurumu;

public class Teacher : Person
{
    public Teacher(string name, int age, string öğrKonu) : base(name, age)
    {
        ÖğrKonu = öğrKonu;
    }

    public string ÖğrKonu { get; set; }
    public override void AttendClass()
    {
        base.AttendClass();
        System.Console.WriteLine($"Dersin Konusu: {ÖğrKonu}\n Öğretmenimiz Derse Katılım Sağlamıştır. :)");
    }
}
