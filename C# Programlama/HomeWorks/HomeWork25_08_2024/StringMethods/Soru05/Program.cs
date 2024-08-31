namespace Soru05;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir Metin Giriniz :");
        string anaMetin = Console.ReadLine();

        Console.Write("Aranacak Metini Giriniz :");
        string aranacakMetin = Console.ReadLine();

        int indeks = anaMetin.IndexOf(aranacakMetin, StringComparison.CurrentCultureIgnoreCase);

        if (indeks != -1)
        {
            System.Console.WriteLine($"Aranan Metin {aranacakMetin} ana metinde ilk olarak {indeks} de bulunuyor");
        }
        else
        {
                System.Console.WriteLine($"{aranacakMetin} Bulunamadı");
        }
    }
}
