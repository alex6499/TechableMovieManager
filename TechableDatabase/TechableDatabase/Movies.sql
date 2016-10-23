CREATE TABLE [dbo].[Movies]
(
	[movieId] INT NOT NULL PRIMARY KEY, 
    [quantityTotal] INT NOT NULL, 
    [quantityAvailable] INT NOT NULL, 
	[upc] INT NOT NULL,
    [name] NCHAR(10) NULL, 
    [date] DATE NULL, 
    [director] NCHAR(10) NULL, 
)