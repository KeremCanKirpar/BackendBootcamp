namespace Project07_NumberMethods;

class Program
{
    static void Main(string[] args)
    {
        #region Aritmetik Operatörler
        
        int a = 10;
        int b = 5;
        

        int result = a + b;
        result = a-b;
        result = a*b;
        result = a/b;
        result = a%b;

        result = Math.Abs(-10); // mutlak değer+
        result = (int)Math.Pow(4,5); // karesini alma 
       double result2;
       result2 = Math.Sqrt(16); // karekökünü alma
       result2 = Math.Round(7.25); // yuvarlama 
       result2 = Math.Floor(8.3); // tabana yuvarlama
       result2 = Math.Ceiling(7.25); // yukarı yuvarlama

       //tan,cos,cotan
       


        System.Console.WriteLine(result);
        System.Console.WriteLine(result2);
        #endregion


    }
}
