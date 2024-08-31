namespace Soru04;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Sayıyı Giriniz: ");
        int number = Convert.ToInt32(Console.ReadLine());

        double newResult = Math.Sqrt(number);

        System.Console.WriteLine($"Sayının Karekökü : {newResult}");
    }
}
