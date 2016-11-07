GO
CREATE TABLE [dbo].[Movies]
(
	[movieId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [available] BIT NOT NULL, 
	[upc] INT NOT NULL,
    [name] NCHAR(70) NULL, 
    [date] DATE NULL, 
    [director] NCHAR(40) NULL, 
    [deleted] BIT NOT NULL, 
)
