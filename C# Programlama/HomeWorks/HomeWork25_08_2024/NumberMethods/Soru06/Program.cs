namespace Soru06;

class Program
{
    static void Main(string[] args)
    {
            Console.Write("Dereceyi Giriniz: ");
            double degree =  Convert.ToDouble(Console.ReadLine());

           double radian =  degree * (Math.PI/180);

           double sin = Math.Sin(radian);

           System.Console.WriteLine($"Derecenin Sinüsü: {sin}");

    }
}
