namespace homeWork07;

class Program
{
    static void Main(string[] args)
    {
        int longerNumber = 1000000;
        byte newResult = (byte)longerNumber;
        System.Console.WriteLine(newResult);
        /*Burada ki kodda byte'ın asıl alabilecek değeri en fazla 255 iken biz fazladan bit yüklemesi yaptığımız için veri kaybına sebeb oluyor ve sonuca sayının son 8 biti sığdırılıyor.Eksik bit kaybı da 64 bit oluyor.
        */
    }
}
