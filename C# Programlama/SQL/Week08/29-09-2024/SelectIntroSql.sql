-- SELECT CategoryName, [Description] FROM Categories
-- Products tablosundaki tüm kayıların ProductID, Product Name, UnitInStock, UnitPrice kolonlarını geri döndürün

-- SELECT 
--     p.ProductID AS Id, 
--     p.ProductName 'Ürün Adı',
--     p.UnitsInStock 'Stok Adedi', 
--     p.UnitPrice AS 'Birim Fiyatı' 
-- FROM Products p

-- En yüksek Fiyatı Bulalım

-- SELECT
-- MAX(p.UnitPrice) as 'En Yüksek Fiyat',
-- MIN(p.UnitPrice) as 'En Düşük Fiyat',
-- AVG(p.UnitPrice) as 'Ortalama',
-- COUNT(p.UnitPrice) as [Ürün Sayısı],
-- SUM(p.UnitPrice*p.UnitsInStock) as [Toplam]
-- From Products p

-- SELECT
-- p.ProductName as [Default],
-- UPPER(p.ProductName) as [Büyük Harf],
-- LOWER(p.ProductName) as [Küçük Harf],
-- LOWER(REPLACE(REPLACE(p.ProductName,' ','_'),'?','')) AS [Url]
-- FROM Products p


SELECT *
FROM Products p
--WHERE p.UnitPrice >=40 AND p.UnitPrice<=100
WHERE p.UnitPrice BETWEEN 40 and 100
ORDER BY p.CategoryID,p.UnitPrice