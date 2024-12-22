/*
Generic yapılar, özellikle tip güvenliği sağlama konusunda işimizi görürler. Fakat aynı zamanda kodun YENİDEN KULLANILABİLİRLİĞİNİ arttırır.
DRY- DON'T Repeat Yourself
*/

//Dictionary<TKey,TValue>

Dictionary<string,int> ages= new Dictionary<string, int>();
ages.Add("Ali",34);
ages.Add("Seren",19);
ages.Add("Can",26);

foreach(var age in ages)
{
    System.Console.WriteLine($"{age.Key}: {age.Value}");
}

if(ages.ContainsKey("Seren"))
{
    System.Console.WriteLine(ages["Seren"]);
}
ages.Remove("Can");

foreach (var age in ages)
{
    System.Console.WriteLine($"{age.Key}: {age.Value}");
}




// Box<int> numberBox = new Box<int>();
// numberBox.Add(5);
// System.Console.WriteLine(numberBox.Get());

// Box<string> stringBox = new Box<string>();
// stringBox.Add("Aleyna");
// System.Console.WriteLine(stringBox.Get());

// class Box<T>
// {
//     private T content;
//     public void Add(T item)
//     {
//         content = item;
//     }
//     public T Get()
//     {
//         return content;
//     }
// }