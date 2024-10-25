namespace Soru_3;

class Program
{
    static void Main(string[] args)
    {

        System.Console.Write("1. sayıyı giriniz.");
        double sayi1 = Convert.ToDouble(Console.ReadLine());

        System.Console.Write("2. sayıyı giriniz.");
        double sayi2 = Convert.ToDouble(Console.ReadLine());

        System.Console.Write("Yapmak istediğiniz işlemi giriniz (+ , -, * , /)");

        char islem = Convert.ToChar(Console.ReadLine());

        double sonuc = 0;
        bool yapİslem = true;

        switch (islem)
        {
            case '+':
                sonuc = sayi1 + sayi2;


                break;
            case '-':
                sonuc = sayi1 - sayi2;

                break;
            case '*':
                sonuc = sayi1 * sayi2;

                break;
            case '/':
                if (sayi2 > 0 && sayi1 >= 0)
                {
                    sonuc = sayi1 / sayi2;

                }
                else
                {
                    System.Console.WriteLine("Hatalı bir sayı girdiniz : 0'ı bir şeye bölemeyiz...!!!");
                    yapİslem = false;
                }
                break;
            default:
                System.Console.WriteLine("Hatalı bir işlem seçtiniz.");
                yapİslem = false;
                break;
        }

        if (yapİslem)
        {
            System.Console.WriteLine($"sonuc : {sonuc} <<<<<----");
        }
        else
        {
            System.Console.WriteLine("-----------------------------------------------------------");
        }


    }

}
