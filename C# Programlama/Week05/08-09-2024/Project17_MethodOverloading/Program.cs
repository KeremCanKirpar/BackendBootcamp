namespace Project17_MethodOverloading;

class Program
{
    // static int Sum(int a, int b)
    // {
    //     return a + b;
    // }
    // static int Sum(int a, int b, int c)
    // {
    //     return a + b + c;
    // }
    // static int Sum(int a, int b, int c, int d)
    // {
    //     return a + b + c + d;
    // }
    // static void Greet(string name, byte age)
    // {
    //     Console.WriteLine($"Merhaba {age} yaşındaki {name}");
    // }


    static string GetCoffe(string coffeType, int quantitySugar=0, bool withMilk=true)
    {
        string coffe = $"{coffeType} Kahve";
        coffe += quantitySugar>0?$",{quantitySugar}, Şekerli": " Şekersiz";
        if (withMilk)
        {
            coffe += $", Sütlü";
        }
        else
        {
            coffe += $", Sade";
        }
        coffe+="\nKahveniz Hazır Afiyet Olsun...";
        return coffe;
    }


    static void Main(string[] args)
    {
        Console.WriteLine(GetCoffe("Americano", 0));
        Console.WriteLine(GetCoffe("Americano", 0));
        Console.WriteLine(GetCoffe("Americano", 5,false));

























        // Console.WriteLine(Sum(18, 5));
        // Greet("Kerem", 21);
    }
}
