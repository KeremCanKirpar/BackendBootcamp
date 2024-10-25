using System.Diagnostics;
using System.Net.WebSockets;
using System.Reflection;

namespace WhileHomeWork;

class Program
{
    static void Main(string[] args)
    {
        #region Soru1
        // // Kullanıcıdan pozitif tam sayılar girmesini isteyin. Kullanıcı sıfır girdiğinde, program sona erer ve girilen tüm sayıların toplamını ekrana yazdırır. Her sayının toplanmasından sonra kullanıcıya yeni bir sayı girmesi istenir. Program sadece sıfır girildiğinde sona ermelidir.
        // int sayi;
        // int top =0;
        // do
        // {
        //     System.Console.Write("Bir sayı giriniz  = ");
        //     sayi = int.Parse(Console.ReadLine());

        //     top = top + sayi;

        // } while (sayi != 0);
        // System.Console.WriteLine($"İşlemin sonucu =>{top}");



        #endregion

        #region Soru2

        //Kullanıcıdan bir metin alın. Bu metindeki tüm harfleri büyük harfe çeviren bir program yazın. Sadece harf karakterleri büyük harfe çevrilmeli, diğer karakterler(noktalama işaretleri vb.) olduğu gibi kalmalıdır.Örneğin, "Merhaba Dünya!" metni "MERHABA DÜNYA!" olarak ekrana yazdırılmalıdır.

        // string metin = "";
        // string çevMetin = "";

        // do
        // {
        //     System.Console.Write("Bir Metin Giriniz = ");
        //     metin = Console.ReadLine();

        //     çevMetin = metin.ToUpper();

        // } while (false);
        // System.Console.WriteLine(çevMetin);


        #endregion

        #region soru3
        // Kullanıcıdan sürekli pozitif tam sayılar alın. Kullanıcı negatif bir sayı girdiğinde, program sona erer ve bu sayılardan her birinin karesini ekrana yazdırır.Örneğin, 4, 5, -1 girildiğinde, program 16 ve 25'i gösterir, ardından sonlanır.

        // int sayi;

        // Console.WriteLine("Bir pozitif tam sayı girin (negatif bir sayı girdiğinizde program sonlanır):");

        // do
        // {
        //     sayi = Convert.ToInt32(Console.ReadLine());

        //     if (sayi >= 0)
        //     {
        //         int karesi = sayi * sayi;
        //         Console.WriteLine("Sayının karesi: " + karesi);
        //     }
        // }
        // while (sayi >= 0);
        #endregion

        #region Soru4

        // Kullanıcıdan bir sayı alın ve bu sayının rakamlarının toplamını while döngüsü ile hesaplayın. Sonucu ekrana yazdırın.Örneğin, 245 sayısı girildiğinde, program 2 + 4 + 5 işlemini yaparak sonucu ekranda göstermelidir.

        //   System.Console.Write("Bir sayı giriniz : ");
        //   string input =Console.ReadLine();
        //     int top=0;
        //     int index=0;

        //   while (index < input.Length)
        //   {
        //      char karakter = input[index];
        //      int rakam = karakter - '0';

        //      top = top + rakam;
        //      index++;

        //   }
        //   System.Console.WriteLine("Karakterler toplamı = "+ top);



        #endregion

        #region Soru5

        // Console.Write("Bir pozitif tam sayı girin: ");
        // string sayi = Console.ReadLine();

        // int uzunluk = sayi.Length;
        // int index = uzunluk - 1;

        // string tersSayi = "";

        // while (index >= 0)
        // {
        //     tersSayi += sayi[index];
        //     index--;
        // }

        // Console.WriteLine("Ters çevrilmiş sayı: " + tersSayi);

        #endregion

        #region Soru6

        // string metin="";
        // string tersMetin="";

        //      System.Console.Write("Bir metin giriniz = ");
        //      System.Console.WriteLine();
        //       metin = Console.ReadLine();

        //         int uzunluk = metin.Length;
        //         int index = uzunluk - 1;

        //         while (index >= 0)
        //         {
        //             tersMetin = tersMetin+metin[index];
        //             index--;
        //         }
        //         System.Console.WriteLine($"Girilen metin => {metin}// Çevrilmiş hali => {tersMetin} ");

        #endregion

        #region Soru7
        // Console.Write("Bir pozitif tam sayı girin: ");
        // int sayi = int.Parse(Console.ReadLine());

        // Console.Write("Bir üst sınır değeri girin: ");
        // int ustSinir = int.Parse(Console.ReadLine());

        // while (sayi <= ustSinir)
        // {
        //     Console.WriteLine("Sayı: " + sayi);

        //     sayi *= 2;
        // }

        // Console.WriteLine("Döngü bitti, sayı üst sınırı aştı.");

        #endregion

        #region Soru8

        // int sayi;
        // int toplam = 0; 
        // int sayac = 0; 

        // while (true)
        // {
        //     Console.Write("Bir pozitif tam sayı girin (Programdan çıkmak için 100'den büyük bir sayı girin): ");
        //     sayi = int.Parse(Console.ReadLine());

        //     if (sayi > 100)
        //     {
        //         break;
        //     }
        
        //     toplam += sayi;
        //     sayac++;
        // }

        // double ortalama = (sayac > 0) ? (double)toplam / sayac : 0;

        // Console.WriteLine("Girilen sayı adedi: " + sayac);
        // Console.WriteLine("Girilen sayıların toplamı: " + toplam);
        // Console.WriteLine("Girilen sayıların ortalaması: " + ortalama);

        #endregion

        #region Soru9

        // Console.Write("Bir pozitif tam sayı girin: ");
        // int sayi = int.Parse(Console.ReadLine());

        // int i = 1; 

        // while (i <= sayi)
        // {
        //     bool asal = true;

        //     if (i == 1)
        //     {
        //         asal = false;
        //     }
        //     else
        //     {
        //         int bolen = 2;
        //         while (bolen <= Math.Sqrt(i))
        //         {
        //             if (i % bolen == 0)
        //             {
        //                 asal = false; 
        //                 break;
        //             }
        //             bolen++;
        //         }
        //     }

        //     if (asal)
        //     {
        //         Console.WriteLine(i + " - Asal");
        //     }
        //     else
        //     {
        //         Console.WriteLine(i + " - Asal değil");
        //     }
        //     i++;

        #endregion

        #region Soru10

        // Console.Write("Birinci pozitif tam sayıyı girin: ");
        // int ilkSayi = int.Parse(Console.ReadLine());

        // Console.Write("İkinci pozitif tam sayıyı girin: ");
        // int ikinciSayi = int.Parse(Console.ReadLine());

        // if (ilkSayi > ikinciSayi)
        // {
        //     int temp = ilkSayi;
        //     ilkSayi = ikinciSayi;
        //     ikinciSayi = temp;
        // }

        // int carpim = 1;
        // int sayi = ilkSayi;

        // while (sayi <= ikinciSayi)
        // {
        //     carpim *= sayi; 
        //     sayi++; 
        // }
        // Console.WriteLine(ilkSayi + " ile " + ikinciSayi + " arasındaki sayıların çarpımı: " + carpim);

        #endregion
    }
}
