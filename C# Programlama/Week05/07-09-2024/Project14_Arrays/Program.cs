using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Project14_Arrays;

class Program
{
    static void Main(string[] args)
    {
        //     int[] numbers;
        //     numbers = new int[5];

        //     numbers[0] = 45;
        //     numbers[1] = 23;
        //     numbers[2] = 76;
        //     numbers[3] = 34;
        //     numbers[4] = 56;

        //    for (int i = 0; i < 5; i++)
        //    {
        //     Console.WriteLine($"Dizinin {i+1}.Elemanı: {numbers[i]}");
        //    }

        // int[] numbers = {49,34,90,25,67}; //Boyutu: 5 new int[5] demiş gibi olduk

        // for (int i = 0; i < 5; i++)
        // {
        //     System.Console.WriteLine($"Dizinin {i+1}.Elemanı: {numbers[i]}");
        // }


        // string[] studentNames = {
        //     "Ali",
        //     "Veli",
        //     "Murro",
        //     "Korcan"
        // };
        //     foreach (string student in studentNames)
        //     {
        //         Console.WriteLine(student);

        //     }
        //     foreach (string student in studentNames)
        //     {
        //         //student değişkeni iteration variable yani döngü değişkeni olduğundan, readonly özelliğine sahiptir. Yani değeri değiştirilemez!!!!
        //         student += "Canoğlu";
        //     }

        // int[] prices = { 40, 50, 60, 70, 80 };
        // //prices dizisinin içerisinde ki fiyatlara %10 zam gelmiştir. zamlı fiyatlatı içerecek şekilde prices dizisini güncelleyecek kodu yazınız.

        // System.Console.WriteLine("Zamsız ürün Fiyatları:");
        // System.Console.WriteLine("----------------------");
        // foreach (int p in prices)
        // {
        //     Console.WriteLine(p);
        // }

        // for (int i = 0; i < prices.Length; i++)
        // {
        //     prices[i] = (int)(prices[i] * 1.1);
        // }

        // System.Console.WriteLine("Zamlı ürün Fiyatları:");
        // System.Console.WriteLine("----------------------");
        // foreach (int p in prices)
        // {
        //     Console.WriteLine(p);
        // }

        //a = 40 b= 50 c=45 şeklinde elimizde bulunan en büyüğünü bulduran kodu yazınız.

        // int a = 40;
        // int b = 50;
        // int c = 45;

        // int max = int.MinValue;


        // // if(a>max)
        // // {
        // //     max = a;
        // // }
        // // if(b>max)
        // // {
        // //     max = b;
        // // }
        // // if(c>max)
        // // {
        // //     max= c;
        // // }
        // // System.Console.WriteLine(max);

        //20 elemanlı bir int dizisinde rastgele değerler atayalım. Ardından bu dizinin içinde ki en küçük ve en büyük değeri tespit edip ekrana yazdıralım 

        // Random rnd = new Random();

        // int[] numbers = new int[10];
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     numbers[i] = rnd.Next(1, 101);
        //     Console.WriteLine(numbers[i]);
        // }
        // //En Büyük ve En küçüğü bulduruyoruz 

        // int max = int.MinValue;
        // int min = int.MaxValue;

        // foreach (int p in numbers)
        // {
        //     if (p > max) max = p;
        //     if (p < min) min = p;

        // }
        // System.Console.WriteLine($"En Küçük: {min} \nEn Büyüğü : {max}");

        // Random rnd = new Random();

        // int[] numbers = new int[10];
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     numbers[i] = rnd.Next(1, 1001);
        //     Console.WriteLine(numbers[i]);
        // }
        // Array.Sort(numbers);
        // System.Console.WriteLine("Dizinin Küçükten Büyüğe Sıralanmış Hali");
        // System.Console.WriteLine("----------------------------------------");
        // for (int i = 0; i < numbers.Length; i++)
        // {

        //     Console.WriteLine(numbers[i]);
        // }
        // Array.Reverse(numbers);
        // System.Console.WriteLine("Dizinin Büyükten Küçüğe Sıralanmış Hali");
        // System.Console.WriteLine("----------------------------------------");
        // for (int i = 0; i < numbers.Length; i++)
        // {

        //     Console.WriteLine(numbers[i]);
        // }

        // Random rnd = new Random();

        // int[] numbers = new int[10];
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     numbers[i] = rnd.Next(1, 1001);

        // }
        // numbers[0] = 99;

        // for (int i = 0; i < numbers.Length; i++)
        // {

        //     Console.WriteLine($"Index: {i} - Numbers {numbers[i]}");
        // }
        // Console.WriteLine(Array.IndexOf(numbers, "metin"));


        // string firstName = "Alex de Souza";
        // Console.WriteLine(firstName.Length);,


        // string text = "çok hava çok güzel çok ama çok fazla çok  ";
        // string[] result = text.Split("çok");
        // int wordCount =  result.Length -1;
        // System.Console.WriteLine(wordCount);


        //DİZİLERİ KOPYALAMAK
        // string[] names = {"Kerem" , "Halilişko" , "Celilşko" , "Korcan"};
        // string[] newNames = names;

        // names[0] = "Heda";
        // System.Console.WriteLine(newNames[0]);

        // string[] names = { "Kerem", "Halilişko", "Celilşko", "Korcan" };
        // string[] newNames = new string[names.Length];
        // Array.Copy(names , newNames, 4);

        // foreach (var name in names)
        // {
        //     System.Console.WriteLine(name);
        // }
        // newNames[0] = "Heda";
        // System.Console.WriteLine();

        // foreach (var name in names)
        // {
        //     System.Console.WriteLine(name);
        // }

        //DİZİDE VAR / YOK KONTROLÜ YAPMAK
        // int[] numbers = { 3, 4, 5, 6, 7 };
        // bool exists = Array.Exists(numbers, n => n == 6);
        // System.Console.WriteLine(exists);

        // //DİZİDE BELİRTİLEN  KOŞULA UYGUN İLK ELEMANI GETİRMEK
        // int[] numbers = { 3, 4, 5, 6, 7 };
        // int result = Array.Find(numbers, n => n == 6);
        // System.Console.WriteLine(result);

        //DİZİDE BELİRTİLEN  KOŞULA UYGUN İLK ELEMANI GETİRMEK
        // int[] numbers = { 3, 4, 5, 6, 7 };
        // int[] result = Array.FindAll(numbers, x => x>=6);
        // foreach (var item in result)
        // {
        //     System.Console.WriteLine(item);
        // }

        //DİZİNİN BOYUTUNU(ELEMAN SAYISINI) DEĞİŞTİRMEK
        // int[] numbers = { 3, 6, 9 };
        // System.Console.WriteLine(numbers.Length);
        // Array.Resize(ref numbers, numbers.Length+1);
        // numbers[3]=55;
        // System.Console.WriteLine(numbers.Length);

        // //DİZİNİN BELİRLİ BİR BÖLÜMÜNÜ TEMİZLEMEK
        // int[] numbers = { 4, 5, 6, 7, 8, 9,  7,  5, 12 };
        // System.Console.WriteLine("Dizinin Orjinal Hali");

        // foreach (int item in numbers)
        // {
        //     Console.WriteLine(item);
        // }

        // Array.Clear(numbers, 2,6);
        // System.Console.WriteLine();
        // System.Console.WriteLine("Dizinin Temizenmiş  Hali");

        


    }
}
