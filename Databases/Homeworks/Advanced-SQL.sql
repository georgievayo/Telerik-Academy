--- Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. ---
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary)
				FROM Employees);

--- Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company. ---
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary >= 1.1 * (SELECT MIN(Salary)
				FROM Employees);

--- Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. ---
SELECT FirstName + ' ' + LastName AS [Full name], Salary, Name
FROM Employees JOIN Departments d ON Employees.DepartmentID = d.DepartmentID
Where Salary = (SELECT MIN(Salary)
				 FROM Employees e
				 WHERE e.DepartmentID = d.DepartmentID)

--- Write a SQL query to find the average salary in the department #1. ---
SELECT AVG(Salary) AS [Avg Salary]
FROM Employees
WHERE DepartmentID = 1;

--- Write a SQL query to find the average salary in the "Sales" department. ---
SELECT AVG(Salary) AS [Avg Salary]
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Name = 'Sales';

--- Write a SQL query to find the number of employees in the "Sales" department. ---
SELECT COUNT(*) AS [Count of Employees]
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Name = 'Sales';

---  Write a SQL query to find the number of all employees that have manager. ---
SELECT COUNT(*)
FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID;

--- Write a SQL query to find the number of all employees that have no manager. ---
SELECT COUNT(*)
FROM Employees e LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IS NULL;

--- Write a SQL query to find all departments and the average salary for each of them. ---
SELECT Name, AVG(Salary) AS [Avg Salary]
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
GROUP BY Name;

--- Write a SQL query to find the count of all employees in each department and for each town. ---
SELECT Name, COUNT(*) AS [Avg Salary], TownID
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
				JOIN Addresses ON Employees.AddressID = Addresses.AddressID
GROUP BY Name, TownID;

--- Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. ---
SELECT m.FirstName
FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName
HAVING COUNT(*) = 5;

--- Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)". ---
SELECT e.FirstName, e.LastName, ISNULL(m.FirstName, '(no manager)') AS [Manager name]
FROM Employees e LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID;

--- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function. ---
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

--- Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".  ---
SELECT CONVERT(VARCHAR(19),GETDATE(), 113) AS [Current Date];

--- Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. ---
CREATE TABLE Users (
	UserID INT IDENTITY(1,1) PRIMARY KEY,
	Username NVARCHAR(20) UNIQUE,
	Password NVARCHAR(20) CHECK (LEN(Password) >= 5),
	FullName NVARCHAR(50),
	LastLogin DATETIME
);

--- Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. ---
CREATE VIEW V_LastLoggedUsers
AS
SELECT Username
FROM Users
WHERE CAST(LastLogin AS DATE) = CAST(GETDATE() AS DATE);

INSERT INTO Users
VALUES('user1', '12345', 'User One', GETDATE());

SELECT*
FROM V_LastLoggedUsers;

--- Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).---
CREATE TABLE Groups (
	GroupID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(20) UNIQUE
);

--- Write a SQL statement to add a column GroupID to the table Users. ---
ALTER TABLE Users
ADD GroupID INT FOREIGN KEY REFERENCES Groups(GroupID);

--- Write SQL statements to insert several records in the Users and Groups tables. ---
INSERT INTO Groups
VALUES('Databases');
INSERT INTO Groups
VALUES('Design patterns');

INSERT INTO Users
VALUES('user2', '12345', 'User One', GETDATE(), 1);
INSERT INTO Users
VALUES('user3', '12345', 'User One', GETDATE(), 2);

--- Write SQL statements to update some of the records in the Users and Groups tables. ---
UPDATE Groups
SET Name = 'Databases NEW'
WHERE GroupID = 1;

UPDATE Users
SET FullName = 'Guci Guci'
WHERE UserID = 3;

--- Write SQL statements to delete some of the records from the Users and Groups tables. ---
DELETE FROM Users
WHERE Username = 'user1';

--- Write SQL statements to insert in the Users table the names of all employees from the Employees table. ---
INSERT INTO Users
SELECT (LOWER(LEFT(FirstName, 1))+ LOWER(LastName)), 
		(LOWER(LEFT(FirstName, 1)) + LOWER(LastName) + '12'), 
		FirstName + ' ' + LastName, NULL, 1
FROM Employees;

INSERT INTO Users
VALUES('userToDelete', '15486512', 'User', '02.10.2010', 1)
--- Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. ---
UPDATE Users
SET Password = NULL
WHERE CAST(LastLogin AS DATE) <= '03.10.2010';

--- Write a SQL statement that deletes all users without passwords (NULL password) ---
DELETE FROM Users
WHERE Password IS NULL;

--- Write a SQL query to display the average employee salary by department and job title. ---
SELECT Name, JobTitle, AVG(Salary) AS [Avg Salary]
FROM Employees JOIN Departments On Employees.DepartmentID = Departments.DepartmentID
GROUP BY Name, JobTitle;

--- Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it. ---
SELECT Name, JobTitle, MIN(Salary) AS Salary, MIN (FirstName + LastName) AS [Full name]
FROM Employees JOIN Departments d ON Employees.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle

--- Write a SQL query to display the town where maximal number of employees work. ---
SELECT TOP(1) Towns.Name, COUNT(*) AS [Count]
FROM Employees JOIN Addresses ON Employees.AddressID = Addresses.AddressID
				JOIN Towns ON Addresses.TownID = Towns.TownID
GROUP BY Towns.Name
ORDER BY Count DESC;

--- Write a SQL query to display the number of managers from each town. ---
SELECT Towns.Name, COUNT(m.FirstName) AS [Count]
FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID
				JOIN Addresses ON m.AddressID = Addresses.AddressID
				JOIN Towns ON Addresses.TownID = Towns.TownID
GROUP BY Towns.Name;

--- Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). ---
CREATE TABLE WorkHours(
	WorkID INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
	Date DATE,
	Task NVARCHAR(100),
	Hours INT,
	Comments TEXT
);