
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/24/2021 13:44:57
-- Generated from EDMX file: C:\Users\DjNik\source\repos\VorontsovNikita\ComputerFirm_Vorontsov_N.A_3802-2.0\LibraryDBComputers\ModelCompFirm.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Computer_Firm_Vorontsov_N.A];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Auth_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Auth] DROP CONSTRAINT [FK_Auth_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_Customer_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_City];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_ProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_ProductType];
GO
IF OBJECT_ID(N'[dbo].[FK_Sales_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sales_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Sales_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sales_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auth]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auth];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductType];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Auth'
CREATE TABLE [dbo].[Auth] (
    [Login] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [idRole] int  NOT NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [idCity] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [idCustomer] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(20)  NOT NULL,
    [SecondName] nvarchar(20)  NOT NULL,
    [PatherName] nvarchar(30)  NULL,
    [idCity] int  NULL,
    [CustStreet] nvarchar(50)  NULL,
    [CustTelephone] nvarchar(50)  NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [idProduct] int IDENTITY(1,1) NOT NULL,
    [idProductType] int  NULL,
    [ProductName] nvarchar(50)  NULL,
    [Price] decimal(18,2)  NULL,
    [Discount] float  NULL
);
GO

-- Creating table 'ProductType'
CREATE TABLE [dbo].[ProductType] (
    [idProductType] int IDENTITY(1,1) NOT NULL,
    [ProductTypeName] nvarchar(50)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [idRole] int IDENTITY(1,1) NOT NULL,
    [RoleName] nchar(10)  NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [idSale] int IDENTITY(1,1) NOT NULL,
    [Sale_Date] datetime  NOT NULL,
    [idCustomer] int  NULL,
    [idProduct] int  NULL,
    [Count] int  NULL,
    [Price_Total] decimal(18,0)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Login] in table 'Auth'
ALTER TABLE [dbo].[Auth]
ADD CONSTRAINT [PK_Auth]
    PRIMARY KEY CLUSTERED ([Login] ASC);
GO

-- Creating primary key on [idCity] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([idCity] ASC);
GO

-- Creating primary key on [idCustomer] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([idCustomer] ASC);
GO

-- Creating primary key on [idProduct] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([idProduct] ASC);
GO

-- Creating primary key on [idProductType] in table 'ProductType'
ALTER TABLE [dbo].[ProductType]
ADD CONSTRAINT [PK_ProductType]
    PRIMARY KEY CLUSTERED ([idProductType] ASC);
GO

-- Creating primary key on [idRole] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([idRole] ASC);
GO

-- Creating primary key on [idSale] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([idSale] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idRole] in table 'Auth'
ALTER TABLE [dbo].[Auth]
ADD CONSTRAINT [FK_Auth_Roles]
    FOREIGN KEY ([idRole])
    REFERENCES [dbo].[Roles]
        ([idRole])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Auth_Roles'
CREATE INDEX [IX_FK_Auth_Roles]
ON [dbo].[Auth]
    ([idRole]);
GO

-- Creating foreign key on [idCity] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [FK_Customer_City]
    FOREIGN KEY ([idCity])
    REFERENCES [dbo].[City]
        ([idCity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer_City'
CREATE INDEX [IX_FK_Customer_City]
ON [dbo].[Customer]
    ([idCity]);
GO

-- Creating foreign key on [idCustomer] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_Sales_Customer]
    FOREIGN KEY ([idCustomer])
    REFERENCES [dbo].[Customer]
        ([idCustomer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sales_Customer'
CREATE INDEX [IX_FK_Sales_Customer]
ON [dbo].[Sales]
    ([idCustomer]);
GO

-- Creating foreign key on [idProductType] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_Product_ProductType]
    FOREIGN KEY ([idProductType])
    REFERENCES [dbo].[ProductType]
        ([idProductType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductType'
CREATE INDEX [IX_FK_Product_ProductType]
ON [dbo].[Product]
    ([idProductType]);
GO

-- Creating foreign key on [idProduct] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_Sales_Product]
    FOREIGN KEY ([idProduct])
    REFERENCES [dbo].[Product]
        ([idProduct])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sales_Product'
CREATE INDEX [IX_FK_Sales_Product]
ON [dbo].[Sales]
    ([idProduct]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------