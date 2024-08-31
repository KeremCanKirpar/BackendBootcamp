namespace Soru01;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("Ondalıklı Sayıyı Giriniz: ");
       double number = Convert.ToDouble(Console.ReadLine());

       double value = Math.Round(number);

       System.Console.WriteLine($"Yeni Sayı: {value}");
    }
}
