using System;

namespace HomeWork16092024.ÇalışanYönetimSistemi;

public class Employee
{
    public Employee(string name, int ıd, decimal salary)
    {
        Name = name;
        Id = ıd;
        Salary = salary;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public decimal Salary { get; set; }

    public virtual void Bilgilendirme()
    {
        System.Console.WriteLine($"Markası:{Name}\nModeli:{Id}\nYılı:{Salary}");
    }
}
