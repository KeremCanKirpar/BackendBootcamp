namespace Soru06;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] dizi = new int[100];
        int sayaç = 1;
        for (int i = 0; i < dizi.Length; i++)

        {
            dizi[i] = rnd.Next(1, 101);
        }
        foreach (var item in dizi)
        {
            System.Console.WriteLine($"dizideki {sayaç}. sayı:{item}");
            sayaç++;
        }
        Array.Sort(dizi);
        System.Console.WriteLine($"Dizinin en küçük değeri: {dizi[0]}");
        Array.Reverse(dizi);
        System.Console.WriteLine($"Dizinin en büyük değeri {dizi[0]}");
    }
}
