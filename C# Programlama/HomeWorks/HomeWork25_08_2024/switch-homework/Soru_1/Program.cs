namespace Soru_1;

class Program
{
    static void Main(string[] args)
    {
        System.Console.Write("Bir sayı giriniz : ");
        int günSayi;

        if (int.TryParse(Console.ReadLine(), out günSayi))
        {

            switch (günSayi)
            {
                case 1:
                    System.Console.WriteLine("Pazartesi");
                    break;
                case 2:
                    System.Console.WriteLine("Salı");
                    break;

                case 3:
                    System.Console.WriteLine("Çarşamba");
                    break;
                case 4:
                    System.Console.WriteLine("Perşembe");
                    break;
                case 5:
                    System.Console.WriteLine("Cuma");
                    break;
                case 6:
                    System.Console.WriteLine("Cumartesi");
                    break;
                case 7:
                    System.Console.WriteLine("Pazar");
                    break;
                default:
                    System.Console.WriteLine(" 1-7 arasında sayı girilmedi.");
                    break;
            }

        }
        else
            System.Console.WriteLine("1-7 ARASINDA BİR SAYI GİRİNİZ.");

    }
}
