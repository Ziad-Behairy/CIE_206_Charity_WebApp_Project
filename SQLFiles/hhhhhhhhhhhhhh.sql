

create database Charity_DataBase;

GO

use Charity_DataBase;

GO

create table Persons (
	Number int unique not null,

	EnteredDate date NOT NULL DEFAULT GETDATE(),

	PersonType varchar(2) NOT NULL,

	PersonID varchar(20) NOT NULL primary key,
		
	Fname nvarchar(20) COLLATE Arabic_CI_AS not null,

	Lname nvarchar(20) COLLATE Arabic_CI_AS not null,

	PhoneNumber nvarchar(12) COLLATE Arabic_CI_AS unique,

	Gender nvarchar(6) CHECK (Gender IN ('Male', 'Female')),

	BirthDate date CHECK (BirthDate >= '1923-01-01' AND DATEDIFF(day, BirthDate, GETDATE()) >= (365.25 * 18)),

	Age int,

	Country varchar(20)
);

GO

CREATE FUNCTION GenerateID(@UserType VARCHAR(2), @EnteredDate DATE, @Number INT)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @ID VARCHAR(20)

    SET @ID = 
        CASE @UserType
            WHEN 'A' THEN '1'
            WHEN 'E' THEN '2'
            WHEN 'V' THEN '3'
            WHEN 'D' THEN '4'
            WHEN 'AD' THEN '5'
            WHEN 'ED' THEN '6'
            WHEN 'DV' THEN '7'
            WHEN 'VD' THEN '7'
            WHEN 'U' THEN '9'
			When 'N' THEN '10'
        END 
        + RIGHT(YEAR(@EnteredDate), 4) 
        + CASE 
            WHEN @Number < 10 THEN '000' + CAST(@Number AS CHAR(1))
            WHEN @Number < 100 THEN '00' + CAST(@Number AS CHAR(2))
            WHEN @Number < 1000 THEN '0' + CAST(@Number AS CHAR(3))
            ELSE CAST(@Number AS VARCHAR(20))
        END

    RETURN @ID
END

GO

CREATE PROCEDURE ModifyPersonType @PersonID VARCHAR(20), @UserType VARCHAR(2)
AS
BEGIN
    UPDATE Persons
    SET PersonID = 
        CASE @UserType
            WHEN 'A' THEN '1' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'E' THEN '2' + SUBSTRING(PersonID, 2, LEN(PersonID))
			WHEN 'EM' THEN '3' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'V' THEN '4' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'D' THEN '5' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'AD' THEN '6' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'ED' THEN '7' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'DV' THEN '8' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'VD' THEN '8' + SUBSTRING(PersonID, 2, LEN(PersonID))
            WHEN 'U' THEN '9' + SUBSTRING(PersonID, 2, LEN(PersonID))
            ELSE PersonID
        END,
        PersonType = @UserType
    WHERE PersonID = @PersonID
END

GO

drop trigger trInsertPerson
CREATE TRIGGER trInsertPerson
ON Persons
INSTEAD OF INSERT
AS
BEGIN

	DECLARE @currentDate Date, @maxDate Date, @Number INT
	SET @currentDate = GETDATE()
	SELECT @maxDate = MAX(EnteredDate) FROM Persons
	IF (@maxDate IS NOT NULL)
	BEGIN
		IF (@currentDate < @maxDate)
		BEGIN
			RAISERROR ('Invalid Date Please Check Your System Date (Current Date Cannot be in past!)', 16, 1)
			ROLLBACK TRANSACTION
			RETURN
		END
		IF (Year(@currentDate) <> Year(@maxDate))
		BEGIN
			DBCC CHECKIDENT (Persons, RESEED, 0)
		END
	END
	 

	SELECT @Number = ISNULL(MAX(Number), 0) + 1 FROM Persons
	

	INSERT INTO Persons (Number, PersonID, PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Age, Country)
	SELECT
		@Number,
		dbo.GenerateID(I.PersonType,I.EnteredDate, @Number),
		I.PersonType,
		I.Fname,
		I.Lname,
		I.PhoneNumber,
		COALESCE(I.Gender, null),
		COALESCE(I.BirthDate, null),
		CASE WHEN I.BirthDate IS NULL THEN null ELSE DATEDIFF(YEAR, I.BirthDate, GETDATE()) END,
		COALESCE(I.Country, Null)
	FROM inserted AS I;
