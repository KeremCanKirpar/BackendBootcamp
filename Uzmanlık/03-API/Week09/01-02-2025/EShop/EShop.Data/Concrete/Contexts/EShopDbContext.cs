using System;
using EShop.Entity.Concrete;
using EShop.Shared.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Concrete.Contexts;

public class EShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public EShopDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductCategory>? ProductCategories { get; set; }
    public DbSet<Cart>? Carts { get; set; }
    public DbSet<CartItem>? CartItems { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(x => new { x.ProductId, x.CategoryId });
            //Product=>ProductCategory 1e Çok İlişki
            entity
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
            //Category=>ProductCategory 1e Çok İlişki
            entity
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            entity.HasData(
                new ProductCategory(1, 1),
                new ProductCategory(2, 1),
                new ProductCategory(3, 2),
                new ProductCategory(4, 4),
                new ProductCategory(5, 10),
                new ProductCategory(6, 6),
                new ProductCategory(7, 7),
                new ProductCategory(8, 8),
                new ProductCategory(9, 9),
                new ProductCategory(10, 5),
                new ProductCategory(11, 1),
                new ProductCategory(12, 1),
                new ProductCategory(13, 1),
                new ProductCategory(14, 10),
                new ProductCategory(15, 10),
                new ProductCategory(16, 1),
                new ProductCategory(17, 1),
                new ProductCategory(18, 4),
                new ProductCategory(19, 3),
                new ProductCategory(20, 10),
                new ProductCategory(21, 4),
                new ProductCategory(22, 2),
                new ProductCategory(23, 2),
                new ProductCategory(24, 10),
                new ProductCategory(25, 10),
                new ProductCategory(26, 10),
                new ProductCategory(27, 7),
                new ProductCategory(28, 7),
                new ProductCategory(29, 1),
                new ProductCategory(30, 1),
                new ProductCategory(31, 1),
                new ProductCategory(32, 1),
                new ProductCategory(33, 1),
                new ProductCategory(34, 1),
                new ProductCategory(35, 1),
                new ProductCategory(36, 1),
                new ProductCategory(37, 1),
                new ProductCategory(38, 1),
                new ProductCategory(39, 1),
                new ProductCategory(40, 1),
                new ProductCategory(41, 1),
                new ProductCategory(42, 4),
                new ProductCategory(43, 4),
                new ProductCategory(44, 4),
                new ProductCategory(45, 4),
                new ProductCategory(46, 7),
                new ProductCategory(47, 7),
                new ProductCategory(48, 10),
                new ProductCategory(49, 10),
                new ProductCategory(50, 10),
                new ProductCategory(51, 10),
                new ProductCategory(52, 10),
                new ProductCategory(53, 10),
                new ProductCategory(54, 10),
                new ProductCategory(55, 10),
                new ProductCategory(56, 10),
                new ProductCategory(57, 10),
                new ProductCategory(58, 10),
                new ProductCategory(59, 10),
                new ProductCategory(60, 10),
                new ProductCategory(61, 10),
                new ProductCategory(62, 10),
                new ProductCategory(63, 10),
                new ProductCategory(64, 10),
                new ProductCategory(65, 4),
                new ProductCategory(66, 4),
                new ProductCategory(67, 4),
                new ProductCategory(68, 4),
                new ProductCategory(69, 4),
                new ProductCategory(70, 4),
                new ProductCategory(71, 4),
                new ProductCategory(72, 4),
                new ProductCategory(73, 4),
                new ProductCategory(74, 4),
                new ProductCategory(75, 4),
                new ProductCategory(76, 4),
                new ProductCategory(77, 4),
                new ProductCategory(78, 4),
                new ProductCategory(79, 4),
                new ProductCategory(80, 4),
                new ProductCategory(81, 4),
                new ProductCategory(82, 4),
                new ProductCategory(83, 4),
                new ProductCategory(84, 4),
                new ProductCategory(85, 4),
                new ProductCategory(86, 4),
                new ProductCategory(87, 4),
                new ProductCategory(88, 4),
                new ProductCategory(89, 4),
                new ProductCategory(90, 4),
                new ProductCategory(91, 4),
                new ProductCategory(92, 4),
                new ProductCategory(93, 4),
                new ProductCategory(94, 4),
                new ProductCategory(95, 4),
                new ProductCategory(96, 4),
                new ProductCategory(97, 4),
                new ProductCategory(98, 4),
                new ProductCategory(99, 4),
                new ProductCategory(100, 4)
            );
        });

        builder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Name).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Description).HasMaxLength(500);
            entity.HasData(
                new Category("Elektronik", "/images/categories/elektronik.jpg")
                {
                    Id = 1,
                    Description = "Bilgisayarlar, telefonlar ve diğer elektronik ürünler.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Moda", "/images/categories/moda.jpg")
                {
                    Id = 2,
                    Description = "Kadın, erkek ve çocuk giyim ürünleri.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Ev & Yaşam", "/images/categories/ev-ve-yasam.jpg")
                {
                    Id = 3,
                    Description = "Ev dekorasyonu ve yaşam alanları için ürünler.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Spor & Outdoor", "/images/categories/spor-outdoor.jpg")
                {
                    Id = 4,
                    Description = "Outdoor ve spor yaparken kullanabileceğiniz ekipmanlar.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Otomotiv", "/images/categories/otomotiv.jpg")
                {
                    Id = 5,
                    Description = "Araba aksesuarları ve yedek parçalar.",
                    IsActive = false,
                    IsDeleted = false
                },
                new Category("Kitaplar", "/images/categories/kitaplar.jpg")
                {
                    Id = 6,
                    Description = "Farklı kategorilerde kitaplar.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Sağlık & Kozmetik", "/images/categories/saglik-kozmetik.jpg")
                {
                    Id = 7,
                    Description = "Sağlık ve güzellik ürünleri.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Gıda", "/images/categories/gida.jpg")
                {
                    Id = 8,
                    Description = "Yiyecek ve içecek ürünleri.",
                    IsActive = true,
                    IsDeleted = false
                },
                new Category("Hobi & Eğlence", "/images/categories/hobi-eglence.jpg")
                {
                    Id = 9,
                    Description = "Hobi, oyun ve eğlence ürünleri.",
                    IsActive = false,
                    IsDeleted = false
                },
                new Category("Beyaz Eşya", "/images/categories/beyaz-esya.jpg")
                {
                    Id = 10,
                    Description = "Buzdolapları, çamaşır makineleri ve diğer büyük ev aletleri.",
                    IsActive = true,
                    IsDeleted = true
                }
            );
        });

        builder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.ImageUrl).IsRequired();
            entity.HasData(
                new Product("Laptop", "16GB RAM, 512GB SSD", 1500.00m, "/images/products/laptop.jpg") { Id = 1, IsActive = true, IsDeleted = false },
                new Product("Smartphone", "128GB Storage, 6GB RAM", 800.00m, "/images/products/smartphone.jpg") { Id = 2, IsActive = true, IsDeleted = false },
                new Product("T-Shirt", "100% Cotton, Size M", 20.00m, "/images/products/tshirt.jpg") { Id = 3, IsActive = true, IsDeleted = false },
                new Product("Running Shoes", "Size 42, Black", 60.00m, "/images/products/running_shoes.jpg") { Id = 4, IsActive = true, IsDeleted = false },
                new Product("Refrigerator", "300L, Energy Class A++", 500.00m, "/images/products/refrigerator.jpg") { Id = 5, IsActive = true, IsDeleted = false },
                new Product("Novel Book", "Fiction, 300 pages", 15.00m, "/images/products/novel_book.jpg") { Id = 6, IsActive = true, IsDeleted = false },
                new Product("Face Cream", "50ml, Anti-aging", 25.00m, "/images/products/face_cream.jpg") { Id = 7, IsActive = true, IsDeleted = false },
                new Product("Organic Apple", "1kg, Fresh", 3.00m, "/images/products/organic_apple.jpg") { Id = 8, IsActive = true, IsDeleted = false },
                new Product("Guitar", "Acoustic, 6 strings", 120.00m, "/images/products/guitar.jpg") { Id = 9, IsActive = true, IsDeleted = false },
                new Product("Car Tire", "195/65 R15", 70.00m, "/images/products/car_tire.jpg") { Id = 10, IsActive = true, IsDeleted = false },
                new Product("Smartwatch", "Heart Rate Monitor, GPS", 200.00m, "/images/products/smartwatch.jpg") { Id = 11, IsActive = true, IsDeleted = false },
                new Product("Tablet", "10.1 inch, 64GB", 300.00m, "/images/products/tablet.jpg") { Id = 12, IsActive = true, IsDeleted = false },
                new Product("Headphones", "Noise Cancelling", 150.00m, "/images/products/headphones.jpg") { Id = 13, IsActive = true, IsDeleted = false },
                new Product("Blender", "500W, 1.5L", 50.00m, "/images/products/blender.jpg") { Id = 14, IsActive = true, IsDeleted = false },
                new Product("Microwave", "800W, 20L", 100.00m, "/images/products/microwave.jpg") { Id = 15, IsActive = true, IsDeleted = false },
                new Product("Camera", "24MP, 4K Video", 700.00m, "/images/products/camera.jpg") { Id = 16, IsActive = true, IsDeleted = false },
                new Product("Watch", "Analog, Water Resistant", 80.00m, "/images/products/watch.jpg") { Id = 17, IsActive = true, IsDeleted = false },
                new Product("Backpack", "30L, Waterproof", 40.00m, "/images/products/backpack.jpg") { Id = 18, IsActive = true, IsDeleted = false },
                new Product("Desk Lamp", "LED, Adjustable", 25.00m, "/images/products/desk_lamp.jpg") { Id = 19, IsActive = true, IsDeleted = false },
                new Product("Electric Kettle", "1.7L, 2200W", 30.00m, "/images/products/electric_kettle.jpg") { Id = 20, IsActive = true, IsDeleted = false },
                new Product("Gaming Chair", "Ergonomic, Adjustable", 200.00m, "/images/products/gaming_chair.jpg") { Id = 21, IsActive = true, IsDeleted = false },
                new Product("Sunglasses", "UV Protection", 50.00m, "/images/products/sunglasses.jpg") { Id = 22, IsActive = true, IsDeleted = false },
                new Product("Sneakers", "Size 43, White", 70.00m, "/images/products/sneakers.jpg") { Id = 23, IsActive = true, IsDeleted = false },
                new Product("Coffee Maker", "12 Cups, Programmable", 80.00m, "/images/products/coffee_maker.jpg") { Id = 24, IsActive = true, IsDeleted = false },
                new Product("Vacuum Cleaner", "Bagless, 2000W", 150.00m, "/images/products/vacuum_cleaner.jpg") { Id = 25, IsActive = true, IsDeleted = false },
                new Product("Air Conditioner", "12000 BTU, Inverter", 600.00m, "/images/products/air_conditioner.jpg") { Id = 26, IsActive = true, IsDeleted = false },
                new Product("Electric Toothbrush", "Rechargeable, 3 Modes", 40.00m, "/images/products/electric_toothbrush.jpg") { Id = 27, IsActive = true, IsDeleted = false },
                new Product("Hair Dryer", "2000W, Ionic", 30.00m, "/images/products/hair_dryer.jpg") { Id = 28, IsActive = true, IsDeleted = false },
                new Product("Smart TV", "55 inch, 4K UHD", 700.00m, "/images/products/smart_tv.jpg") { Id = 29, IsActive = true, IsDeleted = false },
                new Product("Gaming Console", "1TB, 4K HDR", 500.00m, "/images/products/gaming_console.jpg") { Id = 30, IsActive = true, IsDeleted = false },
                new Product("Wireless Mouse", "Ergonomic, 1600 DPI", 25.00m, "/images/products/wireless_mouse.jpg") { Id = 31, IsActive = true, IsDeleted = false },
                new Product("Keyboard", "Mechanical, RGB", 80.00m, "/images/products/keyboard.jpg") { Id = 32, IsActive = true, IsDeleted = false },
                new Product("Monitor", "27 inch, 144Hz", 300.00m, "/images/products/monitor.jpg") { Id = 33, IsActive = true, IsDeleted = false },
                new Product("Printer", "All-in-One, Wireless", 150.00m, "/images/products/printer.jpg") { Id = 34, IsActive = true, IsDeleted = false },
                new Product("Router", "Dual Band, Gigabit", 100.00m, "/images/products/router.jpg") { Id = 35, IsActive = true, IsDeleted = false },
                new Product("External Hard Drive", "2TB, USB 3.0", 80.00m, "/images/products/external_hard_drive.jpg") { Id = 36, IsActive = true, IsDeleted = false },
                new Product("Flash Drive", "64GB, USB 3.0", 20.00m, "/images/products/flash_drive.jpg") { Id = 37, IsActive = true, IsDeleted = false },
                new Product("Power Bank", "10000mAh, Fast Charging", 30.00m, "/images/products/power_bank.jpg") { Id = 38, IsActive = true, IsDeleted = false },
                new Product("Wireless Charger", "10W, Fast Charging", 25.00m, "/images/products/wireless_charger.jpg") { Id = 39, IsActive = true, IsDeleted = false },
                new Product("Smart Light Bulb", "RGB, WiFi", 20.00m, "/images/products/smart_light_bulb.jpg") { Id = 40, IsActive = true, IsDeleted = false },
                new Product("Security Camera", "1080p, Night Vision", 60.00m, "/images/products/security_camera.jpg") { Id = 41, IsActive = true, IsDeleted = false },
                new Product("Fitness Tracker", "Heart Rate Monitor, GPS", 50.00m, "/images/products/fitness_tracker.jpg") { Id = 42, IsActive = true, IsDeleted = false },
                new Product("Electric Scooter", "25km/h, 30km Range", 400.00m, "/images/products/electric_scooter.jpg") { Id = 43, IsActive = true, IsDeleted = false },
                new Product("Drone", "4K Camera, GPS", 500.00m, "/images/products/drone.jpg") { Id = 44, IsActive = true, IsDeleted = false },
                new Product("Action Camera", "4K, Waterproof", 150.00m, "/images/products/action_camera.jpg") { Id = 45, IsActive = true, IsDeleted = false },
                new Product("Electric Shaver", "Rechargeable, Wet & Dry", 60.00m, "/images/products/electric_shaver.jpg") { Id = 46, IsActive = true, IsDeleted = false },
                new Product("Hair Straightener", "Ceramic, 200°C", 40.00m, "/images/products/hair_straightener.jpg") { Id = 47, IsActive = true, IsDeleted = false },
                new Product("Electric Grill", "2000W, Non-Stick", 70.00m, "/images/products/electric_grill.jpg") { Id = 48, IsActive = true, IsDeleted = false },
                new Product("Rice Cooker", "1.8L, Non-Stick", 50.00m, "/images/products/rice_cooker.jpg") { Id = 49, IsActive = true, IsDeleted = false },
                new Product("Air Fryer", "3.5L, Digital", 100.00m, "/images/products/air_fryer.jpg") { Id = 50, IsActive = true, IsDeleted = false },
                new Product("Electric Blanket", "150x200cm, 3 Heat Settings", 40.00m, "/images/products/electric_blanket.jpg") { Id = 51, IsActive = true, IsDeleted = false },
                new Product("Water Filter", "10L, 5-Stage", 30.00m, "/images/products/water_filter.jpg") { Id = 52, IsActive = true, IsDeleted = false },
                new Product("Electric Heater", "2000W, Adjustable Thermostat", 50.00m, "/images/products/electric_heater.jpg") { Id = 53, IsActive = true, IsDeleted = false },
                new Product("Dehumidifier", "20L, Digital", 150.00m, "/images/products/dehumidifier.jpg") { Id = 54, IsActive = true, IsDeleted = false },
                new Product("Humidifier", "5L, Ultrasonic", 40.00m, "/images/products/humidifier.jpg") { Id = 55, IsActive = true, IsDeleted = false },
                new Product("Electric Fan", "16 inch, Oscillating", 30.00m, "/images/products/electric_fan.jpg") { Id = 56, IsActive = true, IsDeleted = false },
                new Product("Electric Iron", "2400W, Steam", 40.00m, "/images/products/electric_iron.jpg") { Id = 57, IsActive = true, IsDeleted = false },
                new Product("Sewing Machine", "Portable, 12 Stitches", 100.00m, "/images/products/sewing_machine.jpg") { Id = 58, IsActive = true, IsDeleted = false },
                new Product("Electric Screwdriver", "Rechargeable, 3.6V", 30.00m, "/images/products/electric_screwdriver.jpg") { Id = 59, IsActive = true, IsDeleted = false },
                new Product("Cordless Drill", "18V, 2 Batteries", 80.00m, "/images/products/cordless_drill.jpg") { Id = 60, IsActive = true, IsDeleted = false },
                new Product("Tool Set", "100 Pieces, Chrome Vanadium", 50.00m, "/images/products/tool_set.jpg") { Id = 61, IsActive = true, IsDeleted = false },
                new Product("Lawn Mower", "Electric, 1600W", 150.00m, "/images/products/lawn_mower.jpg") { Id = 62, IsActive = true, IsDeleted = false },
                new Product("Garden Hose", "30m, Expandable", 40.00m, "/images/products/garden_hose.jpg") { Id = 63, IsActive = true, IsDeleted = false },
                new Product("BBQ Grill", "Charcoal, Portable", 70.00m, "/images/products/bbq_grill.jpg") { Id = 64, IsActive = true, IsDeleted = false },
                new Product("Tent", "4 Person, Waterproof", 100.00m, "/images/products/tent.jpg") { Id = 65, IsActive = true, IsDeleted = false },
                new Product("Sleeping Bag", "3 Season, Mummy", 50.00m, "/images/products/sleeping_bag.jpg") { Id = 66, IsActive = true, IsDeleted = false },
                new Product("Camping Stove", "Portable, Gas", 30.00m, "/images/products/camping_stove.jpg") { Id = 67, IsActive = true, IsDeleted = false },
                new Product("Hiking Backpack", "50L, Waterproof", 60.00m, "/images/products/hiking_backpack.jpg") { Id = 68, IsActive = true, IsDeleted = false },
                new Product("Binoculars", "10x50, Waterproof", 80.00m, "/images/products/binoculars.jpg") { Id = 69, IsActive = true, IsDeleted = false },
                new Product("Fishing Rod", "Carbon Fiber, 2.1m", 40.00m, "/images/products/fishing_rod.jpg") { Id = 70, IsActive = true, IsDeleted = false },
                new Product("Yoga Mat", "6mm, Non-Slip", 20.00m, "/images/products/yoga_mat.jpg") { Id = 71, IsActive = true, IsDeleted = false },
                new Product("Dumbbell Set", "20kg, Adjustable", 50.00m, "/images/products/dumbbell_set.jpg") { Id = 72, IsActive = true, IsDeleted = false },
                new Product("Treadmill", "Folding, 2.5HP", 500.00m, "/images/products/treadmill.jpg") { Id = 73, IsActive = true, IsDeleted = false },
                new Product("Exercise Bike", "Magnetic, 8 Resistance Levels", 200.00m, "/images/products/exercise_bike.jpg") { Id = 74, IsActive = true, IsDeleted = false },
                new Product("Rowing Machine", "Magnetic, Foldable", 300.00m, "/images/products/rowing_machine.jpg") { Id = 75, IsActive = true, IsDeleted = false },
                new Product("Elliptical Trainer", "Magnetic, 8 Resistance Levels", 400.00m, "/images/products/elliptical_trainer.jpg") { Id = 76, IsActive = true, IsDeleted = false },
                new Product("Weight Bench", "Adjustable, Foldable", 100.00m, "/images/products/weight_bench.jpg") { Id = 77, IsActive = true, IsDeleted = false },
                new Product("Pull-Up Bar", "Doorway, Adjustable", 30.00m, "/images/products/pull_up_bar.jpg") { Id = 78, IsActive = true, IsDeleted = false },
                new Product("Resistance Bands", "Set of 5, Different Resistance Levels", 20.00m, "/images/products/resistance_bands.jpg") { Id = 79, IsActive = true, IsDeleted = false },
                new Product("Jump Rope", "Adjustable, Speed", 10.00m, "/images/products/jump_rope.jpg") { Id = 80, IsActive = true, IsDeleted = false },
                new Product("Basketball", "Size 7, Indoor/Outdoor", 25.00m, "/images/products/basketball.jpg") { Id = 81, IsActive = true, IsDeleted = false },
                new Product("Soccer Ball", "Size 5, Synthetic Leather", 20.00m, "/images/products/soccer_ball.jpg") { Id = 82, IsActive = true, IsDeleted = false },
                new Product("Tennis Racket", "Graphite, Lightweight", 50.00m, "/images/products/tennis_racket.jpg") { Id = 83, IsActive = true, IsDeleted = false },
                new Product("Badminton Set", "2 Rackets, 3 Shuttlecocks", 30.00m, "/images/products/badminton_set.jpg") { Id = 84, IsActive = true, IsDeleted = false },
                new Product("Golf Clubs", "Set of 12, Graphite", 500.00m, "/images/products/golf_clubs.jpg") { Id = 85, IsActive = true, IsDeleted = false },
                new Product("Skateboard", "31 inch, Maple", 40.00m, "/images/products/skateboard.jpg") { Id = 86, IsActive = true, IsDeleted = false },
                new Product("Roller Skates", "Adjustable, Size 38-42", 60.00m, "/images/products/roller_skates.jpg") { Id = 87, IsActive = true, IsDeleted = false },
                new Product("Helmet", "Bike, Size M", 30.00m, "/images/products/helmet.jpg") { Id = 88, IsActive = true, IsDeleted = false },
                new Product("Knee Pads", "Set of 2, Adjustable", 20.00m, "/images/products/knee_pads.jpg") { Id = 89, IsActive = true, IsDeleted = false },
                new Product("Elbow Pads", "Set of 2, Adjustable", 20.00m, "/images/products/elbow_pads.jpg") { Id = 90, IsActive = true, IsDeleted = false },
                new Product("Wrist Guards", "Set of 2, Adjustable", 20.00m, "/images/products/wrist_guards.jpg") { Id = 91, IsActive = true, IsDeleted = false },
                new Product("Bike Lock", "Combination, Heavy Duty", 25.00m, "/images/products/bike_lock.jpg") { Id = 92, IsActive = true, IsDeleted = false },
                new Product("Bike Pump", "Portable, High Pressure", 20.00m, "/images/products/bike_pump.jpg") { Id = 93, IsActive = true, IsDeleted = false },
                new Product("Bike Light", "Front and Rear, USB Rechargeable", 30.00m, "/images/products/bike_light.jpg") { Id = 94, IsActive = true, IsDeleted = false },
                new Product("Bike Bell", "Loud, Easy to Install", 10.00m, "/images/products/bike_bell.jpg") { Id = 95, IsActive = true, IsDeleted = false },
                new Product("Bike Basket", "Front, Wicker", 40.00m, "/images/products/bike_basket.jpg") { Id = 96, IsActive = true, IsDeleted = false },
                new Product("Bike Rack", "Rear, Adjustable", 50.00m, "/images/products/bike_rack.jpg") { Id = 97, IsActive = true, IsDeleted = false },
                new Product("Bike Seat", "Comfort, Gel", 30.00m, "/images/products/bike_seat.jpg") { Id = 98, IsActive = true, IsDeleted = false },
                new Product("Bike Gloves", "Padded, Size L", 20.00m, "/images/products/bike_gloves.jpg") { Id = 99, IsActive = true, IsDeleted = false },
                new Product("Bike Shorts", "Padded, Size M", 40.00m, "/images/products/bike_shorts.jpg") { Id = 100, IsActive = true, IsDeleted = false }
            );
        });

        builder.Entity<OrderItem>().Property(x => x.UnitPrice).HasColumnType("decimal(10,2)");

        #region Users
        var hasher = new PasswordHasher<ApplicationUser>();
        var adminUser = new ApplicationUser("Ali", "Cabbar", new DateTime(1995, 1, 1), Gender.Male)
        {
            Id = "d4757375-a497-496b-85dc-a510027bd9b1",
            UserName = "adminuser@gmail.com",
            NormalizedUserName = "ADMINUSER@GMAIL.COM",
            Email = "adminuser@gmail.com",
            NormalizedEmail = "ADMINUSER@GMAIL.COM",
            EmailConfirmed = true,
            Address = "Ataşehir",
            City = "İstanbul"
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Qwe123.,");


        var normalUser = new ApplicationUser("Esin", "Çelik", new DateTime(1995, 1, 1), Gender.Female)
        {
            Id = "d2fe392f-4f60-4963-ba3a-ea52b71fb53e",
            UserName = "normaluser@gmail.com",
            NormalizedUserName = "NORMALUSER@GMAIL.COM",
            Email = "normaluser@gmail.com",
            NormalizedEmail = "NORMALUSER@GMAIL.COM",
            EmailConfirmed = true,
            Address = "Kadıköy",
            City = "İstanbul"
        };
        normalUser.PasswordHash = hasher.HashPassword(normalUser, "Qwe123.,");

        
        builder.Entity<ApplicationUser>().HasData(adminUser, normalUser);
        #endregion

        #region Roles
        var adminRole = new ApplicationRole("Yönetici rolü")
        {
            Id = "0517f36e-53b1-4a0d-b6b3-599afdd926cf",
            Name = "Admin",
            NormalizedName = "ADMIN"
        };
        var userRole = new ApplicationRole("Normal kullanıcı rolü")
        {
            Id = "c44cd475-5365-409f-845c-6ea238190b2b",
            Name = "User",
            NormalizedName = "USER"
        };
        builder.Entity<ApplicationRole>().HasData(adminRole, userRole);
        #endregion

        #region UserRoles
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            },
            new IdentityUserRole<string>
            {
                RoleId = userRole.Id,
                UserId = normalUser.Id
            }
        );
        #endregion

        #region Carts
        builder.Entity<Cart>().HasData(
            new Cart(normalUser.Id) { Id = 1 },
            new Cart(adminUser.Id) { Id = 2 }
        );
        #endregion

        base.OnModelCreating(builder);
    }
}
