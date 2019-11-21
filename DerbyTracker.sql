USE master;
GO

DROP DATABASE IF EXISTS DerbyTracker

CREATE DATABASE DerbyTracker
GO

USE DerbyTracker
GO

CREATE TABLE Skater(
SkaterNumber int PRIMARY KEY,
SkaterName nvarchar(50) NOT NULL
)

CREATE TABLE Penalty(
PenaltyID int IDENTITY PRIMARY KEY,
PenaltyType nvarchar(1) NOT NULL,
SkaterNumber int NOT NULL,
CONSTRAINT fk_Penalty_Skater FOREIGN KEY(SkaterNumber) REFERENCES Skater(SkaterNumber)
)

INSERT INTO Skater(SkaterNumber, SkaterName)
VALUES (423, 'Annabelle Lecture'),
		(210, 'Aphrobitey'),
		(122, 'Barbie'),
		(37, 'Brianna Ruins'),
		(1330, 'ChewRockYa'),
		(4, 'CoCo Sparx'),
		(666, 'Crazy Hex Girlfriend'),
		(256, 'Dee Crypt'),
		(00, 'Deja Voodoo'),
		(14, 'Dottie HitSomeone'),
		(74, 'Enemylou Harris'),
		(1337, 'Furious George'),
		(718, 'Ghostgrace Killah'),
		(78, 'Gnat'),
		(19, 'Ginger n Tonic'),
		(25, 'Gogo Geronimo'),
		(79, 'Golden Malicious'),
		(919, 'Hermione Deranger'),
		(9, 'Killdash'),
		(28, 'Killer Queen'),
		(80, 'Leia Flat'),
		(318, 'Magdalena'),
		(988, 'Maloik'),
		(3, 'Parakeet'),
		(1021, 'Peach Hobble Her'),
		(311, 'Pinky Teasadero'),
		(8181, 'Premo Donna'),
		(425, 'Purple Storm'),
		(84, 'Rainbow Fright'),
		(175, 'Roseblud'),
		(146, 'Sarah-bellum'),
		(30, 'Sheila'),
		(200, 'Sk8-bit'),
		(42, 'Sloan U. Down'),
		(11, 'Stink Flamingo'),
		(10, 'Taco Bout Pain'),
		(208, 'UnicornPrincess'),
		(519, 'Wrath of Khannie'),
		(928, 'Winona Spider'),
		(908, 'Yakity-Yak'),
		(714, 'Youngstown Tune-Up'),
		(17, 'Zooey DishinHell')
	

	
INSERT INTO Penalty(PenaltyType, SkaterNumber) 
VALUES ('A', 919),
		('X', 919),
		('B', 919),
		('A', 11),
		('X', 714),
		('B', 17),
		('D', 42),
		('D', 42),
		('D', 11),
		('F', 175),
		('C', 175),
		('G', 10),
		('H', 10),
		('I', 78),
		('L', 78)
		SELECT * FROM Penalty