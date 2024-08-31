namespace Soru02;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1.Sayıyı Giriniz: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("2.Sayıyı Giriniz: ");
        double number2 = Convert.ToDouble(Console.ReadLine());


        double maxValue = Math.Max(number1,number2);

        System.Console.WriteLine($"En Büyük Sayı {maxValue}");


        
    }
}
