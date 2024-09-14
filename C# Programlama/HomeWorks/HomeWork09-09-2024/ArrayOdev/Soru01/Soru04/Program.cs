namespace Soru04;

class Program
{
    static void Main(string[] args)
    {
        int[] dizi = new int[20];
        int sayaç = 0;
        Random rnd = new Random();
        for (int i = 0; i < dizi.Length; i++)
        {
            dizi[i] = rnd.Next(1, 21);
        }
        foreach (var item in dizi)
        {
            System.Console.WriteLine($"sayı {sayaç}. index ={item}");
            sayaç++;
        }
        for (int i = 0; i < dizi.Length; i++)
        {
            for (int j = i + 1; j < dizi.Length; j++)
            {
                if (dizi[i] == dizi[j])
                {
                    System.Console.WriteLine($"Sayı {dizi[j]} index {i} ve index{j} tekrar ediyor. ");
                }
            }
        }
    }
}
