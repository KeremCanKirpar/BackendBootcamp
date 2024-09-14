namespace Soru05;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Bir sayı giriniz: ");
        int input = Convert.ToInt32(Console.ReadLine());
        int[] dizi = new int[100];
        Random rnd = new Random();
        int sayaç = 0;
        int sayaç1 = 0;

        for (int i = 0; i < dizi.Length; i++)
        {
            dizi[i] = rnd.Next(1, 15);
        }
        foreach (var item in dizi)
        {
            System.Console.WriteLine($"{sayaç + 1}. index={item}");
            sayaç++;
        }

        for (int i = 0; i < dizi.Length; i++)
        {
            if (dizi[i] == input)
            {
                System.Console.WriteLine($"Girilen sayı({input}) {i + 1}. indexte var.");
                sayaç1++;
            }
        }
        System.Console.WriteLine($"girdiğiniz sayı ({input}) dizide {sayaç1} kere bulunuyor");
    }
}
