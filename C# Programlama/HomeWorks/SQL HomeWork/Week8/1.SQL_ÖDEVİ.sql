USE Northwind

--1.SORGU
--Tüm ürünlerin adlarını ve birim fiyatlarını listeleyin.
SELECT p.ProductName, p.UnitPrice
FROM Products p

--2.SORGU
--Müşterilerin şirket adlarını ve bulundukları şehirleri alfabetik sırayla listeleyin.

SELECT c.CompanyName, c.City
FROM Customers c
ORDER BY c.CompanyName ASC

--3.SORGU
--Çalışanların ad ve soyadlarını birleştirerek tam isimlerini listeleyin.

SELECT
    e.FirstName +' '+e.LastName AS [AdSoyad]
FROM Employees e

--4.SORGU
--Stok miktarı 10'dan az olan ürünleri listeleyin.

SELECT *
FROM Products p
WHERE p.UnitsInStock<10

--5.SORGU
--1998 yılında yapılan siparişleri listeleyin.

SELECT *
FROM Orders o
WHERE o.OrderDate = '1998'

--6.SORGU
--Her bir kategorideki ürün sayısını bulun.

SELECT
    c.CategoryName,
    COUNT(p.CategoryID) AS [Ürün Sayısı]
FROM Categories c
    JOIN Products p ON p.CategoryID=c.CategoryID
GROUP BY c.CategoryName

--7.SORGU
--En pahalı 5 ürünü fiyatlarıyla birlikte listeleyin.
SELECT TOP 5
    P.ProductName, P.UnitPrice
FROM Products p
ORDER BY P.UnitPrice DESC

--8.SORGU
--Her bir ülkedeki müşteri sayısını bulun ve müşteri sayısına göre azalan sırayla listeleyin.

SELECT c.Country,
    COUNT(C.CustomerID) AS [Müşteri Sayısı]
FROM Customers c
GROUP BY c.Country
ORDER BY [Müşteri Sayısı] DESC

--9.SORGU
--Nakliye ücreti 50'den fazla olan siparişleri listeleyin.
SELECT
    o.OrderID,
    o.Freight

FROM Orders o
WHERE o.Freight>50

--10.SORGU
--Her bir çalışanın toplam sipariş sayısını bulun.

SELECT
    e.EmployeeID,
    e.FirstName +' '+ e.LastName as [Çalışan AdSoyad],
    COUNT(o.OrderID) AS [SİPARİŞ SAYISI]
FROM Employees e
    JOIN Orders o ON o.EmployeeID=e.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
ORDER BY e.EmployeeID

--11.SORGU
-- Ürünleri kategorileriyle birlikte listeleyin.
SELECT
    p.ProductName,
    c.CategoryName
FROM Products p
    JOIN Categories c ON P.CategoryID = c.CategoryID

--12.SORGU 
--Her bir siparişin toplam tutarını hesaplayın.
SELECT od.OrderID,
    SUM(od.UnitPrice*od.Quantity) AS [TOP TUTAR]
FROM OrderDetails od
GROUP BY od.OrderID

--13.SORGU
--En çok satılan 5 ürünü ve satış miktarlarını listeleyin.
SELECT TOP 5
    p.ProductID,
    P.ProductName,
    od.Quantity AS [Satılan Ürün Mik],
    od.UnitPrice

FROM Products p
    JOIN OrderDetails od ON OD.ProductID = P.ProductID
GROUP BY p.ProductID,p.ProductName,od.UnitPrice,od.Quantity
ORDER BY [Satılan Ürün Mik] DESC

--14.SORGU
--Her bir müşterinin verdiği sipariş sayısını bulun.
SELECT
    c.CustomerID ,
    COUNT(o.OrderID) AS [sipariş Sayısı]

FROM Customers c
    JOIN Orders o ON C.CustomerID = O.CustomerID
GROUP BY c.CustomerID

--15.SORGU
--Hangi kargo şirketinin kaç sipariş taşıdığını listeleyin.

SELECT
    s.CompanyName,
    COUNT(o.OrderID) AS [Taşıdığı Sirapiş Sayısı]
FROM Shippers s
    JOIN Orders o ON s.ShipperID= o.ShipVia
GROUP BY S.CompanyName
ORDER BY [Taşıdığı Sirapiş Sayısı] DESC

--16.SORGU
--Her bir çalışanın toplam satış tutarını hesaplayın.
SELECT
    e.EmployeeID,
    e.FirstName +' '+e.LastName AS [Çalışan AdSoyad],
    SUM(od.UnitPrice*od.Quantity*(1-od.Discount)) AS [Yapılan Sayış Tutarı]

FROM Employees e
    JOIN Orders o ON O.EmployeeID=E.EmployeeID
    JOIN OrderDetails od ON o.OrderID = od.OrderID
GROUP BY e.EmployeeID,e.FirstName,e.LastName
ORDER BY [Yapılan Sayış Tutarı] DESC


--17.SORGU
--Her bir kategorideki ürünlerin ortalama fiyatını bulun.

SELECT
    c.CategoryName,
    AVG(p.UnitPrice) AS [ortalama fiyatları]

FROM Categories c
    JOIN Products p ON P.CategoryID = C.CategoryID

GROUP BY c.CategoryName

--18.SORGU
--En az 5 sipariş veren müşterileri ve sipariş sayılarını listeleyin.

SELECT TOP 5
    c.CustomerID,
    COUNT(O.OrderID) AS [SİPARİŞ SAYISI]
FROM Customers c
    JOIN Orders o ON o.CustomerID=c.CustomerID
GROUP BY C.CustomerID
ORDER BY COUNT (O.OrderID) ASC

--19.SORGU
--Her bir ülke için toplam satış tutarını hesaplayın.
SELECT
    c.Country,
    SUM(od.UnitPrice*od.Quantity) AS [TOP SATIŞ TUTARI]
FROM Customers C
    JOIN Orders o on o.CustomerID=c.CustomerID
    JOIN OrderDetails od ON  o.OrderID = od.OrderID
GROUP BY c.Country

--20.SORGU
--Siparişleri, sipariş tarihine göre yıllar ve aylar bazında gruplayarak toplam satış tutarlarını listeleyin. 

SELECT
    YEAR(o.OrderDate) AS [YIL],
    MONTH(o.OrderDate) AS [AY],
    SUM(od.UnitPrice*od.Quantity*(1-od.Discount)) AS [Satış Tutarı]
FROM Orders o
    JOIN OrderDetails od ON o.OrderID=od.OrderID
GROUP BY  YEAR(o.OrderDate),MONTH(o.OrderDate)




    




    
      

















