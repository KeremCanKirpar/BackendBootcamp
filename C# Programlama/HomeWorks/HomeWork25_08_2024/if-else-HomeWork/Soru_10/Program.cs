namespace Soru10;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bir Sayı Giriniz: ");
        int number = Convert.ToInt32(Console.ReadLine());
        

        if(number%1 == 0 && number%number==0)
        {
           
            System.Console.WriteLine("Sayı Asaldır");
        }
        else
        {
            System.Console.WriteLine("Sayı Asal Değildir");
        }
       
    }
}
