namespace Soru_7;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Birinci sayıyı girin: ");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("İkinci sayıyı girin: ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Üçüncü sayıyı girin: ");
        int sayi3 = Convert.ToInt32(Console.ReadLine());

        int enBuyuk;

        if (sayi1 >= sayi2 && sayi1 >= sayi3)
        {
            enBuyuk = sayi1;
        }
        else if (sayi2 >= sayi1 && sayi2 >= sayi3)
        {
            enBuyuk = sayi2;
        }
        else
        {
            enBuyuk = sayi3;
        }

        Console.WriteLine($"En büyük sayı: {enBuyuk}");
    }
}
