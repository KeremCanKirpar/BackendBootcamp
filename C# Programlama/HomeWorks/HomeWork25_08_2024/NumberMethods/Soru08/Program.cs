namespace Soru08;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("Sayı Giriniz: ");
       int number = Convert.ToInt32(Console.ReadLine());

       double logValue = Math.Log(number);

       System.Console.WriteLine($"Doğal Logaritması : {logValue}");
    }
}
