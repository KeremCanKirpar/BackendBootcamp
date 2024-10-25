using System;

namespace HomeWork16092024.OyunKarakterleri;

public class Warrior : Character
{
    public Warrior(string name, int health) : base(name, health)
    {

    }

    public void SwordAttack()
    {
        System.Console.WriteLine("Kılıç saldırısı atıyor.");
    }
    public void RuhVuruşu()
    {
        System.Console.WriteLine("Ruh Vuruşu yeteneğini atıyor.");
    }
}
