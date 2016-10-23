CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [lastName] NCHAR(10) NOT NULL, 
    [firstName] NCHAR(10) NOT NULL, 
    [email] NCHAR(10) NULL, 
    [address] NCHAR(10) NULL, 
    [phoneNumber] NCHAR(10) NULL
)
