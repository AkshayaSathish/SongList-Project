CREATE DATABASE MyProject
USE MyProject;
CREATE TABLE Song
(
SongId int not null PRIMARY KEY,
--SingerId int not null ,Constraint FK_SongSinger FOREIGN KEY (SingerId) REFERENCES Singers(SingerId), 
Name varchar(30),
Genre varchar(10),
Instruments varchar(15),
Directors varchar(30),

);

INSERT INTO Song (Name,Genre,Instruments,Directors)
VALUES('Anbil Avan','Rock','Piano','Imman');
INSERT INTO Song  VALUES('Nee Dhan En Ponvasandham','Jazz','Guitar','Santhosh Narayanan');
INSERT INTO Song  VALUES('My Name Is Billa','Pop','Violin','Arijt Singh');
INSERT INTO Song  VALUES('Munbea Vaa En ','Blues','SaxoPhone','Anirudh');
INSERT INTO Song  VALUES('Kanmani Anbodu','Disco','Clarinet','Hiphop Tamizha');

ALTER TABLE SONG DROP CONSTRAINT FK_SongSinger   
ALTER TABLE SONG DROP COLUMN SingerId

SELECT * FROM Song
DROP TABLE Song



CREATE TABLE Singers
(
SingerId int not null PRIMARY KEY ,
SingerName varchar(20),
Gender varchar(1),
AwardsId int not null ,
CONSTRAINT FK_AwardSinger FOREIGN KEY (AwardsId)
REFERENCES Awards(AwardsId)

--ALTER TABLE Singers
--DROP FOREIGN KEY FK_AwardSinger;

--ALTER TABLE Singers
--DROP CONSTRAINT FK_AwardSinger;
);

INSERT INTO Singers (SingerName,Gender,AwardsId)
VALUES ('SidSriram','M',1);
INSERT INTO Singers VALUES ('Akshaya','F',2);
INSERT INTO Singers VALUES ('Shreya Ghoshal','F',3);
INSERT INTO Singers VALUES ('AR Rahman','M',4);
INSERT INTO Singers VALUES ('SPB','M',3);



SELECT * FROM Singers
DROP TABLE Singers


CREATE TABLE Awards
(
AwardsId int NOT NULL PRIMARY KEY,
Year int,
AwardsName varchar(20)

);

INSERT INTO Awards (Year,AwardsName) VALUES (1980,'Grammy');
INSERT INTO Awards VALUES (1994,'Mirchi');
INSERT INTO Awards VALUES (1992,'Filmfare');
INSERT INTO Awards VALUES (1992,'BillBoard');
INSERT INTO Awards VALUES (1960,'American');

SELECT * FROM Awards
DROP TABLE Awards