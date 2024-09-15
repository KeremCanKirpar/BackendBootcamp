using System;

namespace Project23_InheritanceSamples.SchoolSystem;
/*
 -Öğrenci Bir Kişi'dir
 -Öğrenci'nin  numarası 
 -öğrenci bilgileri ekrana yazdırılırken öğrenci numarasıda ekrana yazdırılmalıdır
 
*/
public class Ogrenci : Kisi
{
    public Ogrenci(string Ad, string Soyad, DateTime DogumTarihi, int ogrenciNumarasi) : base(Ad, Soyad, DogumTarihi)
    {
        OgrenciNumarasi = ogrenciNumarasi;
    }
    public  int OgrenciNumarasi { get; set; }

    public override void BilgileriGetir()
    {
        Console.WriteLine($"Öğrenci Bilgileri\n-----------------\nAdı: {Ad}\nSoyadı: {Soyad}\nDoğum Tarihi:{DogumTarihi}\nÖğrenci Numarası:{OgrenciNumarasi}");
    }
}
