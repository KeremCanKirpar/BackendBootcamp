using System;

namespace HomeWork16092024.OyunKarakterleri;

public class Mage : Character
{
    public Mage(string name, int health) : base(name, health)
    {

    }

    public void CastSpell()
    {
        System.Console.WriteLine("Büyü atıyor.");
    }
    public void ToprakKaldırma()
    {
        System.Console.WriteLine("Toprak Kaldırma yeteneğini atıyor.");
    }

}
