namespace Soru03;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan cümle ve kelime girişi
        Console.WriteLine("Bir cümle girin:");
        string cumle = Console.ReadLine();

        Console.WriteLine("Kaç kez geçtiğini öğrenmek istediğiniz kelimeyi girin:");
        string kelime = Console.ReadLine();

        // Cümleyi kelimelere ayırma
        string[] kelimeler = cumle.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Belirli kelimenin sayısını sayma
        int sayac = 0;
        foreach (string k in kelimeler)
        {
            if (k.Equals(kelime, StringComparison.OrdinalIgnoreCase))
            {
                sayac++;
            }
        }

        // Sonucu ekrana yazdırma
        Console.WriteLine($"Kelime '{kelime}' cümlede {sayac} kez geçiyor.");


    }
}
