namespace Soru_5;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Birinci kenar uzunluğunu girin: ");
        int kenar1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("İkinci kenar uzunluğunu girin: ");
        int kenar2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Üçüncü kenar uzunluğunu girin: ");
        int kenar3 = Convert.ToInt32(Console.ReadLine());

        if (kenar1 + kenar2 > kenar3 && kenar1 + kenar3 > kenar2 && kenar2 + kenar3 > kenar1)
        {
            Console.WriteLine("Bu üç kenar bir üçgen oluşturur.");
        }
        else
        {
            Console.WriteLine("Bu üç kenar bir üçgen oluşturmaz.");
        }

    }
}
