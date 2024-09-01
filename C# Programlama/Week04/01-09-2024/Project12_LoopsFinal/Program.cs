namespace Project12_LoopsFinal;

class Program
{
    static void Main(string[] args)
    {
        //Kullanıcıdan arka arkaya alınacak sayıları toplayan kodu hazırlayınız.Ancak Kullanıcının girdiği sayıların Toplamı, 100'den büyük ya da eşitse program sona erip toplmaı ekrana yazsın

        // int total = 0;

        // while (total <= 100)
        // {
        //     Console.Write("Bir Sayı Giriniz: ");
        //     int inputNumber = int.Parse(Console.ReadLine());
        //     total += inputNumber;
        // }
        // System.Console.WriteLine($"Program Sona Erdi Sayıların toplamı: {total}");



        //Sadece sayı girişi yaptıralım!
        // ConsoleKeyInfo character;
        // string resultNumber = "";
        // Console.Write("Bir Sayı Giriniz: ");
        //  do
        // {
        //     character = Console.ReadKey(true);
        //     if (char.IsDigit(character.KeyChar))
        //     {

        //         resultNumber += character.KeyChar.ToString();
        //         Console.Write(character.KeyChar.ToString());
        //     }
        //     else
        //     {
        //         if (character.Key == ConsoleKey.Backspace && resultNumber.Length > 0)
        //         {
        //             resultNumber = resultNumber.Substring(0, resultNumber.Length - 1);
        //             Console.Write("\b \b");
        //         }
        //     }




        // } while (character.Key != ConsoleKey.Enter);

        //Girilen Sayının Asal olup olmadığını tespit edip ekrana yazdıralım
        // bool isPrime = true;
        // Console.Write("Bir Sayı Giriniz: ");
        // int number = int.Parse(Console.ReadLine());

        // if (number <= 1)
        // {
        //     isPrime = false;
        // }
        // else
        // {
        //     for (int i = 2; i <= number - 1; i++)
        //     {
        //         if (number % i == 0)
        //         {
        //             isPrime = false;
        //             break;
        //         }
        //     }
        // }
        // System.Console.WriteLine(isPrime  ? "Sayı Asaldır" : "Sayı Asal Değildir");

        // bool isPrime = true;
        // Console.Write("Bir Sayı Giriniz: ");
        // int number = int.Parse(Console.ReadLine());

        // if (number <= 1)
        // {
        //     isPrime = false;
        // }
        // else
        // {
        //     int i=2;
        //     while(i<=number-1)
        //     {
        //         if (number % i == 0)
        //         {
        //             isPrime = false;
        //             break;
        //         }
        //     }
        // }
        // System.Console.WriteLine(isPrime ? "Sayı Asaldır" : "Sayı Asal Değildir");

        // string answer = "";
        // bool isPrime = true;
        // Console.Write("Bir Sayı Giriniz: ");
        // int number = int.Parse(Console.ReadLine());
        // do{
        //     if (number <= 1)
        //     {
        //         isPrime = false;
        //     }
        //     else
        //     {
        //         int i = 2;
        //         while (i <= number - 1)
        //         {
        //             if (number % i == 0)
        //             {
        //                 isPrime = false;
        //                 break;
        //             }
        //         }
        //     }
        //     System.Console.WriteLine(isPrime ? "Sayı Asaldır" : "Sayı Asal Değildir");
        //     Console.WriteLine("Tekrar denemek İster Misiniz? :");
        //     answer = Console.ReadLine();
        // } while(answer == "H");
        




    }
}
