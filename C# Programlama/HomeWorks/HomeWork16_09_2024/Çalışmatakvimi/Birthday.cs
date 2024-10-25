using System;

namespace HomeWork16092024.Çalışmatakvimi;

public class Birthday : Event
{
    public Birthday(string name, DateTime date, string location) : base(name, date, location)
    {

    }

     public void PastaAlındı()
     {
        System.Console.WriteLine("Pasta alındı!!");
     }

    public void PastaAlınmadı()
    {
        System.Console.WriteLine("Pasta alınmadı!!");
    }
}
