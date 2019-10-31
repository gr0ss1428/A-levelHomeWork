CREATE DATABASE HomeWork23Exel
-- Импортировал Exel фаил с помощью SQL Server 2019 RC1 Import and Export Data  https://docs.microsoft.com/en-us/sql/integration-services/import-export-data/get-started-with-this-simple-example-of-the-import-and-export-wizard?view=sql-server-ver15
USE HomeWork23Exel


--Разбераем сегменты
-- создаем таблицу сегменты и заполняем её
CREATE TABLE Segment
(
 SegmentId int IDENTITY(1,1) PRIMARY KEY,
 SegmentName nvarchar(100) NOT NULL
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
    Country NVARCHAR(100) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    [State] NVARCHAR(100) NOT NULL,
    [Region] NVARCHAR(100) NOT NULL
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
  CustomerId nvarchar(100) PRIMARY KEY NOT NULL,
  [Name] nvarchar(100) NOT NULL,
  SegmentId int NOT NULL FOREIGN KEY REFERENCES dbo.Segment(SegmentId),
);

-- Добавляем записи
INSERT INTO dbo.Customer (CustomerId, Name, SegmentId)
SELECT DISTINCT o.[Customer ID], o.[Customer Name], s.SegmentId FROM dbo.Orders$ o
JOIN dbo.Segment s ON s.SegmentName= o.Segment;

--Category
CREATE TABLE Category
(
   CategoryId int IDENTITY(1,1) PRIMARY KEY,
   CategoryName nvarchar(20) NOT NULL,
   ParentCategoryId INT NULL FOREIGN KEY REFERENCES Category(CategoryId)  
);
--заполняем категориями
INSERT INTO dbo.Category (CategoryName)
SELECT o.Category FROM dbo.Orders$ o GROUP BY o.Category ORDER BY o.Category
--заполняем субкатегориями
INSERT INTO dbo.Category (CategoryName,ParentCategoryId)
SELECT  o.[Sub-Category], c.CategoryId FROM Orders$ o
JOIN Category c ON o.Category=c.CategoryName
GROUP BY o.[Sub-Category], c.CategoryId
ORDER BY o.[Sub-Category];

--Ship Mode
CREATE TABLE ShipMode
(
	ShipModeId INT IDENTITY(1,1) PRIMARY KEY,
	Ship_Mode NVARCHAR(100) NOT NULL
);

INSERT INTO ShipMode(Ship_Mode)
SELECT o.[Ship Mode] FROM Orders$ o GROUP BY o.[Ship Mode] ORDER BY o.[Ship Mode];

