namespace homeWork17;

class Program
{
    static void Main(string[] args)
    {
       byte byteType = 42;
       short shortType =42;
       int intType = 42;
       long longType = 42;
       byteType = sizeof(byte);
       shortType = sizeof(short);
       intType = sizeof(int);
       longType = sizeof(long);

       System.Console.WriteLine(byteType);
       System.Console.WriteLine(shortType);
       System.Console.WriteLine(intType);
       System.Console.WriteLine(longType);
    }
}
