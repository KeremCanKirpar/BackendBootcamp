using System;

namespace Project23_InheritanceSamples.CarManagementSystem;

public class Motorcycle : Vehicle
{
    public Motorcycle(string brand, string model, int year, bool coolingSystem) : base(brand, model, year)
    {
        CoolingSystem = coolingSystem;
    }
    public  bool CoolingSystem { get; set; }


    public override void ShowCar()
    {
        base.ShowCar();
        Console.WriteLine($"Soğutma sistemi: {CoolingSystem}");
    }

}
