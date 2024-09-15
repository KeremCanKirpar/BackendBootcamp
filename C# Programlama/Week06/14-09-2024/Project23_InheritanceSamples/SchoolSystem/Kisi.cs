using System;

namespace Project23_InheritanceSamples.SchoolSystem;

public class Kisi
{
    public Kisi(string ad, string soyad, DateTime dogumTarihi)
    {
        Ad = ad;
        Soyad = soyad;
        DogumTarihi = dogumTarihi;
    }

    public string Ad { get; set; }
    public string Soyad { get; set; }
    public DateTime DogumTarihi { get; set; }
    public byte Yas // içinde sadece get varsa o prop read-only / Salt okunur.
    {
        get
        {
            var result = (byte)(DateTime.Now.Year - DogumTarihi.Year);
            return result;
        }
        

    }
    public virtual void BilgileriGetir()
    {
        Console.Write($"Ad: {Ad} \nSoyad: {Soyad}\nDoğum Tarihi: {DogumTarihi.ToShortDateString()}");
    }
}
