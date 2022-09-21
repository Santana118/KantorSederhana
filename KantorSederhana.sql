--CREATE DATABASE KantorSederhana;

--CREATE TABLE Departement(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	name VARCHAR(50) NOT NULL UNIQUE,
--);

--CREATE TABLE Division(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	name VARCHAR(50) NOT NULL UNIQUE,
--);

--CREATE TABLE Privilege(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	name VARCHAR(50) NOT NULL UNIQUE
--)

--CREATE TABLE Employee(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	name VARCHAR(50) NOT NULL,
--	username VARCHAR(50) UNIQUE,
--	passwd VARCHAR(50) NOT NULL,
--	hireDate DATE,
--	departementId INT,
--	divisionId INT,
--	managerId INT,
--	salary DECIMAL,
--	privilegeLevel INT NOT NULL DEFAULT 0,

--	CONSTRAINT FK_Departement FOREIGN KEY (departementId) REFERENCES Departement(id) ON DELETE SET NULL,
--	CONSTRAINT FK_Division FOREIGN KEY (divisionId) REFERENCES Division(id) ON DELETE SET NULL,
--	CONSTRAINT FK_Manager FOREIGN KEY (managerId) REFERENCES Employee(id) ON DELETE NO ACTION,
--	CONSTRAINT FK_Privilege FOREIGN KEY (privilegeLevel) REFERENCES Privilege(id)ON DELETE SET DEFAULT,

--)

--CREATE TABLE Announcement(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	datePosted DATE DEFAULT GETDATE(),
--	employeeId INT,
--	bodyText TEXT

--	CONSTRAINT FK_Employee FOREIGN KEY (employeeId) REFERENCES Employee(id) ON DELETE SET NULL,
--)

--CREATE TABLE Project(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	name VARCHAR(50) NOT NULL,
--	coordinatorId INT,
--	dateStarted DATE,
--	dateEnd DATE,
--	CONSTRAINT FK_CoordinatorId FOREIGN KEY (coordinatorId) REFERENCES Employee(id) ON DELETE SET NULL
--)

--CREATE TABLE Timesheet(
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	projectId INT, 
--	departementId INT,
--	divisionId INT,
--	task VARCHAR(100),
--	dateStart DATE,
--	dateEnd DATE,
--	currentStatus VARCHAR(50) NOT NULL,

--	CONSTRAINT FK_ProjectID FOREIGN KEY (projectId) REFERENCES Project(id) ON DELETE NO ACTION,
--	CONSTRAINT FK_DepartementID FOREIGN KEY (departementId) REFERENCES Departement(id) ON DELETE NO ACTION,
--	CONSTRAINT FK_DivisionID FOREIGN KEY (divisionId) REFERENCES Division(id) ON DELETE NO ACTION
--)

CREATE TABLE Absen(
	id INT IDENTITY(1,1) PRIMARY KEY,
	employeeId INT,
	checkIn DATE DEFAULT GETDATE(),
	CONSTRAINT FK_EmployeeAbsenId FOREIGN KEY (employeeId) REFERENCES Employee(id) ON DELETE CASCADE
)