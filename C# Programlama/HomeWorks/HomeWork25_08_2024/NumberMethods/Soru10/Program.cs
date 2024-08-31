namespace Soru10;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan bir ondalıklı sayı alın
        Console.Write("Lütfen bir ondalıklı sayı girin: ");
        double number = Convert.ToDouble(Console.ReadLine());

        // Kullanıcıdan kaç ondalık basamağa yuvarlanacağı bilgisini alın
        Console.Write("Lütfen kaç ondalık basamağa yuvarlanacağını girin: ");
        int decimalPlaces = Convert.ToInt32(Console.ReadLine());

        // Sayıyı belirtilen ondalık basamak sayısına göre yuvarlayın
        double roundedNumber = Math.Round(number, decimalPlaces);

        // Sonucu ekrana yazdırın
        Console.WriteLine($"Girilen sayı {decimalPlaces} ondalık basamağa yuvarlandığında: {roundedNumber}");
    }
}
