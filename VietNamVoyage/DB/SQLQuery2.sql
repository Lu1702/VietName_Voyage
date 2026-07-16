CREATE DATABASE TravelDB;
GO

USE TravelDB;
GO

select * from Admin
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


-- Admin
INSERT INTO Admin(Username, Password)
VALUES
('admin', '123456');

-- Users
INSERT INTO Users(Username, Password)
VALUES
('lam', '123456'),
('khoa', '654321');

-- Destinations
INSERT INTO Destinations(NameDestination, Image, Description)
VALUES
(
    N'Đà Lạt',
    'dalat.jpg',
    N'Thành phố ngàn hoa.'
),
(
    N'Phú Quốc',
    'phuquoc.jpg',
    N'Đảo ngọc của Việt Nam.'
);

-- Reviews
INSERT INTO Reviews(IdUser, IdDestination, Review)
VALUES
(1, 1, N'Địa điểm rất đẹp, không khí mát mẻ.'),
(2, 2, N'Biển trong xanh, đồ ăn ngon.');