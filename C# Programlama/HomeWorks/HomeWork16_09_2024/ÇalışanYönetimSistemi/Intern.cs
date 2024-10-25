using System;

namespace HomeWork16092024.ÇalışanYönetimSistemi;

public class Intern : Employee
{
    public Intern(string name, int ıd, decimal salary) : base(name, ıd, salary)
    {
    }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        
    }
}
