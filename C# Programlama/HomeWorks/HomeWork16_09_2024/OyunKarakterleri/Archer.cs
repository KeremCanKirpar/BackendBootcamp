using System;
using System.Reflection.PortableExecutable;

namespace HomeWork16092024.OyunKarakterleri;

public class Archer : Character
{
    public Archer(string name, int health) : base(name, health)
    {

    }
    public void ÇokluAtış()
    {
        System.Console.WriteLine("Çoklu atış yeteneğini kullanıyor.");
    }

    public void AteşlıOk()
    {
        System.Console.WriteLine("Ateşlı Ok yeteneğini kullanıyor.");
    }
}
