using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Project16_Methods;

class Program
{
    /*
     <Erişim Belirleyici> <Geri Dönüş Tipi> MetotAdı (PascalCase isimlendirmesi ile metot adları belirlenir)(parametre1_tipi parametre1_adı, parametre2_tipi parametre2_adı ...)
     {
         Metot gövdesi 
         İşlemleri burada gerçekleştireceğiz
         return geri_döndürecelecek_değer;
        return keyword = sadece metot geriye bir değer döndürecekse kullanılır.
     }
        DRY - Don't Repeat Yourself
    */

    static void Greet()
    {
        Console.WriteLine("Merhaba Drogba");
    }

    static string Greet2(string name, bool gender)
    {

        if (gender)
        {
            return $"Merhaba {name} Hanım";
        }

        return $"Merhaba {name} Bey";

    }


    static int Sum1()
    {
        int a = 40;
        int b = 50;
        int c = a + b;
        return c;
    }
    static void SampleNumberValue(ref int originalNumber)
    {
        originalNumber+=3;
        Console.WriteLine($"Metotun içindeki yazdırma satırı: {originalNumber}");
        
    }
    static void Bolme(int bolunen, int bolen, out int bolum, out int kalan)
    {
         bolum = bolunen / bolen;
        kalan = bolunen%bolen;
    }

    static int Sum2(int number1, int number2)
    {
        int summary = number1 + number2;
        return summary;
    }

    static double SumSqrt(double x, double y)
    {
        double result = x + y;
        result = Math.Sqrt(result);
        return result;
    }

    static void Main(string[] args)
    {

           int kalan;
           int bolum;

           Bolme(8, 3, out bolum, out kalan);

           Console.WriteLine($"8/3 = {bolum}\n8/3 işleminden kalan= {kalan}");

        // // Greet();
        // int x = Sum1();
        // int y = Sum2(50, 70);
        // System.Console.WriteLine(x);
        // System.Console.WriteLine($"Toplamı: {y}");
        // double z = SumSqrt(5, 12);
        // System.Console.WriteLine($"Karekökleri: {z}");
        // System.Console.WriteLine(Greet2("Kerem", false));

        // int originalNumber = 15;
        // Console.WriteLine($"Metot çağırılmadan önceki orijinal Numara Değeri: {originalNumber}");
        // SampleNumberValue(ref originalNumber);

        // Console.WriteLine($"Metot çalıştıktan sonraki orijinal Numara Değeri: {originalNumber}");

        
    }
}
