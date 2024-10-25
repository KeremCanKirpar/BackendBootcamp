namespace Soru_7;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan alınan bir sayıya göre(1 - 5 arası) Türk para biriminin adını yazdıran bir program yazın(1 Kr, 5 Kr, 10 Kr, 25 Kr, 50 Kr).

        System.Console.Write("Lütfen 1-5 arası bir sayı giriniz :");
        int girSayı;

        if (int.TryParse(Console.ReadLine(), out girSayı))
        {

            switch (girSayı)
            {
                case 1:
                    System.Console.WriteLine($"{girSayı} Kr");
                    break;
                case 2:
                    System.Console.WriteLine("5 Kr");
                    break;
                case 3:
                    System.Console.WriteLine("10 Kr");
                    break;
                case 4:
                    System.Console.WriteLine("25 Kr");
                    break;
                case 5:
                    System.Console.WriteLine($"{girSayı}0 Kr");
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
