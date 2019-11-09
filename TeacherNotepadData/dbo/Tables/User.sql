CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NUlL PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL, 
	[SecondName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [TelephoneNumber] VARCHAR(60) NULL, 
    [Country] NVARCHAR(50) NULL, 
	[City] NVARCHAR(50) NULL, 
    [StreetAddress] NVARCHAR(400) NULL,
    [Image] IMAGE NULL    
)
