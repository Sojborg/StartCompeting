--CREATE TABLE [User]
--(
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Username varchar(30),
--	[Password] varchar(30)
--)

--CREATE TABLE [Race]
--(
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Name varchar(200),
--	RaceLength decimal(18, 1),
--	CreatedDate DateTime
--)

--CREATE TABLE [RaceType]
--(
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	Name varchar(50)
--)

--CREATE TABLE [UserRaces]
--(
--	Id int IDENTITY(1,1) PRIMARY KEY,
--	UserId int,
--	RaceId int,
--	CreatedDate DateTime
--)

INSERT INTO [User] (Username, [Password]) VALUES ('Jesper', '123')
INSERT INTO [User] (Username, [Password]) VALUES ('Hans', '456')

INSERT INTO Race (Name, RaceLength, RaceTypeId, CreatedDate) VALUES ('Bakkel�bet 2014', 120, 1, '2014-04-21')
INSERT INTO Race (Name, RaceLength, RaceTypeId, CreatedDate) VALUES ('Grejsdall�bet 2014', 170, 1, '2014-04-30')

INSERT INTO RaceType (Name) VALUES ('Cycling')

INSERT INTO UserRaces (UserId, RaceId, CreatedDate) VALUES (1, 3, '2014-04-21')
INSERT INTO UserRaces (UserId, RaceId, CreatedDate) VALUES (1, 2, '2014-04-21')


select * from [Users]

select * from races

select * from RaceTypes

select * from UserRaces