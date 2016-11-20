CREATE TABLE [dbo].[Copies]
(
	[upc] NCHAR(40) NOT NULL PRIMARY KEY,
	[movieId] INT NOT NULL,
	FOREIGN KEY (movieId)
		REFERENCES Movies (movieId),
	[available] BIT NOT NULL,
	[deleted] BIT NOT NULL
)
