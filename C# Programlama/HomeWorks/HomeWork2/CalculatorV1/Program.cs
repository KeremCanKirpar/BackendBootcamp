namespace CalculatorV1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Kaç adet Rakam Giriceksiniz : ");
        int sayilar = Convert.ToInt32(Console.ReadLine());

        int[] islem = new int[sayilar];
        int toplam = 0;

        for(int i = 0 ; i < sayilar; i++)
        {
            Console.WriteLine($"{i + 1} . Sayıyı Giriniz: ");
            islem[i] = Convert.ToInt32(Console.ReadLine());
            toplam +=  islem[i];      
        }

        int ortalama = toplam / sayilar;

        Console.WriteLine($" Sayıların Toplamı: {toplam}");
        Console.Write($" Sayıların Ortalaması: {ortalama}");
    }
}
