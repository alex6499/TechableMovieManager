GO
CREATE TABLE [dbo].[Movies]
(
	[movieId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NCHAR(40) NULL, 
    [year] INT NULL, 
    [studio] NCHAR(40) NULL, 
    [deleted] BIT NOT NULL, 
	[timesRented] INT NOT NULL
)