--Таблица продуктов
CREATE TABLE Product
(
  ProductId NVARCHAR(100) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(200) NOT NULL,
  CategoryId INT NOT NULL FOREIGN KEY REFERENCES dbo.Category(CategoryId),
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
SELECT DISTINCT o.[Product ID], o.[Product Name], c.CategoryId, dbo.GetSale(o.Sales,o.Quantity,o.Discount) FROM Orders$ o
JOIN  dbo.Category c ON o.[Sub-Category] = c.CategoryName;

--Order
CREATE TABLE [Order]
(
	OrderId NVARCHAR(100) PRIMARY KEY,
	CustomerId NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Customer(CustomerId),
	OrderDate DATETIME2 NOT NULL,
	ShipDate DATETIME2 NULL,
	ShipModeId INT NULL FOREIGN KEY REFERENCES ShipMode(ShipModeId),
	PostalCode INT NULL FOREIGN KEY REFERENCES Address(PostalCode)
);


INSERT INTO [Order](OrderId, CustomerId, OrderDate, ShipDate, ShipModeId, PostalCode)
SELECT  o.[Order ID], o.[Customer ID], o.[Order Date], o.[Ship Date], sm.ShipModeId, o.[Postal Code] FROM Orders$ o
INNER JOIN ShipMode sm ON o.[Ship Mode]=sm.Ship_Mode
GROUP BY o.[Order ID],o.[Customer ID],o.[Order Date], o.[Ship Date], sm.ShipModeId, o.[Postal Code];


--Order Info
CREATE TABLE OrderData
(
	OrderId NVARCHAR(100) NOT NULL  FOREIGN KEY REFERENCES [Order](OrderId),
	ProductId NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT DEFAULT 0,
	Discount REAL DEFAULT 0,
	Profit REAL DEFAULT 0
);

INSERT INTO OrderData (OrderId, ProductId, Quantity, Discount, Profit)
SELECT o.[Order ID], o.[Product ID], o.Quantity, o.Discount, o.Profit FROM Orders$ o


--Общая картина
CREATE OR ALTER FUNCTION GetSaleOrder(@Sales MONEY, @Quantity REAL, @Discount REAL) RETURNS MONEY
AS
BEGIN
	DECLARE @Result MONEY;
	IF @Discount=0
		SET @Result=@Sales*@Quantity;
	ELSE
	BEGIN
		DECLARE @Temp MONEY;
		SET @Temp=@Sales*@Discount;
		SET @Result=(@Sales-@Temp)*@Quantity;
	END;
	RETURN @Result
END;


SELECT od.OrderId, o.OrderDate, o.ShipDate, sm.Ship_Mode, o.CustomerId, c.Name, s.SegmentName, a.Country, a.City, a.State, a.PostalCode, a.Region,
od.ProductId, c2.CategoryName AS Category, c1.CategoryName AS [Sub Category], p.ProductName,dbo.GetSaleOrder(P.Sale,od.Quantity,od.Discount) AS Sales, od.Quantity, od.Discount, od.Profit
FROM OrderData od
JOIN [Order] o ON od.OrderId=o.OrderId
JOIN ShipMode sm ON o.ShipModeId = sm.ShipModeId
JOIN Customer c ON o.CustomerId = c.CustomerId
JOIN Segment s ON c.SegmentId= s.SegmentId
JOIN Address a ON o.PostalCode=a.PostalCode
JOIN Product p ON od.ProductId = p.ProductId
JOIN Category c1 ON p.CategoryId = c1.CategoryId
JOIN Category c2 ON c1.ParentCategoryId=c2.CategoryId



-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Тут темповые вещи для некоторых проверок
IIF(Discount=0,Sales/Quantity,Sales/Quantity/(1-o.Discount))

SELECT  o.[Product ID], o.[Product Name] FROM Orders$ o WHERE o.[Product ID]='FUR-TA-10000198' GROUP BY o.[Product ID], o.[Product Name];

SELECT DISTINCT o.[Order ID], o.[Order Date], o.[Ship Date], o.[Ship Mode], o.[Customer ID], o.[Customer Name], o.Segment, o.Country, o.City, o.State, o.[Postal Code], o.Region, o.[Product ID], o.Category, o.[Sub-Category], o.[Product Name], o.Sales, o.Quantity, o.Discount, o.Profit FROM Orders$ o  WHERE o.[Product ID]='FUR-FU-10004270'; 

JOIN dbo.[Sub-Category] ON o.[Sub-Category] = [Sub-Category].[Sub-Category] WHERE o.Quantity=1

SELECT  o.[Product ID], o.Category, o.[Sub-Category], o.[Product Name] FROM Orders$ o
JOIN Orders$ o1 ON o.[Product ID] = o1.[Product ID] AND o.[Product Name] != o1.[Product Name]
GROUP BY o.[Product Name],o.[Product ID], o.Category, o.[Sub-Category]
ORDER BY o.[Product ID] DESC

SELECT * FROM OrderData o

SELECT DISTINCT o.City,o.[Postal Code] FROM Orders$ o WHERE o.[Postal Code]=92024 

USE master

DROP DATABASE HomeWork23Exel;

DELETE dbo.Segment WHERE dbo.Segment.Id>3;

SELECT * FROM Orders$ o