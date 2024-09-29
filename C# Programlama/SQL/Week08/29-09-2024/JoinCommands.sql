-- Join: SQL'de tabloları İlişkili alanları tablolar üzerinden birleştirme işlemine join denir.

--Joint türleri:
/*
(inner) join: Birleştirilecek iki tablodaki eşleşen kayıtları bir araya getirir.
left join: sol taraftaki tablonun tüm kayıtlarını sağ taraftaki tablonun ise eşleşen kayıtlarını getirir.
right join: sağ taraftaki tablonun tüm kayıtlarını sağ taraftaki tablonun ise eşleşen kayıtlarını getirir.
outer (full) join: Birleştirilecek iki tablodaki eşleşen ya da eşleşmeyen tüm kayıları bir araya getirir.
*/

--Products ve Categories tabloların birleştirilmesini sağlayalım

-- SELECT 
--     p.ProductID as [Id],
--     p.ProductName as [Ürün Adı],
--     p.UnitPrice as [Fiyat],
--     c.CategoryName as [Kategori]
-- FROM Products p  JOIN Categories c on c.CategoryID = p.CategoryID 
-- --WHERE c.CategoryName = 'Beverages'

-- Yeni bir kategori Ekleyelim
-- INSERT Into Categories (CategoryName,[Description])
-- VALUES ('Televizyon', 'Televizyon ürünleri Burada')

-- Select * 
-- FROM Categories c left JOIN Products p  on p.CategoryID = c.CategoryID

--Ürünleri (ProductId, ProductName, UnitPrice) Supplier Company Name'leri ile birlikte listeleyelim

-- SELECT 
-- p.ProductID as [Ürün Id],
-- p.ProductName as [Ürün Adı],
-- p.UnitPrice as [Fiyat],
-- s.CompanyName as [Gönderen Şirket]
-- From Products p JOIN Suppliers s on p.SupplierID = s.SupplierID
-- ORDER BY [Gönderen Şirket]


--Ürünleri (ProductId, ProductName, UnitPrice) Category Name ve Supplier Company Name'leri ile birlikte listeleyelim

-- SELECT 
-- p.ProductID as [Ürün Id],
-- p.ProductName as [Ürün Adı],
-- c.CategoryName as [Kategori Adı],
-- p.UnitPrice as [Fiyat],
-- s.CompanyName as [Şirket]
-- FROM Categories c JOIN Products p JOIN Suppliers s on p.SupplierID = s.SupplierID on c.CategoryID = p.CategoryID
-- ORDER BY [Şirket]

--Hangi Sipariş Hangi Çalışan Tarafından, hangi müşteriye gerçekleştirilmiştir? 
--OrderID, OrderDate, Employee Name,Customer Name

-- SELECT 
-- o.OrderID as [Sipariş No],
-- o.OrderDate as [Sipariş Tarihi],
-- e.FirstName+ '  ' +e.LastName as [Çalışan Adı Soyadı],
-- c.CompanyName as [Müşteri]

-- FROM Orders o JOIN Employees e on o.EmployeeID = e.EmployeeID 
--                 JOIN Customers c on o.CustomerID = c.CustomerID

--Kategoriye göre ürün stok adedini gösterelim
-- SELECT
-- SUM(p.UnitsInStock)
-- FROM Products p join Categories c on p.CategoryID = c.CategoryID
-- GROUP BY c.CategoryName

--Hangi Ülkede kaç müşterim var

-- SELECT TOP(1)
-- c.Country AS [Ülke],
-- COUNT(*) AS [Müşteri Sayısı]
-- FROM Customers c 
-- GROUP BY c.Country
-- ORDER BY  [Müşteri Sayısı]  DESC

-- SELECT 
-- c.CategoryName as [Kategori],
-- COUNT(p.ProductID) as [Adet]
-- FROM Products p left Join Categories c on c.CategoryID = p.CategoryID
-- GROUP BY c.CategoryName

-- SELECT 
-- c.CategoryName as [Kategori],
-- COUNT(p.ProductID) as [Adet]
-- FROM Products p RIGHT Join Categories c on c.CategoryID = p.CategoryID
-- GROUP BY c.CategoryName

--Hangi Ülkeye ne kadarlık kargo harcaması yapmışız
-- SELECT
-- o.ShipCountry as [Ülke],
-- SUM(o.Freight) AS [Kargo Harcaması]
-- From Orders o 
-- GROUP BY o.ShipCountry

