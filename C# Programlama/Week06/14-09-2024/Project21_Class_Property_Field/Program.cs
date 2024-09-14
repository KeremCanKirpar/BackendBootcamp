namespace Project21_Class_Property_Field;

// class Product
// {
//     int id;
// string productName;
// decimal price;
// bool isActive;

// //Class içindeki bilgilerin dışarıya kontrollü bir şekilde açılmasını sağlayan yapılara Property diyoruz. Yaptığımız bu işleme ise Kapsülleme(ENCAPSULATION)

// public string ProductName
// {
//     get
//     {
//         string result = productName.Substring(0, 3).ToUpper();
//         return result;
//     }
//     set
//     {
//         productName = value;
//     }
// }

// public decimal Price
// {
//     get
//     {
//         return price;
//     }
//     set
//     {
//         if (value < 0)
//         {
//             price = 0;
//         }
//         else
//         {
//             price = value;
//         }

//         // price = value < 0 ? 0 : value;
//     }
// }


// }

class Product
{
    //propfull snippet kullanımı
    //    private int id;
    //    public int Id
    //    {
    //     get { return id; }
    //     set { id = value; }
    //    }


    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public required string Notes { get; set; }
    public bool isActive { get; set; }

}

class Student
{
    public Student()
    {
        Console.WriteLine($"{DateTime.Now} zamanında yeni bir Student oluşturuldu...");
    }
    public Student(int studentNumber)
    {
        StudentNumber = studentNumber;
        Console.WriteLine($"{DateTime.Now} zamanında yeni bir Student oluşturuldu...");

    }
    public int StudentNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public bool isActive { get; set; }

}

class Category
{
    public Category(int id)
    {
        Id = id;
    }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Category(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
class Program
{
    static void Main(string[] args)
    {

        Category category1 = new Category(56);
        Category category2 = new Category(65, "Bilgisayar");
        Category category3 = new Category(45, "Telefon", "Ve birçoğu burada");






        // Student s1 = new Student();
        // Student s2 = new Student(48);
        // Console.WriteLine(s2.StudentNumber);

        // Product product1 = new Product() { Notes = "Bişeyler" };
        // product1.Id = 5;
        // product1.Price = 800;
        // product1.ProductName = "Macbook Air M2";

        // Console.WriteLine(product1.Id);
        // Console.WriteLine(product1.Price);
        // Console.WriteLine(product1.ProductName);


        //     Product product1 = new Product();
        //     product1.ProductName = "Iphone 16";
        //     Console.WriteLine(product1.ProductName);

        //    product1.Price = -60.000m;
        //     Console.WriteLine(product1.Price);
    }
}
