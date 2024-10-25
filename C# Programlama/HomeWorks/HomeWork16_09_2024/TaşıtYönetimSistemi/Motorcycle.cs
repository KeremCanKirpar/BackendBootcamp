using System;

namespace HomeWork16092024.TaşıtYönetimSistemi;

public class Motorcycle : Vehicle
{
    public Motorcycle(string make, string model, int year, string soğutmasistemi) : base(make, model, year)
    {
        Soğutmasistemi = soğutmasistemi;
    }

    public string Soğutmasistemi { get; set; }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        System.Console.WriteLine($"Soğutma Sistemi:{Soğutmasistemi}");
    }
}
