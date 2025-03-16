using EShop.Entity.Concrete;
using EShop.Shared.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Concrete.Contexts
{
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
        public DbSet<ApiClient> ApiClients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Categories

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(200);
                entity.Property(c => c.Description).HasMaxLength(500);

                entity.HasData(
                    new Category("Elektronik", "/images/categories/elektronik.png")
                    {
                        Id = 1,
                        Description = "Bilgisayarlar, akıllı telefonlar, tabletler, televizyonlar ve diğer tüm elektronik cihazlar bu kategoride bulunabilir. Teknoloji tutkunları için en yeni ve popüler ürünler burada!",
                        IsActive = true,
                        IsDeleted = false,
                        IsMenuItem = true,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Moda", "/images/categories/moda.png")
                    {
                        Id = 2,
                        Description = "Kadın, erkek ve çocuk giyim ürünleri, ayakkabılar, çantalar ve aksesuarlar bu kategoride. Trendleri yakalayın ve tarzınızı yansıtın!",
                        IsActive = true,
                        IsDeleted = false,
                        IsMenuItem = true,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Ev & Yaşam", "/images/categories/ev-yasam.png")
                    {
                        Id = 3,
                        Description = "Ev dekorasyonu, mobilyalar, mutfak gereçleri, bahçe ürünleri ve daha fazlası bu kategoride. Evinizi güzelleştirmek için ihtiyacınız olan her şey burada!",
                        IsActive = true,
                        IsDeleted = false,
                        IsMenuItem = true,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Spor & Outdoor", "/images/categories/spor-outdoor.png")
                    {
                        Id = 4,
                        Description = "Spor ekipmanları, outdoor giyim, kamp malzemeleri, bisikletler ve fitness ürünleri bu kategoride. Aktif bir yaşam için ihtiyacınız olan her şey burada!",
                        IsActive = true,
                        IsDeleted = false,
                        IsMenuItem = true,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Kitap & Dergi", "/images/categories/kitap-dergi.png")
                    {
                        Id = 5,
                        Description = "Romanlar, kişisel gelişim kitapları, akademik yayınlar, dergiler ve daha fazlası bu kategoride. Okuma tutkunları için geniş bir seçki!",
                        IsActive = true,
                        IsDeleted = false,
                        IsMenuItem = true,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Oyuncak & Hobi", "/images/categories/oyuncak-hobi.png")
                    {
                        Id = 6,
                        Description = "Çocuk oyuncakları, yapbozlar, model kitler, hobi malzemeleri ve koleksiyon ürünleri bu kategoride. Hem çocuklar hem de yetişkinler için eğlenceli seçenekler!",
                        IsActive = true,
                        IsDeleted = false,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Kozmetik & Kişisel Bakım", "/images/categories/kozmetik-bakim.png")
                    {
                        Id = 7,
                        Description = "Cilt bakım ürünleri, makyaj malzemeleri, parfümler, saç bakım ürünleri ve daha fazlası bu kategoride. Kendinizi şımartın ve bakım rutininizi oluşturun!",
                        IsActive = true,
                        IsDeleted = false,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Seyahat & Valiz", "/images/categories/seyahat-valiz.png")
                    {
                        Id = 8,
                        Description = "Valizler, sırt çantaları, seyahat aksesuarları ve seyahat planlaması için gerekli ürünler bu kategoride. Yeni yerler keşfetmeye hazır olun!",
                        IsActive = false, // Bu kategori pasif
                        IsDeleted = false,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Bebek & Çocuk", "/images/categories/bebek-cocuk.png")
                    {
                        Id = 9,
                        Description = "Bebek giysileri, bebek bakım ürünleri, oyuncaklar, çocuk odası dekorasyonu ve daha fazlası bu kategoride. Bebekler ve çocuklar için en kaliteli ürünler!",
                        IsActive = true,
                        IsDeleted = false,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    },
                    new Category("Otomotiv", "/images/categories/otomotiv.png")
                    {
                        Id = 10,
                        Description = "Araç bakım ürünleri, yedek parçalar, araç içi aksesuarlar ve otomotiv ekipmanları bu kategoride. Araç tutkunları için ihtiyaç duyulan her şey!",
                        IsActive = false, // Bu kategori pasif
                        IsDeleted = false,
                        UpdatedAt = DateTimeOffset.UtcNow,
                        DeletedAt = DateTimeOffset.UtcNow,
                    }
                );

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            #endregion

            #region Products
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(p => p.ImageUrl).IsRequired();

                entity.HasData(
                    // Elektronik Kategorisi (Id: 1)
                    new Product("Dizüstü Bilgisayar", "16GB RAM, 512GB SSD, Intel i7 İşlemci", 1500.00m, "/images/products/laptop.png") { Id = 1, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Elektronik
                    new Product("Akıllı Telefon", "128GB Depolama, 6GB RAM, 5G Desteği", 800.00m, "/images/products/smartphone.png") { Id = 2, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Elektronik
                    new Product("Tablet", "10.5 inç Ekran, 256GB Depolama, Kalem Desteği", 600.00m, "/images/products/tablet.png") { Id = 3, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Elektronik
                    new Product("Akıllı Saat", "GPS, Kalp Atışı Ölçer, Suya Dayanıklı", 250.00m, "/images/products/smartwatch.png") { Id = 4, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Elektronik, Spor & Outdoor
                    new Product("Kablosuz Kulaklık", "Gürültü Önleyici, 20 Saat Pil Ömrü", 150.00m, "/images/products/earbuds.png") { Id = 5, IsActive = false, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Elektronik (Pasif)

                    // Moda Kategorisi (Id: 2)
                    new Product("Erkek Ceket", "Slim Fit, Kumaş Ceket", 120.00m, "/images/products/men-jacket.png") { Id = 6, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Moda
                    new Product("Kadın Elbise", "Yazlık Desenli, Pamuklu", 80.00m, "/images/products/women-dress.png") { Id = 7, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Moda
                    new Product("Spor Ayakkabı", "Hafif, Nefes Alabilir Taban", 90.00m, "/images/products/sneakers.png") { Id = 8, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Moda, Spor & Outdoor
                    new Product("Çanta", "Deri, Günlük Kullanım", 70.00m, "/images/products/bag.png") { Id = 9, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Moda, Ev & Yaşam
                    new Product("Güneş Gözlüğü", "UV Koruma, Polarize Cam", 50.00m, "/images/products/sunglasses.png") { Id = 10, IsActive = false, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Moda (Pasif)

                    // Ev & Yaşam Kategorisi (Id: 3)
                    new Product("Yemek Takımı", "12 Parça, Porselen", 100.00m, "/images/products/dinner-set.png") { Id = 11, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Ev & Yaşam
                    new Product("Kanepe", "3 Kişilik, Kumaş Kaplama", 500.00m, "/images/products/sofa.png") { Id = 12, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Ev & Yaşam
                    new Product("Yatak Örtüsü", "Pamuklu, 200x220 cm", 60.00m, "/images/products/bed-sheet.png") { Id = 13, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Ev & Yaşam
                    new Product("Masa Lambası", "LED, Ayarlanabilir Işık", 40.00m, "/images/products/lamp.png") { Id = 14, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Ev & Yaşam
                    new Product("Süpürge", "Elektrikli, HEPA Filtre", 120.00m, "/images/products/vacuum.png") { Id = 15, IsActive = false, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Ev & Yaşam (Pasif)

                    // Spor & Outdoor Kategorisi (Id: 4)
                    new Product("Spor Çantası", "30 Litre, Çok Bölmeli", 45.00m, "/images/products/gym-bag.png") { Id = 16, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Spor & Outdoor, Moda
                    new Product("Tent", "4 Kişilik, Su Geçirmez", 200.00m, "/images/products/tent.png") { Id = 17, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Spor & Outdoor
                    new Product("Bisiklet", "21 Vites, Dağ Bisikleti", 350.00m, "/images/products/bike.png") { Id = 18, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Spor & Outdoor
                    new Product("Koşu Bandı", "Katlanabilir, 12 Program", 600.00m, "/images/products/treadmill.png") { Id = 19, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Spor & Outdoor
                    new Product("Spor Eldiveni", "Antrenman için, Ergonomik", 25.00m, "/images/products/gloves.png") { Id = 20, IsActive = false, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Spor & Outdoor (Pasif)

                    // Kitap & Dergi Kategorisi (Id: 5)
                    new Product("Roman Kitabı", "En Çok Satanlar Listesinden", 20.00m, "/images/products/novel.png") { Id = 21, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kitap & Dergi
                    new Product("Kişisel Gelişim Kitabı", "Motivasyon ve Başarı İçin", 25.00m, "/images/products/self-help.png") { Id = 22, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kitap & Dergi
                    new Product("Bilim Kurgu Kitabı", "Klasik Bilim Kurgu Eseri", 30.00m, "/images/products/sci-fi.png") { Id = 23, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kitap & Dergi
                    new Product("Dergi", "Aylık Teknoloji Dergisi", 10.00m, "/images/products/magazine.png") { Id = 24, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kitap & Dergi
                    new Product("Çocuk Kitabı", "Resimli, Eğitici Hikayeler", 15.00m, "/images/products/kids-book.png") { Id = 25, IsActive = false, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kitap & Dergi, Bebek & Çocuk (Pasif)

                    // Oyuncak & Hobi Kategorisi (Id: 6)
                    new Product("Lego Seti", "1000 Parça, Yaratıcı Set", 80.00m, "/images/products/lego.png") { Id = 26, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Oyuncak & Hobi, Bebek & Çocuk
                    new Product("Model Uçak", "1:100 Ölçekli, Detaylı", 50.00m, "/images/products/model-plane.png") { Id = 27, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Oyuncak & Hobi
                    new Product("Puzzle", "1000 Parça, Manzara Temalı", 30.00m, "/images/products/puzzle.png") { Id = 28, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Oyuncak & Hobi
                    new Product("Boyama Kitabı", "Yetişkinler İçin Mandala", 20.00m, "/images/products/coloring-book.png") { Id = 29, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Oyuncak & Hobi
                    new Product("RC Araba", "Uzaktan Kumandalı, Hızlı", 70.00m, "/images/products/rc-car.png") { Id = 30, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Oyuncak & Hobi, Bebek & Çocuk

                    // Kozmetik & Kişisel Bakım Kategorisi (Id: 7)
                    new Product("Nemlendirici Krem", "Cilt Bariyerini Güçlendirir", 40.00m, "/images/products/moisturizer.png") { Id = 31, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kozmetik & Bakım
                    new Product("Ruj", "Uzun Süre Kalıcı, 12 Renk Seçeneği", 25.00m, "/images/products/lipstick.png") { Id = 32, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kozmetik & Bakım
                    new Product("Parfüm", "100 ml, Günlük Kullanım", 60.00m, "/images/products/perfume.png") { Id = 33, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kozmetik & Bakım
                    new Product("Şampuan", "Saç Dökülmesine Karşı Etkili", 15.00m, "/images/products/shampoo.png") { Id = 34, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kozmetik & Bakım
                    new Product("Tıraş Makinesi", "Islak & Kuru Kullanım", 90.00m, "/images/products/razor.png") { Id = 35, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Kozmetik & Bakım

                    // Bebek & Çocuk Kategorisi (Id: 9)
                    new Product("Bebek Bezi", "Hipoalerjenik, 120 Adet", 40.00m, "/images/products/diapers.png") { Id = 36, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Bebek & Çocuk
                    new Product("Bebek Arabası", "Katlanabilir, Hafif", 200.00m, "/images/products/stroller.png") { Id = 37, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Bebek & Çocuk
                    new Product("Oyuncak Bebek", "Gerçekçi Tasarım, 30 cm", 35.00m, "/images/products/doll.png") { Id = 38, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Bebek & Çocuk, Oyuncak & Hobi
                    new Product("Çocuk Bisikleti", "12 inç, Yardımcı Tekerlekli", 100.00m, "/images/products/kids-bike.png") { Id = 39, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, }, // Kategoriler: Bebek & Çocuk, Spor & Outdoor
                    new Product("Bebek Giysisi", "Pamuklu, Rahat", 20.00m, "/images/products/baby-clothes.png") { Id = 40, IsActive = true, IsDeleted = false, UpdatedAt = DateTimeOffset.UtcNow, DeletedAt = DateTimeOffset.UtcNow, } // Kategoriler: Bebek & Çocuk, Moda
                );

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            #endregion

            #region ProductCategories
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

                entity.HasQueryFilter(x => !x.Category!.IsDeleted && !x.Product!.IsDeleted);

                entity.HasData(
                    // Elektronik Kategorisi (Id:1) İlişkileri
                    new ProductCategory(1, 1),   // Dizüstü Bilgisayar
                    new ProductCategory(2, 1),   // Akıllı Telefon
                    new ProductCategory(3, 1),   // Tablet
                    new ProductCategory(4, 1),   // Akıllı Saat → Elektronik
                    new ProductCategory(5, 1),   // Kablosuz Kulaklık

                    // Moda Kategorisi (Id:2) İlişkileri
                    new ProductCategory(6, 2),   // Erkek Ceket
                    new ProductCategory(7, 2),   // Kadın Elbise
                    new ProductCategory(8, 2),   // Spor Ayakkabı → Moda
                    new ProductCategory(9, 2),   // Çanta → Moda
                    new ProductCategory(10, 2),  // Güneş Gözlüğü

                    // Ev & Yaşam Kategorisi (Id:3) İlişkileri
                    new ProductCategory(11, 3),  // Yemek Takımı
                    new ProductCategory(12, 3),  // Kanepe
                    new ProductCategory(13, 3),  // Yatak Örtüsü
                    new ProductCategory(14, 3),  // Masa Lambası
                    new ProductCategory(15, 3),  // Süpürge

                    // Spor & Outdoor Kategorisi (Id:4) İlişkileri
                    new ProductCategory(4, 4),   // Akıllı Saat → Spor & Outdoor
                    new ProductCategory(8, 4),   // Spor Ayakkabı → Spor & Outdoor
                    new ProductCategory(16, 4),  // Spor Çantası → Spor & Outdoor
                    new ProductCategory(17, 4),  // Tent
                    new ProductCategory(18, 4),  // Bisiklet
                    new ProductCategory(19, 4),  // Koşu Bandı
                    new ProductCategory(20, 4),  // Spor Eldiveni
                    new ProductCategory(39, 4),  // Çocuk Bisikleti → Spor & Outdoor

                    // Kitap & Dergi Kategorisi (Id:5) İlişkileri
                    new ProductCategory(21, 5),  // Roman Kitabı
                    new ProductCategory(22, 5),  // Kişisel Gelişim Kitabı
                    new ProductCategory(23, 5),  // Bilim Kurgu Kitabı
                    new ProductCategory(24, 5),  // Dergi
                    new ProductCategory(25, 5),  // Çocuk Kitabı → Kitap & Dergi

                    // Oyuncak & Hobi Kategorisi (Id:6) İlişkileri
                    new ProductCategory(26, 6),  // Lego Seti → Oyuncak & Hobi
                    new ProductCategory(27, 6),  // Model Uçak
                    new ProductCategory(28, 6),  // Puzzle
                    new ProductCategory(29, 6),  // Boyama Kitabı
                    new ProductCategory(30, 6),  // RC Araba → Oyuncak & Hobi
                    new ProductCategory(38, 6),  // Oyuncak Bebek → Oyuncak & Hobi

                    // Kozmetik & Bakım Kategorisi (Id:7) İlişkileri
                    new ProductCategory(31, 7),  // Nemlendirici Krem
                    new ProductCategory(32, 7),  // Ruj
                    new ProductCategory(33, 7),  // Parfüm
                    new ProductCategory(34, 7),  // Şampuan
                    new ProductCategory(35, 7),  // Tıraş Makinesi

                    // Bebek & Çocuk Kategorisi (Id:9) İlişkileri
                    new ProductCategory(25, 9),  // Çocuk Kitabı → Bebek & Çocuk
                    new ProductCategory(26, 9),  // Lego Seti → Bebek & Çocuk
                    new ProductCategory(30, 9),  // RC Araba → Bebek & Çocuk
                    new ProductCategory(36, 9),  // Bebek Bezi
                    new ProductCategory(37, 9),  // Bebek Arabası
                    new ProductCategory(38, 9),  // Oyuncak Bebek → Bebek & Çocuk
                    new ProductCategory(39, 9),  // Çocuk Bisikleti → Bebek & Çocuk
                    new ProductCategory(40, 9),  // Bebek Giysisi → Bebek & Çocuk

                    // Çapraz İlişkiler
                    new ProductCategory(9, 3),   // Çanta → Ev & Yaşam
                    new ProductCategory(16, 2),  // Spor Çantası → Moda
                    new ProductCategory(40, 2)   // Bebek Giysisi → Moda
                );
            });

            #endregion

            #region Users
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser("Ali", "Cabbar", new DateTime(1995, 1, 1), Gender.Male)
            {
                Id = "d4757375-a497-496b-85dc-a510027bd9b1",
                UserName = "testadmin",
                NormalizedUserName = "TESTADMIN",
                Email = "testadmin@gmail.com",
                NormalizedEmail = "TESTADMIN@GMAIL.COM",
                EmailConfirmed = true,
                Address = "Ataşehir",
                City = "İstanbul"
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Qwe123.,");


            var normalUser = new ApplicationUser("Esin", "Çelik", new DateTime(1995, 1, 1), Gender.Female)
            {
                Id = "d2fe392f-4f60-4963-ba3a-ea52b71fb53e",
                UserName = "testuser",
                NormalizedUserName = "TESTUSER",
                Email = "testuser@gmail.com",
                NormalizedEmail = "TESTUSER@GMAIL.COM",
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
            builder.Entity<Cart>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<CartItem>().HasQueryFilter(x => !x.IsDeleted);

            builder.Entity<Cart>().HasData(
                new Cart(normalUser.Id) { Id = 1 },
                new Cart(adminUser.Id) { Id = 2 }
            );
            #endregion

            #region Orders
            builder.Entity<OrderItem>().Property(x => x.UnitPrice).HasColumnType("decimal(10,2)");
            builder.Entity<OrderItem>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);

            var orders = new List<Order>();
            var orderItems = new List<OrderItem>();

            var userIds = new List<string>
            {
                adminUser.Id,
                normalUser.Id
            };

            Random random = new();
            DateTime startDate = new(2024, 9, 1);
            DateTime endDate = new(2025, 2, 20);
            int range = (endDate - startDate).Days;
            int orderItemId = 1;

            for (int i = 1; i <= 20; i++)
            {
                var order = new Order(
                    userIds[random.Next(0, userIds.Count)],
                    $"Address {i}",
                    $"City {i % 5 + 1}"
                )
                {
                    Id = i,
                    CreatedAt = startDate.AddDays(random.Next(range)),
                    OrderStatus = i <= 10 ? OrderStatus.Delivered : (OrderStatus)random.Next(0, 3)
                };

                orders.Add(order);

                int itemCount = random.Next(1, 6);

                for (int j = 1; j <= itemCount; j++)
                {
                    int productId = random.Next(1, 41);
                    decimal unitPrice = random.Next(10, 501);
                    int quantity = random.Next(1, 6);

                    var orderItem = new OrderItem(order.Id, productId, unitPrice, quantity)
                    {
                        Id = orderItemId,
                        OrderId = i // Order'ın foreign key'ini burada belirtiyoruz
                    };

                    orderItems.Add(orderItem);
                    orderItemId++;
                }
            }

            builder.Entity<Order>().HasData(orders);
            builder.Entity<OrderItem>().HasData(orderItems);
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
