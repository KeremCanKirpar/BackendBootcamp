namespace Soru03;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan tarihi al
        Console.Write("Tarihi YYYY-AA-GG formatında girin: ");
        string input = Console.ReadLine();

        // Kullanıcıdan eklenecek gün sayısını al
        Console.Write("Eklenecek gün sayısını girin: ");
        int gunSayisi = Convert.ToInt32(Console.ReadLine());


        // Kullanıcıdan alınan tarihi DateTime nesnesine çevir
        DateTime girilenTarih = DateTime.Parse(input);

        // Tarihe gün sayısını ekle
        DateTime yeniTarih = girilenTarih.AddDays(gunSayisi);

        // Yeni tarihi ekrana yazdır
        Console.WriteLine($"Yeni tarih: {yeniTarih:yyyy-MM-dd}");

    }
}
