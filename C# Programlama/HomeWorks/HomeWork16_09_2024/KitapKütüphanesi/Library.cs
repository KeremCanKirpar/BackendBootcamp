using System;

namespace HomeWork16092024.KitapKütüphanesi;

public class Library : Book
{
    public Library(string title, string author, int pages, int ıSBN) : base(title, author, pages, ıSBN)
    {

    }

    public Book[] Books { get; set; }=[];

    public override void Borrow()
    {
        base.Borrow();
    }

    public override void Return()
    {
        base.Return();
    }

}
