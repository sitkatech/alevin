
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'ReclamationOneTimeImport')
BEGIN
    exec ('CREATE SCHEMA ReclamationOneTimeImport')
END

IF OBJECT_ID('dbo.BocCleaned') IS NOT NULL
BEGIN
    ALTER SCHEMA ReclamationOneTimeImport TRANSFER dbo.BocCleaned;
END