using System.Runtime.ConstrainedExecution;

namespace Soru_5;

class Program
{
    static void Main(string[] args)
    {
        //**5.* *Kullanıcıdan alınan bir sayıya göre(1 - 4 arası) mevsim adını yazdıran bir program yazın.


        System.Console.Write("Bir sayı giriniz(1-4) = ");
        int giriş;


        if (int.TryParse(Console.ReadLine(), out giriş))
        {
            switch (giriş)
            {
                case 1:
                    System.Console.WriteLine("ilkbahar");
                    break;
                case 2:
                    System.Console.WriteLine("YAZ");
                    break;
                case 3:
                    System.Console.WriteLine("Sonbahar");
                    break;

                case 4:
                    System.Console.WriteLine("Kış");
                    break;

                default:
                    System.Console.WriteLine("Yanlış bir sayı girdiniz !!");
                    break;
            }


        }
        else
        {
            System.Console.WriteLine("lütfen 1 ile 4 arasında bir sayı giriniz!!!!");

        }
    }
}
