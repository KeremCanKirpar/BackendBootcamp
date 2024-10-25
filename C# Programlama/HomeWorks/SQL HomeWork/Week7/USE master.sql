USE master
CREATE DATABASE kutuphane
USE kutuphane

CREATE TABLE Kitaplar
(
    KitapID INT PRIMARY KEY IDENTITY (1,1),
    KitapAdi NVARCHAR(50) NOT NULL,
    Yazar NVARCHAR(50) NOT NULL,
    YayınYılı INT NOT NULL,
    SayfaSayisi SMALLINT NOT NULL,
    ISBN INT NOT NULL
)

CREATE TABLE Dergiler
(
    DergiID INT PRIMARY KEY IDENTITY (1,1),
    DergiAdi NVARCHAR(50) NOT NULL,
    Yayınci NVARCHAR(70) NOT NULL,
    YayınTarihi DATE NULL,
    Sayı INT NOT NULL,
)

CREATE TABLE DVDler
(
    DVDID INT PRIMARY KEY IDENTITY (1,1),
    DVDAdi NVARCHAR(50),
    Yönetmen NVARCHAR(50),
    YayınYılı INT NOT NULL,
    Süre TIME NOT NULL,
)

CREATE TABLE Ogrenciler
(
    OgrenciID INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
)

CREATE TABLE OduncAlmalar
(
    OduncID INT PRIMARY KEY IDENTITY (1,1),
    OgrenciID INT NOT NULL,
    KitapID INT,
    DergiID INT,
    DVDID INT,
    OduncTarihi DATE,
    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID),
    FOREIGN KEY (KitapID) REFERENCES Kitaplar(KitapID),
    FOREIGN KEY (DergiID) REFERENCES Dergiler(DergiID),
    FOREIGN KEY (DVDID) REFERENCES DVDler(DVDID),
)

INSERT INTO Kitaplar
    (KitapAdi,Yazar,YayınYılı,SayfaSayisi,ISBN)
VALUES
    ('Oğullar ve Rencide Ruhlar', 'Alper Canıgüz', 2004, 226, 9786254),
    ('gün olur asra bedel', 'Cengiz Aytmatov', 1991, 419, 9789754),
    ('Ateşten Gömlek', 'Halide Edib Adıvar', 1923, 204, 9789750),
    ('ÜÇ ANADOLU EFSANESİ', 'Yaşar Kemal', 1967, 222, 9789750),
    ('Agathanın Anahtarı', 'Ahmet Ümit', 1999, 142, 9789752),
    ('Bir Çöküşün Öyküsü', 'Halit Ziya Uşaklıgil', 1921, 280, 9786055),
    ('İstanbul Hatırası', 'Ahmet Ümit', 2009, 432, 9786051),
    ('Çalıkuşu', 'Reşat Nuri Güntekin', 1922, 300, 9789755),
    ('Aylak Adam', 'Yusuf Atılgan', 1959, 150, 9789759),
    ('Saatleri Ayarlama Enstitüsü', 'Ahmet Hamdi Tanpınar', 1961, 340, 9786052),
    ('Huzur', 'Ahmet Hamdi Tanpınar', 1948, 290, 9786051),
    ('Küçük Gül', 'İskender Pala', 2014, 140, 9786058),
    ('Kara Kitap', 'Orhan Pamuk', 1990, 600, 9789750),
    ('Kürk Mantolu Madonna', 'Sabahattin Ali', 1943, 120, 9786053),
    ('Bülbülü Öldürseler', 'A. Turgut Özakman', 1990, 300, 9789753),
    ('Sinekli Bakkal', 'Halide Edib Adıvar', 1912, 250, 9789753),
    ('Yalnızım', 'A. H. Tanpınar', 1938, 210, 9789753),
    ('Eylüller', 'Nihal Atsız', 1944, 300, 9789751),
    ('Küçük Mucizeler', 'M. N. Korkmaz', 2010, 250, 9786058),
    ('Düşünen Adam', 'Orhan Veli Kanık', 1938, 150, 9789758);


INSERT INTO Dergiler
    (DergiAdi,Yayınci,YayınTarihi,Sayı)
