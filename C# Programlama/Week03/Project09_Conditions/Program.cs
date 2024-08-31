namespace Project09_Conditions;

class Program
{
    static void Main(string[] args)
    {

        //kullanıcının klavyeden gireceği yaş bilgisini alıp eğer reşit değilse reşit değilsiniz reşit ise giriş yapabilirsiniz eğer reşit ise giriş yapabilirsiniz yazdıran kodu yaz

        #region If
        // if (5>14)
        // {
        //     Console.WriteLine("İşlem Tamam");
        // }
        // else
        // {
        //     System.Console.WriteLine("İşlem Hatalı");
        // }
        // System.Console.WriteLine("Uygulama Sona Erdi...");

        // int x = 15;

        // if (x > 15)
        // {
        //     System.Console.WriteLine("Büyüktür");
        // }
        // else if (x < 15)
        // {
        //     System.Console.WriteLine("Küçüktür");
        // }
        // else
        // {
        //     System.Console.WriteLine("Eşittir");
        // }
        #endregion

        #region Turnery If


        // Console.Write("Yaşınızı Giriniz: ");
        // int  age = Convert.ToInt32(Console.ReadLine());

        // if(age >= 18)
        // {
        //     System.Console.WriteLine("Giriş Yapabilirsiniz");
        // }
        // else
        // {
        //     int result = 18 - age;
        //     System.Console.WriteLine("Reşit Değiliniz " + result + " Sene sonra Reşit olucaksınız ");
        // }
        //DRY-Don't Repeat Yourself

        // string resultMessage;
        // Console.Write("Yaşınızı Giriniz: ");
        // int age = Convert.ToInt32(Console.ReadLine());
        // Console.Write("Adınızı Giriniz: ");
        // string fullName = Console.ReadLine();

        // if (age >= 18)
        // {
        //     resultMessage = "Giriş Yapabilirsiniz";
        // }
        // else
        // {

        //    resultMessage= $"Reşit Değilsiniz { 18-age}  Sene sonra Reşit olucaksınız ";
        // }
        // System.Console.WriteLine($"Sevgili {fullName} {resultMessage}");

        // System.Console.Write("Adınızı Giriniz: ");
        // string fullName = Console.ReadLine();

        // System.Console.Write("Yaşınızı Giriniz: ");
        // byte age = byte.Parse(Console.ReadLine());

        //Ternary If Yapısı
        // string resultMessage = age >= 18 
        //                            ? $"Giriş Yapabilirsin, {fullName}" 
        //                            : $"Sevgili, {fullName} {18 - age} sene sonra reşit olucaksın";

        // System.Console.WriteLine(resultMessage);

        // System.Console.WriteLine(age >= 18
        //                            ? $"Giriş Yapabilirsin, {fullName}"
        //                            : $"Sevgili, {fullName} {18 - age} sene sonra reşit olucaksın");



        // System.Console.Write("Notunuzu Giriniz: ");
        // byte point = byte.Parse(Console.ReadLine());
        // string resultMessage;

        // //If Çözümü 
        // if (point >= 50)
        // {

        // }

        //Turnery If Yapısı
        // resultMessage = point >= 50 
        //                       ? "Geçtin" 
        //                       : "Kaldın";

        // System.Console.WriteLine(resultMessage +$"{point-50} kadar puana ihtiyacın var ");

        #endregion

        #region Switch Case
        // byte point = 140;
        // byte resultPoint = 0;
        // switch (point)
        // {
        //     case < 45:
        //         resultPoint = 1;
        //         break;
        //     case < 55:
        //         resultPoint = 2;
        //         break;
        //     case < 70:
        //         resultPoint = 3;
        //         break;
        //     case < 80:
        //         resultPoint = 4;
        //         break;
        //     case <= 100:
        //         resultPoint = 5;
        //         break;
        //     default:
        //         System.Console.WriteLine("Hata!");
        //         break;
        // }
        // if (point != 0 && point <= 100)
        // {
        //     System.Console.WriteLine(resultPoint);
        // }

        //&& = ve işareti (Kesinlik Gerektirir)
        // || veya işareti ( 1 tane kesinlik olursa okey)

        //Girilen Tarihin Hafta içi mi yoksa hafta sonu mu olduğunu yazın

        // Console.Write("Bir Tarih Giriniz(gg.aa.yyyy): ");
        // string inputDate = Console.ReadLine();

        // if (DateTime.TryParse(inputDate, out DateTime date))
        // {
        //     DayOfWeek day = date.DayOfWeek;
        //     System.Console.WriteLine(date.ToLongDateString());
        //     switch (day)
        //     {
        //         case DayOfWeek.Saturday:
        //         case DayOfWeek.Sunday:
        //             System.Console.WriteLine("Hafta Sonu");
        //             break;
        //         default:
        //             System.Console.WriteLine("Hafta İçi");
        //             break;
        //     }

        // }
        // else
        // {
        //     System.Console.WriteLine("Hatalı Tarih Formatı!");
        // }


        //Girilen Tarihin Hangi mevsime Denk geldiğini bulup ekrana yazdıran kodu bulup switch yapısı kullanarak hazırlayınız.
        // System.Console.WriteLine("Bir Tarih Giriniz:");
        // string inputDate = Console.ReadLine();

        // if (DateTime.TryParse(inputDate, out DateTime date))
        // {
        //     switch (date.Month)
        //     {
        //         case 9:
        //         case 10:
        //         case 11:
        //             System.Console.WriteLine("Sonbahar");
        //             break;
        //         case 12:
        //         case 1:
        //         case 2:
        //             System.Console.WriteLine("Kış");
        //             break;
        //         case 3:
        //         case 4:
        //         case 5:
        //             System.Console.WriteLine("İlkBahar");
        //             break;
        //         default:
        //             System.Console.WriteLine("Yaz");
        //             break;

        //     }

        // }
        // else
        // {
        //     System.Console.WriteLine("Yanlış Tarih Formatı!");
        // }
        #endregion

    }
}
