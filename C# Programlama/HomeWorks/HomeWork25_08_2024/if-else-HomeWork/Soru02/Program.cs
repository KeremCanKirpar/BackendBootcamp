namespace Soru02;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("Birinci sayıyı girin: ");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("İkinci sayıyı girin: ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Üçüncü sayıyı girin: ");
        int sayi3 = Convert.ToInt32(Console.ReadLine());

        int birinci, ikinci, ucuncu;

       
        if (sayi1 >= sayi2 && sayi1 >= sayi3)
        {
            birinci = sayi1;
            if (sayi2 >= sayi3)
            {
                ikinci = sayi2;
                ucuncu = sayi3;
            }
            else
            {
                ikinci = sayi3;
                ucuncu = sayi2;
            }
        }
        else if (sayi2 >= sayi1 && sayi2 >= sayi3)
        {
            birinci = sayi2;
            if (sayi1 >= sayi3)
            {
                ikinci = sayi1;
                ucuncu = sayi3;
            }
            else
            {
                ikinci = sayi3;
                ucuncu = sayi1;
            }
        }
        else
        {
            birinci = sayi3;
            if (sayi1 >= sayi2)
            {
                ikinci = sayi1;
                ucuncu = sayi2;
            }
            else
            {
                ikinci = sayi2;
                ucuncu = sayi1;
            }
        }

        
        Console.WriteLine($"Sayıların büyükten küçüğe sıralaması: {birinci}, {ikinci}, {ucuncu}");
    }
}

