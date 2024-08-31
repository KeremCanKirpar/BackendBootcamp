namespace Soru05;

class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Tarihi YYYY-AA-GG formatında girin: ");
        string input = Console.ReadLine();

            // Kullanıcıdan alınan tarihi DateTime nesnesine çevir
            DateTime girilenTarih = DateTime.Parse(input);

            // Yılın kaçıncı günü olduğunu hesapla
            int yilGunu = girilenTarih.DayOfYear;

            // Sonucu ekrana yazdır
            Console.WriteLine($"Girilen tarih yılın {yilGunu}. günüdür.");
        
      
            Console.WriteLine("Geçersiz tarih formatı! Lütfen YYYY-AA-GG formatında bir tarih girin.");
     
       
          
       
    }
}
