namespace Soru_9;

class Program
{
    static void Main(string[] args)
    {
        System.Console.Write("Lütfen 1-5 arası bir sayı giriniz :");
        int girSayı;

        if (int.TryParse(Console.ReadLine(), out girSayı))
        {

            switch (girSayı)
            {
                case 1:
                    System.Console.WriteLine($"{girSayı}: Birinci");
                    break;
                case 2:
                    System.Console.WriteLine($"{girSayı}: İkinci");
                    break;
                case 3:
                    System.Console.WriteLine($"{girSayı}: Üçüncü");
                    break;
                case 4:
                    System.Console.WriteLine($"{girSayı}: Dördüncü");
                    break;
                case 5:
                    System.Console.WriteLine($"{girSayı}: Beşinci");
                    break;

                default:
                    System.Console.WriteLine("Geçerli bir sayı giriniz.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine(" 1-5 arası bir sayı değeri giriniz !!!");
        }
    }
}
