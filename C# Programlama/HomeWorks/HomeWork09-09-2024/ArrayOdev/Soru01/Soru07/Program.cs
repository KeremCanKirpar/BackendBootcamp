namespace Soru07;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] dizi = new int[50];

        int toplam = 0;
        int sayaç = 1;
        for (int i = 0; i < dizi.Length; i++)
        {
            dizi[i] = rnd.Next(1, 10);
            if (dizi[i] % 2 == 0)
            {
                toplam += dizi[i];
            }

        }
        foreach (var item in dizi)
        {
            System.Console.WriteLine($"dizideki {sayaç}. sayı:{item}");
            sayaç++;
        }

        System.Console.WriteLine($"dizideki çift sayılarım toplamı:{toplam}");
    }
}
