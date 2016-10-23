CREATE TABLE [dbo].[Rentals]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [movieId] INT NOT NULL, 
	FOREIGN KEY (movieId)
		REFERENCES Movies (movieId),
    [customerId] INT NOT NULL,
	FOREIGN KEY (customerId)
		REFERENCES Customers (customerId),
	[dueDate] DATE NULL, 
    [fine] MONEY NULL
	
)
