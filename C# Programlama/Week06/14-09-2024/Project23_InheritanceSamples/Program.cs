using Project23_InheritanceSamples.CarManagementSystem;
using Project23_InheritanceSamples.SchoolSystem;

namespace Project23_InheritanceSamples;

class Program
{
    static void Main(string[] args)
    {
        Vehicle vc1 = new Vehicle("Nissan","Skyline",1994);
        vc1.ShowCar();
        vc1.Start();
        vc1.Stop();
        Console.Write("****************************************\n");
        Car c1 = new Car("Toyota", "Supra", 1990, 4);
        c1.ShowCar();
        c1.OpenTrunk();
        Console.Write("****************************************\n");
        Motorcycle mt1 = new Motorcycle("Yamaha","R25",2016,true);
        mt1.ShowCar();








        // Ogretmen ogretmen1 = new Ogretmen("Halil","Uyar",new DateTime(1980,05,12),"İnkılap Tarihi",35000m);
        // ogretmen1.BilgileriGetir();


        // Ogrenci ogrenci1 = new Ogrenci("Kerem Can","Kırpar", new DateTime(2003,04,05), 2024549381);
        // ogrenci1.BilgileriGetir();

        // Kisi kisi1 = new Kisi("Kerem","Kırpar", new DateTime(2003,04,05));
        // kisi1.BilgileriGetir();
        // Console.WriteLine($"\n{kisi1.Ad}'in Yaşı : {kisi1.Yas}");

        // Cat cat1 = new Cat("Muffy", 5, "Turuncu");
        // cat1.MakeSound();
        // Dog dog = new Dog("Şahbatur",10,4,"3 Yavrusu var");
        // dog.MakeSound();
        // dog.Swim();
    }
}
