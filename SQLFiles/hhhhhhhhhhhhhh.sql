create database CharityDB1;

use CharityDB1;





create table Users (
	UserID int IDENTITY(1,1) primary key,

	UserType nvarchar(2),
		
	Fname nvarchar(20) not null,

	Lname nvarchar(20) not null,

	U_Email nvarchar(50) unique
		CHECK (U_Email LIKE '%@%.__%' AND U_Email NOT LIKE '%@%@%'),
	
	U_Password nvarchar(20) not null
		CHECK( (LEN(U_Password) > 8)
				AND U_Password LIKE '%[A-Z]%'
				AND U_Password LIKE '%[a-z]%'
				AND U_Password LIKE '%[0-9]%'),

	PhoneNumber nvarchar(12),

	Gender nvarchar(6) not null
		CHECK (Gender IN ('Male', 'Female')),

	BirthDate date not null
		CHECK (BirthDate >= '1923-01-01' AND DATEDIFF(day, BirthDate, GETDATE()) >= (365.25 * 18)),


	Country nvarchar(20) not null
		CHECK (Country IN ('Afghanistan', 'Albania', 'Algeria', 'Andorra', 'Angola', 'Antigua and Barbuda',
						   'Argentina', 'Armenia', 'Australia', 'Austria', 'Azerbaijan', 'Bahamas', 'Bahrain', 
						   'Bangladesh', 'Barbados', 'Belarus', 'Belgium', 'Belize', 'Benin', 'Bhutan', 'Bolivia',
						   'Bosnia and Herzegovina', 'Botswana', 'Brazil', 'Brunei', 'Bulgaria', 'Burkina Faso', 
						   'Burundi', 'Cabo Verde', 'Cambodia', 'Cameroon', 'Canada', 'Central African Republic', 
						   'Chad', 'Chile', 'China', 'Colombia', 'Comoros', 'Congo', 'Costa Rica', 'Cote d Ivoire', 
						   'Croatia', 'Cuba', 'Cyprus', 'Czech Republic', 'Denmark', 'Djibouti', 'Dominica', 
						   'Dominican Republic', 'Ecuador', 'Egypt', 'El Salvador', 'Equatorial Guinea', 
						   'Eritrea', 'Estonia', 'Eswatini', 'Ethiopia', 'Fiji', 'Finland', 'France', 'Gabon', 
						   'Gambia', 'Georgia', 'Germany', 'Ghana', 'Greece', 'Grenada', 'Guatemala', 'Guinea', 
						   'Guinea-Bissau', 'Guyana', 'Haiti', 'Honduras', 'Hungary', 'Iceland', 'India', 'Indonesia', 
						   'Iran', 'Iraq', 'Ireland', 'Italy', 'Jamaica', 'Japan', 'Jordan', 'Kazakhstan', 
						   'Kenya', 'Kiribati', 'Kosovo', 'Kuwait', 'Kyrgyzstan', 'Laos', 'Latvia', 'Lebanon', 'Lesotho',
						   'Liberia', 'Libya', 'Liechtenstein', 'Lithuania', 'Luxembourg', 'Madagascar', 'Malawi', 
						   'Malaysia', 'Maldives', 'Mali', 'Malta', 'Marshall Islands', 'Mauritania', 'Mauritius', 
						   'Mexico', 'Micronesia', 'Moldova', 'Monaco', 'Mongolia', 'Montenegro', 'Morocco', 'Mozambique', 
						   'Myanmar', 'Namibia', 'Nauru', 'Nepal', 'Netherlands', 'New Zealand', 'Nicaragua', 'Niger', 
						   'Nigeria', 'North Korea', 'North Macedonia', 'Norway', 'Oman', 'Pakistan', 'Palau', 'Palestine', 
						   'Panama', 'Papua New Guinea', 'Paraguay', 'Peru', 'Philippines', 'Poland', 'Portugal','Qatar', 
						   'Romania', 'Russia', 'Rwanda', 'Saint Kitts and Nevis', 'Saint Lucia', 'Saint Vincent and the Grenadines', 
						   'Samoa', 'San Marino', 'Sao Tome and Principe', 'Saudi Arabia', 'Senegal', 'Serbia', 'Seychelles', 
						   'Sierra Leone', 'Singapore', 'Slovakia', 'Slovenia', 'Solomon Islands', 'Somalia', 'South Africa', 
						   'South Sudan', 'Spain', 'Sri Lanka', 'Sudan', 'Suriname', 'Swaziland', 'Sweden', 'Switzerland', 'Syria',
						   'Taiwan', 'Tajikistan', 'Tanzania', 'Thailand', 'Timor-Leste', 'Togo', 'Tonga', 'Trinidad and Tobago', 
						   'Tunisia', 'Turkey', 'Turkmenistan', 'Tuvalu', 'Uganda', 'Ukraine', 'United Arab Emirates', 'United Kingdom', 
						   'United States of America', 'Uruguay', 'Uzbekistan', 'Vanuatu', 'Venezuela', 'Vietnam', 'Yemen', 'Zambia',
						   'Zimbabwe')),
						   
	Age AS DATEDIFF(YEAR, BirthDate, GETDATE()),


	CreateDate date NOT NULL DEFAULT GETDATE(),
)


insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('A', 'amr', 'ashraf', 'amra@amr.amr', 'Aa12345678', '01019702121', 'Male', '2002-10-16', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('E', 'amr', 'ashraf', 'amre@amr.amr', 'Aa12345678', '01019702121', 'Male', '2002-10-16', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('U', 'amr', 'ashraf', 'amru@amr.amr', 'Aa12345678', '01019702121', 'Male', '2002-10-16', 'Egypt');

insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('A', 'ahmed', 'amin', 'ahmeda@ahmed.ahmed', 'Aa12345678', '01288024972', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('E', 'ahmed', 'amin', 'ahmede@ahmed.ahmed', 'Aa12345678', '01288024972', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ahmed', 'amin', 'ahmedu@ahmed.ahmed', 'Aa12345678', '01288024972', 'Male', '2003-1-1', 'Egypt');

insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('A', 'omar', 'awad', 'omara@omar.omar', 'Aa12345678', '01211653734', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('E', 'omar', 'awad', 'omare@omar.omar', 'Aa12345678', '01211653734', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('U', 'omar', 'awad', 'omaru@omar.omar', 'Aa12345678', '01211653734', 'Male', '2003-1-1', 'Egypt');

insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('A', 'ziad', 'elbehairy', 'ziada@ziad.ziad', 'Aa12345678', '01008000951', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('E', 'ziad', 'elbehairy', 'ziade@ziad.ziad', 'Aa12345678', '01008000951', 'Male', '2003-1-1', 'Egypt');
insert into Users (UserType, Fname, Lname, U_Email, U_Password, PhoneNumber, Gender, BirthDate, Country) values ('U', 'ziad', 'elbehairy', 'ziadu@ziad.ziad', 'Aa12345678', '01008000951', 'Male', '2003-1-1', 'Egypt');



GO
-------------------------------------------------------------------------------------------------------------------------------------------

--CREATE TABLE Volunteers (

--    VolunteerID   int primary key,

--    VolunteeringBranch   int foreign key references Branchs on delete cascade,

--    AreaCode   varchar(255) not null,

--    ZipCode   varchar(255) not null
--);

create table Voulanteer
(
    Number int IDENTITY(1,1) primary key,

	VoulanteerID int foreign key references Users,

	VolunteeringBranch  int foreign key references Branchs on delete cascade,

	Address nvarchar(50) COLLATE Arabic_CI_AS,

	Notes nvarchar(max) COLLATE Arabic_CI_AS,

	VoulanteerSection nvarchar(50)COLLATE Arabic_CI_AS
);


INSERT INTO Voulanteer (Fname, Lname, U_Email, PhoneNumber, Address, VoulanteerSection, VoulanteerId , Notes)
VALUES
(N'«Õ„œ', N'«„Ì‰', 'ahmedamifffn@gmail.com', '015505484430', N'»‰Ì ”ÊÌ›', N'ﬁ”„  Ê“Ì⁄ «·„·«»”', 10, N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 1 „‰ ﬂ· ‘Â—'),
(N'“Ì«œ', N'»ÕÌ—Ì', 'ziadamifffn@gmail.com', '01550542226', N'»‰Â«', N'ﬁ”„  Œ“Ì‰ «·ﬂ—« Ì‰', 11, N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 15 „‰ ﬂ· ‘Â—'),
(N'⁄„—', N'⁄Ê÷', 'awadamffin@gmail.com', '015505476676', N'œ„Ì«ÿ', N'ﬁ”„ «·„«ﬂÊ·« ', 13, N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 1 „‰ ﬂ· ‘Â—'),
(N'⁄„—Ê', N'«‘—›', 'amramfffin@gmail.com', '04122266776', N'«·ﬁ«Â—…', N'ﬁ”„  Ã„Ì⁄ «· »—⁄« ', 14, N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 15 „‰ ﬂ· ‘Â—');



--------------------------------------------------------------------------------------------------------------------------------------------

--create table Donators 
--(
--	DonatorID int primary key not null 
--		check (len (DonatorID)>0) ,
	
--	AreaCode varchar(max) not null ,
	
--	ZipCode varchar(max) not null,
--);


create table Donator
(
    Number int IDENTITY(1,1) primary key,

    DonatorID int foreign key references Users,

	PhoneNumber nvarchar(12) ,

	Address nvarchar(50),

	Job nvarchar (50) COLLATE Arabic_CI_AS,

	DonationAmount nvarchar(50) COLLATE Arabic_CI_AS,

	Notes nvarchar(max) COLLATE Arabic_CI_AS,
);


INSERT INTO DonatorInformation (Fname, Lname, U_Email, PhoneNumber, Address, Job, DonationAmount, Notes)
VALUES
(N'«Õ„œ', N'«„Ì‰', 'ahmedamifffn@gmail.com', '015505484430', N'»‰Ì ”ÊÌ›', N'„Â‰œ”', N'2000', N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 1 „‰ ﬂ· ‘Â—'),
(N'“Ì«œ', N'»ÕÌ—Ì', 'ziadamifffn@gmail.com', '01550542226', N'»‰Â«', N'„Â‰œ”', N'20', N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 15 „‰ ﬂ· ‘Â—'),
(N'⁄„—', N'⁄Ê÷', 'awadamffin@gmail.com', '015505476676', N'œ„Ì«ÿ', N'„Â‰œ”', N'50', N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 1 „‰ ﬂ· ‘Â—'),
(N'⁄„—Ê', N'«‘—›', 'amramfffin@gmail.com', '04122266776', N'«·ﬁ«Â—…', N'„Â‰œ”', N'30', N'Ì „ «· »—⁄ ⁄‰ ÿ—Ìﬁ ›Êœ«›Ê‰ ﬂ«‘ ÌÊ„ 15 „‰ ﬂ· ‘Â—');
select Fname+' '+Lname as name,PhoneNumber,U_Email,Address, Job, DonationAmount, Notes from DonatorInformation;

-------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Needy (
    Number int IDENTITY(1,1),
    NeedyID AS RIGHT(YEAR(CreateDate), 4) + CASE 
        WHEN Number < 10 THEN '000' + CAST(Number AS CHAR(1))
        WHEN Number < 100 THEN '00' + CAST(Number AS CHAR(2))
        WHEN Number < 1000 THEN '0' + CAST(Number AS CHAR(3))
        ELSE CAST(Number AS VARCHAR(20))
    END PERSISTED NOT NULL PRIMARY KEY,
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
	AcceptStatus varchar(10)  Default '0',
    CreateDate date NOT NULL DEFAULT GETDATE(),
    ImageDataPath nvarchar(max) COLLATE Arabic_CI_AS,
    FrontidimgPath nvarchar(max) COLLATE Arabic_CI_AS,
    BackidimgPath nvarchar(max) COLLATE Arabic_CI_AS
);



CREATE TABLE Employees (
    EmployeeID int PRIMARY KEY,
    WorkingBranch int FOREIGN KEY REFERENCES Branches(BranchID) ON DELETE SET NULL ON UPDATE CASCADE,
    Salary int NOT NULL,
    AreaCode varchar(255) NOT NULL,
    ZipCode varchar(255) NOT NULL,
    Permission varchar(255) NOT NULL
);

CREATE TABLE Branches (
    BranchID int PRIMARY KEY NOT NULL CHECK (BranchID > 0),
    AreaCode varchar(255) NOT NULL,
    ZipCode varchar(255) NOT NULL,
    BranchName varchar(max) NOT NULL,
    Branch_Admin int FOREIGN KEY REFERENCES Employees(EmployeeID) ON DELETE SET NULL ON UPDATE CASCADE
);








CREATE TRIGGER CheckFinishDay
ON Tasks
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted 
        WHERE T_finsh_day < T_assigne_day AND T_State = ' „'
    )
    BEGIN
        RAISERROR ('The finish day cannot be earlier than the assignment day when the state is " „".', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;



CREATE TABLE Tasks (
    T_Name nvarchar(50) NOT NULL,
    T_assigne_day date NOT NULL,
    T_State nvarchar(13) NOT NULL CHECK (T_State IN (' „', 'Ã«—Ì «·⁄„·')),
    T_finsh_day date,
    T_Employee_id int FOREIGN KEY REFERENCES Employees(EmployeeID),
    T_notes nvarchar(max)
);



-- Create a trigger to enforce the CHECK constraint
CREATE TRIGGER CheckFinishDay
ON Tasks
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted 
        WHERE T_finsh_day < T_assigne_day AND T_State = ' „'
    )
    BEGIN
        RAISERROR ('The finish day cannot be earlier than the assignment day when the state is " „".', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;



insert into Tasks values (N' Ê“Ì⁄ ﬂ«— Ì‰ —„÷«‰','1923-01-01',N' „','1924-03-01',7,N' „ „ „ „ „ „ „ „ „ ' )


SELECT T.T_Name, T.T_assigne_day, CONCAT(U.Fname, ' ', U.Lname) AS EmployeeName, T.T_State,T_finsh_day ,T.T_notes 
FROM Tasks AS T JOIN Employees AS E  ON T.T_Employee_id = E.EmployeeID
JOIN Users AS U ON UserID= E.EmployeeID
order by CONCAT(U.Fname, ' ', U.Lname)
--------------------------------------------------------------------------------------------------------------------------------------------------








