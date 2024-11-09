USE master
GO

if DB_ID('PortfolioDb') is not null
begin
    alter database PortfolioDb set single_user with rollback immediate
    drop database PortfolioDb
end
go

create database PortfolioDb collate Turkish_CI_AS
go

use PortfolioDb
go

create table AppSettings(
    Id int primary key identity,
    BrandName nvarchar(100) not null,
    HeroTitle nvarchar(200) not null,
    HeroSubTitle nvarchar(300) not null,
    HeroImageUrl nvarchar(1000) not null,
    AboutText nvarchar(3000) not null,
    AboutImageUrl nvarchar(1000) not null,
    SkillsImageUrl nvarchar(1000) not null,
    AddressText nvarchar(500) not null,
    AddressDistrict nvarchar(100) not null,
    AddressCity nvarchar(100) not null,
    PhoneNumber nvarchar(20) not null,
    Email nvarchar(100) not null,
    GoogleMap nvarchar(1000) not null,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime
)
go

insert into AppSettings(BrandName,HeroTitle,HeroSubTitle,HeroImageUrl,AboutText,AboutImageUrl,SkillsImageUrl,AddressText,AddressDistrict,AddressCity,PhoneNumber,Email,GoogleMap)
values 
    (
        'Kemal Kodyazar',
        'Backend Developer',
        'DotNet | Asp.Net Core MVC | Asp.Net Core WebAPI',
        'http://localhost:5100/ui/img/hero-img.png',
        '<p>AcunMedya Akademi''de aldığım yazılım eğitimi sırasında ve sonrasında yaptığım çalışmalarla kendimi geliştirdim. Hem frontend hem de backend konularında bilgi ve deneyim sahibi olmama karşın, kendimi backend tarafında geliştiriyorum.</p>
        <h4>Eğitim Aldığım Konular</h4>
        <ul>
            <li>Temel C# Programlama</li>
            <li>Object Oriented Programming</li>
            <li>HTML, CSS, JavaScript</li>
            <li>EntityFramework Core</li>
        </ul>',
        'http://localhost:5100/ui/img/about-img.png',
        'http://localhost:5100/ui/img/skills-img.png',
        'Cemal Reşit Rey Yolu, Medium Plaza K:4',
        'Kadıköy',
        'İstanbul',
        '90 555 467 98 89',
        'info@kemalkodyazar.com',
        'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3012.8621993112492!2d29.105485473413253!3d40.96259752224049!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cabbe7eee803fb%3A0x2f64ecd26d22527a!2sYowa%20Academy!5e0!3m2!1str!2str!4v1729941803604!5m2!1str!2str'
    )
go

create table Socials(
    Id int primary key identity,
    Name nvarchar(50) not null,
    Url nvarchar(500) not null,
    Icon nvarchar(20) not null,
    IsActive bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime
)
go

insert into Socials(Name, Url,Icon)
values
    ('Github','https://www.github.com','github'),
    ('LinkedIn','https://www.linkedin.com','linkedin'),
    ('Medium','https://www.medium.com','medium'),
    ('Instagram','https://www.instagram.com','instagram'),
    ('X','https://www.x.com','twitter-x')
go

create table Skills(
    Id int primary key identity,
    Name nvarchar(50) not null,
    Rate tinyint not null,
    IsActive bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime
)
go

insert into Skills(Name, Rate)
values 
    ('Html',100),
    ('Css',95),
    ('JavaScript',90),
    ('AspNet Core MVC',85)
go

create table Services(
    Id int primary key identity,
    Title nvarchar(50) not null,
    Description nvarchar(1000) not null,
    Icon nvarchar(20) not null,
    IsActive bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime    
)
go

insert into Services(Title, Description,Icon)
values
    ('SEO Hizmeti','Arama Motoru Optimizasyonu','activity'),
    ('Web Uygulamaları','İsteğe özel web uygulamaları geliştirme','bounding-box-circles'),
    ('Server Yönetimi','Sunucuların oluşturulup bakım ve yönetimlerinin yapılması','calendar4-week'),
    ('SPA','Single Page Application uygulamalarının geliştirilmesi','broadcast')
go

create table Categories(
    Id int primary key identity,
    Name nvarchar(50) not null,
    IsActive bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime    
)
go

insert into Categories(Name)
values ('MVC'),('FrontEnd'),('API')
go

create table Projects(
    Id int primary key identity,
    Name nvarchar(50) not null,
    Description nvarchar(200) not null,
    GithubUrl nvarchar(500) not null,
    ImageUrl nvarchar(1000) not null,
    IsActive bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime,
    CategoryId int FOREIGN KEY REFERENCES Categories(Id)
)
go

insert into Projects(Name,Description,GithubUrl,ImageUrl)
values
    ('Proje 1','Proje 1 Açıklaması','https://www.github.com/project1','http://localhost:5100/ui/img/projects/project1.jpg'),
    ('Proje 2','Proje 2 Açıklaması','https://www.github.com/project2','http://localhost:5100/ui/img/projects/project2.jpg'),
    ('Proje 3','Proje 3 Açıklaması','https://www.github.com/project3','http://localhost:5100/ui/img/projects/project3.jpg'),
    ('Proje 4','Proje 4 Açıklaması','https://www.github.com/project4','http://localhost:5100/ui/img/projects/project4.jpg'),
    ('Proje 5','Proje 5 Açıklaması','https://www.github.com/project5','http://localhost:5100/ui/img/projects/project5.jpg'),
    ('Proje 6','Proje 6 Açıklaması','https://www.github.com/project6','http://localhost:5100/ui/img/projects/project6.jpg'),
    ('Proje 7','Proje 7 Açıklaması','https://www.github.com/project7','http://localhost:5100/ui/img/projects/project7.jpg'),
    ('Proje 8','Proje 8 Açıklaması','https://www.github.com/project8','http://localhost:5100/ui/img/projects/project8.jpg')
go

create table Contacts(
    Id int primary key identity,
    Name nvarchar(100) not null,
    Email nvarchar(100) not null,
    Subject nvarchar(100) not null,
    Message nvarchar(max) not null,
    IsRead bit not null default 0,
    SendingTime datetime not null default getdate(),
    ContactId int null foreign key references Contacts(Id)
)
go

insert into Contacts(Name, Email, Subject, Message)
values 
    ('Sezen Aksu','sezen@gmail.com','Proje Teklifi','Proje teklifimizi paylaşmak isteriz'),
    ('Ali Cabbar','ali@cabbar.com','Klarnet Teklifi','Düğünlerinizde klarnet çalmaya hazırım'),
    ('Alex de Souza','alex@gmail.com','Jübile','Onca yıl olda jübile yapmadık')
go

insert into Contacts(Name, Email, Subject, Message, ContactId)
values
    ('Kemal Kodyazar','info@kemalkodyazar.com','YNT:Klarnet Teklifi','Ali bey, düğün yapmıyoruz!',2),
    ('Kemal Kodyazar','info@kemalkodyazar.com','YNT:Jübile','Bu konuda biz de mahçubuz, ilk fırsatta yapalım',3)
go
    