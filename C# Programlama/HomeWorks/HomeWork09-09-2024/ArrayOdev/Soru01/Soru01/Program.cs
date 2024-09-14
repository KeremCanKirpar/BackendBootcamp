namespace Soru01;

class Program
{
    static void Main(string[] args)
    {
        Random rn = new Random();
        int[] array = new int[10];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rn.Next(1, 10);
        }

        foreach (var arrayList in array)
        {
            Console.WriteLine(arrayList + " ");
        }
        Console.WriteLine("\n");

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1] && array[i] < array[i + 1])
            {
                Console.WriteLine("Sonuç: " + i + array[i]);
            }
        }

    }
}
