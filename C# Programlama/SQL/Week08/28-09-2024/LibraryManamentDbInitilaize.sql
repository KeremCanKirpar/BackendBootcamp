-------------------------------------------------------------------------
---- 1) VERİ TABANI YARATMA ADIMI
-------------------------------------------------------------------------
USE master
GO

DROP DATABASE IF EXISTS LibraryManagement
GO

CREATE DATABASE LibraryManagement
GO

USE LibraryManagement
GO

-------------------------------------------------------------------------
---- 2) TABLOLARIN YARATILMASI ADIMI
-------------------------------------------------------------------------

CREATE TABLE LibraryItems(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    PublishedDate DATE NOT NULL,
    ItemType NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Books(
    ItemId INT PRIMARY KEY,
    Author NVARCHAR(100) NOT NULL,
    FOREIGN KEY(ItemId) REFERENCES LibraryItems(Id)
)
GO

CREATE TABLE Magazines(
    ItemId INT PRIMARY KEY,
    IssueNumber NVARCHAR(50) NOT NULL,
    FOREIGN KEY(ItemId) REFERENCES LibraryItems(Id)
)
GO

CREATE TABLE DVDs(
    ItemId INT PRIMARY KEY,
    Director NVARCHAR(100) NOT NULL,
    FOREIGN KEY(ItemId) REFERENCES LibraryItems(Id)
)
GO

CREATE TABLE Members(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    MembershipStatus NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE ContactInfos(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    ContactInfo NVARCHAR(255) NOT NULL,
    FOREIGN KEY(MemberId) REFERENCES Members(Id)
)
GO

CREATE TABLE Borrowings(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    ItemId INT NOT NULL,
    BorrowedDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    FOREIGN KEY(MemberId) REFERENCES Members(Id),
    FOREIGN KEY(ItemId) REFERENCES LibraryItems(Id),
    CHECK (ReturnDate IS NULL OR ReturnDate>BorrowedDate)
)
GO

CREATE TABLE LateFees(
    Id INT PRIMARY KEY IDENTITY(1,1),
    BorrowingId INT NOT NULL,
    FeeAmount DECIMAL(10,2),
    FOREIGN KEY(BorrowingId) REFERENCES Borrowings(Id)
)
GO

CREATE TABLE Ratings(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ItemId INT NOT NULL,
    MemberId INT NOT NULL,
    RatingValue INT CHECK(RatingValue BETWEEN 1 AND 5),
    FOREIGN KEY(ItemId) REFERENCES LibraryItems(Id),
    FOREIGN KEY(MemberId) REFERENCES Members(Id),
    CONSTRAINT UQ_Item_Member UNIQUE(ItemId,MemberId)
)


