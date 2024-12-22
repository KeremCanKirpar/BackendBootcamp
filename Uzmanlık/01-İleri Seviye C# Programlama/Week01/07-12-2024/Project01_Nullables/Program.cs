/*
Nullable Types;
Bu tipler, bu değerin "YOK" (null) olabilmesine izin veren veri türleridir.Genellikle referans tipler için mümkün olan bir durumdur. Varsayılan olarak null değer içeremeyen Value Type'ler istenilirse null değer içerebilecek hale getirilebilirler. Bunun için tip adının yanına "?" yazılır.
*/

// int? nullableInt = null;


// if(nullableInt.HasValue)
// {
//     System.Console.WriteLine("Değeri Yok");
// }else
// {
//     System.Console.WriteLine("Değeri Var");
// }

int? nullableValue = 250;
// int? result = nullableValue== null ? 100 : nullableValue;
int result = nullableValue ?? 100;

// System.Console.WriteLine(result);

// Bir veritabanından kullanıcının yaşını alıyoruz, ancak bazı durumlarda bu veri null gelebiliyor

int userAge = GetUserAge();
if(userAge<0)
{
    System.Console.WriteLine("Kişinin Yaş Bilgisi Yok");
}else
{
    System.Console.WriteLine(userAge);
}
System.Console.WriteLine(userAge);
 int GetUserAge()
{
    int? age = null; // bu fake bir veritabanından yaş çekme kodu
    return age ?? -1;
}

