namespace Project18_MethodExamples;

class Program
{
    /*
    Kendisine Gönderilen int tipindeki sayı Listesinde yer alan negatif sayıları geri döndüren bir metot hazırlayalım.
    */

    static List<int> GetNegativeNumbers(List<int> numbers)
    {
        List<int> negativeNumbers = new List<int>();
        foreach (var number in numbers)
        {
            if (number < 0)
            {
                negativeNumbers.Add(number);
            }
        }
        return negativeNumbers;
    }

    static int TotalOfSquaers(int a, int b)
    {
        int x = a * a;
        int y = b * b;
        int result = x + y;
        Console.WriteLine($"{a}'nın Karesi: {x}");
        Console.WriteLine($"{b}'nın Karesi: {y}");
        return result;
    }


    static void Main(string[] args)
    {
        // List<int> numbers = [9, -5, -4, 3, -12, 3];
        // List<int> resultNumbers = GetNegativeNumbers(numbers);
        // foreach (var number in resultNumbers)
        // {
        //     Console.WriteLine(number);
        // }


        Console.WriteLine($"Karelerin Toplamı:{TotalOfSquaers(3, 4)}"); // 5 ve 7 nin karelerini bulup toplayıp ve geri döndüren metot.
    }
}
