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

