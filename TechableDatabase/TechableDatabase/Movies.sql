GO
CREATE TABLE [dbo].[Movies]
(
	[movieId] INT NOT NULL PRIMARY KEY, 
    [quantityTotal] INT NOT NULL, 
    [quantityAvailable] INT NOT NULL, 
	[upc] INT NOT NULL,
    [name] NCHAR(70) NULL, 
    [date] DATE NULL, 
    [director] NCHAR(40) NULL, 
)
