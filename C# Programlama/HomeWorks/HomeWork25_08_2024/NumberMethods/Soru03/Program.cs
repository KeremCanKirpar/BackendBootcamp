namespace Soru03;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1.Sayıyı Giriniz: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int newValue = Math.Abs(number);

        System.Console.WriteLine($"Sayının Mutlat Değeri: {newValue}");
    }
}
