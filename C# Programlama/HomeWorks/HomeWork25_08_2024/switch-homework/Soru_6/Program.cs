namespace Soru_6;

class Program
{
    static void Main(string[] args)
    {
        // **6.* *Kullanıcıdan alınan bir nota göre(A, B, C, D, F) geçme veya kalma durumunu belirleyen bir program yazın.

        System.Console.Write("Bir not giriniz (0-100) arasında : ");
        int girNot;

        if (int.TryParse(Console.ReadLine(), out girNot))
        {
            switch (girNot)
            {
                case < 39:
                    if (girNot == 0)
                    {
                        System.Console.WriteLine("Devamsız");
                    }
                    else
                    {
                        System.Console.WriteLine("FF - YS");
                    }
                    break;
                case < 49:
                    System.Console.WriteLine("FD- YS");
                    break;
                case < 54:
                    System.Console.WriteLine("FD- YS");
                    break;
                case < 59:
                    System.Console.WriteLine("DD- YE");
                    break;
                case < 69:
                    System.Console.WriteLine("DC - YE");
                    break;
                case < 79:
                    System.Console.WriteLine("CC - YE");
                    break;
                case < 84:
                    System.Console.WriteLine("CB- YE");
                    break;
                case < 89:
                    System.Console.WriteLine("BB- YE");
                    break;
                case <= 100:
                    System.Console.WriteLine("BA- YE");
                    break;

                default:
                    System.Console.WriteLine("Yanlış bir not girdiniz !!!!");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("Lütfen 1-100 arasında bir sayı giriniz.!!!!!!!!!");
        }

    }
}
