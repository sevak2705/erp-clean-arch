-- Create database named ErpDB
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ErpDB')
BEGIN
    CREATE DATABASE [ErpDB];
END
GO