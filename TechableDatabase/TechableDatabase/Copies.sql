CREATE TABLE [dbo].[Copies]
(
	[upc] INT NOT NULL PRIMARY KEY,
	[movieId] INT NOT NULL,
	FOREIGN KEY (movieId)
		REFERENCES Movies (movieId),
	[available] BIT NOT NULL,
	[deleted] BIT NOT NULL
)
