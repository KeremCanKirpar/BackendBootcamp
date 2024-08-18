namespace Proje04_ConvertTypes;

class Program
{
    static void Main(string[] args)
    {
    #region Imlict Convert(Örtülü Dönüştürme)
    /*   int myAge = 21;
      long newMyAge = myAge; //int to long

      float rate=0.87f;
      double newRate = rate; // float to double

      byte studentNote = 75;
      int newStudentNote = studentNote; // byte to int */

    #endregion

    #region Explicit Convert(Açık Dönüştürme)
    // double myValue = 123.58;
    // int newMyValue = (int)myValue; // Cast etmek ya da Unboxing
    // System.Console.WriteLine("Double: " + myValue + "\n" + "int: " + newMyValue);

    string numberString = "125";
    int result = Convert.ToInt32(numberString) + 58;
    System.Console.WriteLine(result);


    #endregion




  }
}
