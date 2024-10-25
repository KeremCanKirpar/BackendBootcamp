using System;
using System.Runtime.InteropServices.Marshalling;

namespace HomeWork16092024.TaşıtYönetimSistemi;

public class Vehicle
{
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public string Make { get; set; }
    public string Model { get;set; }
    public int Year { get; set; }

    public virtual void Bilgilendirme()
    {
        System.Console.WriteLine($"Markası:{Make}\nModeli:{Model}\nYılı:{Year}");
    }

}
