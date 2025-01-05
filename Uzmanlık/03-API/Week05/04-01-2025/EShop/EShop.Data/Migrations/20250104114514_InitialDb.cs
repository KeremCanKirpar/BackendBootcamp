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
                    Descripiton = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(146), "Günlük kullanım için cihazlar ve aksesuarlar.", "/images/elektronik.jpg", true, false, "Elektronik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(149), "Kadın ve erkek giyim ile aksesuarları.", "/images/moda.jpg", false, false, "Moda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(151), "Mobilya, bahçe ekipmanları ve dekorasyon ürünleri.", "/images/ev-bahce.jpg", true, true, "Ev ve Bahçe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(153), "Farklı türlerde kitaplar ve romanlar.", "/images/kitap.jpg", true, false, "Kitap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(155), "Çocuklar için eğitici ve eğlenceli oyuncaklar.", "/images/oyuncak.jpg", true, false, "Oyuncak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(157), "Kozmetik, cilt bakımı ve sağlık ürünleri.", "/images/saglik-guzellik.jpg", false, false, "Sağlık ve Güzellik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(159), "Spor tutkunları için ekipman ve aksesuarlar.", "/images/spor.jpg", true, false, "Spor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(161), "Araç aksesuarları ve bakım ürünleri.", "/images/otomotiv.jpg", true, true, "Otomotiv", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(163), "Günlük ihtiyaçlar ve temel gıda ürünleri.", "/images/gida.jpg", true, false, "Gıda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(165), "Konsollar, oyunlar ve oyun aksesuarları.", "/images/oyun.jpg", true, false, "Oyun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImageUrl", "IsActive", "IsDeleted", "Name", "Price", "Properties", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(736), "elektronik1.jpg", true, false, "Elektronik Ürün 1", 1500m, "4K çözünürlüklü televizyon.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(738) },
                    { 2, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(740), "elektronik2.jpg", true, false, "Elektronik Ürün 2", 350m, "Kablosuz kulaklık.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(741) },
                    { 3, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(743), "elektronik3.jpg", false, false, "Elektronik Ürün 3", 300m, "Bluetooth hoparlör.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(744) },
                    { 4, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(745), "elektronik4.jpg", true, false, "Elektronik Ürün 4", 200m, "Taşınabilir şarj cihazı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(746) },
                    { 5, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(747), "elektronik5.jpg", true, false, "Elektronik Ürün 5", 1200m, "Akıllı saat.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(748) },
                    { 6, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(749), "moda1.jpg", true, false, "Moda Ürün 6", 100m, "Pamuklu tişört.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(750) },
                    { 7, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(751), "moda2.jpg", true, true, "Moda Ürün 7", 250m, "Kot pantolon.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(752) },
                    { 8, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(753), "moda3.jpg", false, false, "Moda Ürün 8", 450m, "Şık ceket.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(754) },
                    { 9, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(755), "moda4.jpg", true, false, "Moda Ürün 9", 400m, "Kadın spor ayakkabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(756) },
                    { 10, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(757), "moda5.jpg", true, false, "Moda Ürün 10", 150m, "Rahat spor taytı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(758) },
                    { 11, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(759), "ev_aletleri1.jpg", true, false, "Ev Aletleri Ürün 11", 1200m, "Elektrikli süpürge.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(759) },
                    { 12, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(761), "ev_aletleri2.jpg", false, false, "Ev Aletleri Ürün 12", 2500m, "Çamaşır makinesi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(761) },
                    { 13, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(762), "ev_aletleri3.jpg", true, true, "Ev Aletleri Ürün 13", 800m, "Mikrodalga fırın.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(763) },
                    { 14, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(764), "ev_aletleri4.jpg", true, false, "Ev Aletleri Ürün 14", 3000m, "Buzdolabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(765) },
                    { 15, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(766), "ev_aletleri5.jpg", true, false, "Ev Aletleri Ürün 15", 900m, "Hava temizleyici.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(767) },
                    { 16, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(768), "kitap1.jpg", true, false, "Kitap Ürün 16", 90m, "Tarihi roman.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(769) },
                    { 17, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(769), "kitap2.jpg", true, false, "Kitap Ürün 17", 120m, "Bilim kurgu romanı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(770) },
                    { 18, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(771), "kitap3.jpg", true, false, "Kitap Ürün 18", 75m, "Kişisel gelişim kitabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(772) },
                    { 19, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(773), "kitap4.jpg", false, false, "Kitap Ürün 19", 130m, "Popüler bilim kitabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(774) },
                    { 20, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(775), "kitap5.jpg", true, false, "Kitap Ürün 20", 100m, "Fantastik roman.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(776) },
                    { 21, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(777), "oyuncak1.jpg", true, false, "Oyuncak Ürün 21", 50m, "Ahşap yapboz.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(778) },
                    { 22, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(779), "oyuncak2.jpg", true, false, "Oyuncak Ürün 22", 150m, "Peluş oyuncak.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(779) },
                    { 23, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(780), "oyuncak3.jpg", false, false, "Oyuncak Ürün 23", 300m, "LEGO seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(781) },
                    { 24, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(782), "oyuncak4.jpg", true, false, "Oyuncak Ürün 24", 120m, "Eğitici oyuncak.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(783) },
                    { 25, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(784), "oyuncak5.jpg", true, false, "Oyuncak Ürün 25", 500m, "Uzaktan kumandalı araba.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(785) },
                    { 26, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(786), "spor1.jpg", true, false, "Spor Malzemesi Ürün 26", 250m, "Fitness matı, kaymaz yüzey.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(787) },
                    { 27, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(788), "spor2.jpg", true, false, "Spor Malzemesi Ürün 27", 500m, "Dumbell seti, 10kg.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(788) },
                    { 28, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(789), "spor3.jpg", false, false, "Spor Malzemesi Ürün 28", 4000m, "Koşu bandı, elektronik ekran.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(790) },
                    { 29, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(791), "spor4.jpg", true, false, "Spor Malzemesi Ürün 29", 150m, "Yoga kemeri, dayanıklı malzeme.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(792) },
                    { 30, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(793), "spor5.jpg", true, false, "Spor Malzemesi Ürün 30", 180m, "Pilates topu, anti-patlama özelliği.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(794) },
                    { 31, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(795), "kozmetik1.jpg", true, false, "Kozmetik Ürün 31", 120m, "Doğal içerikli yüz kremi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(796) },
                    { 32, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(797), "kozmetik2.jpg", false, false, "Kozmetik Ürün 32", 90m, "Mat ruj, uzun süre kalıcı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(798) },
                    { 33, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(800), "kozmetik3.jpg", true, false, "Kozmetik Ürün 33", 50m, "Nemlendirici el kremi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(801) },
                    { 34, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(802), "kozmetik4.jpg", true, false, "Kozmetik Ürün 34", 75m, "Saç bakım yağı, doğal içerik.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(803) },
                    { 35, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(804), "kozmetik5.jpg", true, false, "Kozmetik Ürün 35", 130m, "Göz altı kapatıcısı, hafif formül.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(805) },
                    { 36, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(806), "gida1.jpg", true, false, "Gıda Ürün 36", 120m, "Organik bal, 500g.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(806) },
                    { 37, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(807), "gida2.jpg", true, false, "Gıda Ürün 37", 150m, "Sızma zeytinyağı, 1L.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(808) },
                    { 38, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(809), "gida3.jpg", true, false, "Gıda Ürün 38", 15m, "Tam buğday ekmeği, 800g.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(810) },
                    { 39, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(811), "gida4.jpg", true, true, "Gıda Ürün 39", 75m, "Doğal çiğ fındık, 250g.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(812) },
                    { 40, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(813), "gida5.jpg", false, false, "Gıda Ürün 40", 80m, "Filtre kahve, 1kg.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(813) },
                    { 41, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(814), "otomotiv1.jpg", true, false, "Otomotiv Ürün 41", 120m, "Araç içi telefon tutucu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(815) },
                    { 42, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(894), "otomotiv2.jpg", true, false, "Otomotiv Ürün 42", 60m, "Lastik tamir spreyi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(895) },
                    { 43, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(897), "otomotiv3.jpg", true, true, "Otomotiv Ürün 43", 200m, "Araç içi hava temizleyici.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(897) },
                    { 44, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(899), "otomotiv4.jpg", true, false, "Otomotiv Ürün 44", 150m, "Bagaj düzenleyici.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(900) },
                    { 45, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(901), "otomotiv5.jpg", false, false, "Otomotiv Ürün 45", 800m, "Akıllı araç kamerası.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(902) },
                    { 46, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(903), "oyun1.jpg", true, false, "Oyun Ürün 46", 250m, "Strateji oyunu, 2-4 kişi için.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(904) },
                    { 47, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(905), "oyun2.jpg", true, false, "Oyun Ürün 47", 12000m, "PlayStation 5 oyun konsolu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(906) },
                    { 48, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(907), "oyun3.jpg", true, false, "Oyun Ürün 48", 300m, "Bilgisayar oyunu, macera türü.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(908) },
                    { 49, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(909), "oyun4.jpg", false, true, "Oyun Ürün 49", 200m, "Monopoly masa oyunu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(910) },
                    { 50, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(911), "oyun5.jpg", true, false, "Oyun Ürün 50", 5000m, "VR gözlük seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(912) },
                    { 51, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(913), "elektronik6.jpg", true, false, "Elektronik Ürün 51", 15000m, "Dizüstü bilgisayar, i7 işlemci.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(914) },
                    { 52, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(915), "elektronik7.jpg", true, false, "Elektronik Ürün 52", 8000m, "Akıllı telefon, 128GB.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(915) },
                    { 53, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(916), "elektronik8.jpg", false, false, "Elektronik Ürün 53", 600m, "Kablosuz klavye ve mouse seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(917) },
                    { 54, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(918), "elektronik9.jpg", true, true, "Elektronik Ürün 54", 1500m, "4TB harici disk.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(919) },
                    { 55, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(920), "elektronik10.jpg", true, false, "Elektronik Ürün 55", 2500m, "Grafik tableti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(921) },
                    { 56, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(922), "moda6.jpg", true, false, "Moda Ürün 56", 1000m, "Kadın kaban, yün karışımlı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(923) },
                    { 57, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(924), "moda7.jpg", true, false, "Moda Ürün 57", 350m, "Erkek deri cüzdan.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(925) },
                    { 58, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(926), "moda8.jpg", true, false, "Moda Ürün 58", 100m, "Unisex şapka, pamuklu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(927) },
                    { 59, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(928), "moda9.jpg", false, true, "Moda Ürün 59", 700m, "Kadın spor ceketi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(928) },
                    { 60, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(929), "moda10.jpg", true, false, "Moda Ürün 60", 1200m, "Erkek klasik ayakkabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(930) },
                    { 61, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(931), "ev_aletleri6.jpg", true, false, "Ev Aletleri Ürün 61", 1500m, "Kapsül kahve makinesi.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(932) },
                    { 62, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(933), "ev_aletleri7.jpg", true, false, "Ev Aletleri Ürün 62", 900m, "Mini fırın.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(934) },
                    { 63, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(935), "ev_aletleri8.jpg", false, false, "Ev Aletleri Ürün 63", 2000m, "Mutfak robotu, 15 fonksiyonlu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(936) },
                    { 64, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(937), "ev_aletleri9.jpg", true, false, "Ev Aletleri Ürün 64", 2500m, "Su arıtma cihazı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(938) },
                    { 65, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(939), "ev_aletleri10.jpg", true, true, "Ev Aletleri Ürün 65", 800m, "Mikser, çok fonksiyonlu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(939) },
                    { 66, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(940), "kitap6.jpg", true, false, "Kitap Ürün 66", 90m, "Psikoloji kitabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(941) },
                    { 67, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(942), "kitap7.jpg", true, false, "Kitap Ürün 67", 75m, "Klasik roman, dünya edebiyatı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(943) },
                    { 68, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(943), "kitap8.jpg", true, false, "Kitap Ürün 68", 50m, "Çocuk kitabı, resimli hikaye.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(944) },
                    { 69, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(945), "kitap9.jpg", false, true, "Kitap Ürün 69", 45m, "Şiir kitabı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(946) },
                    { 70, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(947), "kitap10.jpg", true, false, "Kitap Ürün 70", 120m, "Tarih kitabı, araştırma eseri.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(948) },
                    { 71, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(949), "oyuncak6.jpg", true, false, "Oyuncak Ürün 71", 60m, "Zeka geliştiren kart oyunu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(950) },
                    { 72, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(951), "oyuncak7.jpg", true, false, "Oyuncak Ürün 72", 90m, "Yumuşak top seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(952) },
                    { 73, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(953), "oyuncak8.jpg", false, false, "Oyuncak Ürün 73", 140m, "Manyetik yapboz seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(954) },
                    { 74, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(955), "oyuncak9.jpg", true, true, "Oyuncak Ürün 74", 200m, "İnşaat araçları seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(956) },
                    { 75, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(957), "oyuncak10.jpg", true, false, "Oyuncak Ürün 75", 800m, "Uzaktan kumandalı helikopter.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(957) },
                    { 76, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(958), "spor6.jpg", true, false, "Oyun Ürün 76", 300m, "Denge tahtası.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(959) },
                    { 77, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(960), "spor7.jpg", true, false, "Oyun Ürün 77", 180m, "Yüzme gözlüğü, UV korumalı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(961) },
                    { 78, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(963), "spor8.jpg", false, true, "Oyun Ürün 78", 220m, "Basketbol topu, dayanıklı malzeme.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(964) },
                    { 79, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(965), "spor9.jpg", true, false, "Oyun Ürün 79", 700m, "Koşu ayakkabısı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(966) },
                    { 80, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(967), "spor10.jpg", true, false, "Oyun Ürün 80", 250m, "Spor çantası, hafif ve geniş.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(968) },
                    { 81, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(969), "kozmetik6.jpg", true, false, "Kozmetik Ürün 81", 400m, "Parfüm, ferah koku.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(970) },
                    { 82, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(971), "kozmetik7.jpg", false, false, "Kozmetik Ürün 82", 70m, "Cilt temizleme jeli.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(971) },
                    { 83, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(972), "kozmetik8.jpg", true, true, "Kozmetik Ürün 83", 90m, "Doğal şampuan, organik içerik.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(973) },
                    { 84, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(974), "kozmetik9.jpg", true, false, "Kozmetik Ürün 84", 120m, "Tırnak bakım seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(975) },
                    { 85, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(976), "kozmetik10.jpg", true, false, "Kozmetik Ürün 85", 100m, "Vücut losyonu, yoğun nemlendirici.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(977) },
                    { 86, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(978), "gida6.jpg", true, false, "Gıda Ürün 86", 25m, "Süt, yarım yağlı, 1L.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(979) },
                    { 87, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(980), "gida7.jpg", false, false, "Gıda Ürün 87", 30m, "Organik muz, 1kg.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(981) },
                    { 88, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(982), "gida8.jpg", true, true, "Gıda Ürün 88", 15m, "Çikolata, sütlü, 100g.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(982) },
                    { 89, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(983), "gida9.jpg", true, false, "Gıda Ürün 89", 20m, "Tam buğday makarna, 500g.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(984) },
                    { 90, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(985), "gida10.jpg", true, false, "Gıda Ürün 90", 40m, "Organik yumurta, 10'lu.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(986) },
                    { 91, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(987), "otomotiv6.jpg", true, false, "Otomotiv Ürün 91", 40m, "Cam suyu, antifrizli.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(988) },
                    { 92, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(989), "otomotiv7.jpg", false, false, "Otomotiv Ürün 92", 150m, "Araç lastik basınç ölçer.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(990) },
                    { 93, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(990), "otomotiv8.jpg", true, true, "Otomotiv Ürün 93", 120m, "Direksiyon kılıfı.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(991) },
                    { 94, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(992), "otomotiv9.jpg", true, false, "Otomotiv Ürün 94", 180m, "Koltuk düzenleyici.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(993) },
                    { 95, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(994), "otomotiv10.jpg", true, false, "Otomotiv Ürün 95", 300m, "Bagaj örtüsü, su geçirmez.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(995) },
                    { 96, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1040), "oyun6.jpg", true, false, "Oyun Ürün 96", 250m, "Satranç seti, ahşap malzeme.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1041) },
                    { 97, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1042), "oyun7.jpg", false, false, "Oyun Ürün 97", 600m, "PC oyun kolu, kablosuz.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1043) },
                    { 98, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1044), "oyun8.jpg", true, false, "Oyun Ürün 98", 150m, "Puzzle, 1000 parça.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1045) },
                    { 99, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1046), "oyun9.jpg", true, true, "Oyun Ürün 99", 1200m, "Çocuk masası ve sandalye seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1047) },
                    { 100, new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1048), "oyun10.jpg", true, false, "Oyun Ürün 100", 5000m, "Eğitici robot seti.", new DateTime(2025, 1, 4, 11, 45, 13, 942, DateTimeKind.Utc).AddTicks(1049) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 4, 4 },
                    { 10, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 5, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 4, 18 },
                    { 3, 19 },
                    { 10, 20 },
                    { 4, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 10, 24 },
                    { 10, 25 },
                    { 10, 26 },
                    { 7, 27 },
                    { 7, 28 },
                    { 1, 29 },
                    { 1, 30 },
                    { 1, 31 },
                    { 1, 32 },
                    { 1, 33 },
                    { 1, 34 },
                    { 1, 35 },
                    { 1, 36 },
                    { 1, 37 },
                    { 1, 38 },
                    { 1, 39 },
                    { 1, 40 },
                    { 1, 41 },
                    { 4, 42 },
                    { 4, 43 },
                    { 4, 44 },
                    { 4, 45 },
                    { 7, 46 },
                    { 7, 47 },
                    { 10, 48 },
                    { 10, 49 },
                    { 10, 50 },
                    { 10, 51 },
                    { 10, 52 },
                    { 10, 53 },
                    { 10, 54 },
                    { 10, 55 },
                    { 10, 56 },
                    { 10, 57 },
                    { 10, 58 },
                    { 10, 59 },
                    { 10, 60 },
                    { 10, 61 },
                    { 10, 62 },
                    { 10, 63 },
                    { 10, 64 },
                    { 4, 65 },
                    { 4, 66 },
                    { 4, 67 },
                    { 4, 68 },
                    { 4, 69 },
                    { 4, 70 },
                    { 4, 71 },
                    { 4, 72 },
                    { 4, 73 },
                    { 4, 74 },
                    { 4, 75 },
                    { 4, 76 },
                    { 4, 77 },
                    { 4, 78 },
                    { 4, 79 },
                    { 4, 80 },
                    { 4, 81 },
                    { 4, 82 },
                    { 4, 83 },
                    { 4, 84 },
                    { 4, 85 },
                    { 4, 86 },
                    { 4, 87 },
                    { 4, 88 },
                    { 4, 89 },
                    { 4, 90 },
                    { 4, 91 },
                    { 4, 92 },
                    { 4, 93 },
                    { 4, 94 },
                    { 4, 95 },
                    { 4, 96 },
                    { 4, 97 },
                    { 4, 98 },
                    { 4, 99 },
                    { 4, 100 }
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
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
