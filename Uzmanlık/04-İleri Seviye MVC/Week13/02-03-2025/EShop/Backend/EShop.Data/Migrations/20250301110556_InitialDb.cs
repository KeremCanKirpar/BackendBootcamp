using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", null, "Yönetici rolü", "Admin", "ADMIN" },
                    { "c44cd475-5365-409f-845c-6ea238190b2b", null, "Normal kullanıcı rolü", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", 0, "Kadıköy", "İstanbul", "d78d095a-81a2-47a9-93e5-86fd34b568eb", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "normaluser@gmail.com", true, "Esin", 2, "Çelik", false, null, "NORMALUSER@GMAIL.COM", "NORMALUSER@GMAIL.COM", "AQAAAAIAAYagAAAAELeqHUk31T1/9fSZCIx6DjMmtV4x+DWW7vLM6OyhTpTtXs1GbyjwkF6Rv4Q8mEBXfg==", null, false, "f41a89e6-1c51-4eae-badc-fe7658f15ab8", false, "normaluser@gmail.com" },
                    { "d4757375-a497-496b-85dc-a510027bd9b1", 0, "Ataşehir", "İstanbul", "788a6915-877a-427f-b2c0-55da9afa78aa", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminuser@gmail.com", true, "Ali", 3, "Cabbar", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER@GMAIL.COM", "AQAAAAIAAYagAAAAEIQOqMddeGYkhBLIxwFuQsSzV949SssTd9Hzvyo6YeJWxVN9683PX9g6DefBlG1rbw==", null, false, "a5e5c047-7b4f-418a-811c-5d8217e43f03", false, "adminuser@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4505), "Bilgisayarlar, akıllı telefonlar, tabletler, televizyonlar ve diğer tüm elektronik cihazlar bu kategoride bulunabilir. Teknoloji tutkunları için en yeni ve popüler ürünler burada!", "/images/categories/elektronik.png", true, false, "Elektronik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4508), "Kadın, erkek ve çocuk giyim ürünleri, ayakkabılar, çantalar ve aksesuarlar bu kategoride. Trendleri yakalayın ve tarzınızı yansıtın!", "/images/categories/moda.png", true, false, "Moda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4510), "Ev dekorasyonu, mobilyalar, mutfak gereçleri, bahçe ürünleri ve daha fazlası bu kategoride. Evinizi güzelleştirmek için ihtiyacınız olan her şey burada!", "/images/categories/ev-yasam.png", true, false, "Ev & Yaşam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4511), "Spor ekipmanları, outdoor giyim, kamp malzemeleri, bisikletler ve fitness ürünleri bu kategoride. Aktif bir yaşam için ihtiyacınız olan her şey burada!", "/images/categories/spor-outdoor.png", true, false, "Spor & Outdoor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4512), "Romanlar, kişisel gelişim kitapları, akademik yayınlar, dergiler ve daha fazlası bu kategoride. Okuma tutkunları için geniş bir seçki!", "/images/categories/kitap-dergi.png", true, false, "Kitap & Dergi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4541), "Çocuk oyuncakları, yapbozlar, model kitler, hobi malzemeleri ve koleksiyon ürünleri bu kategoride. Hem çocuklar hem de yetişkinler için eğlenceli seçenekler!", "/images/categories/oyuncak-hobi.png", true, false, "Oyuncak & Hobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4542), "Cilt bakım ürünleri, makyaj malzemeleri, parfümler, saç bakım ürünleri ve daha fazlası bu kategoride. Kendinizi şımartın ve bakım rutininizi oluşturun!", "/images/categories/kozmetik-bakim.png", true, false, "Kozmetik & Kişisel Bakım", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4543), "Valizler, sırt çantaları, seyahat aksesuarları ve seyahat planlaması için gerekli ürünler bu kategoride. Yeni yerler keşfetmeye hazır olun!", "/images/categories/seyahat-valiz.png", false, false, "Seyahat & Valiz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4544), "Bebek giysileri, bebek bakım ürünleri, oyuncaklar, çocuk odası dekorasyonu ve daha fazlası bu kategoride. Bebekler ve çocuklar için en kaliteli ürünler!", "/images/categories/bebek-cocuk.png", true, false, "Bebek & Çocuk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(4545), "Araç bakım ürünleri, yedek parçalar, araç içi aksesuarlar ve otomotiv ekipmanları bu kategoride. Araç tutkunları için ihtiyaç duyulan her şey!", "/images/categories/otomotiv.png", false, false, "Otomotiv", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImageUrl", "IsActive", "IsDeleted", "Name", "Price", "Properties", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5026), "/images/products/laptop.png", true, false, "Dizüstü Bilgisayar", 1500.00m, "16GB RAM, 512GB SSD, Intel i7 İşlemci", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5028), "/images/products/smartphone.png", true, false, "Akıllı Telefon", 800.00m, "128GB Depolama, 6GB RAM, 5G Desteği", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5031), "/images/products/tablet.png", true, false, "Tablet", 600.00m, "10.5 inç Ekran, 256GB Depolama, Kalem Desteği", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5032), "/images/products/smartwatch.png", true, false, "Akıllı Saat", 250.00m, "GPS, Kalp Atışı Ölçer, Suya Dayanıklı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5060), "/images/products/earbuds.png", false, false, "Kablosuz Kulaklık", 150.00m, "Gürültü Önleyici, 20 Saat Pil Ömrü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5061), "/images/products/men-jacket.png", true, false, "Erkek Ceket", 120.00m, "Slim Fit, Kumaş Ceket", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5062), "/images/products/women-dress.png", true, false, "Kadın Elbise", 80.00m, "Yazlık Desenli, Pamuklu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5063), "/images/products/sneakers.png", true, false, "Spor Ayakkabı", 90.00m, "Hafif, Nefes Alabilir Taban", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5064), "/images/products/bag.png", true, false, "Çanta", 70.00m, "Deri, Günlük Kullanım", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5065), "/images/products/sunglasses.png", false, false, "Güneş Gözlüğü", 50.00m, "UV Koruma, Polarize Cam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5066), "/images/products/dinner-set.png", true, false, "Yemek Takımı", 100.00m, "12 Parça, Porselen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5067), "/images/products/sofa.png", true, false, "Kanepe", 500.00m, "3 Kişilik, Kumaş Kaplama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5068), "/images/products/bed-sheet.png", true, false, "Yatak Örtüsü", 60.00m, "Pamuklu, 200x220 cm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5069), "/images/products/lamp.png", true, false, "Masa Lambası", 40.00m, "LED, Ayarlanabilir Işık", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5070), "/images/products/vacuum.png", false, false, "Süpürge", 120.00m, "Elektrikli, HEPA Filtre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5071), "/images/products/gym-bag.png", true, false, "Spor Çantası", 45.00m, "30 Litre, Çok Bölmeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5072), "/images/products/tent.png", true, false, "Tent", 200.00m, "4 Kişilik, Su Geçirmez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5073), "/images/products/bike.png", true, false, "Bisiklet", 350.00m, "21 Vites, Dağ Bisikleti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5075), "/images/products/treadmill.png", true, false, "Koşu Bandı", 600.00m, "Katlanabilir, 12 Program", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5076), "/images/products/gloves.png", false, false, "Spor Eldiveni", 25.00m, "Antrenman için, Ergonomik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5077), "/images/products/novel.png", true, false, "Roman Kitabı", 20.00m, "En Çok Satanlar Listesinden", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5078), "/images/products/self-help.png", true, false, "Kişisel Gelişim Kitabı", 25.00m, "Motivasyon ve Başarı İçin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5079), "/images/products/sci-fi.png", true, false, "Bilim Kurgu Kitabı", 30.00m, "Klasik Bilim Kurgu Eseri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5080), "/images/products/magazine.png", true, false, "Dergi", 10.00m, "Aylık Teknoloji Dergisi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5081), "/images/products/kids-book.png", false, false, "Çocuk Kitabı", 15.00m, "Resimli, Eğitici Hikayeler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5082), "/images/products/lego.png", true, false, "Lego Seti", 80.00m, "1000 Parça, Yaratıcı Set", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5083), "/images/products/model-plane.png", true, false, "Model Uçak", 50.00m, "1:100 Ölçekli, Detaylı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5084), "/images/products/puzzle.png", true, false, "Puzzle", 30.00m, "1000 Parça, Manzara Temalı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5085), "/images/products/coloring-book.png", true, false, "Boyama Kitabı", 20.00m, "Yetişkinler İçin Mandala", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5086), "/images/products/rc-car.png", true, false, "RC Araba", 70.00m, "Uzaktan Kumandalı, Hızlı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5087), "/images/products/moisturizer.png", true, false, "Nemlendirici Krem", 40.00m, "Cilt Bariyerini Güçlendirir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5088), "/images/products/lipstick.png", true, false, "Ruj", 25.00m, "Uzun Süre Kalıcı, 12 Renk Seçeneği", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5089), "/images/products/perfume.png", true, false, "Parfüm", 60.00m, "100 ml, Günlük Kullanım", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5090), "/images/products/shampoo.png", true, false, "Şampuan", 15.00m, "Saç Dökülmesine Karşı Etkili", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5091), "/images/products/razor.png", true, false, "Tıraş Makinesi", 90.00m, "Islak & Kuru Kullanım", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5092), "/images/products/diapers.png", true, false, "Bebek Bezi", 40.00m, "Hipoalerjenik, 120 Adet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5092), "/images/products/stroller.png", true, false, "Bebek Arabası", 200.00m, "Katlanabilir, Hafif", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5093), "/images/products/doll.png", true, false, "Oyuncak Bebek", 35.00m, "Gerçekçi Tasarım, 30 cm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5094), "/images/products/kids-bike.png", true, false, "Çocuk Bisikleti", 100.00m, "12 inç, Yardımcı Tekerlekli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2025, 3, 1, 11, 5, 55, 579, DateTimeKind.Utc).AddTicks(5095), "/images/products/baby-clothes.png", true, false, "Bebek Giysisi", 20.00m, "Pamuklu, Rahat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c44cd475-5365-409f-845c-6ea238190b2b", "d2fe392f-4f60-4963-ba3a-ea52b71fb53e" },
                    { "0517f36e-53b1-4a0d-b6b3-599afdd926cf", "d4757375-a497-496b-85dc-a510027bd9b1" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId", "CreateDate", "IsActive", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "d2fe392f-4f60-4963-ba3a-ea52b71fb53e", new DateTime(2025, 3, 1, 11, 5, 55, 662, DateTimeKind.Utc).AddTicks(9528), true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "d4757375-a497-496b-85dc-a510027bd9b1", new DateTime(2025, 3, 1, 11, 5, 55, 662, DateTimeKind.Utc).AddTicks(9535), true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 2, 16 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 },
                    { 9, 25 },
                    { 6, 26 },
                    { 9, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 9, 30 },
                    { 7, 31 },
                    { 7, 32 },
                    { 7, 33 },
                    { 7, 34 },
                    { 7, 35 },
                    { 9, 36 },
                    { 9, 37 },
                    { 6, 38 },
                    { 9, 38 },
                    { 4, 39 },
                    { 9, 39 },
                    { 2, 40 },
                    { 9, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
