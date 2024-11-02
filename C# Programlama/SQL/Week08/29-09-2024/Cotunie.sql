Use master
GO

if DB_ID('PortfolioDB') is not NULL
BEGIN
    alter database PortfolioDB set single_user WITH rollback IMMEDIATE
    drop database PortfolioDB
END
go

create DATABASE PortfolioDB COLLATE Turkish_CI_AS

CREATE table AppSettings
(
    Id int primary key IDENTITY(1,1),
    BrandName NVARCHAR(100) not null,
    HeroTitle NVARCHAR(200) not null,
    HeroSubTitle NVARCHAR(300) not null,
    HeroImageUrl NVARCHAR(1000) not NULL,
    AboutText NVARCHAR(3000) not null,
    AboutImageUrl NVARCHAR(1000) not null,
    SkillsImageUrl NVARCHAR(1000) not null,
    AddressText NVARCHAR(500) not null,
    AddressDisctrict NVARCHAR(100) not null,
    AddressCountry NVARCHAR(100) not null,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) not null,
    GoogleMap NVARCHAR(1000) not null,
    CreatedDate DATETIME not null DEFAULT GETDATE(),
    ModifiedDate DATETIME
);
GO

INSERT into AppSettings
    (BrandName,HeroTitle,HeroSubTitle,HeroImageUrl,AboutText,AboutImageUrl,SkillsImageUrl,AddressText,AddressDisctrict,AddressCountry,PhoneNumber,Email,GoogleMap,CreatedDate,ModifiedDate)
VALUES
    (
        'Kerem Can Kırpar',
        'Backend Developer',
        'Dotnet|Asp.Net Core MVC| Asp.net Core WebAPI',
        'http://localhost:5100/ui/img/hero-img.png',
            '<p>
        AcunMedya Akademi''de aldığım yazılım eğitimi sırasında ve sonrasında yaptığım çalışmalarla kendimi geliştirdim. Hem frontend hem de backend konularında bilgi ve deneyim sahibi olmama karşın, kendimi backend tarafında geliştiriyorum.
            </p>
    <h4>Eğitim Aldığım Konular</h4>
    <ul>
        <li>Temel C# Programlama</li>
        <li>Object Oriented Prgramming</li>
        <li>HTML,CSS, JavaScript</li>
        <li>EntityFramework ore</li>
    </ul>',
    'http://localhost:5100/ui/img/skills-img.png',
     'Cemal Reşit Rey Yolu, Medium Plaza Kat:4',
     'Kadıköy',
     'İstanbul',
     '905554679889',
     'info@kemalkodyazar.com',
     'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3059.608547211538!2d32.8507791!3d39.9277756!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14d34ef8d63f929f%3A0xd9093bf2a3dcda04!2sWORA%20Studios!5e0!3m2!1str!2str!4v1729941867326!5m2!1str!2str'


);
go

CREATE table Socials(
    Id int primary key IDENTITY,
    Name NVARCHAR(50) not null,
    Url NVARCHAR(500) not null,
    Icon NVARCHAR(20) not null,
    IsActive bit not NULL default 1,
     CreatedDate DATETIME not null DEFAULT GETDATE(),
    ModifiedDate DATETIME
);
GO
Insert INTO Socials (Name,Url,Icon)
VALUES
    ('GitHub','http://www.github.com','github'),
     ('LinkedIn','http://www.linkedin.com','linkedin'),
      ('Medium','http://www.medium.com','medium'),
       ('Instagram','http://www.instagram.com','instagram'),
        ('X','http://www.x.com','twitter-x')
GO
CREATE TABLE Skilss(
     Id int primary key IDENTITY,
    Name NVARCHAR(50) not null,
    Rate TINYINT not null,
    IsActive bit not NULL default 1,
     CreatedDate DATETIME not null DEFAULT GETDATE(),
    ModifiedDate DATETIME
)
GO
INSERT Into Skilss(Name,Rate)
VALUES
('HTML',100),
('CSS',90),
('JavaScript',85),
('AspNet Core MVC',95)
GO

CREATE TABLE Services(
     Id int primary key IDENTITY,
    Title NVARCHAR(50) not null,
    Descripton NVARCHAR(1000) not null,
    Icon NVARCHAR(20) not null,
    IsActive bit not NULL default 1,
     CreatedDate DATETIME not null DEFAULT GETDATE(),
    ModifiedDate DATETIME

)
GO

INSERT Into Services(Title,Descripton,Icon)
VALUES
('SEO Hizmeti', 'Arama Motoru Optimizasyonu','activity'),
('Web Uygulamaları','İsteğe Özel Web Uygulamaları Geliştirme','bounding-box-circles'),
('Server Yönetimi','Sunucuların oluşturulup bakım ve yönetimlerinin yapılması','calendar4-week'),
('SPA','Single Page Application uygulamalarının geliştirilmesi','brodcast')
GO

Create TABLE Categories(
     Id int primary key IDENTITY,
     Name NVARCHAR(50) not null,
     IsActive bit not NULL default 1,
     CreatedDate DATETIME not null DEFAULT GETDATE(),
     ModifiedDate DATETIME
)
GO
INSERT Into Categories(Name)
VALUES
('MVC'),('FrontEnd'),('API')
GO

CREATE TABLE Projects(
    Id int primary key IDENTITY,
     Name NVARCHAR(50) not null,
     Description NVARCHAR(200),
     GithubUrl NVARCHAR(500) not NULL,
     ImageUrl NVARCHAR(1000) not null,
     IsActive bit not NULL default 1,
     CreatedDate DATETIME not null DEFAULT GETDATE(),
     ModifiedDate DATETIME,
     CategoryId int FOREIGN key REFERENCES Categories(Id)
)
GO
Insert Into Projects (Name,Description,GithubUrl,ImageUrl)
VALUES
('Project1','Proje 1 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project1'),
('Project2','Proje 2 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project2'),
('Project3','Proje 3 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project3'),
('Project4','Proje 4 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project4'),
('Project5','Proje 5 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project5'),
('Project6','Proje 6 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project6'),
('Project7','Proje 7 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project7'),
('Project8','Proje 8 açıklaması','https://www.github.com','https://localhost:5100/ui/img/portfolio/project8')
GO
