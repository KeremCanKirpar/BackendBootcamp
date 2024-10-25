using System;

namespace HomeWork16092024.Çalışmatakvimi;

public class Task : Event
{
    public Task(string name, DateTime date, string location) : base(name, date, location)
    {

    }

    public void Tamamlandı()
    {

        System.Console.WriteLine("Görev başatıyla tamamalandı!");
    }

    public void Tamamlanmadı()
    {

        System.Console.WriteLine("Görev başarısız oldu !!");
    }
}
