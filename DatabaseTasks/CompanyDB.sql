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


