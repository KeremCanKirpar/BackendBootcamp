-- SELECT GETDATE()
-----------------------------------------------
--1960 ve Sonrasında Doğan Çalışanlar
-- SELECT *
-- FROM Employees e 
-- WHERE YEAR(e.BirthDate)>= 1960
-----------------------------------------------
-- SELECT *
-- FROM Employees e 
-- WHERE MONTH(GETDATE())=MONTH(e.BirthDate)

--Her ayın 8 i ve sonrasında işe başlayanlar

SELECT *
FROM Employees e 
WHERE DAY(e.HireDate)>=8