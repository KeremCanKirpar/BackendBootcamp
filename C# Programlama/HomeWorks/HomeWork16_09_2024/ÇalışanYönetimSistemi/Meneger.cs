using System;

namespace HomeWork16092024.ÇalışanYönetimSistemi;

public class Meneger : Employee
{
    public Meneger(string name, int ıd, decimal salary, int numberOfTeams) : base(name, ıd, salary)
    {
        NumberOfTeams = numberOfTeams;
    }

    public int NumberOfTeams { get; set; }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        System.Console.WriteLine($"Takım Sayısı:{NumberOfTeams}");
    }
}
