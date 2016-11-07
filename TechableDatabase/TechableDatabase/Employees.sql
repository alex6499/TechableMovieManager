GO
CREATE TABLE [dbo].[Employees]
(
	[employeeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstName] CHAR(40) NOT NULL, 
    [lastName] NCHAR(40) NOT NULL, 
    [isAdmin] BIT NOT NULL, 
    [userName] NCHAR(40) NOT NULL, 
    [password] NCHAR(40) NOT NULL, 
    [deleted] BIT NOT NULL
)
GO
CREATE SEQUENCE seq_employee_id as int
MINVALUE 100
START WITH 100
INCREMENT BY 1