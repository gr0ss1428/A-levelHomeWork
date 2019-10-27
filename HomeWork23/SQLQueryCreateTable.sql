CREATE DATABASE OfficeStruct;

USE OfficeStruct;

CREATE TABLE Department (
	ID INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Employee
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(ID),
	ChiefId INT NULL FOREIGN KEY REFERENCES Employee(ID),
	[Name] NVARCHAR(100) NOT NULL,
	Salary MONEY NOT NULL DEFAULT(0)
);

ALTER TABLE Employee ADD UNIQUE([Name]); 

INSERT INTO Department (Name) VALUES ('Administration'), ('Cafeteria'), ('Human Resources'), ('Power'), ('Shipping'), ('Accounting'), ('Data processing'), ('Cleaning');

INSERT INTO Employee (ChiefId, Name, DepartmentId)
VALUES (NULL, 'Steve', (SELECT d.Id FROM Department d WHERE Name = 'Cafeteria')),
	   (NULL, 'Gordon', (SELECT d.Id FROM Department d WHERE Name = 'Human Resources')),
	   (NULL, 'Denis', (SELECT d.Id FROM Department d WHERE Name = 'Power')),
	   (NULL, 'John', (SELECT d.Id FROM Department d WHERE Name = 'Shipping')),
	   (NULL, 'Samantha', (SELECT d.Id FROM Department d WHERE Name = 'Accounting')),
	   (NULL, 'Trace', (SELECT d.Id FROM Department d WHERE Name = 'Data processing'));

INSERT INTO Employee (ChiefId, Name, DepartmentId)
SELECT (SELECT TOP 1 Id FROM Employee WHERE Name != 'Bob'), -- подзапрос получения идентификатора начальника
	   Names.Name, -- имя из FROM
	   (SELECT Id FROM Department WHERE Name = 'Administration') -- подзапрос получения идентификатора департамента 'Administration'
FROM (VALUES ('Raymond'), ('Hannah'), ('Ruby')) AS Names(Name);


CREATE TABLE #names (Name nvarchar(100) UNIQUE)
INSERT INTO #names VALUES ('Lionel'), ('Kermit'), ('Hayden'), ('Rashad'), ('Kimberly'), ('Thaddeus'), ('Brynn'), ('Madonna'), ('Eagan'), ('Rudyard'), ('Aidan'), ('Kim'), ('Oscar'), ('Stewart'), ('Kirk'), ('Keith'), ('Blaine'), ('Eden'), ('Aubrey'), ('Lydia'), ('Rhea'), ('Shelby'), ('Haviva'), ('Miranda'), ('Dorian'), ('Reuben'), ('Michael'), ('Joy'), ('Thane'), ('Cynthia'), ('Chanda'), ('Macey'), ('Fay'), ('Ryder'), ('Olivia'), ('Imelda'), ('Marah'), ('Eric'), ('Denise'), ('Clark'), ('Cheryl'), ('Tyrone'), ('Otto'), ('Dakota'), ('Nora'), ('Neville'), ('Adena'), ('Hiram'), ('Cally'), ('Lois'), ('Cassandra'), ('Herman'), ('Len'), ('Walker'), ('Fiona'), ('Graiden'), ('Hamilton'), ('Cruz'), ('Axel'), ('Velma'), ('Mariam'), ('Jin'), ('Colt'), ('Kaitlin'), ('Frances'), ('Britanni'), ('Linus'), ('Wayne'), ('Knox'), ('Hyacinth'), ('Yael'), ('Lesley'), ('Jaime'), ('Aline'), ('Dalton'), ('Irene'), ('Scarlet'), ('Mariko'), ('Brady'), ('Blair'), ('Madeson'), ('Jena'), ('Josephine'), ('Joel'), ('Moana'), ('Colton'), ('Abbot'), ('Aristotle'), ('Perry'), ('Phillip'), ('Kamal'), ('Lamar'), ('Steel');


DECLARE @currentName nvarchar(100) = (SELECT TOP 1 Name from #names); -- создать переменную и записать в нее первое имя из временной таблицы
DECLARE @departmentId int, @chiefId int; -- объявить переменные для хранения идентификаторов
-- цикл while
WHILE @currentName IS NOT NULL -- пока имена во временной таблице не закончатся
BEGIN
	SELECT TOP 1 @chiefId = Id, @departmentId = DepartmentId FROM Employee ORDER BY NEWID(); -- выбрать 1 случайного Employee и записать его Id и DepartmentId в @переменные; если сложно понять выполните SELECT * FROM Employee ORDER BY NEWID(); несколько раз и следите за порядком
	INSERT INTO Employee (ChiefId, Name, DepartmentId) VALUES (@chiefId, @currentName, @departmentId); -- вставить нового рабочего с полями из переменных
	DELETE FROM #names WHERE Name = @currentName; -- удалить текущее имя из временной таблицы имен
	SET @currentName = (SELECT TOP 1 Name from #names); -- выбрать следующее имя из таблицы или NULL если имена закончились
END;
DROP TABLE #names;

UPDATE Employee -- таблица
SET Salary = CAST(ABS(CHECKSUM(NewId())) AS MONEY) % 100000 / 100 + 500 -- не стоит особо вникать в генерацию, полученное число в пределах [500.00; 1500.00]
WHERE Salary = 0; -- проставить только тем у кого зарплата 0


SELECT * FROM Employee ORDER BY Salary;


