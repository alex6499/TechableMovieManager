CREATE TABLE [dbo].[Copies]
(
	[copyId] INT NOT NULL PRIMARY KEY,
	[movieId] INT NOT NULL,
	FOREIGN KEY (movieId)
		REFERENCES Movies (movieId),
	[upc] INT NOT NULL,
	UNIQUE (upc),
	[available] BIT NOT NULL,
	[deleted] BIT NOT NULL
)
