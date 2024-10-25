namespace Soru_6;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Lütfen notunuzu girin (0-100): ");
        int not = Convert.ToInt32(Console.ReadLine());

        if (not >= 90 && not <= 100)
        {
            Console.WriteLine("Harf Notu: AA");
        }
        else if (not >= 85 && not < 89)
        {
            Console.WriteLine("Harf Notu: BA-YE");
        }
        else if (not >= 80 && not < 84)
        {
            Console.WriteLine("Harf Notu: BB-YE");
        }
        else if (not >= 70 && not < 79)
        {
            Console.WriteLine("Harf Notu: CB-YE");
        }
        else if (not >= 60 && not < 69)
        {
            Console.WriteLine("Harf Notu: CC-YE");
        }
        else if (not >= 55 && not < 59)
        {
            Console.WriteLine("Harf Notu: DC-YE");
        }
        else if (not >= 50 && not < 54)
        {
            Console.WriteLine("Harf Notu: DD-YE");
        }
        else if (not >= 40 && not < 49)
        {
            Console.WriteLine("Harf Notu: FD-YS");
        }
        else if (not >= 0 && not < 39)
        {
            Console.WriteLine("Harf Notu: FF - DS");
        }
        else
        {
            Console.WriteLine("Geçersiz not girdiniz.");
        }
    }
}
