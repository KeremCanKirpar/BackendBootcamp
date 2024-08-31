namespace Project11_Loops;

class Program
{
    static void Main(string[] args)
    {
        #region For Döngüsü
        // for(int counter = 1;counter<=5;counter++)
        // {
        //     //Döngü Gövdesi : Döngü içerisinde tekrar tekrar çalıştırılmasını istediğimiz kodlar
        //         System.Console.WriteLine($"{counter}.Hello World");
        // }

        // for (int i = 1; i <= 5; i++)
        // {
        //     //Döngü Gövdesi : Döngü içerisinde tekrar tekrar çalıştırılmasını istediğimiz kodlar
        //     System.Console.WriteLine($"{i}.Hello World");
        // }
        #endregion

        #region For Döngüsü Örnek
        //Ekrana 1 İle 10 arasında ki sayıları yazdıran program
        // int counter = 1;
        // for (int i = 100; i <= 200; i++)
        // {
        //     System.Console.WriteLine($"Sayı {++counter}: {i}");

        // }

        // for (int i = 1; i <= 10; i++)
        // {
        //     if(i%2==0) // 2 ye bölümünden kalan 0 ise yani çift sayı 
        //     //ise
        //     {
        //         System.Console.WriteLine(i);
        //     }
        // }

        //kullanıcıdan alınan iki sayı alın bu iki sayı arasındaki çift sayıları ekrana yazdırın

        // Console.Write("Alt Sınırı Giriniz: ");
        // int min = Convert.ToInt32(Console.ReadLine());
        // min = min%2 ==0 ? min :++min;
        // Console.Write("Üst Sınırı Giriniz: ");
        // int max = Convert.ToInt32(Console.ReadLine());

        // for (int i = min; i <= max; i+=2)
        // {
        //     System.Console.WriteLine($"{i}");
        // }


        //Kullanıcının Klavyeden Girdiği sayının faktöriyelini hesaplayan programı yazınız.
        //5!= 2*3*4*5
        //5! = 5*4*3*2

        /*
        f=1;
        f=f*2
        f=f*3
        f=f*4
        f=f*5
        */
        // Console.Write("Faktöriyelini hesaplamak istediğiniz sayıyı giriniz: ");
        // // int value = Convert.ToInt32(Console.ReadLine());
        // // int factorial = 1;

        // // for (int i = 2; i <= value; i++)
        // // {
        // //     // factorial= factorial*i;
        // //     factorial *= i;
        // // }
        // // System.Console.WriteLine($"{value}!= {factorial}");

        // Console.Write("Faktöriyelini hesaplamak istediğiniz sayıyı giriniz: ");
        // int value = Convert.ToInt32(Console.ReadLine());
        // int factorial = value;

        // for (int i = 0; i > 1; i++)
        // {

        // }
        // System.Console.WriteLine($"{value}!= {factorial}");


        #endregion

        #region While
        // int i = 1;
        // while(i<=5)
        // {
        //     System.Console.WriteLine($"{i}.Merhaba Dünya");
        //     i++;
        // }

        // int total = 0;
        // string input = "";
        // while (input != "exit")
        // {
        //     Console.Write("Toplanılacak Sayıyı Giriniz(Çıkış için exit yazınız): ");
        //     input = Console.ReadLine();
        //     if (int.TryParse(input, out int inputNumber))
        //     {
        //         total += inputNumber;
        //     }
        //     else if (input != "exit")
        //     {


        //         Console.WriteLine("Geçerli Bir Değer Giriniz!");

        //     }

        // }
        // System.Console.WriteLine($"Toplam: {total}");


        //kullanıcıdan arka arkada alınacak sayıları toplayan kodu hazırlayınız. Ancak kullanıcının girdiği sayıların toplamı, 100'den büyük ya da eşitse program sona erip toplamı ekrana yazsın.

        // int total = 0;
        // string input = "";

        // while (total < 100)
        // {
        //     Console.Write("Toplanılacak Sayıları Girin: ");
        //     input = Console.ReadLine();

        //     if (int.TryParse(input, out int intNumber))
        //     {
        //             total+= intNumber;
        //     }
        //     else if(input != "")
        //     {
        //         System.Console.WriteLine("Geçerli Bir Değer Giriniz");
        //     }
        // }
        // System.Console.WriteLine($"Toplam: {total} Program sona Erdi... ");
        #endregion


    }
}
