using System;

namespace Project23_InheritanceSamples.CarManagementSystem;

public  class Vehicle
{
    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public  void Start(){
        Console.WriteLine($"{Brand} Markalı Araba Çalıştı");
    }
    public  void Stop()
    {
        Console.WriteLine($"{Brand} Markalı Araba Durdu");
    }

    public  virtual void ShowCar()
    {
        Console.WriteLine($"Marka: {Brand}\nModel: {Model}\nÇıkış Yılı: {Year}");
    }
    
    
}
