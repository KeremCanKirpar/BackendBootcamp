using System;

namespace HomeWork16092024.TaşıtYönetimSistemi;

public class Bicycle : Vehicle
{
    public Bicycle(string make, string model, int year, string sepetVarMi) : base(make, model, year)
    {
        SepetVarMi = sepetVarMi;
    }

    public string SepetVarMi { get; set; }

    public override void Bilgilendirme()
    {
        base.Bilgilendirme();
        System.Console.WriteLine($"SepetVarMi:{SepetVarMi}");
    }
}
