USE master
CREATE DATABASE OgrenciKulupleriYonetimi
USE OgrenciKulupleriYonetimi

CREATE TABLE Kulüpler
(
    KulupID INT PRIMARY KEY IDENTITY (1,1),
    KulupAdi NVARCHAR(70) NOT NULL,
    KurulusYili INT NOT NULL
)

CREATE TABLE OgrenciKulup
(
    OgrencıID INT PRIMARY KEY IDENTITY (1,1),
    Rol NVARCHAR(50) NOT NULL,
    KatilimTarihi DATE NOT NULL,
    KulupID INT,
    FOREIGN KEY (KulupID) REFERENCES Kulüpler(KulupID)
)

INSERT INTO Kulüpler
    (KulupAdi, KurulusYili)
VALUES
    ('Tiyatro Kulübü', 2010),
    ('Müzik Kulübü', 2012),
    ('Spor Kulübü', 2015),
    ('Bilim Kulübü', 2018),
    ('Sanat Kulübü', 2020);

INSERT INTO OgrenciKulup
    (KulupID, Rol, KatilimTarihi)
VALUES
    (1, 'Başkan', '2021-09-01'),
    (1, 'Üye', '2022-01-15'),
    (1, 'Sekreter', '2023-05-10'),

    (2, 'Başkan', '2020-10-01'),
    (2, 'Üye', '2021-02-20'),
    (2, 'Sekreter', '2022-11-15'),

    (3, 'Başkan', '2019-08-30'),
    (3, 'Üye', '2020-03-10'),
    (3, 'Sekreter', '2021-12-05'),

    (4, 'Başkan', '2022-05-01'),
    (4, 'Üye', '2022-09-15'),
    (4, 'Sekreter', '2023-01-20'),

    (5, 'Başkan', '2023-03-01'),
    (5, 'Üye', '2023-06-15'),
    (5, 'Sekreter', '2023-09-01');

--SORGULAR--
-- 3.
-- **
-- Sorgular:
-- ** Aşağıdaki işlemleri
-- yapın:

--1 -  Tüm kulüp üyelerinin adlarını, soyadlarını ve hangi kulüpte yer aldıklarını listeleyin.
-- (`JOIN`)
SELECT o.OgrencıID, o.Rol, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID;


--2       -  "Tiyatro Kulübü" üyelerini ve rollerini listeleyin.
-- (`WHERE` ve `JOIN`)
SELECT o.OgrencıID, o.Rol, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
WHERE k.KulupAdi = 'Tiyatro Kulübü';


--3      -  Tüm kulüplerde başkan olarak görev yapan öğrencileri listeleyin.
-- (`WHERE`)
SELECT o.OgrencıID, o.Rol, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
WHERE o.Rol = 'Başkan';


--4       -  Her kulübün kaç üyesi olduğunu listeleyin.
-- (`GROUP BY` ve `COUNT`)
SELECT k.KulupAdi, COUNT(o.OgrencıID) AS UyeSayisi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
GROUP BY k.KulupAdi;

--5       -  Kuruluş yılı en eski olan kulübün üyelerini listeleyin.
-- (`ORDER BY` ve `JOIN`)

SELECT o.OgrencıID, o.Rol, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
WHERE k.KurulusYili = (SELECT MIN(KurulusYili)
FROM Kulüpler);


-- 6      -  Öğrencilerin hangi tarihte hangi kulübe katıldıklarını listeleyin.
-- (`
-- SELECT` ve
-- `JOIN`)

SELECT o.OgrencıID, o.KatilimTarihi, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
ORDER BY o.KatilimTarihi;


--7      -  "Müzik Kulübü"nde bulunan tüm rollerin bir listesini çıkarın.
-- (`WHERE` ve `DISTINCT`)

SELECT DISTINCT o.Rol
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
WHERE k.KulupAdi = 'Müzik Kulübü';



-- 8     -  Her kulüpte kaç başkan olduğunu gruplandırarak listeleyin.
-- (`GROUP BY` ve `COUNT`)

SELECT k.KulupAdi, COUNT(o.OgrencıID) AS BaskanSayisi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
WHERE o.Rol = 'Başkan'
GROUP BY k.KulupAdi;


-- 9      -  Hangi öğrenci en son hangi kulübe katılmış, bu bilgiyi listeleyin.
-- (`JOIN` ve `ORDER BY`)

SELECT o.OgrencıID, o.KatilimTarihi, k.KulupAdi
FROM OgrenciKulup o
    JOIN Kulüpler k ON o.KulupID = k.KulupID
ORDER BY o.KatilimTarihi DESC



-- 10     -  Birden fazla kulüpte yer alan öğrencileri ve katıldıkları kulüpleri listeleyin.
-- (`GROUP BY` ve `HAVING`)

SELECT o.OgrencıID, COUNT(o.KulupID) AS KulupSayisi
FROM OgrenciKulup o
GROUP BY o.OgrencıID
HAVING COUNT(o.KulupID) > 1;






