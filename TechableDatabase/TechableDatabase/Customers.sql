GO
CREATE TABLE [dbo].[Customers]
(
	[customerId] int NOT NULL PRIMARY KEY, 
    [lastName] NCHAR(30) NOT NULL, 
    [firstName] NCHAR(30) NOT NULL, 
    [email] NCHAR(30) NULL, 
    [address] NCHAR(30) NULL, 
    [phoneNumber] NCHAR(30) NULL
)
GO
CREATE SEQUENCE seq_customer_id as int
MINVALUE 100
START WITH 100
INCREMENT BY 1