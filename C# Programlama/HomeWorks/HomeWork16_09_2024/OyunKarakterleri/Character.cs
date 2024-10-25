using System;
using System.Runtime.InteropServices;

namespace HomeWork16092024.OyunKarakterleri;

public class Character
{

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
    public string Name { get; set; }
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            if (value > 0 && value <= 100)

                health = value;

            else System.Console.WriteLine("1 ile 100 arası bir can giriniz!.");

        }
    }





}
