using System.Runtime.InteropServices;

namespace Soru_4;

class Program
{
    static void Main(string[] args)
    {
        // System.Console.Write(" Lütfen türkçe bir harf giriniz(a-z) :");
        // char harf = Console.ReadLine()[0];
        // bool yapİslem = true;
        // char sonuc='\0';

        // switch (harf)
        // {
        //     case 'a':
        //         sonuc = 'a';
        //         break;
        //     case 'e':
        //         sonuc = 'e';
        //         break;
        //     case 'ı':
        //         sonuc = 'ı';
        //         break;
        //     case 'i':
        //         sonuc = 'i';
        //         break;
        //     case 'o':
        //         sonuc = 'o';
        //         break;
        //     case 'ö':
        //         sonuc = 'ö';
        //         break;
        //     case 'u':
        //         sonuc = 'u';
        //         break;
        //     case 'ü':
        //         sonuc = 'ü';
        //         break;

        //     default:
        //         yapİslem = false;
        //         //System.Console.WriteLine($"Yanlış bir tuşlama yaptınız !!!!!!!!!!!!!!!!!");

        //         break;
        // }
        // if (yapİslem)
        // {
        //     System.Console.Write($"Sesli bir harf girdiniz = {sonuc}");

        // }
        // else
        // {
        //     System.Console.Write($"Sessiz bir harf girdiniz = {sonuc}");

        // }

        // System.Console.Write(" Lütfen türkçe bir harf giriniz(a-z) :");
        // char harf = char.ToLower(Console.ReadKey().KeyChar);

        // switch (harf)
        // {
        //     case 'a':

        //     case 'e':

        //     case 'ı':

        //     case 'i':

        //     case 'o':

        //     case 'ö':

        //     case 'u':

        //     case 'ü':
        //         System.Console.WriteLine($"{harf} sesli bir harftir.");
        //         break;

        //     default:

        //         System.Console.WriteLine($"{harf} sessiz bir harftir.");

        //         break;
        // }

        System.Console.Write("Bir sayı giriniz (a-z) : ");
        String harf = Console.ReadLine();

        if (harf.Length == 1)
        {
            char girilenharf = Char.ToLower(harf[0]);
            switch (girilenharf)
            {
                case 'a':
                case 'e':
                case 'ı':
                case 'i':
                case 'o':
                case 'ö':
                case 'u':
                case 'ü':
                    System.Console.WriteLine($"{harf} sesli harf girdiniz !!");
                    break;

                case 'z':
                case 'y':
                case 'v':
                case 't':
                case 'ş':
                case 's':
                case 'r':
                case 'p':
                case 'n':
                case 'm':
                case 'l':
                case 'k':
                case 'h':
                case 'j':
                case 'ğ':
                case 'g':
                case 'd':
                case 'ç':
                case 'c':
                case 'b':
                    System.Console.WriteLine($"{harf} sessiz bir harf girdiniz!!!");
                    break;


                default:
                    System.Console.WriteLine("Yanlış bir harf girişi yaptınız.!!!!!!!!!!!");
                    break;
            }

        }
        else
        {
            System.Console.WriteLine("lütfen tek bir harf girişi yapınız");
        }

    }
}
