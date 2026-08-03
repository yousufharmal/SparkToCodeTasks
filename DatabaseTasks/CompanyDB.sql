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
   PART 1: TABLE CREATION
   ========================================================= */

CREATE TABLE Department
(
    Dnumber INT NOT NULL,
    Dname VARCHAR(50) NOT NULL,
    NumberOfEmployees INT NOT NULL
        CONSTRAINT DF_Department_NumberOfEmployees DEFAULT (0),
    Mgr_ssn CHAR(9) NULL,
    Mgr_start_date DATE NULL,

    CONSTRAINT PK_Department
        PRIMARY KEY (Dnumber),

    CONSTRAINT UQ_Department_Dname
        UNIQUE (Dname),

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
    Address VARCHAR(150) NOT NULL,
    Sex CHAR(1) NOT NULL,
    Bdate DATE NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Dno INT NOT NULL,
    Super_ssn CHAR(9) NULL,

    CONSTRAINT PK_Employee
        PRIMARY KEY (Ssn),

    CONSTRAINT CK_Employee_Sex
        CHECK (Sex IN ('M', 'F', 'O')),

    CONSTRAINT CK_Employee_Salary
        CHECK (Salary > 0),

    CONSTRAINT CK_Employee_NotOwnSupervisor
        CHECK (Super_ssn IS NULL OR Super_ssn <> Ssn),

    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (Dno)
        REFERENCES Department(Dnumber)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,

    CONSTRAINT FK_Employee_Supervisor
        FOREIGN KEY (Super_ssn)
        REFERENCES Employee(Ssn)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO


ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager
    FOREIGN KEY (Mgr_ssn)
    REFERENCES Employee(Ssn)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
GO


/* Allows many NULL managers during initial insertion,
   but prevents one employee managing multiple departments. */
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


CREATE TABLE Project
(
    Pnumber INT NOT NULL,
    Pname VARCHAR(80) NOT NULL,
    Plocation VARCHAR(50) NOT NULL,
    Dnum INT NOT NULL,

    CONSTRAINT PK_Project
        PRIMARY KEY (Pnumber),

    CONSTRAINT UQ_Project_Pname
        UNIQUE (Pname),

    CONSTRAINT FK_Project_Department
        FOREIGN KEY (Dnum)
        REFERENCES Department(Dnumber)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO


CREATE TABLE Works_On
(
    Essn CHAR(9) NOT NULL,
    Pno INT NOT NULL,
    Hours DECIMAL(5,2) NOT NULL
        CONSTRAINT DF_WorksOn_Hours DEFAULT (0),

    CONSTRAINT PK_Works_On
        PRIMARY KEY (Essn, Pno),

    CONSTRAINT CK_WorksOn_Hours
        CHECK (Hours BETWEEN 0 AND 168),

    CONSTRAINT FK_WorksOn_Employee
        FOREIGN KEY (Essn)
        REFERENCES Employee(Ssn)
        ON DELETE CASCADE
        ON UPDATE NO ACTION,

    CONSTRAINT FK_WorksOn_Project
        FOREIGN KEY (Pno)
        REFERENCES Project(Pnumber)
        ON DELETE CASCADE
        ON UPDATE NO ACTION
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
        ON UPDATE NO ACTION
);
GO


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


/* =========================================================
   PART 2: SAMPLE DATA
   ========================================================= */

/* INSERT 1 */
INSERT INTO Department
    (Dnumber, Dname, Mgr_ssn, Mgr_start_date)
VALUES
    (1, 'Headquarters', NULL, NULL),
    (4, 'Administration', NULL, NULL),
    (5, 'Research', NULL, NULL);
GO


/* INSERT 2 */
INSERT INTO Employee
    (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Dno, Super_ssn)
VALUES
    ('111111111', 'Ahmed', 'A', 'Al-Hinai',
     'Muscat, Oman', 'M', '1985-04-15', 3200.00, 1, NULL);
GO


/* INSERT 3 */
INSERT INTO Employee
    (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Dno, Super_ssn)
VALUES
    ('222222222', 'Fatma', 'M', 'Al-Balushi',
     'Seeb, Oman', 'F', '1988-09-21', 2900.00, 4, '111111111'),

    ('333333333', 'Khalid', 'S', 'Al-Lawati',
     'Bawshar, Oman', 'M', '1990-01-11', 2700.00, 5, '111111111');
GO


/* INSERT 4 */
INSERT INTO Employee
    (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Dno, Super_ssn)
VALUES
    ('444444444', 'Mariam', 'H', 'Al-Rawahi',
     'Al Khoudh, Oman', 'F', '1995-06-30', 1900.00, 4, '222222222'),

    ('555555555', 'Yousef', 'R', 'Al-Harmali',
     'Muscat, Oman', 'M', '1998-12-05', 1750.00, 5, '333333333');
GO


UPDATE Department
SET
    Mgr_ssn =
        CASE Dnumber
            WHEN 1 THEN '111111111'
            WHEN 4 THEN '222222222'
            WHEN 5 THEN '333333333'
        END,
    Mgr_start_date =
        CASE Dnumber
            WHEN 1 THEN '2020-01-01'
            WHEN 4 THEN '2021-03-15'
            WHEN 5 THEN '2022-06-01'
        END
WHERE Dnumber IN (1, 4, 5);
GO


/* INSERT 5 */
INSERT INTO Dept_Locations
    (Dnumber, Dlocation)
VALUES
    (1, 'Muscat'),
    (1, 'Seeb'),
    (4, 'Bawshar'),
    (5, 'Muscat'),
    (5, 'Sohar');

INSERT INTO Project
    (Pnumber, Pname, Plocation, Dnum)
VALUES
    (10, 'Digital Records System', 'Muscat', 4),
    (20, 'AI Research Platform', 'Sohar', 5),
    (30, 'Company Website Upgrade', 'Muscat', 1);

INSERT INTO Works_On
    (Essn, Pno, Hours)
VALUES
    ('111111111', 30, 12.00),
    ('222222222', 10, 25.00),
    ('333333333', 20, 30.00),
    ('444444444', 10, 20.00),
    ('555555555', 20, 18.50);

INSERT INTO Dependent
    (Essn, Dependent_name, Sex, Bdate, Relationship)
VALUES
    ('111111111', 'Sara', 'F', '2012-05-14', 'Daughter'),
    ('222222222', 'Omar', 'M', '2015-08-09', 'Son'),
    ('555555555', 'Aisha', 'F', '2020-02-20', 'Child');
GO
