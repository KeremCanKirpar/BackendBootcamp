-- Önce burayı çalıştır
-- Tüm constarintleri sil (foreign key)
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'ALTER TABLE [' + OBJECT_SCHEMA_NAME(parent_object_id) + '].[' + OBJECT_NAME(parent_object_id) + '] DROP CONSTRAINT [' + name + '];' + CHAR(13)
FROM sys.foreign_keys;

EXEC sp_executesql @sql;



-- Sonra burayı çalıştır
-- Tüm tabloları sil
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP TABLE [' + SCHEMA_NAME(schema_id) + '].[' + name + '];'
FROM sys.tables;

EXEC sp_executesql @sql;




