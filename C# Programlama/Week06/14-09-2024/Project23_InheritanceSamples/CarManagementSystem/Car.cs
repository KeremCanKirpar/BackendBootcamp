using System;

namespace Project23_InheritanceSamples.CarManagementSystem;

public   class Car : Vehicle
{
    public Car(string brand, string model, int year, int countOfDoors) : base(brand, model, year)
    {
        CountOfDoors = countOfDoors;
    }
    int doors;
    public  int CountOfDoors { 
        get
        {
            return doors;
        }
    set
    {
        if(value<=0)
        {
            throw new ArgumentException("Arabanın Kapılarını Girin");
        }
        doors = value;
    }
    }

    public void OpenTrunk()
    {
        Console.WriteLine("Arabanın Kaputu Var.");
    }

    public override void ShowCar()
    {
        base.ShowCar();
        Console.WriteLine($"{CountOfDoors} Kapılı. ");
    }
  
   

}
