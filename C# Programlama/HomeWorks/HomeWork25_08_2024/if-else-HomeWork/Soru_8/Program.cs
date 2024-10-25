namespace Soru_8;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        if (sayi % 3 == 0 && sayi % 5 == 0)
        {
            Console.WriteLine($"{sayi} hem 3'e hem de 5'e tam bölünür.");
        }
        else if (sayi % 3 == 0)
        {
            Console.WriteLine($"{sayi} sadece 3'e tam bölünür.");
        }
        else if (sayi % 5 == 0)
        {
            Console.WriteLine($"{sayi} sadece 5'e tam bölünür.");
        }
        else
        {
            Console.WriteLine($"{sayi} 3 ve 5 tam bölünmez!.");
        }
    }
}
