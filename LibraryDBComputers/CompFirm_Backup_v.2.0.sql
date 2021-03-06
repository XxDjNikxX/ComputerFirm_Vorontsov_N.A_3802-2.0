USE [master]
GO
/****** Object:  Database [Computer_Firm_Vorontsov_N.A]    Script Date: 25.06.2021 12:54:03 ******/
CREATE DATABASE [Computer_Firm_Vorontsov_N.A]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Computer_Firm_Vorontsov_N.A', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Computer_Firm_Vorontsov_N.A.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Computer_Firm_Vorontsov_N.A_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Computer_Firm_Vorontsov_N.A_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Computer_Firm_Vorontsov_N.A].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ARITHABORT OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET RECOVERY FULL 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET  MULTI_USER 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Computer_Firm_Vorontsov_N.A', N'ON'
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET QUERY_STORE = OFF
GO
USE [Computer_Firm_Vorontsov_N.A]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[idAuth] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[idRole] [int] NOT NULL,
 CONSTRAINT [PK_Auth] PRIMARY KEY CLUSTERED 
(
	[idAuth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[idCity] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[idCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[idCustomer] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[PatherName] [nvarchar](30) NULL,
	[idCity] [int] NULL,
	[CustStreet] [nvarchar](50) NULL,
	[CustTelephone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[idProductType] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [float] NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[idProductType] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[idProductType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nchar](10) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[idSale] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Date] [datetime] NOT NULL,
	[idCustomer] [int] NULL,
	[idProduct] [int] NULL,
	[Count] [int] NULL,
	[Price_Total] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[idSale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Auth] ON 

INSERT [dbo].[Auth] ([idAuth], [Login], [Password], [idRole]) VALUES (1, N'DjNik', N'D410F069B816D1AFC2DEFCBFE0E984BD', 2)
SET IDENTITY_INSERT [dbo].[Auth] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([idCity], [CityName]) VALUES (2, N'Москва')
INSERT [dbo].[City] ([idCity], [CityName]) VALUES (3, N'Сочи')
INSERT [dbo].[City] ([idCity], [CityName]) VALUES (4, N'Казахстан')
INSERT [dbo].[City] ([idCity], [CityName]) VALUES (5, N'-----')
INSERT [dbo].[City] ([idCity], [CityName]) VALUES (6, N'Прочее')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (1, N'Никита', N'Воронцов', N'Воронцов', 2, N'Ул.Пушкина д.6', N'89353949901')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (2, N'Аркадий', N'Паровозов', N'Паравозович', 4, N'Ул.Каст д.2', N'89263819205')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (3, N'Максим', N'Николаевич', N'Николаевич', 4, N'Ул.Красных Партизан д.2', N'89356626666')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (5, N'Аркадик', N'Витальевич', N'Витальевич', 5, N'Ул.Чёрных Ворон д.6', N'89353949901')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([idProductType], [ProductTypeName]) VALUES (1, N'Компьютеры')
INSERT [dbo].[ProductType] ([idProductType], [ProductTypeName]) VALUES (2, N'Принтеры')
INSERT [dbo].[ProductType] ([idProductType], [ProductTypeName]) VALUES (3, N'Расходники')
INSERT [dbo].[ProductType] ([idProductType], [ProductTypeName]) VALUES (4, N'Прочее')
INSERT [dbo].[ProductType] ([idProductType], [ProductTypeName]) VALUES (6, N'Струйники')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([idRole], [RoleName]) VALUES (1, N'User      ')
INSERT [dbo].[Roles] ([idRole], [RoleName]) VALUES (2, N'Admin     ')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
/****** Object:  Index [IX_FK_Auth_Roles]    Script Date: 25.06.2021 12:54:03 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Auth_Roles] ON [dbo].[Auth]
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Customer_City]    Script Date: 25.06.2021 12:54:03 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Customer_City] ON [dbo].[Customer]
(
	[idCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Product_ProductType]    Script Date: 25.06.2021 12:54:03 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Product_ProductType] ON [dbo].[Product]
(
	[idProductType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Sales_Customer]    Script Date: 25.06.2021 12:54:03 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Sales_Customer] ON [dbo].[Sales]
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Sales_Product]    Script Date: 25.06.2021 12:54:03 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Sales_Product] ON [dbo].[Sales]
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Auth]  WITH CHECK ADD  CONSTRAINT [FK_Auth_Roles] FOREIGN KEY([idRole])
REFERENCES [dbo].[Roles] ([idRole])
GO
ALTER TABLE [dbo].[Auth] CHECK CONSTRAINT [FK_Auth_Roles]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([idCity])
REFERENCES [dbo].[City] ([idCity])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([idProductType])
REFERENCES [dbo].[ProductType] ([idProductType])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer] FOREIGN KEY([idCustomer])
REFERENCES [dbo].[Customer] ([idCustomer])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([idProduct])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Product]
GO
/****** Object:  Trigger [dbo].[Total_Sum_UPDATE]    Script Date: 25.06.2021 12:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Total_Sum_UPDATE]
ON [dbo].[Sales]
AFTER INSERT, UPDATE
AS
	UPDATE dbo.Sales SET Price_Total = (SELECT ((dbo.Sales.Count * dbo.Product.Price) - (dbo.Product.Price * dbo.Product.Discount / 100))) FROM dbo.Sales,dbo.Product
	WHERE dbo.Product.idProduct = Sales.idProduct;
GO
ALTER TABLE [dbo].[Sales] ENABLE TRIGGER [Total_Sum_UPDATE]
GO
USE [master]
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET  READ_WRITE 
GO
