GO
CREATE TABLE [dbo].[Employees]
(
	[userName] NCHAR(40) NOT NULL PRIMARY KEY, 
    [firstName] CHAR(40) NOT NULL, 
    [lastName] NCHAR(40) NOT NULL, 
    [isAdmin] BIT NOT NULL,  
    [password] NCHAR(40) NOT NULL, 
    [deleted] BIT NOT NULL
)