namespace Soru01;

class Program
{
    static void Main(string[] args)
    {
         Console.Write("Tarihi YYYY - AA - GG formatında girin: ");
        string input = Console.ReadLine();

        DateTime tarih = DateTime.Parse(input);

        string gun = tarih.ToString("dddd");
        Console.WriteLine($"Girdiğiniz tarih haftanın {gun} gününe denk geliyor.");

    }
}
