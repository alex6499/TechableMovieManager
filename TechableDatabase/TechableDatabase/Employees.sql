GO
CREATE TABLE [dbo].[Employees]
(
	[employeeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstName] CHAR(25) NOT NULL, 
    [lastName] NCHAR(25) NOT NULL, 
    [isAdmin] BIT NOT NULL, 
    [userName] NCHAR(25) NOT NULL, 
    [password] NCHAR(30) NOT NULL
)
GO
CREATE SEQUENCE seq_employee_id as int
MINVALUE 100
START WITH 100
INCREMENT BY 1