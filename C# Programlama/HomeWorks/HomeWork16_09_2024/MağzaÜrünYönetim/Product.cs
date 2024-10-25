using System;

namespace HomeWork16092024.MağzaÜrünYönetim;

public class Product
{
    public Product(string name, decimal price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }


    public virtual int ChechStock()
    {
        return StockQuantity;
    }

    public virtual int UpdateAddStock(int sayi)
    {
        // System.Console.Write("Ekleyeceğiniz Stok adetini giriniz =>");
        // int sayi = int.Parse(Console.ReadLine());

        int AddStock = StockQuantity + sayi;
        StockQuantity = AddStock;
        return StockQuantity;



    }

    public virtual int UpdateDeleteStock(int sayi)
    {
        // System.Console.Write("Çıkartacağınız Stok adetini giriniz =>");
        // int sayi = int.Parse(Console.ReadLine());

        int AddStock = StockQuantity - sayi;
        StockQuantity = AddStock;
        return StockQuantity;

    }

    public virtual int UpdateStock(int sayi)
    {
        // System.Console.Write("Başlangıç Stok adetini giriniz =>");
        // int sayi = int.Parse(Console.ReadLine());

        int AddStock = sayi;
        StockQuantity = AddStock;
        return StockQuantity;

    }

    public virtual void BiLgilendirme()
    {
        System.Console.WriteLine($"Ürün Adı: {Name}\nÜrün Fiyatı: {Price}\nStock Adeti: {StockQuantity}");
    }

}
