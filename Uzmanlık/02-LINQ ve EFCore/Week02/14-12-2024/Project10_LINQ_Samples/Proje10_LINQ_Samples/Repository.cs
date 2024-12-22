using System;
using Proje10_LINQ_Samples;

namespace LINQ_Samples;

public class Repository
{
    public List<Category> Categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Elektronik",
                    Description = "Telefon, bilgisayar ve diğer elektronik ürünler",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Ev Eşyaları",
                    Description = "Evde kullanılan eşyalar ve mobilyalar",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    Name = "Kıyafet",
                    Description = "Kadın, erkek ve çocuk kıyafetleri",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Yiyecek & İçecek",
                    Description = "Gıda ve içecek ürünleri",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 5,
                    Name = "Spor & Outdoor",
                    Description = "Spor malzemeleri ve açık hava aktiviteleri",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            };
    public List<Customer> Customers = new List<Customer>
{
    new Customer { Id=1,Name = "John Doe", ContactName = "John Doe", Email = "john.doe@gmail.com", PhoneNumber = "+90 555 111 22 33", Address = "Kadıköy, İstanbul", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=2,Name = "Jane Smith", ContactName = "Jane Smith", Email = "jane.smith@gmail.com", PhoneNumber = "+90 555 222 33 44", Address = "Beyoğlu, İstanbul", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=3,Name = "Ali Yıldız", ContactName = "Ali Yıldız", Email = "ali.yildiz@gmail.com", PhoneNumber = "+90 555 333 44 55", Address = "Ankara, Çankaya", City = "Ankara", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=4,Name = "Fatma Demir", ContactName = "Fatma Demir", Email = "fatma.demir@gmail.com", PhoneNumber = "+90 555 444 55 66", Address = "İzmir, Konak", City = "İzmir", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=5,Name = "Mustafa Tekin", ContactName = "Mustafa Tekin", Email = "mustafa.tekin@gmail.com", PhoneNumber = "+90 555 555 66 77", Address = "Antalya, Muratpaşa", City = "Antalya", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=6,Name = "Ayşe Çetin", ContactName = "Ayşe Çetin", Email = "ayse.cetin@gmail.com", PhoneNumber = "+90 555 666 77 88", Address = "Bursa, Nilüfer", City = "Bursa", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=7,Name = "Mehmet Özdemir", ContactName = "Mehmet Özdemir", Email = "mehmet.ozdemir@gmail.com", PhoneNumber = "+90 555 777 88 99", Address = "Konya, Meram", City = "Konya", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=8,Name = "Emine Aksoy", ContactName = "Emine Aksoy", Email = "emine.aksoy@gmail.com", PhoneNumber = "+90 555 888 99 00", Address = "İstanbul, Beşiktaş", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=9,Name = "Okan Kızıl", ContactName = "Okan Kızıl", Email = "okan.kizil@gmail.com", PhoneNumber = "+90 555 999 00 11", Address = "İzmir, Bornova", City = "İzmir", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=10,Name = "Deniz Aydoğan", ContactName = "Deniz Aydoğan", Email = "deniz.aydogan@gmail.com", PhoneNumber = "+90 555 101 11 22", Address = "İstanbul, Kadıköy", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=11,Name = "Büşra Sarı", ContactName = "Büşra Sarı", Email = "busra.sari@gmail.com", PhoneNumber = "+90 555 202 22 33", Address = "Antalya, Kepez", City = "Antalya", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Customer { Id=12,Name = "Serkan Yılmaz", ContactName = "Serkan Yılmaz", Email = "serkan.yilmaz@gmail.com", PhoneNumber = "+90 555 303 33 44", Address = "Ankara, Altındağ", City = "Ankara", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false }
};
    public List<Supplier> Suppliers = new List<Supplier>
{
    new Supplier { Name = "TechSupply Inc.", ContactName = "Ali Yılmaz", Email = "ali@techsupply.com", PhoneNumber = "+90 555 123 45 67", Address = "İstanbul, Avcılar", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "Furniture World", ContactName = "Mehmet Kaya", Email = "mehmet@furnitureworld.com", PhoneNumber = "+90 555 234 56 78", Address = "Ankara, Çankaya", City = "Ankara", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "ClothShop", ContactName = "Fatma Demir", Email = "fatma@clothshop.com", PhoneNumber = "+90 555 345 67 89", Address = "İzmir, Konak", City = "İzmir", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "Gourmet Foods", ContactName = "Zeynep Yüksel", Email = "zeynep@gourmetfoods.com", PhoneNumber = "+90 555 456 78 90", Address = "Antalya, Muratpaşa", City = "Antalya", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "SportGear", ContactName = "Ahmet Sönmez", Email = "ahmet@sportgear.com", PhoneNumber = "+90 555 567 89 01", Address = "Bursa, Nilüfer", City = "Bursa", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "SuperTech Ltd.", ContactName = "Ayşe Çetin", Email = "ayse@supertech.com", PhoneNumber = "+90 555 678 90 12", Address = "İstanbul, Beşiktaş", City = "İstanbul", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
    new Supplier { Name = "HomeLux", ContactName = "Kadir Çalışkan", Email = "kadir@homelux.com", PhoneNumber = "+90 555 789 01 23", Address = "Konya, Meram", City = "Konya", Country = "Türkiye", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false }
};
    public List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "iPhone 14", Description = "Apple iPhone 14 Pro 128GB", CategoryId = 1, SupplierId = 1, StockQuantity = 50, MinimumStockLevel = 10, Price = 15000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 2, Name = "Samsung Galaxy S22", Description = "Samsung Galaxy S22 128GB", CategoryId = 1, SupplierId = 1, StockQuantity = 40, MinimumStockLevel = 8, Price = 14000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 3, Name = "MacBook Pro 16\"", Description = "Apple MacBook Pro 16\" M1 Pro", CategoryId = 1, SupplierId = 1, StockQuantity = 20, MinimumStockLevel = 5, Price = 30000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 4, Name = "Samsun 55\" 4K TV", Description = "Samsun 55\" UHD Smart TV", CategoryId = 1, SupplierId = 2, StockQuantity = 15, MinimumStockLevel = 3, Price = 9000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 5, Name = "Ergonomic Office Chair", Description = "High-back ergonomic office chair", CategoryId = 2, SupplierId = 2, StockQuantity = 100, MinimumStockLevel = 20, Price = 5000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 6, Name = "Wooden Dining Table", Description = "Dining table for 6 people", CategoryId = 2, SupplierId = 3, StockQuantity = 30, MinimumStockLevel = 6, Price = 3500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 7, Name = "Cotton T-shirt", Description = "Basic white cotton T-shirt", CategoryId = 3, SupplierId = 3, StockQuantity = 200, MinimumStockLevel = 50, Price = 150.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 8, Name = "Leather Jacket", Description = "Genuine leather jacket", CategoryId = 3, SupplierId = 3, StockQuantity = 70, MinimumStockLevel = 10, Price = 1200.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 9, Name = "Jogging Pants", Description = "Comfortable jogger pants", CategoryId = 3, SupplierId = 4, StockQuantity = 100, MinimumStockLevel = 20, Price = 400.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 10, Name = "Organic Peanut Butter", Description = "All natural peanut butter", CategoryId = 4, SupplierId = 4, StockQuantity = 500, MinimumStockLevel = 50, Price = 30.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 11, Name = "Protein Bar", Description = "High protein snack bar", CategoryId = 4, SupplierId = 4, StockQuantity = 300, MinimumStockLevel = 50, Price = 20.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 12, Name = "Mountain Bike", Description = "MTB for outdoor activities", CategoryId = 5, SupplierId = 5, StockQuantity = 10, MinimumStockLevel = 2, Price = 3500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 13, Name = "Hiking Backpack", Description = "Water-resistant hiking backpack", CategoryId = 5, SupplierId = 5, StockQuantity = 15, MinimumStockLevel = 3, Price = 2500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 14, Name = "Yoga Mat", Description = "Eco-friendly yoga mat", CategoryId = 5, SupplierId = 6, StockQuantity = 200, MinimumStockLevel = 50, Price = 250.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 15, Name = "Camping Tent", Description = "4-person camping tent", CategoryId = 5, SupplierId = 6, StockQuantity = 30, MinimumStockLevel = 5, Price = 4500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 16, Name = "Smart Watch", Description = "Waterproof smart watch", CategoryId = 1, SupplierId = 7, StockQuantity = 75, MinimumStockLevel = 15, Price = 2200.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 17, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker", CategoryId = 1, SupplierId = 7, StockQuantity = 120, MinimumStockLevel = 25, Price = 700.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 18, Name = "Kitchen Blender", Description = "Powerful kitchen blender", CategoryId = 2, SupplierId = 2, StockQuantity = 50, MinimumStockLevel = 10, Price = 1800.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 19, Name = "Recliner Sofa", Description = "3-seater recliner sofa", CategoryId = 2, SupplierId = 2, StockQuantity = 20, MinimumStockLevel = 4, Price = 6500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 20, Name = "Espresso Machine", Description = "Professional espresso machine", CategoryId = 2, SupplierId = 3, StockQuantity = 10, MinimumStockLevel = 2, Price = 8000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 21, Name = "Blender", Description = "High-speed blender", CategoryId = 2, SupplierId = 3, StockQuantity = 70, MinimumStockLevel = 15, Price = 1500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 22, Name = "Air Fryer", Description = "Oil-free air fryer", CategoryId = 2, SupplierId = 4, StockQuantity = 100, MinimumStockLevel = 20, Price = 1200.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 23, Name = "Smart Thermostat", Description = "Smart home temperature controller", CategoryId = 2, SupplierId = 5, StockQuantity = 50, MinimumStockLevel = 10, Price = 2000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 24, Name = "Portable Power Bank", Description = "Large capacity power bank", CategoryId = 1, SupplierId = 6, StockQuantity = 300, MinimumStockLevel = 50, Price = 400.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false },
        new Product { Id = 25, Name = "Fitness Tracker", Description = "Wearable fitness tracking device", CategoryId = 1, SupplierId = 6, StockQuantity = 150, MinimumStockLevel = 30, Price = 1500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false }
    };
    public List<Sale> Sales = new List<Sale>
    {
        new Sale { Id = 1, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 1, CustomerId = 1, Quantity = 1, UnitPrice = 15000.00m, SaleDate = new DateTime(2022, 1, 15) },
        new Sale { Id = 2, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 1, CustomerId = 2, Quantity = 2, UnitPrice = 15000.00m, SaleDate = new DateTime(2023, 1, 5) },
        new Sale { Id = 3, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 1, CustomerId = 3, Quantity = 1, UnitPrice = 15000.00m, SaleDate = new DateTime(2024, 1, 1) },

        new Sale { Id = 4, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 2, CustomerId = 4, Quantity = 2, UnitPrice = 14000.00m, SaleDate = new DateTime(2022, 1, 20) },
        new Sale { Id = 5, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 2, CustomerId = 5, Quantity = 1, UnitPrice = 14000.00m, SaleDate = new DateTime(2023, 3, 1) },

        new Sale { Id = 6, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 3, CustomerId = 6, Quantity = 1, UnitPrice = 30000.00m, SaleDate = new DateTime(2022, 2, 10) },
        new Sale { Id = 7, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 3, CustomerId = 7, Quantity = 2, UnitPrice = 30000.00m, SaleDate = new DateTime(2023, 5, 15) },
        new Sale { Id = 8, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 3, CustomerId = 8, Quantity = 1, UnitPrice = 30000.00m, SaleDate = new DateTime(2024, 1, 15) },

        new Sale { Id = 9, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 4, CustomerId = 9, Quantity = 3, UnitPrice = 9000.00m, SaleDate = new DateTime(2022, 2, 15) },
        new Sale { Id = 10, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 4, CustomerId = 10, Quantity = 2, UnitPrice = 9000.00m, SaleDate = new DateTime(2023, 2, 10) },

        new Sale { Id = 11, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 5, CustomerId = 11, Quantity = 2, UnitPrice = 5000.00m, SaleDate = new DateTime(2022, 3, 1) },
        new Sale { Id = 12, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 5, CustomerId = 12, Quantity = 1, UnitPrice = 5000.00m, SaleDate = new DateTime(2023, 4, 20) },

        new Sale { Id = 13, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 6, CustomerId = 1, Quantity = 1, UnitPrice = 3500.00m, SaleDate = new DateTime(2022, 3, 10) },
        new Sale { Id = 14, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 6, CustomerId = 1, Quantity = 1, UnitPrice = 3500.00m, SaleDate = new DateTime(2023, 6, 5) },
        new Sale { Id = 15, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 6, CustomerId = 1, Quantity = 1, UnitPrice = 3500.00m, SaleDate = new DateTime(2024, 3, 1) },

        new Sale { Id = 16, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 7, CustomerId = 2, Quantity = 3, UnitPrice = 25000.00m, SaleDate = new DateTime(2022, 4, 12) },
        new Sale { Id = 17, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 7, CustomerId = 3, Quantity = 1, UnitPrice = 25000.00m, SaleDate = new DateTime(2023, 8, 17) },
        new Sale { Id = 18, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 7, CustomerId = 4, Quantity = 2, UnitPrice = 25000.00m, SaleDate = new DateTime(2024, 1, 20) },

        new Sale { Id = 19, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 8, CustomerId = 5, Quantity = 1, UnitPrice = 17000.00m, SaleDate = new DateTime(2022, 5, 25) },
        new Sale { Id = 20, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 8, CustomerId = 6, Quantity = 2, UnitPrice = 17000.00m, SaleDate = new DateTime(2023, 9, 10) },

        new Sale { Id = 21, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 9, CustomerId = 7, Quantity = 1, UnitPrice = 20000.00m, SaleDate = new DateTime(2022, 6, 1) },
        new Sale { Id = 22, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 9, CustomerId = 8, Quantity = 3, UnitPrice = 20000.00m, SaleDate = new DateTime(2023, 12, 15) },

        new Sale { Id = 23, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 10, CustomerId = 9, Quantity = 1, UnitPrice = 18000.00m, SaleDate = new DateTime(2022, 7, 10) },
        new Sale { Id = 24, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 10, CustomerId = 10, Quantity = 2, UnitPrice = 18000.00m, SaleDate = new DateTime(2023, 11, 8) },

        new Sale { Id = 25, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 11, CustomerId = 11, Quantity = 1, UnitPrice = 13000.00m, SaleDate = new DateTime(2022, 8, 15) },
        new Sale { Id = 26, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 11, CustomerId = 12, Quantity = 2, UnitPrice = 13000.00m, SaleDate = new DateTime(2024, 2, 20) },

        new Sale { Id = 27, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 12, CustomerId = 1, Quantity = 1, UnitPrice = 22000.00m, SaleDate = new DateTime(2022, 9, 5) },
        new Sale { Id = 28, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 12, CustomerId = 2, Quantity = 2, UnitPrice = 22000.00m, SaleDate = new DateTime(2023, 10, 30) },

        new Sale { Id = 29, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 13, CustomerId = 3, Quantity = 2, UnitPrice = 11000.00m, SaleDate = new DateTime(2022, 10, 1) },
        new Sale { Id = 30, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 13, CustomerId = 4, Quantity = 1, UnitPrice = 11000.00m, SaleDate = new DateTime(2023, 6, 18) },

        new Sale { Id = 31, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 14, CustomerId = 5, Quantity = 3, UnitPrice = 4000.00m, SaleDate = new DateTime(2022, 11, 5) },
        new Sale { Id = 32, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 14, CustomerId = 6, Quantity = 2, UnitPrice = 4000.00m, SaleDate = new DateTime(2023, 7, 7) },

        new Sale { Id = 33, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 15, CustomerId = 7, Quantity = 2, UnitPrice = 7000.00m, SaleDate = new DateTime(2022, 12, 10) },
        new Sale { Id = 34, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 15, CustomerId = 8, Quantity = 1, UnitPrice = 7000.00m, SaleDate = new DateTime(2024, 1, 5) },

        new Sale { Id = 35, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 16, CustomerId = 9, Quantity = 1, UnitPrice = 5500.00m, SaleDate = new DateTime(2023, 4, 11) },
        new Sale { Id = 36, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 16, CustomerId = 10, Quantity = 3, UnitPrice = 5500.00m, SaleDate = new DateTime(2024, 3, 8) },

        new Sale { Id = 37, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 17, CustomerId = 11, Quantity = 1, UnitPrice = 15000.00m, SaleDate = new DateTime(2023, 8, 25) },
        new Sale { Id = 38, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 17, CustomerId = 12, Quantity = 2, UnitPrice = 15000.00m, SaleDate = new DateTime(2024, 5, 2) },

        new Sale { Id = 39, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 18, CustomerId = 1, Quantity = 1, UnitPrice = 2500.00m, SaleDate = new DateTime(2023, 2, 18) },
        new Sale { Id = 40, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 18, CustomerId = 2, Quantity = 2, UnitPrice = 2500.00m, SaleDate = new DateTime(2023, 7, 13) },

        new Sale { Id = 41, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 19, CustomerId = 3, Quantity = 2, UnitPrice = 8500.00m, SaleDate = new DateTime(2023, 10, 15) },
        new Sale { Id = 42, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 19, CustomerId = 4, Quantity = 1, UnitPrice = 8500.00m, SaleDate = new DateTime(2024, 6, 22) },

        new Sale { Id = 43, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 20, CustomerId = 5, Quantity = 2, UnitPrice = 12000.00m, SaleDate = new DateTime(2023, 9, 25) },
        new Sale { Id = 44, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 20, CustomerId = 6, Quantity = 1, UnitPrice = 12000.00m, SaleDate = new DateTime(2024, 5, 18) },

        new Sale { Id = 45, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 21, CustomerId = 7, Quantity = 1, UnitPrice = 7000.00m, SaleDate = new DateTime(2023, 8, 10) },
        new Sale { Id = 46, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 21, CustomerId = 8, Quantity = 2, UnitPrice = 7000.00m, SaleDate = new DateTime(2024, 2, 12) },

        new Sale { Id = 47, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 22, CustomerId = 9, Quantity = 3, UnitPrice = 3200.00m, SaleDate = new DateTime(2023, 5, 6) },
        new Sale { Id = 48, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 22, CustomerId = 10, Quantity = 1, UnitPrice = 3200.00m, SaleDate = new DateTime(2024, 4, 1) },

        new Sale { Id = 49, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 23, CustomerId = 11, Quantity = 2, UnitPrice = 2000.00m, SaleDate = new DateTime(2023, 12, 5) },
        new Sale { Id = 50, IsDeleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ProductId = 23, CustomerId = 12, Quantity = 3, UnitPrice = 2000.00m, SaleDate = new DateTime(2024, 3, 7) }
    };
}
