--Veritabanı Yaratma İşlemi başlıyor
USE master

Drop DATABASE IF EXISTS Okul

Create DATABASE Okul
-- Veritabanı Yaratma İşlemi bitti
USE Okul
-- Tabloları Yaratma İşlemi başlıyor
Create TABLE Bolumler
(
    BolumID int PRIMARY key IDENTITY(1,1),
    BolumAdi NVARCHAR(50) not null
);

Create Table Dersler
(
    DersID INT PRIMARY KEY IDENTITY(1,1),
    DersAdi NVARCHAR(100) not null,
    Kredi TINYINT NOT NULL,
    BolumID INT NOT NULL ,
    FOREIGN KEY (BolumID) REFERENCES Bolumler (BolumID)
);

CREATE TABLE Ogrenciler
(
    OgrenciID INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    DogumTarihi DATE NULL,
    BolumID INT NOT NULL,
    FOREIGN KEY (BolumID) REFERENCES Bolumler(BolumID)
);

CREATE TABLE DersKayitlari(
    OgrenciID INT,
    DersID INT,
    PRIMARY KEY(OgrenciID,DersID),
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler (OgrenciID),
    FOREIGN KEY (DersID) REFERENCES Dersler (DersID)
);
-- Tabloları Yaratma İşlemi bitti

-- Veri Ekleme İşlemi başlıyor
INSERT INTO Bolumler(BolumAdi)
VALUES
('Bilgisayar Mühendisliği'),
('Hukuk'),
('Mekatronik Mühendisliği')

INSERT INTO Dersler (DersAdi, Kredi, BolumID)
VALUES
('Temel Programlama', 4, 1),
('Web Geliştirme', 8, 1),
('Veritabanı', 3, 1),
('Temel Hukuk', 6, 1),
('Anayasa Hukuku', 10, 2),
('Malzeme Bilimi', 3, 3)

INSERT INTO Ogrenciler (Ad, Soyad, DogumTarihi, BolumID)
VALUES
('Alican','Kintutar','2000-05-19',1),
('Seden','Serdengeçen','1998-06-12',1),
('Candan','Tutankaçan','1985-03-19',2),
('Kemal','Evrim','1996-07-16',3)

INSERT INTO DersKayitlari(OgrenciID, DersID)
VALUES
(1,1),(1,2),(1,3),

(2,3),

(3,4),(3,5),

(4,1)
-- Veri Ekleme İşlemi bitti

