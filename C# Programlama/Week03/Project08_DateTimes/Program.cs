namespace Project08_DateTimes;

class Program
{
    static void Main(string[] args)
    {
      //C#'ta tarih ve saat tipindeki verilerle çalışmak için DateTime adında bir sınıf vardır.
      DateTime now = DateTime.Now;
    //   string result = $@"Şu anki tarih saat: {DateTime.Now}";
    //   System.Console.WriteLine($@"{now.AddDays(21)}"); // 3 hafta sonraki tarih
    //   System.Console.WriteLine(result);
    //   System.Console.WriteLine($@"{now.AddMonths(3)}"); // 3 ay sonraki tarih

    // System.Console.WriteLine(now.ToString("dd/MM/yyyy"));
    // System.Console.WriteLine(now.ToString("HH:mm:ss"));
    // System.Console.WriteLine(now.ToString("d"));
    // System.Console.WriteLine(now.ToString("D"));
   
   

//    System.Console.WriteLine(now.ToShortDateString());
//    System.Console.WriteLine(now.ToShortTimeString());

        // int day =5;
        // int month =6;
        // int year = 1988;
        // DateTime date = new DateTime(year,month,day,4,5,0);

        // System.Console.WriteLine(date);
        // System.Console.WriteLine(date.AddMonths(-3));

        // DateTime birthDate = new DateTime(1975,7,16);
        // int month = birthDate.Month;
        // System.Console.WriteLine(birthDate.Day);
        // System.Console.WriteLine(month);
        // System.Console.WriteLine(birthDate.Year);

        System.Console.WriteLine(now.DayOfWeek);
    }
}
