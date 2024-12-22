/*
Collections: C# içerisinden dizi benzeri bir veri yapısını ifade eder. Bir kaç türü vardır.

1) IEnumerable: En temel Collection yapılarından biridir. Ve şu özelliklere sahiptir;
    * Iteration sağlar(dönhü kullanabilme)
    * Verilerin sadece OKUNMASI GEREKEN durumlarda tercih  edilir.
    * Bu durumda ekleme, silme gibi operasyonlara izin vermez.
    * Özellikle foreach döngüsü ile kullanmaya oldukça uygundur.
    * Verileri belleğe almadan işlem yapar.

*/

// using System.Reflection.Emit;

// List<string> names = new List<string> { "Ali", "Veli", "Murat", "Sezen" };
// IEnumerable<string> enumerableNames = names;
// foreach (var name in enumerableNames)
// {
//     System.Console.WriteLine(name);
// }

/*
2) ICollection: IEnumarable'dan türetilmiştir. Ek olarak şu özelliklere 
sahiptir:
    * Veri ekleme ve silme operasyonlarını destekler.
    * Eleman sayısın öğrenme imkanı sağlar.
    * Veri üzerinde iteration yaparken manipülasyon yapma ihtiyacı olan durumlarda tercih edilir.
*/

// ICollection<string> names = new List<string> { "Ali", "Veli", "Murat", "Sezen" };
// System.Console.WriteLine(names.Count);

/*
3) IList: ICollection'dan türetilmiştir. Ek olarak sahip olduğu özellikler şunlardır:
    * Indeksleme imkanı sunar. Bu sayede collection elemanlarına bir index numarası ile erişlebilir. ([])
    * Sıralı veri yapılarında tercih edilir.
*/
// IList<string> names = new List<string> { "Ali", "Veli", "Murat", "Sezen" };
//  System.Console.WriteLine(names[0]);

/*
4) IQuerable: Bu collection yapısı biraz daha özel amaçlara hizmet eder:
    * Daha çok veri tabanı sorguları oluşturmak için tercih edilir.
    * Sorguyu, veri tabanına göndermeden önce optimize
    * Büyük veri setlerinde çok ciddi bir performans sağlar.
    * Filtreleme operasyonlarını direkt olarak veri tabanı üzerinde yaparak, hız kazandırır.
*/