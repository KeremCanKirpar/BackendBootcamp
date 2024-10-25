using System;

namespace HomeWork16092024.MağzaÜrünYönetim;

public class ElectronicProduct : Product
{
    public ElectronicProduct(string name, decimal price, int stockQuantity, int garantiSüresi) : base(name, price, stockQuantity)
    {
        GarantiSüresi = garantiSüresi;
    }

    public int GarantiSüresi { get; set; }

    public override int ChechStock()
    {
        return base.ChechStock();
    }

    public override int UpdateAddStock(int sayi)
    {
        return base.UpdateAddStock(sayi);
    }
    public override int UpdateDeleteStock(int sayi)
    {
        return base.UpdateDeleteStock(sayi);
    }
    public override int UpdateStock(int sayi)
    {
        return base.UpdateStock(sayi);
    }

    public override void BiLgilendirme()
    {
        base.BiLgilendirme();
        System.Console.WriteLine($"Ürün Garanti Sürei(yıl): {GarantiSüresi}");
    }

}
