--Veri tabanı oluşturma operasyonu
use master
go

if exists (select * from sys.databases where name = 'LearnifyStockAppDb')
begin
    alter database LearnifyStockAppDb set single_user with rollback immediate
    drop database LearnifyStockAppDb
end
go

create database LearnifyStockAppDb
go

use LearnifyStockAppDb
go

-- Categories tablosu
create table Categories(
    Id int primary key identity,
    Name nvarchar(max) not null,
    Description nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go

-- Suppliers tablosu
create table Suppliers(
    Id int primary key identity,
    Name nvarchar(max) not null,
    Contact nvarchar(max) not null,
    Email nvarchar(max) not null,
    PhoneNumber nvarchar(max) not null,
    Address nvarchar(max),
    City nvarchar(max) not null,
    Country nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go

-- Products tablosu
create table Products(
    Id int primary key identity,
    Name nvarchar(max) not null,
    Description nvarchar(max) not null,
    CategoryId int not null,
    SupplierId int not null,
    StockQuantity int not null default 0,
    MinimumStockLevel int not null default 1,
    Price decimal(10,2) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3),
    constraint FK_Products_Categories foreign key (CategoryId) references Categories(Id),
    constraint FK_Products_Suppliers foreign key (SupplierId) references Suppliers(Id),
    constraint CHK_Products_StockQuantity check (StockQuantity>=0),
    constraint CHK_Products_MinimumStockLevel check(MinimumStockLevel>=1),
    constraint CHK_Products_Price check (Price>=0)
)
go

-- TransactionTypes tablosu
create table TransactionTypes(
    Id int primary key identity,
    Name nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go
-- 1 'Giriş'
-- 2 'Çıkış'

--StockTransactions tablosu
create table StockTransactions(
    Id int primary key identity,
    ProductId int not null,
    TransactionTypeId int not null,
    TransactionDate datetime not null default getdate(),
    Quantity int not null default 1,
    Note nvarchar(max),
    IsDeleted bit not null default 0,
    constraint FK_StockTransactions_Products foreign key (ProductId) references Products(Id),
    constraint FK_StockTransactions_TransactionTypes foreign key (TransactionTypeId) references TransactionTypes(Id),
    constraint CHK_StockTransactions_Quantity check (Quantity>0)
)
go

--Customers tablosu
create table Customers(
    Id int primary key identity,
    Name nvarchar(max) not null,
    Contact nvarchar(max) not null,
    Email nvarchar(max) not null,
    PhoneNumber nvarchar(max) not null,
    Address nvarchar(max),
    City nvarchar(max) not null,
    Country nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go

-- Sales tablosu
create table Sales(
    Id int primary key identity,
    ProductId int not null,
    CustomerId int not null,
    Quantity int not null,
    UnitPrice decimal(10,2) not null,
    SaleDate datetime2(3) not null default getdate(),
    IsDeleted bit not null default 0
)
go

-- Index'ler 
-- Products
create nonclustered index IX_Products_CategoryId on Products(CategoryId);
create nonclustered index IX_Products_SupplierId on Products(SupplierId);
-- create nonclustered index IX_Products_Name on Products(Name);

-- Sales
create nonclustered index IX_Sales_ProductId on Sales(ProductId);
create nonclustered index IX_Sales_CustomerId on Sales(CustomerId);
create nonclustered index IX_Sales_SaleDate on Sales(SaleDate);

-- StockTransactions
create nonclustered index IX_StockTransactions_ProductId on StockTransactions(ProductId);
create nonclustered index IX_StockTransactions_TransactionDate on StockTransactions(TransactionDate);
create nonclustered index IX_StockTransactions_TransactionTypeId on StockTransactions(TransactionTypeId);


-- Categories tablosuna örnek veri ekle
insert into Categories (Name, Description) values
('Elektronik', 'Elektronik ürünler, bilgisayarlar, telefonlar, vb.'),
('Giyim', 'Erkek ve kadın giyim ürünleri'),
('Gıda', 'Yiyecek ve içecekler');

-- Suppliers tablosuna örnek veri ekle
insert into Suppliers (Name, Contact, Email, PhoneNumber, Address, City, Country) values
('TechSupply', 'John Doe', 'john@techsupply.com', '555-1234', '123 Tech St.', 'İstanbul', 'Türkiye'),
('FashionWorld', 'Jane Smith', 'jane@fashionworld.com', '555-5678', '456 Fashion Rd.', 'Ankara', 'Türkiye'),
('FoodMart', 'Ali Kılıç', 'ali@foodmart.com', '555-9876', '789 Food Ave.', 'İzmir', 'Türkiye');

-- Products tablosuna örnek veri ekle
insert into Products (Name, Description, CategoryId, SupplierId, StockQuantity, MinimumStockLevel, Price) values
('iPhone 14', 'Apple iPhone 14, 128GB', 1, 1, 50, 5, 12000.00),
('Samsung Galaxy S21', 'Samsung Galaxy S21, 128GB', 1, 1, 30, 3, 9500.00),
('Tişört', 'Pamuklu erkek tişört', 2, 2, 100, 10, 150.00),
('Kot Pantolon', 'Kot pantolon, mavi', 2, 2, 80, 8, 250.00),
('Paket Makarnalar', '500g makarna', 3, 3, 500, 50, 10.00),
('Şişe Su', '1.5L su', 3, 3, 300, 30, 5.00);

-- TransactionTypes tablosuna örnek veri ekle
insert into TransactionTypes (Name) values
('Giriş'),
('Çıkış');

-- StockTransactions tablosuna örnek veri ekle
insert into StockTransactions (ProductId, TransactionTypeId, TransactionDate, Quantity, Note) values
(1, 1, '2024-11-01', 20, 'Yeni ürün stoğu girişi'),
(2, 1, '2024-11-02', 15, 'Yeni ürün stoğu girişi'),
(3, 2, '2024-11-03', 10, 'Satış sonrası çıkış'),
(4, 2, '2024-11-04', 5, 'Satış sonrası çıkış'),
(5, 1, '2024-11-05', 100, 'Yeni ürün stoğu girişi'),
(6, 1, '2024-11-06', 200, 'Yeni ürün stoğu girişi');

-- Customers tablosuna örnek veri ekle
insert into Customers (Name, Contact, Email, PhoneNumber, Address, City, Country) values
('Mehmet Yılmaz', 'mehmet.yilmaz@example.com', 'mehmet@example.com', '555-1111', '1234 Example St.', 'İstanbul', 'Türkiye'),
('Ayşe Kara', 'ayse.kara@example.com', 'ayse@example.com', '555-2222', '5678 Another Rd.', 'Ankara', 'Türkiye'),
('Fatma Çelik', 'fatma.celik@example.com', 'fatma@example.com', '555-3333', '91011 Old St.', 'İzmir', 'Türkiye');

-- Sales tablosuna örnek veri ekle
insert into Sales (ProductId, CustomerId, Quantity, UnitPrice, SaleDate) values
(1, 1, 1, 12000.00, '2024-11-10'),
(2, 2, 2, 9500.00, '2024-11-11'),
(3, 3, 3, 150.00, '2024-11-12'),
(4, 1, 1, 250.00, '2024-11-13'),
(5, 2, 10, 10.00, '2024-11-14'),
(6, 3, 5, 5.00, '2024-11-15')
go

-- Categories UpdatedAt Trigger
create trigger trg_UpdatedAt_Categories on Categories
after update 
as
begin
    update Categories set UpdatedAt=getdate()
    from Categories x inner join inserted i on x.Id=i.Id
end
go

-- Customers UpdatedAt Trigger
create trigger trg_UpdatedAt_Customers on Customers
after update 
as
begin
    update Customers set UpdatedAt=getdate()
    from Customers x inner join inserted i on x.Id=i.Id
end
go

-- Products UpdatedAt Trigger
create trigger trg_UpdatedAt_Products on Products
after update 
as
begin
    update Products set UpdatedAt=getdate()
    from Products x inner join inserted i on x.Id=i.Id
end
go

-- Suppliers UpdatedAt Trigger
create trigger trg_UpdatedAt_Suppliers on Suppliers
after update 
as
begin
    update Suppliers set UpdatedAt=getdate()
    from Suppliers x inner join inserted i on x.Id=i.Id
end
go

-- TransactionTypes UpdatedAt Trigger
create trigger trg_UpdatedAt_TransactionTypes on TransactionTypes
after update 
as
begin
    update TransactionTypes set UpdatedAt=getdate()
    from TransactionTypes x inner join inserted i on x.Id=i.Id
end
go

