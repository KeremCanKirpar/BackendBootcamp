namespace Soru05;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Sayıyı Giriniz: ");
        int value = Convert.ToInt32(Console.ReadLine());

        Console.Write("Sayının Üssünü Giriniz: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        double result = Math.Pow(value,number1);

        System.Console.WriteLine($"Sayının Üssü: {result}");
    }
}
