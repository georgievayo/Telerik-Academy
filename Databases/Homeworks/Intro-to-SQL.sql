 --- Write a SQL query to find all department names. ---
SELECT Name
FROM Departments;

--- Write a SQL query to find the salary of each employee. ---
SELECT Salary
FROM Employees;

--- Write a SQL to find the full name of each employee. ---
SELECT (FirstName + ' ' + LastName) AS FullName
FROM Employees;

--- Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses" ---
SELECT (FirstName + '.' + LastName + '@telerik.com') AS [Full Email Addresses]
FROM Employees;

--- Write a SQL query to find all different employee salaries. ---
SELECT DISTINCT Salary
FROM Employees;

--- Write a SQL query to find all information about the employees whose job title is “Sales Representative“. ---
SELECT*
FROM Employees
WHERE JobTitle = 'Sales Representative';

--- Write a SQL query to find the names of all employees whose first name starts with "SA". ---
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%';

--- Write a SQL query to find the names of all employees whose last name contains "ei". ---
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--- Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. ---
SELECT Salary
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000;

--- Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. ---
SELECT FirstName, LastName
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);

--- Write a SQL query to find all employees that do not have manager. ---
SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL;

--- Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. ---
SELECT FirstName, LastName
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

--- Write a SQL query to find the top 5 best paid employees. ---
SELECT TOP(5) FirstName, LastName
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

--- Write a SQL query to find all employees along with their address. Use inner join with ON clause. ---
SELECT FirstName, LastName, AddressText
FROM Employees JOIN Addresses ON Employees.AddressID = Addresses.AddressID;

--- Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). ---

--- Write a SQL query to find all employees along with their manager. ---
SELECT (e1.FirstName + ' ' + e1.LastName) AS [Employee name], (e2.FirstName + ' ' + e2.LastName) AS [Manager name]
FROM Employees AS e1 JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID;

--- Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a. ---
SELECT (e1.FirstName + ' ' + e1.LastName) AS [Employee name], AddressText, (e2.FirstName + ' ' + e2.LastName) AS [Manager name]
FROM Employees AS e1 JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID 
		JOIN Addresses ON e1.AddressID = Addresses.AddressID;

--- Write a SQL query to find all departments and all town names as a single list. Use UNION. ---
(SELECT Name AS [Department name]
FROM Departments)
UNION
(SELECT Name AS [Town]
FROM Towns);

--- Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join. ---
SELECT (e1.FirstName + ' ' + e1.LastName) AS [Employee name], (e2.FirstName + ' ' + e2.LastName) AS [Manager name]
FROM Employees AS e1 LEFT JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID;

SELECT (e1.FirstName + ' ' + e1.LastName) AS [Manager name], (e2.FirstName + ' ' + e2.LastName) AS [Employee name]
FROM Employees AS e1 RIGHT JOIN Employees AS e2 ON e2.ManagerID = e1.EmployeeID;

--- Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. ---
SELECT FirstName, LastName
FROM Employees JOIN Departments ON Employees.DepartmentID = Departments.DepartmentID
WHERE Name IN ('Sales', 'Finance') AND HireDate BETWEEN '19950101' AND '20050101';