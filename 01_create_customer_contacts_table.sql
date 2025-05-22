USE [ErpDB];
GO

-- Create the table
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'CustomerContacts'
)
BEGIN
    CREATE TABLE [dbo].[CustomerContacts] (
        [Id] INT IDENTITY(1,1) PRIMARY KEY,
        [FirstName] NVARCHAR(20) NOT NULL,
        [LastName] NVARCHAR(MAX) NULL,
        [PhoneNo] BIGINT NULL,
        [WhatsAppNo] BIGINT NULL,
        [Status] BIT NOT NULL,
        [IsPhoneVerified] BIT NOT NULL,
        [Description] NVARCHAR(MAX) NULL,
        [Address] NVARCHAR(MAX) NULL,
        [Email] NVARCHAR(MAX) NULL,
        [CreatedDate] DATETIME2 NOT NULL,
        [CreatedDateUtc] DATETIME2 NOT NULL,
        [UpdatedDate] DATETIME2 NULL,
        [UpdatedDateUtc] DATETIME2 NULL,
        [CreatedBy] NVARCHAR(MAX) NOT NULL,
        [UpdatedBy] NVARCHAR(MAX) NOT NULL
    );
END
GO


-- Create the filtered unique index
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'UX_CustomerContacts_PhoneNo'
      AND object_id = OBJECT_ID('dbo.CustomerContacts')
)
BEGIN
    CREATE UNIQUE INDEX [UX_CustomerContacts_PhoneNo]
    ON [dbo].[CustomerContacts] ([PhoneNo])
    WHERE [PhoneNo] IS NOT NULL;
END
GO
