using System;

namespace HomeWork16092024.TaşıtYönetimSistemi;

public class Car : Vehicle
{
    public Car(string make, string model, int year, string sanruf) : base(make, model, year)
    {
        Sanruf = sanruf;
    }

    public string Sanruf { get; set; }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        System.Console.WriteLine($"Sanruf:{Sanruf}");
    }
}
