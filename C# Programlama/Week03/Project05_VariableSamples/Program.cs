namespace Project05_VariableSamples;

class Program
{
    static void Main(string[] args)
    {
        #region Yaş Hesaplama
        //Kullanıcıdan Girilen doğum yılına göre kaç yaşında olduğunu hesapla ve yazdır.
        // Console.Write("Doğum yılınızı Giriniz : ");
        // string input = Console.ReadLine();
        // int birthYear = int.Parse(input);
        // int calculatedAge = DateTime.Now.Year - birthYear;
        // string message = "Yaşınız: " + calculatedAge;
        // System.Console.WriteLine(message);
        #endregion

        #region Ürün Fiyatı Hesaplama
        //Bir Ürünün Fiyatı Girildiğinde, onun Kdv dahil fiyatını hesaplayıp hem ham hem de de kdv dahil fiyatını ekrana yazdıracağız.
        // Console.Write("Ürünün fiyatını giriniz :");
        // decimal productPrice = decimal.Parse(Console.ReadLine());

        // double vatRate = 0.18;
        // double vat = (double)productPrice * vatRate;
        // decimal totalProductPrice = productPrice + (decimal)vat;

        // //         string resultMessge = $@"---------------
        // // KDV Dahil Fiyat: {totalProductPrice}
        // // Ürün Fiyatı: {productPrice}
        // // KDV Fiyatı: {vatRate}";

        // string resultMessage = $"---------------\nÜrün Fiyatı: {productPrice}\nKDV Dahil Fiyatı: {totalProductPrice}\nKDV Fiyatı: {vatRate}";
        // System.Console.WriteLine(resultMessage);

        #endregion

        #region Sıcaklık Dönüştürme
        //Kullanıcıdan Celsius cinsinden alınan sıcaklık değerini, fahrenheit cinsine çevirip ekrana her ikisini de alt alta yazdıran kodu hazırla.

        // Console.Write("Sıcaklık Derecesini Girin:");
        // double celcius = double.Parse(Console.ReadLine());
        // double fahrenheit = (celcius *9) / 5 +32;
       
        // string resultMessage = $"Celcius Derecesi: {celcius}\nFahrenheit Derecesi:{fahrenheit}";
        // Console.Clear();
        // System.Console.WriteLine(resultMessage);
            
        #endregion

        #region Ağırlık Dönüştürme 
        //Kullanıcının girdiği kilogram cinsinden ağırlığı gram'a çevirip sonucu ekrana yazdıran kodu hazırlayınız.

        //Not: Küsüratlı değerler girilebilir.
        //Not: sonuç ekranında hem kilogram hem de gram değerlerini göster

        Console.Write("Kilogram Giriniz:");
        double kilogram = double.Parse(Console.ReadLine());
        double gram = 1000*kilogram;

        string resultMessage = $"Kilogram:{kilogram}\nGram:{gram}";

        System.Console.WriteLine(resultMessage);
        #endregion
    }
}
