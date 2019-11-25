CREATE DATABASE GameStories;

USE GameStories;

CREATE TABLE Publishers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    License NVARCHAR(100) NOT NULL
)

CREATE TABLE Genres
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
)

CREATE TABLE Games
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL, 
    YearPublishing INT NOT NULL,
    GenreId INT NULL FOREIGN KEY REFERENCES Genres(Id) ON DELETE SET NULL,
    PublicherId INT NULL FOREIGN KEY REFERENCES Publishers(Id) ON DELETE SET NULL,
    UNIQUE([Name],YearPublishing)
)

CREATE TABLE GenrePub
(
  PubId INT FOREIGN KEY REFERENCES Publishers(Id),
  GenId INT FOREIGN KEY REFERENCES Genres(Id),
  PRIMARY KEY(PubId,GenId),
  UNIQUE(GenId)
)
INSERT GenrePub (PubId, GenId)
	VALUES (2, 1);

USE master;

DROP DATABASE GameStories;

DROP TABLE Games
DROP TABLE Publishers
DROP TABLE Genres

USE JewerlyStore;
DELETE Stones;
DELETE Products;
DELETE JewerlyTypes;
DELETE StoneProducts;