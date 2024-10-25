using System;

namespace HomeWork16092024.ÇalışanYönetimSistemi;

public class Developer : Employee
{
    public Developer(string name, int ıd, decimal salary, string programmingLanguage) : base(name, ıd, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }
    public string ProgrammingLanguage { get; set; }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        System.Console.WriteLine($"Programlama Dili:{ProgrammingLanguage}");
    }
}
