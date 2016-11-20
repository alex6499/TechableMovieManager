GO
CREATE TABLE [dbo].[Rentals]
(
	[rentalId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [upc] NCHAR(40) NOT NULL, 
	FOREIGN KEY (upc)
		REFERENCES Copies ([upc]),
    [customerId] INT NOT NULL,
	FOREIGN KEY (customerId)
		REFERENCES Customers (customerId),
	[userName] NCHAR(40) NOT NULL,
	FOREIGN KEY (userName)
		REFERENCES Employees (userName),
	[dueDate] DATE NOT NULL, 
    [returned] BIT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The movie rented',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Rentals',
    @level2type = N'COLUMN',
    @level2name = N'upc'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Customer who the movie is rented to.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Rentals',
    @level2type = N'COLUMN',
    @level2name = N'customerId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Employee that rented out movie',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Rentals',
    @level2type = N'COLUMN',
    @level2name = N'userName'
