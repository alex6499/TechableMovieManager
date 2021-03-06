﻿GO
CREATE TABLE [dbo].[Customers]
(
	[customerId] int NOT NULL PRIMARY KEY IDENTITY, 
    [lastName] NCHAR(40) NOT NULL, 
    [firstName] NCHAR(40) NOT NULL, 
    [email] NCHAR(40) NULL, 
    [address] NCHAR(100) NULL, 
    [phoneNumber] NCHAR(40) NULL, 
    [deleted] BIT NULL, 
    [timesRented] INT NOT NULL
)
