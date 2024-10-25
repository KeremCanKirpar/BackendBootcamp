namespace Soru01;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir Sayı Giriniz: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if(number > 0 )
        {
            System.Console.WriteLine($"Sayı Pozitiftir. {number}");
        }
        else if (number<0)
        {
            System.Console.WriteLine($"Bu Sayı Negatiftir. {number}");
        }
        else
        {
            System.Console.WriteLine($"Sayı Sıfırdır. {number}");
        }
    }
}
