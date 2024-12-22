using System.Security.Cryptography.X509Certificates;
using LINQ_Samples;
using Proje10_LINQ_Samples;
Repository repository = new Repository();

#region Tüm Kategorileri Listeleme
// var result = repository.Categories.ToList();
// var resultQuery = from category in repository.Categories
//                   select category;

#endregion

#region Kategori İsimleri Listeleme
// var categoryNames = repository
//     .Categories
//     .Select(x=>x.Name)
//     .ToList();
//     Console.ReadLine();
// var resultQuery = from category in repository.Categories.Select(x=>x.Name)
//                  select category;
#endregion

#region Silinmemiş Kategorileri Listeleme
    // var deletedCategories = repository
    //     .Categories
    //     .Where(x=>!x.IsDeleted)
    //     .ToList();
    //     Console.ReadLine();
    //     var deletedCategories = from category in repository.Categories
    //                             where !category.IsDeleted
    //                             select category;
    // Console.ReadLine();
#endregion

#region Ürünlerin Fiyatlarını Listeleme
    // var resultProduct = repository
    //                     .Products
    //                     .Select(x=>x.Price);
    // Console.ReadLine();
    // var resultProduct = from product in repository.Products
    //                     select product.Price;
//     var resultPrice = repository
//                       .Products
//                       .Where(x=>x.Price>=1000)
//                       .Select(x=>x.Price);
// Console.ReadLine();
#endregion

#region Kategoriye Göre Gruplanmış Ürünleri Listeleme
    // var groupedByCategory = repository
    //                         .Products
    //                         .GroupBy(x=>x.CategoryId)
    //                         .ToList();
    // Console.ReadLine();
    // var groupedByCategory = from product in repository.Products
    //                         group product by product.CategoryId;
   
#endregion

#region Tedarikçi başına ürün sayısı
    // var productCountBySupplier = repository
    //                              .Products
    //                              .GroupBy(p=>p.SupplierId)
    //                              .Select(g=> new {SupplierId=g.Key, ProductCount=g.Count()})
    //                              .ToList();
    // Console.ReadLine();
#endregion

#region  Her Kategorideki İlk Ürünü Getirme
// var firstProductInCategory =
//     repository
//     .Products
//     .GroupBy(p=>p.CategoryId)
//     .Select(g=>g.First())
//     .ToList();

// var firstProductInCategory = from first in repository
//                              .Products
//                              group first by first.CategoryId into firstGroup
//                              select firstGroup.FirstOrDefault();

//  Console.ReadLine();
#endregion

#region Ürünler arasındaki en küçük fiyatı
//     var productMin = repository
//                      .Products
//                      .Min(p=>p.Price);
// Console.ReadLine();
#endregion
