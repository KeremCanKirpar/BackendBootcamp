// namespace Proje03_Variables;

class Program
{
    static void Main(string[] args)
    {
        #region Değişken isimlendirme kural ve teknikleri
        /*
        1) C# Büyük/Küçük harf duyarlı bir dildir.
        Örn: adSoyad ile AdSoyad aynı DEĞİLDİR!!!!
       
        2) Özel karakterler değişken adı içerisinde yer alamaz. (_) Alt tire hariç
        Örn: Ad Soyad,Ogrenci-numarası bunlar geçersiz isimlerdir.
        Örn: Sayi1,Sayi_2, Sayi2Var
        örn:1Sayi,4Not bunlar geçersiz isimlerdir.Çünkü Değişken İsmi harf yada alt tire ile başlamak zorundadır!!
        
        3) Anahtar sözcükler yani c#'ın özel anlam yüklediği sözcükler değişken ismi olarak kullanılamaz.
        Örn: int static; geçersiz
        Örn: string void; geçersiz
        Örn: int @static; geçerli
        
        4) Değişkenler anlamlı bir şekilde isimlendirilmelidir.
        Örn:  string adSoyad;
        Örn: bool isActive;
        Örn: bool devletOzelTesvikSistemindenYararlaniyorMu; geçersiz

        5) Değişken isimlendirirken camelCase tekniği kullanılmalıdır.
        Örn: string anneadi; sting anne_adi; bunlar camelCase'e uygun değil
        Örn: string anneAdi; string mezunOlduguOkul; uygun örnekler

        6) Değişken isimlendirirken Türkçe karakter kullanmak yasak değildir. Ancak tercih etmemeniz şiddetle ÖNERİLİR!

        7) Sabit(const) tanımlarken genellikle tamamen BÜYÜK HARF kullanılır.
        Örn: const int MAX_AGE=40; geçerli bir kullanım
        Örn: const double PI=3.14;

        */
        #endregion

        #region TamSayilar
        // int degiskenAdi = 56;
        // int degiskenAdi2;
        // System.Console.WriteLine(degiskenAdi);

        /* Vs Code Kısayolları;
        LineCommand = Ctrl + ö, Ctrl + k c
        BlockCommand = Shift + alt + A
        Uncommand  = Ctrl + k u */

        //Tam Sayılar
        //C#'da ayrıca belirtilmedikçe tüm sayısal değerler int tipinde kabul edilir
        sbyte studentPoint = 127; // -128 den 127 ye kadar değer alır 1 byte (8-bit)
        System.Console.WriteLine(studentPoint);

        byte studentPoint2 = 255; // 0 dan 255 e kadar değer alır 1 byte (8-bit)
        System.Console.WriteLine(studentPoint2);

        // short price = 500; // 16-bit
        // ushort price2 = 65535; //16-bit
        // int number = -589; //32-bit
        // uint number2 = 97; // 32-bit
        // long longnumber = -98897987; // 64-bit
        // ulong longnumber2 = 545; //64-bit
        #endregion

        #region OndalikSayilar
        //Ondalık Sayılar
        //  float oran = 0.5f; // 32-bit, hassasiyet: 7 basamak
        //  double oran2 = 0.5; // 64-bit, hassasiyet: 15-16 basamak
        //  decimal maas = 0.5m; // 128-bit, hassasiyet: 28-29 basamak

        #endregion

        #region DigerTipler
        // bool varMi= true;
        // bool gecerliMi=false; // 8-bit 

        // char cevap = 'E';
        // char sembol = '&'; // UTF-16 charset, 16-bit

        #endregion

        #region Value Types(Deger Tipleri)

        /*
        Yukarıda ki tüm tiplere c# value types der.
        Value Types, bellek içinde direkt olarak değer saklayan yapıları anlatır.
        Ayrıca bunlara Primitive Types (ilkel Veri Tipi) da denir
        */
        #endregion

        #region Referance Types (Referans Tipleri)
        /*
        Ram'in stack kısmında verinin yerine, verinin bulunduğu yerin adresini tutan veri tipleridir.
        Yani bir referans tipi, bir nesneyi ya da değeri işaret eder.
        */
        #endregion

        #region Temel Referans Tipleri
        string adSoyad = "Kerem Can Kırpar";
        object nesne = 15;
        object nesne2 = true;
        object nesne3 = "Merhaba";
        //String ve Object  tiplerinin bellekte ne kadar yer kapladığın araştırınız.
        #endregion

        #region Const(Sabitler)
        const int MAX_AGE=45;
        // MAX_AGE=50;
        #endregion
    
    }
}
