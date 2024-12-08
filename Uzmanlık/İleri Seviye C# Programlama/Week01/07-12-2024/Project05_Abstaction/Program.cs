/*Bir E-Ticaret sistemimiz var. Ürünlerin farklı tipleri olabilir, Elektronik,giyim, gıda...
Her ürünün temel özellikleri aynı iken, bazı özellikleri tipe göre değişiklik gösterebilir. Bu durumda üst sınıf olarak planlayacağımız Product bir abstract class olacaktır

*/

//class Product: BaseEntity,IEntity,ICommon

Electronic electronic1 = new()
{
    Id = 1,
    Name = "Müzik Çalar",
    Price = 580
};
decimal discount = electronic1.CalculatedDiscountPrice();
System.Console.WriteLine(discount);


interface IProduct
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public abstract decimal CalculatedDiscountPrice();
}



class Electronic : IProduct
{
    public int Id { get ; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public decimal CalculatedDiscountPrice()
    {
        double result = (double)Price*0.1;
        return Convert.ToDecimal(result);
        
    }
}


class Clothing : IProduct
{
    public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Name { get => Name?.ToUpper(); set => throw new NotImplementedException(); }
    public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public decimal CalculatedDiscountPrice()
    {
        throw new NotImplementedException();
    }
}








































// abstract class Product{
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public decimal Price { get; set; }

//     public abstract decimal CalculatedDiscountPrice();
// }

// class Electronic : Product
// {
//     public int WarrantyPeriod { get; set; }

//     public override decimal CalculatedDiscountPrice()
//     {
//         throw new NotImplementedException();
//     }
// }

// class Clothing : Product
// {
//     public string? Size { get; set; }
//     public override decimal CalculatedDiscountPrice()
//     {
//         throw new NotImplementedException();
//     }
// }

