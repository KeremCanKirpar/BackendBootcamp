using System;

namespace Project23_InheritanceSamples.SchoolSystem;

/*
    -Öğretmen Bir Kisi'dir
    -Öğretmeni ek olarak branş ve Maaş Bilgisi Olacak
*/
public class Ogretmen : Kisi
{
    public Ogretmen(string ad, string soyad, DateTime dogumTarihi, string brans, decimal maas) : base(ad, soyad, dogumTarihi)
    {
        Brans = brans;
        Maas = maas;
    }

    public string Brans { get; set; }

    decimal maas;
    public decimal Maas { 
         get{
             return maas;
         }
        set 
        {
            if (value < 0)
            {
                 throw new ArgumentException("Hatalı Maaş Girişi");
               

            }
              maas = value;
            
        }
        }
    public override void BilgileriGetir()
    {
        base.BilgileriGetir();
        Console.WriteLine($"Branşı: {Brans}\nMaaşı: {Maas:c2}");
    }
}
