-- VeriTabanı Oluşturma Operasyonu
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

--Categories Tablosu
create table Categories(
    Id int primary  key identity,
    Name nvarchar(max) not null,
    Description nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go 

--Suppliers Tablosu
create table Suppliers(
    Id int primary  key identity,
    Name nvarchar(max) not null,
    Contact nvarchar(max) not null,
    Email nvarchar(max) not null,
    PhoneNumber nvarchar(max),
    Address nvarchar(max),
    City nvarchar(max) not null,
    Country nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go 

--Products Tablosu
create table Products(
    Id int primary  key identity,
    Name nvarchar(max) not null,
    Description nvarchar(max) not null,
    CategoryId int not null,
    SupplierId int not null,
    StockQuantity int not null,
    MinimumStockLevel int not null default 1,
    Price decimal(10,2) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
    constraint FK_Products_Categories FOREIGN key (CategoryId) REFERENCES Categories(Id),
    constraint FK_Products_Suppliers FOREIGN key (SupplierId) REFERENCES Suppliers(Id),
    constraint CHK_Products_StockQuantity check(StockQuantity>=0),
    constraint CHK_Products_MinimumStockLevel check(MinimumStockLevel>=1),
    constraint CHK_Products_Price check(Price>=0),
)
go 

--TranscationTypes Tablosu
create table TranscationTypes(
    Id int primary  key identity,
    Name nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go 

-- StockTransactions tablosu
create table StockTransactions(
    Id int primary key identity,
    ProductId int not null,
    TransactionTypeId int not null,
    TransactionDate datetime not null default getdate(),
    Quantity int not null default 1,
    Note nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
    constraint FK_StockTransactions_Products foreign key (ProductId) references Products(Id),
    constraint FK_StockTransactions_TransactionTypes foreign key (TransactionTypeId) references TranscationTypes(Id),
    constraint CHK_StockTransactions_Quantity check (Quantity>0)
)
go


--Customers Tablosu
create table Customers(
    Id int primary  key identity,
    Name nvarchar(max) not null,
    Contact nvarchar(max) not null,
    Email nvarchar(max) not null,
    PhoneNumber nvarchar(max),
    Address nvarchar(max),
    City nvarchar(max) not null,
    Country nvarchar(max) not null,
    IsDeleted bit not null default 0,
    CreatedAt datetime2(3) not null default getdate(),
    UpdatedAt datetime2(3)
)
go 

--Sales Tablosu
create table Sales(
    Id int primary  key identity,
    ProductId int not null,
    CustomerId int not null,
    Quantity int not null,
    UnitPrice decimal(10,2) not null,
    SaleDate datetime2(3) not null default getdate(),
    IsDeleted bit not null default 0, 
)
go 
 
 --Index'ler
 --Products
create nonclustered index IX_Products_CategoryId on Products(CategoryId);
create nonclustered index IX_Products_SupplierId on Products(SupplierId);
--create nonclustered index IX_Products_Name on Products(Name);

--Sales
create nonclustered index IX_Sales_ProductId on Sales(ProductId);
create nonclustered index IX_Sales_SupplierId on Sales(CustomerId);
create nonclustered index IX_Products_SaleDate on Sales(SaleDate);


--StockTransactions
create nonclustered index IX_StockTransactions_ProductId on StockTransactions(ProductId);
create nonclustered index IX_StockTransactions_TransactionDate on StockTransactions(TransactionDate);
create nonclustered index IX_StockTransactions_TransactionTypeId on StockTransactions(TransactionTypeId);