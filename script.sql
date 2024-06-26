USE [master]
GO
/****** Object:  Database [Expense Management]    Script Date: 17-06-2024 10:00:23 ******/
CREATE DATABASE [Expense Management]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Expense Management', FILENAME = N'D:\New SQL\MSSQL15.SQLEXPRESS02\MSSQL\DATA\Expense Management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Expense Management_log', FILENAME = N'D:\New SQL\MSSQL15.SQLEXPRESS02\MSSQL\DATA\Expense Management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Expense Management] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Expense Management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Expense Management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Expense Management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Expense Management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Expense Management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Expense Management] SET ARITHABORT OFF 
GO
ALTER DATABASE [Expense Management] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Expense Management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Expense Management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Expense Management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Expense Management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Expense Management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Expense Management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Expense Management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Expense Management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Expense Management] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Expense Management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Expense Management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Expense Management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Expense Management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Expense Management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Expense Management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Expense Management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Expense Management] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Expense Management] SET  MULTI_USER 
GO
ALTER DATABASE [Expense Management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Expense Management] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Expense Management] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Expense Management] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Expense Management] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Expense Management] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Expense Management] SET QUERY_STORE = OFF
GO
USE [Expense Management]
GO
/****** Object:  Table [dbo].[MST_Category]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[CategoryImage] [varchar](max) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_MST_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MST_PaymentMode]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_PaymentMode](
	[PaymentModeID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentModeType] [varchar](50) NOT NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_MST_PaymentMode] PRIMARY KEY CLUSTERED 
(
	[PaymentModeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MST_Transfer]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_Transfer](
	[TransferID] [int] IDENTITY(1,1) NOT NULL,
	[TransferTypeID] [int] NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[TransferAmount] [decimal](10, 2) NOT NULL,
	[TransferNote] [varchar](max) NULL,
	[UserID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PaymentModeID] [int] NOT NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_MST_Transfer] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MST_TransferType]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_TransferType](
	[TransferTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TransferTypeName] [varchar](50) NOT NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_MST_TransferType] PRIMARY KEY CLUSTERED 
(
	[TransferTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MST_User]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MST_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NULL,
	[ProfilePicture] [varchar](max) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_MST_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MST_Category]  WITH CHECK ADD  CONSTRAINT [FK_MST_Category_MST_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[MST_User] ([UserID])
GO
ALTER TABLE [dbo].[MST_Category] CHECK CONSTRAINT [FK_MST_Category_MST_User]
GO
ALTER TABLE [dbo].[MST_PaymentMode]  WITH CHECK ADD  CONSTRAINT [FK_MST_PaymentMode_MST_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[MST_User] ([UserID])
GO
ALTER TABLE [dbo].[MST_PaymentMode] CHECK CONSTRAINT [FK_MST_PaymentMode_MST_User]
GO
ALTER TABLE [dbo].[MST_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_MST_Transfer_MST_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[MST_Category] ([CategoryID])
GO
ALTER TABLE [dbo].[MST_Transfer] CHECK CONSTRAINT [FK_MST_Transfer_MST_Category]
GO
ALTER TABLE [dbo].[MST_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_MST_Transfer_MST_PaymentMode] FOREIGN KEY([PaymentModeID])
REFERENCES [dbo].[MST_PaymentMode] ([PaymentModeID])
GO
ALTER TABLE [dbo].[MST_Transfer] CHECK CONSTRAINT [FK_MST_Transfer_MST_PaymentMode]
GO
ALTER TABLE [dbo].[MST_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_MST_Transfer_MST_TransferType] FOREIGN KEY([TransferTypeID])
REFERENCES [dbo].[MST_TransferType] ([TransferTypeID])
GO
ALTER TABLE [dbo].[MST_Transfer] CHECK CONSTRAINT [FK_MST_Transfer_MST_TransferType]
GO
ALTER TABLE [dbo].[MST_Transfer]  WITH CHECK ADD  CONSTRAINT [FK_MST_Transfer_MST_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[MST_User] ([UserID])
GO
ALTER TABLE [dbo].[MST_Transfer] CHECK CONSTRAINT [FK_MST_Transfer_MST_User]
GO
ALTER TABLE [dbo].[MST_TransferType]  WITH CHECK ADD  CONSTRAINT [FK_MST_TransferType_MST_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[MST_User] ([UserID])
GO
ALTER TABLE [dbo].[MST_TransferType] CHECK CONSTRAINT [FK_MST_TransferType_MST_User]
GO
/****** Object:  StoredProcedure [dbo].[PR_ADMIN_MST_CATEGORY_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_ADMIN_MST_CATEGORY_INSERT]
@CategoryName VARCHAR(50),
@CategoryImage VARCHAR(MAX)
AS
	INSERT INTO MST_Category
	(
		CategoryName,
		CategoryImage,
		Created,
		Modified
	)
	VALUES
	(
		@CategoryName,
		@CategoryImage,
		GETDATE(),
		GETDATE()
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_DASHBOARD_CATEGORY_FILTER]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_DASHBOARD_CATEGORY_FILTER] 
@USERID INT
AS
	SELECT 
		MC.CategoryName,
		FORMAT(SUM(CASE WHEN MTT.TransferTypeName='INCOME' THEN MT.TransferAmount ELSE 0 END),'C','en-IN') AS INCOME,
		format(SUM(CASE WHEN MTT.TransferTypeName='EXPENSE' THEN MT.TransferAmount ELSE 0 END),'C','en-IN') AS EXPENSE
	FROM MST_Transfer MT
	INNER JOIN MST_Category MC
	ON MT.CategoryID=MC.CategoryID
	INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID=MTT.TransferTypeID
	WHERE MT.UserID=@USERID
	GROUP BY MC.CategoryName
GO
/****** Object:  StoredProcedure [dbo].[PR_DASHBOARD_CATEGORY_FILTER_RANGEDATE]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_DASHBOARD_CATEGORY_FILTER_RANGEDATE]
@USERID INT,
@FROMDATE DATETIME,
@TODATE DATETIME
AS
	SELECT 
		MT.TransferDate,
		MC.CategoryName,
		SUM(CASE WHEN MTT.TransferTypeName='INCOME' THEN MT.TransferAmount ELSE 0 END) AS INCOME,
		SUM(CASE WHEN MTT.TransferTypeName='EXPENSE' THEN MT.TransferAmount ELSE 0 END) AS EXPENSE
	FROM MST_Transfer MT
	INNER JOIN MST_Category MC
	ON MT.CategoryID = MC.CategoryID
	INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID=MTT.TransferTypeID

	WHERE MT.UserID=@USERID AND MT.TransferDate BETWEEN @FROMDATE AND @TODATE
	GROUP BY MC.CategoryName,
			MT.TransferDate
GO
/****** Object:  StoredProcedure [dbo].[PR_Dashboard_Count]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_Dashboard_Count]
AS
	Declare @CategoryCount int
	Select @CategoryCount = Count(*) from MST_Category

	Declare @PaymentModeCount int
	Select @PaymentModeCount = Count(*) from MST_PaymentMode

	Declare @UserCount int
	Select @UserCount = Count(*) from MST_User

	Declare @Income decimal
	select @Income = sum(TransferAmount)
	from MST_Transfer MT
	inner join MST_TransferType MTT
	on MT.TransferTypeID=MTT.TransferTypeID
	where MTT.TransferTypeName='Income'

	Declare @Expense decimal
	select @Expense = sum(TransferAmount)
	from MST_Transfer MT
	inner join MST_TransferType MTT
	on MT.TransferTypeID=MTT.TransferTypeID
	where MTT.TransferTypeName='Expense'

	Select 
		@CategoryCount AS CategoryCount,
		@PaymentModeCount AS PaymentModeCount,
		@UserCount AS UserCount,
		Format(@Income, 'c', 'en-IN') AS Income,
		Format(@Expense, 'c', 'en-IN') AS Expense
GO
/****** Object:  StoredProcedure [dbo].[PR_DASHBOARD_PAYMENTMODE_FILTER]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_DASHBOARD_PAYMENTMODE_FILTER]
@USERID INT
AS
	SELECT 
		MP.PaymentModeType,
		FORMAT(SUM(CASE WHEN MTT.TransferTypeName='INCOME' THEN MT.TransferAmount ELSE 0 END),'C','EN-IN') AS INCOME,
		FORMAT(SUM(CASE WHEN MTT.TransferTypeName='EXPENSE' THEN MT.TransferAmount ELSE 0 END),'C','EN-IN') AS EXPENSE
	FROM MST_Transfer MT
	INNER JOIN MST_PaymentMode MP
	ON MT.PaymentModeID=MP.PaymentModeID
	INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID=MTT.TransferTypeID
	WHERE MT.UserID=@USERID
	GROUP BY MP.PaymentModeType
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_Category_Count]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[PR_MST_Category_Count]
AS
	Select 
		COUNT(MC.CategoryName) AS Category_Count
	From MST_Category MC
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_DELETEBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_DELETEBYID]
@CATEGORYID INT
AS
	DELETE 
	FROM MST_Category
	WHERE MST_Category.CategoryID=@CATEGORYID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_INSERT]
@CategoryName VARCHAR(50),
@CategoryImage VARCHAR(MAX),
@UserID INT
AS
	INSERT INTO MST_Category
	(
		CategoryName,
		CategoryImage,
		Created,
		Modified,
		UserID
	)
	VALUES
	(
		@CategoryName,
		@CategoryImage,
		GETDATE(),
		GETDATE(),
		@UserID
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_PIECHART_BYCATEGORY_EXPENSE]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_PIECHART_BYCATEGORY_EXPENSE]
@USERID INT
AS
	SELECT 
		MC.CategoryName,
		SUM(CASE WHEN MTT.TransferTypeName='EXPENSE' THEN MT.TransferAmount ELSE 0 END) AS EXPENSE
	FROM MST_Transfer MT
	INNER JOIN MST_Category MC
	ON MT.CategoryID=MC.CategoryID
	INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID = MTT.TransferTypeID
	WHERE MT.UserID=@USERID
	GROUP BY MC.CategoryName

GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_SELECTALL]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_SELECTALL]
AS
	SELECT MC.CategoryID,
			MC.CategoryName,
			MC.CategoryImage,
			MC.Created,
			MC.Modified,
			MC.UserID,
			MC.Created,
			MC.Modified
	FROM MST_Category MC
	Order By MC.CategoryName
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_SELECTBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_SELECTBYID]
@CATEGORYID INT
AS
	SELECT MC.CategoryID,
			MC.CategoryImage,
			MC.CategoryName,
			MC.Created,
			MC.Modified,
			MC.UserID
	FROM MST_Category MC
	WHERE MC.CategoryID=@CATEGORYID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_SELECTBYNAME]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[PR_MST_CATEGORY_SELECTBYNAME]
	@CATEGORYNAME varchar(100) = null
AS
	Select MST_Category.CategoryID,
		MST_Category.CategoryName,
		MST_Category.CategoryImage,
		MST_Category.Created,
		MST_Category.Modified
	From MST_Category
	Where (@CATEGORYNAME IS NULL OR CategoryName LIKE CONCAT('%',@CATEGORYNAME,'%'))
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_CATEGORY_UPDATEBYPK]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_CATEGORY_UPDATEBYPK]
@CATEGORYID INT,
@CATEGORYNAME VARCHAR(50),
@CATEGORYIMAGE VARCHAR(MAX)
AS
	UPDATE MST_Category
	SET CategoryName=@CATEGORYNAME,
		CategoryImage=@CATEGORYIMAGE,
		Modified=GETDATE()
	WHERE CategoryID=@CATEGORYID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PaymentMode_Count]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[PR_MST_PaymentMode_Count]
AS
	Select 
		COUNT(MP.PaymentModeType) AS PaymentMode_Count
	From MST_PaymentMode MP
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PAYMENTMODE_DELETEBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_PAYMENTMODE_DELETEBYID]
@PAYMENTMODEID INT
AS
	DELETE 
	FROM MST_PaymentMode
	WHERE MST_PaymentMode.PaymentModeID=@PAYMENTMODEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PAYMENTMODE_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_PAYMENTMODE_INSERT]
@PaymentModeType VARCHAR(50)
AS
	INSERT INTO MST_PaymentMode
	(
		PaymentModeType,
		Created,
		Modified
	)
	VALUES
	(
		@PaymentModeType,
		GETDATE(),
		GETDATE()
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PAYMENTMODE_SELECTALL]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_PAYMENTMODE_SELECTALL]
AS
	SELECT MP.PaymentModeID,
			MP.PaymentModeType,
			MP.UserID,
			MP.Created,
			MP.Modified
	FROM MST_PaymentMode MP
	Order by MP.PaymentModeType
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PAYMENTMODE_SELECTBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_PAYMENTMODE_SELECTBYID]
@PAYMENTMODEID INT
AS
	SELECT MP.PaymentModeID,
			MP.PaymentModeType,
			MP.UserID,
			MP.Created,MP.Modified
	FROM MST_PaymentMode MP
	WHERE MP.PaymentModeID=@PAYMENTMODEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_PAYMENTMODE_UPDATEBYPK]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_PAYMENTMODE_UPDATEBYPK]
@PAYMENTMODEID INT,
@PAYMENTMODETYPE VARCHAR(50)
AS
	UPDATE MST_PaymentMode
	SET PaymentModeType=@PAYMENTMODETYPE,
		Modified=GETDATE()
	WHERE PaymentModeID=@PAYMENTMODEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_DELETEBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_DELETEBYID]
@TRANSFERID INT
AS
	DELETE 
	FROM MST_Transfer
	WHERE MST_Transfer.TransferID=@TRANSFERID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_FILTER]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_FILTER]
@TRANSFERTYPEID INT = NULL,
@CATEGORYID INT = NULL,
@PAYMENTMODEID INT = NULL,
@TRANSFERAMOUNT DECIMAL = NULL
AS
	SELECT 
		MT.TransferID,
		MT.TransferTypeID,
		MTT.TransferTypeName,
		MT.CategoryID,
		MC.CategoryName,
		MT.PaymentModeID,
		MP.PaymentModeType,
		MT.TransferAmount,
		MT.TransferDate,
		MT.TransferNote
	FROM MST_Transfer MT
	INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID=MTT.TransferTypeID
	INNER JOIN MST_Category MC
	ON MT.CategoryID=MC.CategoryID
	INNER JOIN MST_PaymentMode MP
	ON MT.PaymentModeID=MP.PaymentModeID
	WHERE(
		(@TRANSFERTYPEID IS NULL OR MT.TransferTypeID = @TRANSFERTYPEID) AND
		(@CATEGORYID IS NULL OR MT.CategoryID = @CATEGORYID) AND
		(@PAYMENTMODEID IS NULL OR MT.PaymentModeID = @PAYMENTMODEID) AND
		(@TRANSFERAMOUNT IS NULL OR MT.TransferAmount<=@TRANSFERAMOUNT)
	)

	ORDER BY MT.TransferAmount,
			MT.TransferDate,
			MT.TransferNote,
			MC.CategoryName,
			MP.PaymentModeType,
			MTT.TransferTypeName
		
--PR_MST_TRANSFER_FILTER NULL,NULL,NULL,10000
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_INSERT]
@TransferTypeID INT,
@TransferAmount DECIMAL(10,2),
@TransferDate DATETIME,
@TransferNote VARCHAR(MAX),
@CategoryID INT,
@PaymentModeID INT,
@UserID INT
AS
	INSERT INTO MST_Transfer
	(
		TransferTypeID,
		TransferAmount,
		TransferDate,
		TransferNote,
		CategoryID,
		PaymentModeID,
		UserID,
		Created,
		Modified
	)
	VALUES
	(
		@TransferTypeID,
		@TransferAmount,
		@TransferDate,
		@TransferNote,
		@CategoryID,
		@PaymentModeID,
		@UserID,
		GETDATE(),
		GETDATE()
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_SELECTALL]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_SELECTALL]
@USERID int
AS
	SELECT MT.TransferID,
			MT.TransferTypeID,
			MTT.TransferTypeName,
			FORMAT(MT.TransferAmount,'C','EN-IN') as TransferAmount,
			MT.TransferDate,
			MT.TransferNote,
			MT.CategoryID,
			MC.CategoryName,
			MT.PaymentModeID,
			MP.PaymentModeType,
			MT.UserID,
			MU.UserName,
			MU.IsAdmin,
			MT.Created,
			MT.Modified
	FROM MST_Transfer MT
	INNER JOIN MST_Category MC
	ON MT.CategoryID=MC.CategoryID
		INNER JOIN MST_PaymentMode MP
	ON MT.PaymentModeID=MP.PaymentModeID
		INNER JOIN MST_TransferType MTT
	ON MT.TransferTypeID=MTT.TransferTypeID
		INNER JOIN MST_User MU
	ON MT.UserID=MU.UserID
	where MU.UserID=@USERID
	


GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_SELECTBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_SELECTBYID]
@TRANSFERID INT
AS
	SELECT MT.TransferID,
			MT.TransferTypeID,
			MT.TransferAmount,
			MT.TransferDate,
			MT.TransferNote,
			MT.CategoryID,
			MT.PaymentModeID,
			MT.UserID,
			MT.Created,
			MT.Modified
	FROM MST_Transfer MT
	WHERE MT.TransferID=@TRANSFERID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFER_UPDATEBYPK]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFER_UPDATEBYPK]
@TRANSFERID	INT,
@TRANSFERTYPEID INT,
@TRANSFERAMOUNT DECIMAL(10,2),
@TRANSFERNOTE VARCHAR(MAX),
@TRANSFERDATE DATETIME,
@PAYMENTMODEID INT,
@CATEGORYID INT,
@USERID INT
AS
	UPDATE MST_Transfer
	SET TransferTypeID=@TRANSFERTYPEID,
		TransferAmount=@TRANSFERAMOUNT,
		TransferNote=@TRANSFERNOTE,
		TransferDate=@TRANSFERDATE,
		PaymentModeID=@PAYMENTMODEID,
		CategoryID=@CATEGORYID,
		UserID=@USERID,
		Modified=GETDATE()
	WHERE MST_Transfer.TransferID=@TRANSFERID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFERTYPE_DELETEBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFERTYPE_DELETEBYID]
@TRANSFERTYPEID INT
AS
	DELETE 
	FROM MST_TransferType
	WHERE MST_TransferType.TransferTypeID=@TRANSFERTYPEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFERTYPE_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFERTYPE_INSERT]
@TRANSFERTYPENAME VARCHAR(50),
@USERID INT = null
AS
	INSERT INTO MST_TransferType
	(
		TransferTypeName,
		UserID,
		Created,
		Modified
	)
	VALUES
	(
		@TRANSFERTYPENAME,
		@USERID,
		GETDATE(),
		GETDATE()
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFERTYPE_SELECTALL]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFERTYPE_SELECTALL]
AS
	SELECT MTT.TransferTypeID,
			MTT.TransferTypeName,
			MTT.UserID,
			MTT.Created,
			MTT.Modified
	FROM MST_TransferType MTT
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFERTYPE_SELECTBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFERTYPE_SELECTBYID]
@TRANSFERTYPEID INT
AS
	SELECT MTT.TransferTypeID,
			MTT.TransferTypeName,
			MTT.UserID,
			MTT.Created,
			MTT.Modified
	FROM MST_TransferType MTT
	WHERE MTT.TransferTypeID=@TRANSFERTYPEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_TRANSFERTYPE_UPDATEBYPK]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_TRANSFERTYPE_UPDATEBYPK]
@TRANSFERTYPEID INT,
@TRANSFERTYPENAME VARCHAR(50)
AS
	UPDATE MST_TransferType
	SET TransferTypeName=@TRANSFERTYPENAME,
		Modified=GETDATE()
	WHERE TransferTypeID=@TRANSFERTYPEID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_User_Count]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[PR_MST_User_Count]
AS
	Select
		COUNT(MU.UserName) AS User_Count
	From MST_User MU
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_DEAVTIVE]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_USER_DEAVTIVE]
@USERID INT
AS 
	UPDATE MST_User SET IsActive='FALSE' WHERE UserID=@USERID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_DELETEBYID]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PR_MST_USER_DELETEBYID
CREATE PROC [dbo].[PR_MST_USER_DELETEBYID]
@USERID INT
AS
	DELETE 
	FROM MST_User
	WHERE MST_User.UserID=@USERID
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_INSERT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PR_MST_USER_INSERT 'RUSHI','R','R','R','R','R'
CREATE PROC [dbo].[PR_MST_USER_INSERT]
@UserName VARCHAR(50),
@FirstName VARCHAR(50),
@LastName VARCHAR(50),           
@Email VARCHAR(50),
@Password VARCHAR(50),
@ProfilePicture VARCHAR(MAX)
AS
	INSERT INTO MST_User
	(
		UserName,
		FirstName,
		LastName,           
		Email,
		Password,
		ProfilePicture,
		IsAdmin,
		IsActive,
		Created,
		Modified
	)
	VALUES
	(
		@UserName,
		@FirstName,
		@LastName,
		@Email,
		@Password,
		@ProfilePicture,
		0,
		1,
		GETDATE(),
		GETDATE()
	)
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_SELECTALL]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_USER_SELECTALL]
AS
	SELECT MU.UserID,
			MU.UserName,
			MU.Password,
			MU.Email,
			MU.FirstName,
			MU.LastName,
			MU.ProfilePicture,
			MU.IsAdmin,
			MU.Created,
			MU.Modified
	FROM MST_User MU
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_SELECTBYNAME]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_MST_USER_SELECTBYNAME]
@USERNAME varchar(50)
AS
	SELECT MST_User.UserID,
			MST_User.UserName,
			MST_User.FirstName,
			MST_User.LastName,
			MST_User.Email,
			MST_User.Password,
			MST_User.ProfilePicture,
			MST_User.IsAdmin
	FROM MST_User
	WHERE MST_User.UserName=@USERNAME
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_SELECTBYNAMEPASSWORD]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PR_MST_USER_SELECTBYNAMEPASSWORD 'RUSHI','RUSHI'
CREATE PROC [dbo].[PR_MST_USER_SELECTBYNAMEPASSWORD]
@USERNAME VARCHAR(50),
@PASSWORD VARCHAR(50)
AS
	SELECT MU.UserID,
			MU.UserName,
			MU.Password,
			MU.FirstName,
			MU.LastName,
			MU.Email,
			MU.ProfilePicture,
			MU.IsAdmin,
			MU.Created,
			MU.Modified
	FROM MST_User MU
	WHERE MU.UserName=@USERNAME AND MU.Password=@PASSWORD
GO
/****** Object:  StoredProcedure [dbo].[PR_MST_USER_UPDATEBYPK]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PR_MST_USER_UPDATEBYPK
CREATE PROC [dbo].[PR_MST_USER_UPDATEBYPK]
@USERID INT,
@USERNAME VARCHAR(50),
@EMAIL VARCHAR(50),
@PASSWORD VARCHAR(50),
@FIRSTNAME VARCHAR(50),
@LASTNAME VARCHAR(50),
@PROFILEPICTURE VARCHAR(MAX)
AS
	UPDATE MST_User
	SET UserName=@USERNAME,
		Email=@EMAIL,
		Password=@PASSWORD,
		FirstName=@FIRSTNAME,
		LastName=@LASTNAME,
		ProfilePicture=@PROFILEPICTURE,
		Modified=GETDATE()
	WHERE MST_User.UserID=@USERID
GO
/****** Object:  StoredProcedure [dbo].[pr_test]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[pr_test]
as
	DECLARE @INCOME DECIMAL
	SELECT @INCOME = SUM(TransferAmount) FROM MST_Transfer MT
											INNER JOIN MST_TransferType MTT
											ON MT.TransferTypeID=MTT.TransferTypeID
											INNER JOIN MST_Category MC
											ON MT.CategoryID=MC.CategoryID
											WHERE MTT.TransferTypeName='INCOME'

	DECLARE @EXPENSE DECIMAL
	SELECT @EXPENSE = SUM(TransferAmount) FROM MST_Transfer MT
											INNER JOIN MST_TransferType MTT
											ON MT.TransferTypeID=MTT.TransferTypeID
											INNER JOIN MST_Category MC
											ON MT.CategoryID=MC.CategoryID
											WHERE MTT.TransferTypeName='EXPENSE'

	SELECT 
		@EXPENSE AS EXPENSE,
		@INCOME AS INCOME
GO
/****** Object:  StoredProcedure [dbo].[pr_test_COUNT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_test_COUNT]
as
	DECLARE @INCOME DECIMAL
	SELECT @INCOME = SUM(TransferAmount) FROM MST_Transfer MT
											INNER JOIN MST_TransferType MTT
											ON MT.TransferTypeID=MTT.TransferTypeID
											INNER JOIN MST_Category MC
											ON MT.CategoryID=MC.CategoryID
											WHERE MTT.TransferTypeName='INCOME'
											GROUP BY MC.CategoryName

	DECLARE @EXPENSE DECIMAL
	SELECT @EXPENSE = SUM(TransferAmount) FROM MST_Transfer MT
											INNER JOIN MST_TransferType MTT
											ON MT.TransferTypeID=MTT.TransferTypeID
											INNER JOIN MST_Category MC
											ON MT.CategoryID=MC.CategoryID
											WHERE MTT.TransferTypeName='EXPENSE'
											GROUP BY MC.CategoryName

	SELECT 
		@EXPENSE AS EXPENSE,
		@INCOME AS INCOME,
		CategoryName
	FROM MST_Transfer MT
	INNER JOIN MST_Category MC
	ON MT.CategoryID=MC.CategoryID

GO
/****** Object:  StoredProcedure [dbo].[PR_USER_DASHBOARDCOUNT]    Script Date: 17-06-2024 10:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PR_USER_DASHBOARDCOUNT]
@USERID INT
AS
	Declare @Income decimal
	select @Income = sum(TransferAmount)
	from MST_Transfer MT
	inner join MST_TransferType MTT
	on MT.TransferTypeID=MTT.TransferTypeID
	where MTT.TransferTypeName='Income' AND MT.UserID=@USERID

	Declare @Expense decimal
	select @Expense = sum(TransferAmount)
	from MST_Transfer MT
	inner join MST_TransferType MTT
	on MT.TransferTypeID=MTT.TransferTypeID
	where MTT.TransferTypeName='Expense' AND MT.UserID=@USERID

	SELECT
		Format(@Income, 'c', 'en-IN') AS Income,
		Format(@Expense, 'c', 'en-IN') AS Expense
GO
USE [master]
GO
ALTER DATABASE [Expense Management] SET  READ_WRITE 
GO
