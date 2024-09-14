namespace Project22_Inheritance;

class Bird
{
    public void Fly()
    {
        Console.WriteLine("Kuş uçuyor");
    }
}

class Penguin : Bird  // : den sonra eğer class çağrılıyorsa  diğer class miras alma özelliğini aktive eder
{
    public void Swim()
    {
        Console.WriteLine("Penguen Yüzüyor");
    }
}

class Otomobil
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Renk { get; set; }
    public int ModelYili { get; set; }

}

class IctenYanmaliOtomobil : Otomobil
{
    public string YakitTipi { get; set; }
    public string MotorGucu { get; set; }
}

class ElektrikliOtomobil : Otomobil
{
    public string Menzil { get; set; }
    public bool KendiniSarjEtme { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        ElektrikliOtomobil elektrikliOtomobil1 = new ElektrikliOtomobil();
        elektrikliOtomobil1.Marka = "Tesla";


        // Penguin penguin1 = new Penguin();
        // penguin1.Swim();
        // penguin1.Fly();
    }
}
