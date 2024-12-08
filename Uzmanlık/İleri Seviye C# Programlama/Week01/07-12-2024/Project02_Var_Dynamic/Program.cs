/*
var anahtar kelimesi, tür çıkarımı(type inference)
sağlayan bir kelimedir. Derleyici, değişkenin 
türünü atanan değerden bakarak otomatik olarak belirler.
Derleme zamanında bu tür sabit bir şekilde belirlenmiş olur.





-var kullanımı, türünaçık bir şekilde belli 
olduğu durumlarda kullanılırsa daha sağlıklı olur.
- Tür bir kez belirlendikten sonra değiştirilemez.
*/

var number = 5;
var name = "Ali";
string address;
address ="İstanbul";

// var price; //Yanlış Kullanım

/*
dynamic, derleme zamanında tür kontrolü yapmadan çalışma zamanına geçerek orada bu çıkarsamanın yapılmasını sağlar. Bu yönüyle daha esnek bir yapı sunarken, hatalara da daha açık bir tekniktir.
*/

// var a= 5;
// a = "Ali";

dynamic a=5;
System.Console.WriteLine(a);
a="Engin";
System.Console.WriteLine(a);
