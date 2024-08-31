namespace Soru09;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1.Sayıyı Giriniz: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("2.Sayıyı Giriniz:");
        double number2 = Convert.ToDouble(Console.ReadLine());

        double resultValue = Math.Min(number1,number2);

        System.Console.WriteLine($"En Küçük Sayı: {resultValue}");
    }
}
