namespace Soru03;

class Program
{
    static void Main(string[] args)
    {
        int[] dizi = new int[10];


        List<int> pozitifler = new List<int>();
        List<int> negatifler = new List<int>();

        int i = 0;


        while (i < dizi.Length)
        {
            if (dizi[i] > 0)
            {
                pozitifler.Add(dizi[i]);
            }
            else if (dizi[i] < 0)
            {
                negatifler.Add(dizi[i]);
            }
            i++;
        }

        Console.WriteLine("Pozitif sayılar:");
        foreach (int sayi in pozitifler)
        {
            Console.WriteLine(sayi);
        }

        Console.WriteLine("Negatif sayılar:");
        foreach (int sayi in negatifler)
        {
            Console.WriteLine(sayi);
        }
    }
}
