namespace Soru02;

class Program
{
    static void Main(string[] args)
    {
            Console.Write("Bir Metin Giriniz: ");
            string metin = Console.ReadLine();

            System.Console.WriteLine(metin.ToUpper());
            System.Console.WriteLine(metin.ToLower());
    }
}
