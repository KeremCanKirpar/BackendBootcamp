using System;

namespace HomeWork16092024.KitapKütüphanesi;

public class Book
{
    public Book(string title, string author, int pages, int ıSBN)
    {
        Title = title;
        Author = author;
        Pages = pages;
        ISBN = ıSBN;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public int ISBN { get; set; }

    public virtual void Borrow()
    {
        System.Console.WriteLine($"{Title} Ödünç Alındı.");
    }
    public virtual void Return()
    {
        System.Console.WriteLine($"{Title} Kitabı İade Edildi.");
    }



}