-- SELECT
--     o.ShipCountry as [Ülke],
--     SUM(od.UnitPrice*od.Quantity*(1-od.Discount))AS [Satış Tutarı]
-- From Orders o JOIN OrderDetails od on o.OrderID = od.OrderID
-- GROUP BY o.ShipCountry
-- ORDER BY  [Satış Tutarı] DESC
--Tutar kolonunda görüntüleyen sayının 18.810,05 şekilinde görünmesi için ne yapmalıyız ? 

-- Germany'den tedarik ettiğimiz ürünlerin toplam satış tutarı

-- SELECT 
-- SUM(od.UnitPrice*od.Quantity*(1-od.Discount))AS [Satış Tutarı]
-- From OrderDetails od JOIN Products p   on od.ProductID  = p.ProductID 
--     JOIN Suppliers s on s.SupplierID = p.SupplierID 
--     WHERE s.Country = 'Germany'

--Germany den tedarik edilen ürünlerin toplam satış tutarını bulunuz.

-- SELECT
--     c.CategoryName as [Kategori],
--     SUM(od.UnitPrice*od.Quantity*(1-od.Discount))AS [Satış Tutarı]
-- FROM OrderDetails od JOIN Products p ON od.ProductID = p.ProductID
--     JOIN Suppliers s on p.SupplierID = s.SupplierID
--     JOIN Categories c on p.CategoryID = c.CategoryID
-- WHERE s.Country = 'Germany'
-- GROUP BY c.CategoryName
-- HAVING SUM(od.UnitPrice*od.Quantity*(1-od.Discount)) > 2000
-- ORDER BY [Satış Tutarı] DESC

--Bölgelere Göre Satış Tutarı

-- SELECT

--     FORMAT(SUM(od.UnitPrice*od.Quantity*(1-od.Discount)), 'N2','tr-TR')AS [Satış Tutarı],
--     reg.RegionDescription As [Bölgeler]
-- FROM OrderDetails od JOIN Orders o on Od.OrderID = o.OrderID
--     JOIN Employees em on em.EmployeeID = o.EmployeeID
--     JOIN EmployeeTerritories emt on em.EmployeeID = emt.EmployeeID
--     JOIN Territories t on emt.TerritoryID= t.TerritoryID
--     JOIN Region reg on t.RegionID = reg.RegionID
-- GROUP BY reg.RegionDescription
-- ORDER BY [Bölgeler]

-- Hangi Çalışanın Hangi Kategoriden, ne kadar satış yaptı ?

-- SELECT
--     e.FirstName AS [Çalışan],
--     c.CategoryName AS [Kategori],
--     SUM(od.UnitPrice*od.Quantity*(1-od.Discount))AS [Satış Tutarı]
-- FROM Employees e JOIN Orders O ON e.EmployeeID = O.EmployeeID
--     JOIN OrderDetails od ON od.OrderID = O.OrderID
--     JOIN Products p ON p.ProductID = od.ProductID
--     JOIN Categories c ON p.CategoryID = c.CategoryID

-- GROUP BY c.CategoryName, e.FirstName
-- ORDER BY e.FirstName, c.CategoryName

-----------------------------------------------

-- SELECT
--     cu.CompanyName as [Müşteri],
--     c.CategoryName AS [Kategori],
--     SUM(od.UnitPrice*od.Quantity*(1-od.Discount))AS [Satış Tutarı]
-- FROM Customers cu JOIN Orders O ON cu.CustomerID = O.CustomerID
--     JOIN OrderDetails od ON od.OrderID = O.OrderID
--     JOIN Products p ON p.ProductID = od.ProductID
--     JOIN Categories c ON p.CategoryID = c.CategoryID

-- GROUP BY c.CategoryName, cu.CompanyName
-- ORDER BY cu.CompanyName, c.CategoryName


--1997 Yılının Mart Ayında Yapılan Satışları listeleyelim

-- SELECT *
-- FROM Orders
-- WHERE OrderDate BETWEEN '1997-03-01' AND '1997-03-31' 

--Chai 1997 Yılının Mart Ayında Yapılan Satışları listeleyelim

SELECT
*
FROM Orders o Join OrderDetails od on o.OrderID = od.OrderID
Join Products p on od.ProductID = p.ProductID
WHERE o.OrderDate BETWEEN '1997-3-1' AND '1997-5-31' AND p.ProductName = 'Chai'
