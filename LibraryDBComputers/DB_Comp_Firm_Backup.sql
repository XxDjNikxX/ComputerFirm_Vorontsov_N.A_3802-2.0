CREATE DATABASE [Computer_Firm_Vorontsov_N.A]
GO
USE [Computer_Firm_Vorontsov_N.A]
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
EXEC sys.sp_db_vardecimal_storage_format N'Computer_Firm_Vorontsov_N.A', N'ON'
GO
ALTER DATABASE [Computer_Firm_Vorontsov_N.A] SET QUERY_STORE = OFF
GO
USE [Computer_Firm_Vorontsov_N.A]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 24.06.2021 22:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[idRole] [int] NOT NULL,
 CONSTRAINT [PK_Auth_1] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 24.06.2021 22:42:53 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 24.06.2021 22:42:53 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 24.06.2021 22:42:53 ******/
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
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 24.06.2021 22:42:53 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 24.06.2021 22:42:53 ******/
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
/****** Object:  Table [dbo].[Sales]    Script Date: 24.06.2021 22:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[idSale] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Date] [date] NOT NULL,
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
INSERT [dbo].[Auth] ([Login], [Password], [idRole]) VALUES (N'DjNik', N'test123', 2)
INSERT [dbo].[Auth] ([Login], [Password], [idRole]) VALUES (N'TestUser', N'test', 1)
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

INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (1, N'Никита', N'Воронцов', N'Воронцов', 2, N'Ул.Пушкина д.6', N'123-22-22')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (2, N'Аркадий', N'Паровозов', N'Паравозович', 4, N'Ул.Каст д.2', N'222-11-31')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (3, N'Максим', N'Николаевич', N'Николаевич', NULL, N'Ул.Красных Партизан д.2', N'666-66-66')
INSERT [dbo].[Customer] ([idCustomer], [FirstName], [SecondName], [PatherName], [idCity], [CustStreet], [CustTelephone]) VALUES (5, N'Аркадик', N'Витальевич', N'Витальевич', 5, N'', N'')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([idProduct], [idProductType], [ProductName], [Price], [Discount]) VALUES (1, 2, N'EPSON "SX420W"', CAST(5600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([idProduct], [idProductType], [ProductName], [Price], [Discount]) VALUES (2, 1, N'GIGABYTE KCAS EDITON', CAST(5000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([idProduct], [idProductType], [ProductName], [Price], [Discount]) VALUES (5, 1, N'KCAS BOMB', CAST(231.12 AS Decimal(18, 2)), 0.31)
INSERT [dbo].[Product] ([idProduct], [idProductType], [ProductName], [Price], [Discount]) VALUES (6, 3, N'Катриджи', CAST(125.00 AS Decimal(18, 2)), 0.15)
SET IDENTITY_INSERT [dbo].[Product] OFF
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
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (1, CAST(N'2021-05-01' AS Date), 1, 1, 2, CAST(11200 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (2, CAST(N'2021-05-13' AS Date), 2, 5, 3, CAST(693 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (4, CAST(N'2001-01-12' AS Date), 1, 5, 2, CAST(462 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (5, CAST(N'2021-04-12' AS Date), 1, 5, 1, CAST(230 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (6, CAST(N'2021-06-18' AS Date), 5, 6, 23, CAST(2875 AS Decimal(18, 0)))
INSERT [dbo].[Sales] ([idSale], [Sale_Date], [idCustomer], [idProduct], [Count], [Price_Total]) VALUES (7, CAST(N'2001-12-12' AS Date), 5, 6, 12, CAST(1500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
ALTER TABLE [dbo].[Auth]  WITH CHECK ADD  CONSTRAINT [FK_Auth_Roles] FOREIGN KEY([idRole])
REFERENCES [dbo].[Roles] ([idRole])
GO
ALTER TABLE [dbo].[Auth] CHECK CONSTRAINT [FK_Auth_Roles]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([idCity])
REFERENCES [dbo].[City] ([idCity])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([idProductType])
REFERENCES [dbo].[ProductType] ([idProductType])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer] FOREIGN KEY([idCustomer])
REFERENCES [dbo].[Customer] ([idCustomer])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([idProduct])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Product]
GO
/****** Object:  Trigger [dbo].[Total_Sum_UPDATE]    Script Date: 24.06.2021 22:42:53 ******/
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
