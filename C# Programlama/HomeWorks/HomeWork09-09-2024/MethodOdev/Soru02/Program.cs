namespace Soru02;

class Program
{
    static int Comp (int a , int b)
    {
        if(a>b)
        {
            return a;
        }
        else
        {
            return b;
        }

        
    }
    static void Main(string[] args)
    {
        int value1 = 25;
        int value2 = 15;

        int buyukSayi = Comp(value1,value2);
        Console.WriteLine("En Büyük Sayı: " + buyukSayi);
    }
}