END

GO

insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('A', 'amr', 'ashraf', '01019702121', 'Male', '2002-10-16', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('E', 'amr', 'ashraf', '01019702122', 'Male', '2002-10-16', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'amr', 'ashraf', '01019702123', 'Male', '2002-10-16', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('V', 'amr', 'ashraf', '01019702124', 'Male', '2002-10-16', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('D', 'amr', 'ashraf', '01019702125', 'Male', '2002-10-16', 'Egypt');


insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('A', 'ahmed', 'amin', '01288024972', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('E', 'ahmed', 'amin', '01288024973', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ahmed', 'amin', '01288024974', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('V', 'ahmed', 'amin', '01288024975', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('D', 'ahmed', 'amin', '01288024976', 'Male', '2003-1-1', 'Egypt');

insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('A', 'omar', 'awad', '01211653734', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('E', 'omar', 'awad', '01211653735', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'omar', 'awad', '01211653736', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('V', 'omar', 'awad', '01211653737', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('D', 'omar', 'awad', '01211653738', 'Male', '2003-1-1', 'Egypt');

insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('A', 'ziad', 'elbehairy', '01008000951', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('E', 'ziad', 'elbehairy', '01008000952', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ziad', 'elbehairy', '01008000953', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('V', 'ziad', 'elbehairy', '01008000954', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('D', 'ziad', 'elbehairy', '01008000955', 'Male', '2003-1-1', 'Egypt');


insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ahmed', 'amin', '01288021072', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'mohamed', 'amin', '01282024972', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'omar', 'awad', '01211655734', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'Fares', 'awad', '01213053734', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'Hamed', 'awad', '01211453734', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ziad', 'elbehairy', '01007000951', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'Shawqy', 'elbehairy', '01002200951', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber, Gender, BirthDate, Country) values ('U', 'Mohsen', 'elbehairy', '01003500951', 'Male', '2003-1-1', 'Egypt');
insert into Persons (PersonType, Fname, Lname, PhoneNumber) values ('U', 'Mohsen', 'elbehairy', '01503500951');
insert into Persons (PersonType, Fname, Lname, PhoneNumber) values ('U', 'Mohsen', 'elbehairy', '01503500751');

select * from Persons
delete from Persons
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

create table Accounts
(
	PersonID varchar(20) foreign key references Persons(PersonID) ON UPDATE CASCADE ON DELETE CASCADE,

	U_Email nvarchar(50) COLLATE Latin1_General_CS_AS unique NOT NULL
		CHECK (U_Email LIKE '%@%.__%' AND U_Email NOT LIKE '%@%@%'),

	U_Password nvarchar(20) COLLATE Latin1_General_CS_AS NOT NULL
		CHECK( (LEN(U_Password) > 8) AND U_Password LIKE '%[A-Z]%' AND U_Password LIKE '%[a-z]%' AND U_Password LIKE '%[0-9]%')
);

select * from Persons Order by Number
select * from Accounts


insert into Accounts (PersonID, U_Email, U_Password) values ('120230001', 'amra@amr.amr', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('220230002', 'amre@amr.amr', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230003', 'amru@amr.amr', 'Aa12345678');


insert into Accounts (PersonID, U_Email, U_Password) values ('420230015', 'ahmeda@ahmed.ahmed', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('420230020', 'ahmede@ahmed.ahmed', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230003', 'ahmedu@ahmed.ahmed', 'Aa12345678');

insert into Accounts (PersonID, U_Email, U_Password) values ('920230022', 'omara@omar.omar', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230025', 'omare@omar.omar', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230027', 'omaru@omar.omar', 'Aa12345678');

insert into Accounts (PersonID, U_Email, U_Password) values ('920230028', 'ziada@ziad.ziad', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230030', 'ziade@ziad.ziad', 'Aa12345678');
insert into Accounts (PersonID, U_Email, U_Password) values ('920230029', 'ziadu@ziad.ziad', 'Aa12345678');
			
GO

CREATE VIEW Users AS
SELECT P.PersonID AS UserID, P.PersonType AS UserType, P.Fname, P.Lname, A.U_Email, A.U_Password, P.PhoneNumber, P.Gender, P.BirthDate, P.Country, P.Age, P.EnteredDate AS CreateDate FROM Persons AS P, Accounts AS A
where P.PersonID =  A.PersonID;

GO

select * from Users



------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------

create table Branchs
(
	BranchID int identity(1,1) primary key,

	BranchAdress nvarchar(100) COLLATE Arabic_CI_AS,

	BranchName nvarchar(100) COLLATE Arabic_CI_AS,

	BranchAdmin varchar(20) FOREIGN KEY REFERENCES Persons ON DELETE SET NULL ON UPDATE CASCADE
);


insert into Branchs(BranchAdress,BranchName,BranchAdmin) values (N'العبور', N'عائلتي','120230001')
insert into Branchs(BranchAdress,BranchName,BranchAdmin) values (N'بنها', N'عائلتي','120230011')
select * from Persons
select * from Branchs




CREATE TABLE Employees (
    EmployeeID varchar(20) foreign key references Persons ON UPDATE CASCADE ON DELETE CASCADE,
    
	WorkingBranch int foreign key references Branchs ON DELETE SET NULL,
    
	Salary   int not null,
    
	EmployeeAdress nvarchar(100) COLLATE Arabic_CI_AS,
    
	EmployeeSSN varchar(20) Unique not null,
);
select p.Fname,p.Lname,v.EmployeeSSN ,p.PhoneNumber,v.EmployeeAdress,v.WorkingBranch,v.Salary from 
Employees as v left join Persons as p
on(v.EmployeeID=p.PersonID)

insert into Employees( EmployeeID,WorkingBranch,Salary,EmployeeAdress,EmployeeSSN)
values ('920230030','5',100000,N'بنها','920230030')
insert into Employees values ('220230002','6',155000,N'دمياط','920230029')

insert into Employees( EmployeeID,WorkingBranch,Salary,EmployeeAdress,EmployeeSSN)
values ('920230029','5',100000,N'بنها','920230028')

insert into Employees values ('920230003','6',155000,N'دمياط','120230001')

insert into Employees( EmployeeID,WorkingBranch,Salary,EmployeeAdress,EmployeeSSN)
values ('420230015','5',100000,N'بنها','920230003')

insert into Employees values ('420230020','6',155000,N'دمياط','420230015')
insert into Employees( EmployeeID,WorkingBranch,Salary,EmployeeAdress,EmployeeSSN)
values ('920230025','5',100000,N'بنها','420230020')

insert into Employees values ('220230002','6',155000,N'دمياط','920230025')

select * from Employees
create table Volunteer
(
	VoulanteerId varchar(20) foreign key references Persons ON UPDATE CASCADE ON DELETE CASCADE,

	Address nvarchar(100) COLLATE Arabic_CI_AS,

	Notes nvarchar(max) COLLATE Arabic_CI_AS,

	VoulanteerSection nvarchar(50) COLLATE Arabic_CI_AS,

	VolunteerBranch int foreign key references Branchs ON DELETE SET NULL
);

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','014569711135')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='014569711135'),'cairo', 'no', 'clothes',5)
---
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','014569722235')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='014569722235'),'cairo', 'no', 'clothes',5)
-------
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','01444422235')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='01444422235'),'cairo', 'no', 'clothes',5)
----
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','0141111115')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='0141111115'),'cairo', 'no', 'clothes',5)
-----
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','014111444')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='014111444'),'cairo', 'no', 'clothes',6)
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','414111444')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='414111444'),'cairo', 'no', 'clothes',6)
INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','888811444')
insert into Volunteer(VoulanteerId,Address,Notes ,VoulanteerSection,VolunteerBranch)
values ((select personID from Persons where PhoneNumber='888811444'),'cairo', 'no', 'clothes',6)

select p.Fname,p.Lname,p.PhoneNumber,v.VoulanteerSection,v.VoulanteerId,v.Address,v.Notes,v.VolunteerBranch from 
Volunteer as v left join Persons as p
on(v.VoulanteerId=p.PersonID)

CREATE TABLE Tasks (
	TaskID int identity(1,1) primary key,
    T_Name nvarchar(50) NOT NULL,
    T_assigne_day date NOT NULL,
    T_State nvarchar(13) NOT NULL CHECK (T_State IN (N'تم', N'قيد التنفيذ')),
    T_finsh_day date,
    T_Employee_id varchar(20) FOREIGN KEY REFERENCES Persons,
    T_notes nvarchar(max)
);


CREATE TRIGGER CheckFinishDay
ON Tasks
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted 
        WHERE T_finsh_day < T_assigne_day AND T_State =N'تم'
    )
    BEGIN
        RAISERROR ('The finish day cannot be earlier than the assignment day when the state is "Êã".', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


insert into Tasks values
(N'توزيع شنط','1923-01-01',N'تم','1924-03-01','220230012',N'لا يوجد' ),
(N'توزيع طعام','1923-01-01',N'تم','1924-03-01','220230017',N'لا يوجد' ),
(N'تجهيز عرائس','1923-01-01',N'تم','1924-03-01','220230012',N'لا يوجد' )

select * from Tasks
select * from DonatorInformation

SELECT T.T_Name, T.T_assigne_day, CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName, T.T_State,T_finsh_day ,T.T_notes 

FROM Tasks AS T JOIN Persons AS U ON U.PersonID = T.T_Employee_id

order by CONCAT(U.Fname, ' ', U.Lname)





------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------






create table Donators
(
	DonatorID varchar(20) foreign key references Persons ON UPDATE CASCADE ON DELETE SET NULL,

	Address nvarchar(100) COLLATE Arabic_CI_AS,

	Job nvarchar (50) COLLATE Arabic_CI_AS,

	Email varchar(20),

	DonationAmount nvarchar(50) COLLATE Arabic_CI_AS,

	Notes nvarchar(max) COLLATE Arabic_CI_AS,
)

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','014777777777')
insert into Donators values ((select personID from Persons where PhoneNumber='014777777777'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','0147744586333')
insert into Donators values ((select personID from Persons where PhoneNumber='0147744586333'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','456666663112')
insert into Donators values ((select personID from Persons where PhoneNumber='456666663112'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','22223111411')
insert into Donators values ((select personID from Persons where PhoneNumber='22223111411'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','22223777777')
insert into Donators values ((select personID from Persons where PhoneNumber='22223111411'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

INSERT INTO Persons (PersonType, Fname, Lname, PhoneNumber)
VALUES ('v','Ahmed','amin','42111111777')
insert into Donators values ((select personID from Persons where PhoneNumber='42111111777'),'dsfd','sdfsdfsg','ghj@gjkg.fjh','4456','no')

select * from Donators

create table Donations
(
   DonationsID varchar(20) primary key,

   dontiontype  nvarchar(50) COLLATE Arabic_CI_AS,

   DonatorID varchar(20) FOREIGN KEY REFERENCES Persons ON UPDATE CASCADE ON DELETE SET NULL,

   donationItem nvarchar(50) COLLATE Arabic_CI_AS,
)
insert into Donations
values(1,N'food',120230016,N'لحم'),
(2,N'food',120230016,N'لحم'),
(3,N'food',120230016,N'لحم'),
(4,N'food',120230016,N'لحم'),
(5,N'food',120230016,N'لحم'),
(6,N'food',120230016,N'لحم'),
(7,N'food',120230016,N'لحم')
select * from Donations

GO

drop view DonatorInformation

create view DonatorInformation
AS 
select P.Fname , P.Lname , P.PhoneNumber, D.Email, D.Address, D.Job, D.DonationAmount, D.Notes 

from Donators AS D , Persons AS P

where D.DonatorID = P.PersonID 


select * from DonatorInformation



select * from Users

------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Needy (
    Number int UNIQUE,
    NeedyID varchar(20) PRIMARY KEY,
    Fname nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    Mname nvarchar(255) COLLATE Arabic_CI_AS,
    Lname nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    Familyname nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    SSN nvarchar(14) COLLATE Arabic_CI_AS UNIQUE NOT NULL,
    PhoneNum nvarchar(14) COLLATE Arabic_CI_AS UNIQUE,
    BirthDate nvarchar(10) COLLATE Arabic_CI_AS NOT NULL,
    StreetAddress nvarchar(max) COLLATE Arabic_CI_AS NOT NULL,
    floornum nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    Area nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    mark nvarchar(255) COLLATE Arabic_CI_AS NOT NULL,
    Income nvarchar(255) COLLATE Arabic_CI_AS,
    NumberOfFamilyMembers nvarchar(255) COLLATE Arabic_CI_AS,
    AreaCode nvarchar(255) COLLATE Arabic_CI_AS,
    Casetype nvarchar(255) COLLATE Arabic_CI_AS,
    HealthStatus nvarchar(255) COLLATE Arabic_CI_AS,
    EducationalState nvarchar(255) COLLATE Arabic_CI_AS,
    SocialState nvarchar(255) COLLATE Arabic_CI_AS,
    Job nvarchar(255) COLLATE Arabic_CI_AS,
    Details nvarchar(max) COLLATE Arabic_CI_AS,
    AcceptStatus varchar(10) Default '0',
    CreateDate date NOT NULL DEFAULT GETDATE(),
    ImageDataPath nvarchar(max) COLLATE Arabic_CI_AS,
    FrontidimgPath nvarchar(max) COLLATE Arabic_CI_AS,
    BackidimgPath nvarchar(max) COLLATE Arabic_CI_AS,
);
INSERT INTO Needy (Number, NeedyID, Fname, Mname, Lname, Familyname, SSN, PhoneNum, BirthDate, StreetAddress, floornum, Area, mark, Income, NumberOfFamilyMembers, AreaCode, Casetype, HealthStatus, EducationalState, SocialState, Job, Details, AcceptStatus, CreateDate, ImageDataPath, FrontidimgPath, BackidimgPath)
VALUES
    (1, '230001', N'زياد', N'محمد', N'علي', N'بحيري', '12345678901203', '012345670', '02/02/1991', N' بنها شارع عرفه', N'الطابق الثاني', N'منشيه النور', N'جامع السلام', N'صفر', N'  5', N' 00عزسوق', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (2, '230002', N'زياد', N'محمد', N'علي', N'بحيري', '12345678901200', '0123456700', '02/02/1991', N' بنها شارع عرفه', N'الطابق الثاني', N'منشيه النور', N'جامع السلام', N'صفر', N'  5', N' 00عزسوق', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (3, '230003', N'علي', N'محمد', N'أحمد', N'خالد', '12345678901235', '0123456189', '02/02/1991', N'عنوان المنزل', N'الطابق الثاني', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (4, '230004', N'خالد', N'علي', N'محمد', N'أحمد', '12345678901236', '0123456289', '03/03/1992', N'عنوان المنزل', N'الطابق الثالث', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (5, '230005', N'أحمد', N'خالد', N'علي', N'محمد', '12345678901237', '0123456389', '04/04/1993', N'عنوان المنزل', N'الطابق الرابع', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (6, '230006', N'محمد', N'أحمد', N'خالد', N'علي', '12345678901238', '0123456489', '05/05/1994', N'عنوان المنزل', N'الطابق الخامس', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (7, '230007', N'علي', N'محمد', N'أحمد', N'خالد', '12345678901239', '0123456589', '06/06/1995', N'عنوان المنزل', N'الطابق السادس', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (8, '230008', N'خالد', N'علي', N'محمد', N'أحمد', '12345678901240', '0123456689', '07/07/1996', N'عنوان المنزل', N'الطابق السابع', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (9, '230009', N'أحمد', N'خالد', N'علي', N'محمد', '12345678901241', '0123456889', '08/08/1997', N'عنوان المنزل', N'الطابق الثامن', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg'),
    (10, '230010', N'محمد', N'أحمد', N'خالد', N'علي', '12345678901242', '0123450789', '09/09/1998', N'عنوان المنزل', N'الطابق التاسع', N'المنطقة', N'علامة', N'الدخل', N'عدد أفراد العائلة', N'رمز المنطقة', N'نوع الحالة', N'الحالة الصحية', N'الحالة التعليمية', N'الحالة الاجتماعية', N'الوظيفة', N'تفاصيل', '0', GETDATE(), '/UploadedImgs/DSC_4070.jpg', '/UploadedImgs/1662090164799.jpg', '/UploadedImgs/ID.jpeg');