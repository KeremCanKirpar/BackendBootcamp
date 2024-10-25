namespace MaxMinHomeWork;

class Program
{
    static void Main(string[] args)
    {
        #region Soru1

        int enBuyuk = int.MinValue;
        int enKucuk = int.MaxValue;

        int sayac = 0;

        while (sayac < 5)
        {
            Console.Write((sayac + 1) + ". sayıyı girin: ");
            int sayi = int.Parse(Console.ReadLine());

            if (sayi > enBuyuk)
            {
                enBuyuk = sayi;
            }

            if (sayi < enKucuk)
            {
                enKucuk = sayi;
            }
            sayac++;
        }
        Console.WriteLine("En Büyük = " + enBuyuk);
        Console.WriteLine("En Küçük = " + enKucuk);


        #endregion


#endregion
    }
}
