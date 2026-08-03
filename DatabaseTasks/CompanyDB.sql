/* =========================================================
   PART 1A: DATABASE CREATION
   ========================================================= */

USE master;
GO

IF DB_ID('CompanyDB') IS NOT NULL
BEGIN
    ALTER DATABASE CompanyDB
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE CompanyDB;
END;
GO

CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO


/* =========================================================
   PART 1B: TABLE CREATION
   ========================================================= */

CREATE TABLE Department
(
    Dnumber INT NOT NULL,
    Dname VARCHAR(50) NOT NULL,
    NumberOfEmployees INT NOT NULL
        CONSTRAINT DF_Department_NumberOfEmployees DEFAULT (0),
    Mgr_ssn CHAR(9) NULL,
    Mgr_start_date DATE NULL,

    CONSTRAINT PK_Department PRIMARY KEY (Dnumber),
    CONSTRAINT UQ_Department_Dname UNIQUE (Dname),
    CONSTRAINT UQ_Department_Manager UNIQUE (Mgr_ssn),
    CONSTRAINT CK_Department_NumberOfEmployees
        CHECK (NumberOfEmployees >= 0),
    CONSTRAINT CK_Department_ManagerDetails
        CHECK
        (
            (Mgr_ssn IS NULL AND Mgr_start_date IS NULL)
            OR
            (Mgr_ssn IS NOT NULL AND Mgr_start_date IS NOT NULL)
        )
);
GO


CREATE TABLE Employee
(
    Ssn CHAR(9) NOT NULL,
    Fname VARCHAR(30) NOT NULL,
    Minit CHAR(1) NULL,
    Lname VARCHAR(30) NOT NULL,
    Bdate DATE NOT NULL,
    Address VARCHAR(150) NOT NULL,
    Sex CHAR(1) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Super_ssn CHAR(9) NULL,
    Dno INT NOT NULL,

    CONSTRAINT PK_Employee PRIMARY KEY (Ssn),

    CONSTRAINT CK_Employee_Sex
        CHECK (Sex IN ('M', 'F', 'O')),

    CONSTRAINT CK_Employee_Salary
        CHECK (Salary > 0),

    CONSTRAINT CK_Employee_NotOwnSupervisor
        CHECK (Super_ssn IS NULL OR Super_ssn <> Ssn),

    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (Dno)
        REFERENCES Department(Dnumber),

    CONSTRAINT FK_Employee_Supervisor
        FOREIGN KEY (Super_ssn)
        REFERENCES Employee(Ssn)
);
GO

CREATE TABLE Dependent
(
    Essn CHAR(9) NOT NULL,
    Dependent_name VARCHAR(50) NOT NULL,
    Sex CHAR(1) NOT NULL,
    Bdate DATE NOT NULL,
    Relationship VARCHAR(30) NOT NULL,

    CONSTRAINT PK_Dependent
        PRIMARY KEY (Essn, Dependent_name),

    CONSTRAINT CK_Dependent_Sex
        CHECK (Sex IN ('M', 'F', 'O')),

    CONSTRAINT FK_Dependent_Employee
        FOREIGN KEY (Essn)
        REFERENCES Employee(Ssn)
        ON DELETE CASCADE
);
GO


/* Keeps the stored NumberOfEmployees value synchronized automatically. */
CREATE TRIGGER TR_Employee_UpdateDepartmentCount
ON Employee
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH ChangedDepartments AS
    (
        SELECT Dno FROM inserted
        UNION
        SELECT Dno FROM deleted
    )
    UPDATE d
    SET NumberOfEmployees =
    (
        SELECT COUNT(*)
        FROM Employee AS e
        WHERE e.Dno = d.Dnumber
    )
    FROM Department AS d
    INNER JOIN ChangedDepartments AS c
        ON c.Dno = d.Dnumber;
END;
GO

ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager
    FOREIGN KEY (Mgr_ssn)
    REFERENCES Employee(Ssn)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
GO

CREATE UNIQUE INDEX UX_Department_Mgr_ssn
ON Department(Mgr_ssn)
WHERE Mgr_ssn IS NOT NULL;
GO

CREATE TABLE Dept_Locations
(
    Dnumber INT NOT NULL,
    Dlocation VARCHAR(50) NOT NULL,

    CONSTRAINT PK_Dept_Locations
        PRIMARY KEY (Dnumber, Dlocation),

    CONSTRAINT FK_DeptLocations_Department
        FOREIGN KEY (Dnumber)
        REFERENCES Department(Dnumber)
        ON DELETE CASCADE
        ON UPDATE NO ACTION
);
GO
