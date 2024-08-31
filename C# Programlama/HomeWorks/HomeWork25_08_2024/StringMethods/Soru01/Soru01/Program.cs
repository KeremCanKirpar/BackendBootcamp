namespace Soru01;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Bir Cümle Giriniz:");
        string spaces = Console.ReadLine();

        string[] kelimeler = spaces.Split(' ');

        int number = kelimeler.Length;


        System.Console.WriteLine($"Girdiniz Kelime Sayısı: {number}");

    }
}
