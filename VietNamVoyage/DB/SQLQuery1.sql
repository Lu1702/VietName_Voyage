CREATE DATABASE TravelDB;
GO

USE TravelDB;
GO

CREATE TABLE Admin
(
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL
);

CREATE TABLE Users
(
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL
);

CREATE TABLE Destinations
(
    IdDestination INT IDENTITY(1,1) PRIMARY KEY,
    NameDestination NVARCHAR(100) NOT NULL,
    Image NVARCHAR(500),
    Description NVARCHAR(MAX)
);

CREATE TABLE Reviews
(
    IdReview INT IDENTITY(1,1) PRIMARY KEY,

    IdUser INT NOT NULL,
    IdDestination INT NOT NULL,

    Review NVARCHAR(MAX) NOT NULL,

    CONSTRAINT FK_Reviews_Users
        FOREIGN KEY (IdUser)
        REFERENCES Users(IdUser),

    CONSTRAINT FK_Reviews_Destinations
        FOREIGN KEY (IdDestination)
        REFERENCES Destinations(IdDestination)
);