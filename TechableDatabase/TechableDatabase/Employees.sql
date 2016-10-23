CREATE TABLE [dbo].[Employees]
(
	[employeeID] INT NOT NULL PRIMARY KEY, 
    [firstName] NCHAR(10) NOT NULL, 
    [lastName] NCHAR(10) NOT NULL, 
    [isAdmin] BIT NOT NULL, 
    [userName] NCHAR(10) NOT NULL, 
    [password] NCHAR(10) NOT NULL
)
