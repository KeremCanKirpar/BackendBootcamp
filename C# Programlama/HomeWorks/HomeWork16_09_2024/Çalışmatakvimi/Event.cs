using System;

namespace HomeWork16092024.Çalışmatakvimi;

public class Event
{
    public  Event(string name, DateTime date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
    }

    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }


    
}
