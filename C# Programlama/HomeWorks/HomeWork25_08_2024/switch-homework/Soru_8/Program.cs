namespace Soru_8;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan alınan bir sayıya göre (0-6 arası) bir geometrik şeklin adını yazdıran bir program yazın (0: Nokta, 1: Çizgi, 2: Açı, 3: Üçgen, 4: Kare, 5: Beşgen, 6: Altıgen).

        System.Console.Write("Lütfen 0-6 arası bir sayı giriniz :");
        int girSayı;

        if (int.TryParse(Console.ReadLine(), out girSayı))
        {

            switch (girSayı)
            {
                case 0:
                    System.Console.WriteLine($"{girSayı}: Nokta");
                    break;
                case 1:
                    System.Console.WriteLine($"{girSayı}: Çizgi");
                    break;
                case 2:
                    System.Console.WriteLine($"{girSayı}: Açı");
                    break;
                case 3:
                    System.Console.WriteLine($"{girSayı}: Üçgen");
                    break;
                case 4:
                    System.Console.WriteLine($"{girSayı}: Kare");
                    break;
                case 5:
                    System.Console.WriteLine($"{girSayı}: Beşgen");
                    break;
                case 6:
                    System.Console.WriteLine($"{girSayı}: Altıgen");
                    break;

                default:
                    System.Console.WriteLine("Geçerli bir sayı giriniz.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine(" 0-6 arası bir sayı değeri giriniz !!!");
        }

    }
}
