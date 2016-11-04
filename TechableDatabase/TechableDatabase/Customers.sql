GO
CREATE SEQUENCE [dbo].[seq_customer_id]
As int
INCREMENT BY 1;

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
