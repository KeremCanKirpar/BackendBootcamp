using System.Xml.XPath;

namespace ForHomeWork;

class Program
{
    static void Main(string[] args)
    {
        #region Soru1

        // int sayı = default;
        // int num = default;
        // string result = "";
        // try
        // {
        //     System.Console.Write("Bir sayı giriniz :");
        //     sayı = int.Parse(Console.ReadLine());
        //     num = 0;

        //     for (int i = 1; i <= sayı; i++)
        //     {
        //         num += i;
        //     }
        //     System.Console.WriteLine(num);


        // }
        // catch (FormatException)
        // {
        //     result = "Bir sayı giriniz.";
        // }
        // catch (OverflowException)
        // {
        //     result = $"Lütfen {int.MinValue}-{int.MaxValue} arasında bir değer giriniz.";

        // }
        // finally
        // {
        //     System.Console.WriteLine(result);
        // }


        #endregion

        #region Soru2

        // int sayı = default;
        // int sonuc = default;
        // string result = default;
        // try
        // {
        //     System.Console.Write("Bir sayı giriniz ");
        //     sayı = int.Parse(Console.ReadLine());
        //     sonuc = default;

        //     for (int i = 1; i <= sayı; i++)
        //     {
        //         sonuc = i * i * i;
        //         System.Console.WriteLine($"{i}^3 ={sonuc}");
        //     }

        // }
        // catch (FormatException)
        // {
        //     result = "Bir sayı giriniz.";
        // }
        // catch (OverflowException)
        // {
        //     result = $"Lütfen {int.MinValue}-{int.MaxValue} arasında bir değer giriniz.";

        // }
        // finally
        // {
        //     System.Console.WriteLine(result);
        // }



        #endregion

        #region soru3

        // uint sayı = default;
        // string result = "";

        // try
        // {
        //     System.Console.Write("Bir Sayı giriniz: ");
        //     sayı = uint.Parse(Console.ReadLine());

        //     for (int i = 1; i <= sayı; i++)
        //     {
        //         if (sayı % i == 0)
        //         {
        //             System.Console.WriteLine($"Girilen Sayı = {sayı} Tam Bölünenler {i} ");
        //         }
        //     }
        // }
        // catch (FormatException)
        // {
        //     result = "Bir sayı giriniz.";
        // }
        // catch (OverflowException)
        // {
        //     result = $"Lütfen {uint.MinValue} ile {uint.MaxValue} arasında bir değer giriniz.";

        // }
        // finally
        // {
        //     System.Console.WriteLine(result);
        // }




        #endregion

        #region Soru4



        // System.Console.Write("Bir sayı giriniz= ");
        // int sayı = int.Parse(Console.ReadLine());
        // string star = "";

        // for (int i = 1; i <= sayı; i++)
        // {
        //     star += i.ToString("*");
        //     System.Console.WriteLine(star);
        // }




        #endregion

        #region Soru5

        // for (int i = 2; i <= 100; i++)
        // {
        //     bool isPrime = true;
        //     for (int j = 2; j < i; j++)
        //     {
        //         if (i % j == 0)
        //         {
        //             isPrime = false;
        //             break;
        //         }

        //     }
        //     if (isPrime)
        //     {
        //         System.Console.WriteLine(i);
        //     }


        // }

        #endregion

        #region Soru6

        // int sayı = default;
        // int sonuc = default;
        // string result ="";
        // try
        // {
        //     System.Console.WriteLine("Lütfen 10'dan büyük bir sayı giriniz = ");
        //     sayı = int.Parse(Console.ReadLine());
        //     sonuc = 0;
        //     if (sayı < 10)
        //     {
        //         System.Console.WriteLine($" 10 dan büyük ve {int.MaxValue} aralığında bir değer girin!! ");
        //     }
        //     else
        //     {

        //         for (int i = 1; i <= sayı; i++)
        //         {
        //             sonuc = i * i;
        //             System.Console.WriteLine($" {sayı} ={i}^2  => {sonuc}");
        //         }
        //     }
        // }
        // catch (FormatException)
        // {

        //     result ="Bir sayı giriniz ";
        //     System.Console.WriteLine(result);
        // }











        #endregion

        #region Soru7

        // System.Console.Write("Bir sayı giriniz = ");
        // int sayı = int.Parse(Console.ReadLine());
        // int sonuc = default;

        // for (int i = 2; i <= sayı; i++)
        // {
        //     if (i % 2 == 0)
        //     {
        //         sonuc = sonuc + i;
        //     }
        // }
        // System.Console.WriteLine(sonuc);



        #endregion

        #region Soru8

        // System.Console.WriteLine("Pozitif bir tam sayı giriniz = ");
        // int sayı = int.Parse(Console.ReadLine());
        // int sonuc =default;

        //     for (int i = sayı ; i > 1 ; i--)            
        //     {
        //         sonuc = i*i;
        //         System.Console.WriteLine($"{i}^2 ={sonuc}");
        //     }


        #endregion

        #region Soru9

        // System.Console.Write("Bir sayı giriniz =");
        // int sayi =int.Parse(Console.ReadLine());
        // bool isPrime = true;


        // for (int i = 2; i <= sayi; i++)
        // {
        //      isPrime=true;

        //     for (int j = 2; j < i; j++)
        //     {
        //         if(i % j ==0)
        //         {
        //             isPrime=false;
        //             break;
        //         }   
        //     }   
        // }
        // if(isPrime)
        // {
        //     System.Console.WriteLine("ASAL");
        // }else
        // {
        //     System.Console.WriteLine("ASALDEĞİL");
        // }

        #endregion

        #region Soru10

        int sonuc = 1;
        System.Console.Write("1.sayıyı giriniz = ");
        int sayi1 = int.Parse(Console.ReadLine());

        System.Console.Write("1. sayıdan daha büyük bir sayı giriniz  = ");
        int sayi2 = int.Parse(Console.ReadLine());

        for (int i = sayi1; i <= sayi2; i++)
        {
            sonuc *= i;
        }
        System.Console.WriteLine($"sonuc = {sonuc}");


        #endregion
    }
}
