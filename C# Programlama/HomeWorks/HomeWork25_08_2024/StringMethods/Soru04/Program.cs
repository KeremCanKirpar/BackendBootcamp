using System.Diagnostics.CodeAnalysis;

namespace Soru04;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Kullanıcı Adınızı Giriniz: ");
        string userName = Console.ReadLine();

        string description = userName.Trim();

        System.Console.WriteLine("Kullanıcı Adınız Düzenlendi: " + description);
    }
}
