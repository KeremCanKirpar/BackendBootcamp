namespace Soru_4;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Lütfen bir yıl girin: ");
        int yil = Convert.ToInt32(Console.ReadLine());

        if ((yil % 4 == 0 && yil % 100 != 0) || (yil % 400 == 0))
        {
            Console.WriteLine($"{yil} artık yıldır.");
        }
        else
        {
            Console.WriteLine($"{yil} artık yıl değildir.");
        }
    }
}