VALUES
    ('National Geographic Türkiye', 'National Geographic Society', '2023', 1),
    ('Popular Science Türkiye', 'Güzel Sanatlar Yayınları', '2023', 2),
    ('Kültür ve Sanat', 'İstanbul Kültür Sanat Vakfı', '2023', 3),
    ('Hayvanlar Alemi', 'Hayvanları Koruma Derneği', '2023', 4),
    ('Cine4', 'Cine4 Yayınları', '2023', 5);

INSERT INTO DVDler
    (DVDAdi,Yönetmen,YayınYılı,Süre)
VALUES
    ('Inception', 'Christopher Nolan', 2010, '02:28:00'),
    ('The Godfather', 'Francis Ford Coppola', 1972, '02:55:00'),
    ('Pulp Fiction', 'Quentin Tarantino', 1994, '02:34:00'),
    ('The Shawshank Redemption', 'Frank Darabont', 1994, '02:22:00'),
    ('The Dark Knight', 'Christopher Nolan', 2008, '02:32:00');

INSERT INTO Ogrenciler
    (Ad,Soyad)
VALUES
    ('Ahmet', 'Yılmaz'),
    ('Elif', 'Kara'),
    ('Mehmet', 'Öztürk'),
    ('Zeynep', 'Demir'),
    ('Emre', 'Çelik');

INSERT INTO OduncAlmalar
    (OgrenciID,DergiID,DVDID,KitapID,OduncTarihi)
VALUES
    (1, 2, 3, 2, '2020-02-02'),
    (3, 3, 2, 8, '2020-02-02'),
    (2, 5, 4, 14, '2020-02-02'),
    (4, 4, 1, 13, '2020-02-02'),
    (5, 1, 5, 20, '2020-02-02'),
    (5, 1, 5, 20, '2020-02-02');

--1.Sorgu
SELECT KitapAdi, Yazar, YayınYılı
FROM Kitaplar
;


--2.Sorgu
SELECT KitapAdi, Yazar
FROM Kitaplar
WHERE YayınYılı>2000;

--3.Sorgu
SELECT ogr.Ad, ogr.Soyad, ktp.KitapAdi
FROM Ogrenciler ogr
    JOIN Kitaplar Ktp ON ogr.OgrenciID=ktp.KitapID;

--4.Sorgu
SELECT TOP 5
    ktp.SayfaSayisi
FROM Kitaplar ktp

ORDER BY ktp.SayfaSayisi DESC;

--5.Sorgu
SELECT ktp.Yazar, ktp.KitapAdi
FROM Kitaplar ktp
WHERE ktp.Yazar = 'Orhan Pamuk';

--6.Sorgu
SELECT ogr.Ad, ogr.Soyad, drg.DergiAdi, drg.Yayınci
FROM Ogrenciler ogr
    JOIN Dergiler drg on ogr.OgrenciID=drg.DergiID


--8.Sorgu
SELECT TOP 3
    Ktp.YayınYılı
FROM Kitaplar Ktp
ORDER BY Ktp.YayınYılı ASC

--9.Sorgu

    SELECT ktp.KitapAdi AS 'Kitap', COUNT(*) AS 'Toplam'
    FROM Kitaplar ktp
        JOIN OduncAlmalar odnc ON ktp.KitapID=odnc.KitapID
    GROUP BY ktp.KitapAdi

UNION

    SELECT drg.DergiAdi AS 'Dergi', COUNT(*) AS 'Toplam'
    FROM Dergiler drg
        JOIN OduncAlmalar odnc ON odnc.DergiID=drg.DergiID
    GROUP BY drg.DergiAdi

UNION

    SELECT dvd.DVDAdi AS 'DVD', COUNT(*) AS 'Toplam'
    FROM DVDler dvd
        JOIN OduncAlmalar odnc ON odnc.DVDID=dvd.DVDID
    GROUP BY dvd.DVDAdi

--10.Sorgu

SELECT ogr.Ad, ogr.Soyad, odn.DergiID, odn.DVDID, odn.KitapID
from Ogrenciler ogr
    JOIN OduncAlmalar odn ON  ogr.OgrenciID=odn.OduncID

WHERE ogr.Ad +' '+ ogr.Soyad ='Ahmet Yılmaz';






     
     
                    






    




   
   

    


















 