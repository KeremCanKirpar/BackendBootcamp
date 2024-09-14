namespace Soru06;

class Program
{
    static int toDoubles(int value)
    {
        if(value % 2 == 0)
        {
            Console.WriteLine("Sayı Çifttir.");
            return value;
        }
        else
        {
            Console.WriteLine("Sayı Tektir");
            return value;
        }
    }
    static void Main(string[] args)
    {
       toDoubles(5);
    }
}
