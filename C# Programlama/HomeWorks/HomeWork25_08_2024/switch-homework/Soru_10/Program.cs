namespace Soru_10;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Bir işlem giriniz (+,-,*,/,%)");
        char girİslem;

        if (char.TryParse(Console.ReadLine(), out girİslem))
        {
            switch (girİslem)
            {
                case '+':
                    System.Console.WriteLine("Toplama İşlemi");
                    break;
                case '-':
                    System.Console.WriteLine("Çıkarma İşlemi");
                    break;
                case '*':
                    System.Console.WriteLine("Çarpma İşlemi");
                    break;
                case '/':
                    System.Console.WriteLine("Bölme İşlemi");
                    break;
                case '%':
                    System.Console.WriteLine("Yüzde İşlemi");
                    break;

                    // default:
                    // System.Console.WriteLine("Yanlış bir işlem girdiniz.");
                    //     break;
            }

        }
        else
        {
            System.Console.WriteLine("(+,-,*,/,%) İşlemlerinden birini giriniz.!!!!");
        }
    }
}
