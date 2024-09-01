namespace Project13_GuessNumberGame;

class Program
{
    static void Main(string[] args)
    {
        string result;
        int number;
        int tr = 1;
        int liveLimit = 5;
        string resultMessage = "";

        do
        {


        Random rn = new Random();
        int secretNumber = rn.Next(1, 101);
        Console.WriteLine($"HİLEEEEE : {secretNumber}");
        Console.WriteLine("***************************");
        Console.WriteLine();


           
            do
            {

                Console.Write("Sayıyı Tahmin Edin: ");
                number = Convert.ToInt32(Console.ReadLine());

                if (number < secretNumber)
                    resultMessage = "Daha Büyük Bir Sayı Giriniz!";

                else if (number > secretNumber)
                    resultMessage = "Daha Küçük Bir Sayı Giriniz!";

                if (number != secretNumber)
                    tr++;

                if (tr <= liveLimit && number != secretNumber)
                    Console.WriteLine(resultMessage);
            } while (number != secretNumber && tr <= liveLimit);
            resultMessage = number == secretNumber ? $"KAZANDINIZ\n PUANIN: {(liveLimit - tr + 1) * 10}" : $"KAYBETTİNİZ DOĞRU CEVAP: {secretNumber}";
            Console.WriteLine(resultMessage);
            Console.Write("Tekrar Denemek İster Misin ? (E): ");
            result = Console.ReadLine();
            
        }while(result=="E" || result == "e");
    
    }
}
