using System;

namespace HomeWork16092024.Çalışmatakvimi;

public class Meeting : Event
{
    public Meeting(string name, DateTime date, string location) : base(name, date, location)
    {

    }

    public void Gerçeklesti()
    {
        System.Console.WriteLine("Toplantı başarıyla Gerçekleşti.");
    }

    public void Gerçeklesmedi()
    {
        System.Console.WriteLine("Toplantı Gerçekleşmedi");
    }
    
}
