



------DDL COMMANDS-----
    ---CREATE DB----
CREATE DATABASE MyProject;
USE MyProject;

----CREATE Table----

CREATE TABLE Singers
(


SingerId int not null PRIMARY KEY ,
SingerName varchar(20),
Gender varchar(1),
AwardsId int not null ,
CONSTRAINT FK_AwardSinger FOREIGN KEY (AwardsId)
REFERENCES Awards(AwardsId)

);


-----INSERT Values into the Respective COLUMNS-----

INSERT INTO Singers (SingerName,Gender,AwardsId)
VALUES ('SidSriram','M',1);
INSERT INTO Singers VALUES ('Akshaya','F',2);
INSERT INTO Singers VALUES ('Shreya Ghoshal','F',3);
INSERT INTO Singers VALUES ('AR Rahman','M',4);
INSERT INTO Singers VALUES ('SPB','M',3);

-----SELECT all columns in the TABLE------

SELECT * FROM Singers

----Delete the Table----

DROP TABLE Singers

----ALTER Table----

ALTER TABLE Singers ADD SingerAward varchar(20);

----To Drop ALTER Table----

ALTER TABLE Singers DROP COLUMN SingerAward;

--- INSERT another Entity to the table---

INSERT INTO Singers VALUES ('GV Prakash','M',4);

TRUNCATE TABLE singers;

---Rename the Table from Singers to Singer ---

sp_rename 'singer','singers';

---------------------------------------------

CREATE TABLE Singers
(

----- Setting NOT NULL Constraint -----
SingerId int not null,
SingerName varchar(20),
Gender varchar(1),
AwardsId int not null ,

----Setting PRIMARY KEY----
PRIMARY KEY(SingerId),


------Setting FOREIGN KEY -------
CONSTRAINT FK_AwardSinger FOREIGN KEY (AwardsId)
REFERENCES Awards(AwardsId)

);

INSERT INTO Singers (SingerName,Gender,AwardsId)
VALUES ('SidSriram','M',1);
INSERT INTO Singers VALUES ('Akshaya','F',2);
INSERT INTO Singers VALUES ('Shreya Ghoshal','F',3);
INSERT INTO Singers VALUES ('AR Rahman','M',4);
INSERT INTO Singers VALUES ('SPB','M',3);

SELECT * FROM Singers


-----Award Table----
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
