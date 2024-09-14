namespace Soru02;

class Program
{
    static void Main(string[] args)
    {
        int[] dizi = new int[10];
        int[] çiftDizi = new int[10];
        int sayaç = 0;
        System.Console.WriteLine("10 tane sayı yazın: ");
        for (int i = 0; i < dizi.Length; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out dizi[i])) ;

        }
        System.Console.WriteLine("-------------------------");
        foreach (var sayı in dizi)
        {
            System.Console.WriteLine(sayı);
        }
        for (int i = 0; i < dizi.Length; i++)
        {
            if (dizi[i] % 2 == 0)
            {
                çiftDizi[sayaç] = dizi[i];
                sayaç++;
            }
        }
        Array.Sort(çiftDizi);
        System.Console.WriteLine("çift ve küçükten büyüğe sıralanmış hali");
        foreach (var item in çiftDizi)
        {
            System.Console.WriteLine(item);
        }


    }
}
