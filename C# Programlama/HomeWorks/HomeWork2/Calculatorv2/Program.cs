namespace Calculatorv2;

class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Hangi matematik işlemini yapmak istersiniz?");
        Console.WriteLine("1 - Toplama");
        Console.WriteLine("2 - Çıkarma");
        Console.WriteLine("3 - Çarpma");
        Console.WriteLine("4 - Bölme");

        int islem = Convert.ToInt32(Console.ReadLine());


        Console.Write("Kaç adet Rakam Giriceksiniz : ");
        int sayilar = Convert.ToInt32(Console.ReadLine());

        int[] adet = new int[sayilar];
        int toplam = 0;

        for (int i = 0; i < sayilar; i++)
        {
            Console.WriteLine($"{i + 1} . Sayıyı Giriniz: ");
            adet[i] = Convert.ToInt32(Console.ReadLine());

        }
        int sonuc = adet[0];
        for (int i = 0; i < sayilar; i++)
        {
            switch (islem)
            {
                case 1:
                    sonuc += adet[i];
                    break;
                case 2:
                    sonuc -= adet[i];
                    break;

                case 3:
                    sonuc *= adet[i];
                    break;

                case 4:
                    sonuc /= adet[i];
                    break;


                default:
                Console.WriteLine("Geçersiz İşlem");
                    break;
            }
        }

        Console.WriteLine($" Sayıların Toplamı: {toplam}");

    }
}



