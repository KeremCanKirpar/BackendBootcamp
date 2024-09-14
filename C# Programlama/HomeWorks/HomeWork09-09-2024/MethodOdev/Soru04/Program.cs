namespace Soru04;

class Program
{
    static double Ortalama(double vize, double final)
    {

        double ortalama = (vize * 0.40) + (final * 0.60);
        return ortalama;

    }
    static void Main(string[] args)
    {
        Console.Write("Vize Notunuzu Giriniz: ");
        double vize = Double.Parse(Console.ReadLine());
        Console.Write("Final Notunuzu Giriniz: ");
        double final = double.Parse(Console.ReadLine());

        double ortalama = Ortalama(vize, final);

        if (ortalama >= 50)
        {
            Console.WriteLine("Geçtiniz: " + ortalama);

        }
        else
        {
            Console.WriteLine("Kaldınız: " + ortalama);

        }
    }
}
