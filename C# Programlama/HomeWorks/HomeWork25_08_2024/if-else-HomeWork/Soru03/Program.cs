namespace Soru03;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Harf Girin: ");
        char letter = Convert.ToChar(Console.ReadLine().ToLower());

        if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' ||
               letter == 'ı' || letter == 'ö' || letter == 'ü')
        {
                System.Console.WriteLine($"Girilen Harf Sesli Harftir {letter}");
        }
        else
        {
            System.Console.WriteLine($"Girilen Harf Sessiz Harftir {letter}");
        }

    }
}
