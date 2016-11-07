GO
CREATE TABLE [dbo].[Rentals]
(
	[rentalId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [movieId] INT NOT NULL, 
	FOREIGN KEY (movieId)
		REFERENCES Movies (movieId),
    [customerId] INT NOT NULL,
	FOREIGN KEY (customerId)
		REFERENCES Customers (customerId),
	[employeeId] INT NOT NULL,
	FOREIGN KEY (employeeId)
		REFERENCES Employees (employeeId),
	[dueDate] DATE NOT NULL, 
    [fine] MONEY NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The movie rented',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Rentals',
    @level2type = N'COLUMN',
    @level2name = N'movieId'
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
    @level2name = N'employeeId'
GO
CREATE SEQUENCE seq_rentals_id as int
MINVALUE 100
START WITH 100
INCREMENT BY 1