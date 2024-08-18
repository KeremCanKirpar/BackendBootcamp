namespace homeWork13;

class Program
{
    static void Main(string[] args)
    {
        long lNumber = 500000000000;
        int newResult = Convert.ToInt32(lNumber);
        System.Console.WriteLine(newResult);

        /*
        Sonuç: at System.Convert.ThrowInt32OverflowException()
   at System.Convert.ToInt32(Int64 value)
   at homeWork13.Program.Main(String[] args) in C:\Users\Kerem\Desktop\HomeWork 18_08_2024\homeWork13\Program.cs:line 8
    Burada int değişkeni en yüksek 2 milyar değer alabildiği için girilen lond değişkeni intin alabileceği maksimum değeri aşıyor ve bu yüzden bize inte çevirdiğimizde ınt32 hatası fırlattı (OverFlowException: hata fırlatma)
   */
    }
}
