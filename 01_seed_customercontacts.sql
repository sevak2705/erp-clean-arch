USE [ErpDB];
GO

INSERT INTO [dbo].[CustomerContacts] (
    [FirstName],
    [LastName],
    [PhoneNo],
    [WhatsAppNo],
    [Status],
    [IsPhoneVerified],
    [Description],
    [Address],
    [Email],
    [CreatedDate],
    [CreatedDateUtc],
    [UpdatedDate],
    [UpdatedDateUtc],
    [CreatedBy],
    [UpdatedBy]
)
VALUES
(
    N'Rahul',                -- FirstName
    N'Sharma',               -- LastName
    9876543210,              -- PhoneNo
    9876543210,              -- WhatsAppNo
    1,                       -- Status (1 = true)
    1,                       -- IsPhoneVerified
    N'First customer seed',  -- Description
    N'123 Main Street',      -- Address
    N'rahul.sharma@email.com', -- Email
    SYSDATETIME(),           -- CreatedDate
    SYSUTCDATETIME(),        -- CreatedDateUtc
    NULL,                    -- UpdatedDate
    NULL,                    -- UpdatedDateUtc
    N'seed-script',          -- CreatedBy
    N'seed-script'           -- UpdatedBy
),
(
    N'Priya',                -- FirstName
    N'Verma',                -- LastName
    9123456780,              -- PhoneNo
    9123456780,              -- WhatsAppNo
    1,                       -- Status
    0,                       -- IsPhoneVerified
    N'Second customer seed', -- Description
    N'456 Lake Road',        -- Address
    N'priya.verma@email.com', -- Email
    SYSDATETIME(),           -- CreatedDate
    SYSUTCDATETIME(),        -- CreatedDateUtc
    NULL,                    -- UpdatedDate
    NULL,                    -- UpdatedDateUtc
    N'seed-script',          -- CreatedBy
    N'seed-script'           -- UpdatedBy
);
GO
