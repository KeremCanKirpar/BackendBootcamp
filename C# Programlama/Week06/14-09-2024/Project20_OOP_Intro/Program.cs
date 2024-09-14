namespace Project20_OOP_Intro;


class FirstClass{
    // Buraya sınıfın özellik ve davranışlarını kodluyor olacağız.

    //Özellik : Property
    //Davranış: Method

    //Erişim Belirleyiciler : public(dışarıya açık), private (sadece bulunduğu classa özel)

   public string message;
   public string age;

    public void DisplayMessage()
    {
        Console.WriteLine(message); 
    }
}


class Program
{
    static void Main(string[] args)
    {
        FirstClass firstClass1 = new FirstClass();
       firstClass1.message = "Selam";
       firstClass1.DisplayMessage();
    }
}
