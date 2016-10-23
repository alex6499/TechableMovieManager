CREATE TABLE [dbo].[Movies]
(
	[upc] INT NOT NULL PRIMARY KEY, 
    [quantityTotal] INT NOT NULL, 
    [quantityAvailable] INT NOT NULL, 
    [name] NCHAR(10) NULL, 
    [date] DATE NULL, 
    [director] NCHAR(10) NULL
)