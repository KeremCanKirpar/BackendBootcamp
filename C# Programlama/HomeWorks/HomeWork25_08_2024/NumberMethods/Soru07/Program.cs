namespace Soru07;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Derece Girin : ");
        double degree = Convert.ToDouble(Console.ReadLine());

        double radian = degree * (Math.PI / 180);

        System.Console.WriteLine($"Sonuç : {radian}");
    }
}
