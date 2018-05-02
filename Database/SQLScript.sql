CREATE DATABASE AppTest;

USE [AppTest]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 02/05/2018 14:41:17 ******/
DROP TABLE [dbo].[customer]
GO
/****** Object:  StoredProcedure [dbo].[SPUpdateCustomer]    Script Date: 02/05/2018 14:41:17 ******/
DROP PROCEDURE [dbo].[SPUpdateCustomer]
GO
/****** Object:  StoredProcedure [dbo].[SPSelectCustomerById]    Script Date: 02/05/2018 14:41:17 ******/
DROP PROCEDURE [dbo].[SPSelectCustomerById]
GO
/****** Object:  StoredProcedure [dbo].[SPSelectCustomerAll]    Script Date: 02/05/2018 14:41:17 ******/
DROP PROCEDURE [dbo].[SPSelectCustomerAll]
GO
/****** Object:  StoredProcedure [dbo].[SPInsertCustomer]    Script Date: 02/05/2018 14:41:17 ******/
DROP PROCEDURE [dbo].[SPInsertCustomer]
GO
/****** Object:  StoredProcedure [dbo].[SPDeleteCustomer]    Script Date: 02/05/2018 14:41:17 ******/
DROP PROCEDURE [dbo].[SPDeleteCustomer]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DOB] [varchar](20) NULL,
	[Gender] [bit] NULL,
	[PhoneNumber] [int] NULL,
	[EmailAddress] [varchar](50) NULL,
	[CompanyName] [varchar](50) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SPDeleteCustomer]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPDeleteCustomer]
	@CustomerID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[customer]
WHERE
	[CustomerID] = @CustomerID

GO
/****** Object:  StoredProcedure [dbo].[SPInsertCustomer]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPInsertCustomer]
	@FirstName varchar(50),
	@LastName varchar(50),
	@DOB varchar(20),
	@Gender bit,
	@PhoneNumber int,
	@EmailAddress varchar(50),
	@CompanyName varchar(50)
AS

SET NOCOUNT ON

IF Not Exists(SELECT 1 FROM [customer] WHERE FirstName = @FirstName AND LastName = @LastName) 
INSERT INTO [dbo].[customer] (
	FirstName,
	LastName,
	DOB,
	Gender,
	PhoneNumber,
	EmailAddress,
	CompanyName
) VALUES (
	@FirstName,
	@LastName,
	@DOB,
	@Gender,
	@PhoneNumber,
	@EmailAddress,
	@CompanyName
)


GO
/****** Object:  StoredProcedure [dbo].[SPSelectCustomerAll]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPSelectCustomerAll]
AS
SET NOCOUNT ON

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[DOB],
	[Gender],
	[PhoneNumber],
	[EmailAddress],
	[CompanyName]
FROM
	[dbo].customer
ORDER BY [FirstName] ASC

GO
/****** Object:  StoredProcedure [dbo].[SPSelectCustomerById]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPSelectCustomerById]
	@CustomerID int
AS
SET NOCOUNT ON

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[DOB],
	[Gender],
	[PhoneNumber],
	[EmailAddress],
	[CompanyName]
FROM
	[dbo].customer
WHERE [CustomerID] = @CustomerID

GO
/****** Object:  StoredProcedure [dbo].[SPUpdateCustomer]    Script Date: 02/05/2018 14:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPUpdateCustomer]
	@CustomerID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@DOB varchar(20),
	@Gender bit,
	@PhoneNumber int,
	@EmailAddress varchar(50),
	@CompanyName varchar(50)
AS

SET NOCOUNT ON
IF Exists(SELECT 1 FROM [customer] WHERE CustomerID = @CustomerID)
UPDATE [dbo].[customer] SET
	FirstName = @FirstName,
	LastName = @LastName,
	DOB = @DOB,
	Gender = @Gender,
	PhoneNumber = @PhoneNumber,
	EmailAddress = @EmailAddress,
	CompanyName = @CompanyName
WHERE
	CustomerID = @CustomerID

GO
