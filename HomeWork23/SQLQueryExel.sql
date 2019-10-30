CREATE DATABASE HomeWork23Exel
-- Импортировал Exel фаил с помощью SQL Server 2019 RC1 Import and Export Data  https://docs.microsoft.com/en-us/sql/integration-services/import-export-data/get-started-with-this-simple-example-of-the-import-and-export-wizard?view=sql-server-ver15
USE HomeWork23Exel


--Разбераем сегменты
-- создаем таблицу сегменты и заполняем её
CREATE TABLE Segment
(
 Id int IDENTITY(1,1) PRIMARY KEY,
 SegmentName nvarchar(20) NOT NULL
);
--заполняем
INSERT INTO dbo.Segment (dbo.Segment.SegmentName)
SELECT DISTINCT  [Segment] FROM dbo.Orders$ ORDER BY [Segment];


--Разбераем  адреса
--Исправил повторение Post Code 92024 повторяется в интернете написано что у San Diego нету кода 92024 есть 92029
UPDATE dbo.Orders$
SET dbo.Orders$.[Postal Code] = 92029
WHERE dbo.Orders$.City='San Diego';

CREATE TABLE [Address] (
	PostalCode INT PRIMARY KEY NOT NULL,
    Country NVARCHAR(20) NOT NULL,
    City NVARCHAR(20) NOT NULL,
    [State] NVARCHAR(20) NOT NULL,
    [Region] NVARCHAR(20) NOT NULL
);
-- Заполняем
INSERT INTO dbo.Address
(
    PostalCode,
    Country,
    City,
    [State],
	[Region]
)
SELECT DISTINCT [Postal Code],[Country],[City],[State],[Region] FROM dbo.Orders$ ORDER BY [Postal Code];


-- Таблица Customer
CREATE TABLE Customer
(
  Id nvarchar(10) PRIMARY KEY NOT NULL,
  [Name] nvarchar(50) NOT NULL,
  SegmentId int NOT NULL FOREIGN KEY REFERENCES dbo.Segment(Id)
);
-- Добавляем записи
INSERT INTO dbo.Customer
(
    Id,
    Name,
    SegmentId
)
SELECT DISTINCT [Customer ID], [Customer Name], dbo.Segment.Id FROM dbo.Orders$ JOIN dbo.Segment ON dbo.Segment.SegmentName= dbo.Orders$.Segment;

--Category
CREATE TABLE Category
(
   Id int IDENTITY(1,1) PRIMARY KEY,
   CategoryName nvarchar(20) NOT NULL,
   ParentCategoryId INT NULL FOREIGN KEY REFERENCES Category(Id)  
);
--заполняем категориями
INSERT INTO dbo.Category (CategoryName)
SELECT o.Category FROM dbo.Orders$ o GROUP BY o.Category ORDER BY o.Category
--заполняем субкатегориями
INSERT INTO dbo.Category (CategoryName,ParentCategoryId)
SELECT  o.[Sub-Category], c.Id FROM Orders$ o
JOIN Category c ON o.Category=c.CategoryName
GROUP BY o.[Sub-Category], c.Id
ORDER BY o.[Sub-Category];

--Ship Mode
CREATE TABLE ShipMode
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Ship_Mode NVARCHAR(100) NOT NULL
);

INSERT INTO ShipMode(Ship_Mode)
SELECT o.[Ship Mode] FROM Orders$ o GROUP BY o.[Ship Mode] ORDER BY o.[Ship Mode];

--Таблица продуктов
CREATE TABLE Product
(
  ProductId NVARCHAR(20) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(200) NOT NULL,
  CategoryId INT NOT NULL FOREIGN KEY REFERENCES dbo.Category(Id),
  Sale MONEY DEFAULT(0)
);

CREATE OR ALTER FUNCTION GetSale(@Sales MONEY,@Quantity MONEY,@Discount MONEY) RETURNS MONEY
AS
BEGIN
 DECLARE @Result MONEY
  IF @Discount=0 
  	SET @Result=(@Sales/@Quantity);
  ELSE
  	SET @Result=(@Sales/@Quantity/(1-@Discount));
 RETURN @Result;
END;

INSERT INTO Product (ProductId, ProductName, CategoryId, Sale)
SELECT DISTINCT o.[Product ID], o.[Product Name], c.Id,dbo.GetSale(o.Sales,o.Quantity,o.Discount) FROM Orders$ o
JOIN  dbo.Category c ON o.[Sub-Category] = c.CategoryName;

--Order
CREATE TABLE [Order]
(
	OrderId NVARCHAR(100) PRIMARY KEY,
	CustomerId NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Customer(Id),
	OrderDate DATETIME2 NOT NULL,
	ShipDate DATETIME2 NULL,
	ShipModeId INT NULL FOREIGN KEY REFERENCES ShipMode(Id),
);


INSERT INTO [Order](OrderId, CustomerId, OrderDate, ShipDate, ShipModeId)
SELECT  o.[Order ID], o.[Customer ID], o.[Order Date], o.[Ship Date], sm.Id FROM Orders$ o
INNER JOIN ShipMode sm ON o.[Ship Mode]=sm.Ship_Mode
GROUP BY o.[Order ID],o.[Customer ID],o.[Order Date], o.[Ship Date], sm.Id;


--Order Info
CREATE TABLE OrderData
(
	OrderId NVARCHAR(100) NOT NULL  FOREIGN KEY REFERENCES [Order](OrderId),
	ProductId NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT DEFAULT 0,
	Discount REAL DEFAULT 0,
	Profit REAL DEFAULT 0
);

INSERT INTO OrderData (OrderId, ProductId, Quantity, Discount, Profit)
SELECT o.[Order ID], o.[Product ID], o.Quantity, o.Discount, o.Profit FROM Orders$ o

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IIF(Discount=0,Sales/Quantity,Sales/Quantity/(1-o.Discount))

SELECT  o.[Product ID], o.[Product Name] FROM Orders$ o WHERE o.[Product ID]='FUR-FU-10004270' GROUP BY o.[Product ID], o.[Product Name];

SELECT DISTINCT o.[Order ID], o.[Order Date], o.[Ship Date], o.[Ship Mode], o.[Customer ID], o.[Customer Name], o.Segment, o.Country, o.City, o.State, o.[Postal Code], o.Region, o.[Product ID], o.Category, o.[Sub-Category], o.[Product Name], o.Sales, o.Quantity, o.Discount, o.Profit FROM Orders$ o  WHERE o.[Product ID]='FUR-FU-10004270'; 

JOIN dbo.[Sub-Category] ON o.[Sub-Category] = [Sub-Category].[Sub-Category] WHERE o.Quantity=1

SELECT  o.[Product ID], o.Category, o.[Sub-Category], o.[Product Name] FROM Orders$ o
JOIN Orders$ o1 ON o.[Product ID] = o1.[Product ID] AND o.[Product Name] != o1.[Product Name]
GROUP BY o.[Product Name],o.[Product ID], o.Category, o.[Sub-Category]
ORDER BY o.[Product ID] DESC

USE HomeWork23Exel

DROP DATABASE TempExel;

DELETE dbo.Segment WHERE dbo.Segment.Id>3;

SELECT * FROM Orders$ o