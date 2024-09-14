namespace Soru05;

class Program
{
    static string[] Convert(string[] names)
    {
       for(int i = 0 ; i< names.Length;i++)
       {
        names[i] = names[i].ToUpper();
       }
       return names;
    }
    static void Main(string[] args)
    {
        string[] names = {
        "Ali",
        "Ayşe",
       };


        string[] ConvertTo = Convert(names);

        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
    }
}
