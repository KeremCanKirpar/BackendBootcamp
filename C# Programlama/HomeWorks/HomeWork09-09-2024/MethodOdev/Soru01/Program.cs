namespace Soru01;

class Program
{

    static int AgeControl(int age)
    {
        if(age >= 65)
        {
            Console.WriteLine("Emeklilik Yaşında");
        }
        else
        {
            Console.WriteLine("Çalışma Yaşında");
        }
        return age;
    }
    static void Main(string[] args)
    {
       AgeControl(65);
    }
}
