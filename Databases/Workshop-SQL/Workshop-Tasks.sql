--- Task 1 ---
CREATE TABLE Cities(
	CityId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(50),
	CONSTRAINT PK_ID PRIMARY KEY (CityId)
);

--- Task 2 ---
INSERT INTO Cities (Name)
SELECT newTable.City
FROM 
((SELECT Distinct City
FROM Employees)
UNION
(SELECT DISTINCT City
FROM Suppliers)
UNION 
(SELECT DISTINCT City
FROM Customers)) AS newTable;

--- Task 3 ---
ALTER TABLE Employees
ADD CityId INT;

ALTER TABLE Employees
ADD CONSTRAINT FK_CityId
FOREIGN KEY (CityId) REFERENCES Cities(CityId);

ALTER TABLE Suppliers
ADD CityId INT;

ALTER TABLE Suppliers
ADD CONSTRAINT FK_Suppliers_CityId
FOREIGN KEY (CityId) REFERENCES Cities(CityId);

ALTER TABLE Customers
ADD CityId INT;

ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_CityId
FOREIGN KEY (CityId) REFERENCES Cities(CityId);

--- Task 4 ---
UPDATE Employees
SET Employees.CityId = Cities.CityId
FROM Employees JOIN Cities ON City = Name; 

UPDATE Suppliers
SET Suppliers.CityId = Cities.CityId
FROM Suppliers JOIN Cities ON City = Name; 

UPDATE Customers
SET Customers.CityId = Cities.CityId
FROM Customers JOIN Cities ON City = Name; 

--- Task 5 ---
ALTER TABLE Cities
ADD UNIQUE (Name);
	
--- Task 6 ---
INSERT INTO Cities (Name)
(SELECT DISTInct ShipCity
FROM Orders)
EXCEPT 
(SELECT Name
FROM Cities);

--- Task 7 ---
ALTER TABLE Orders
ADD CityId INT;

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_CityId FOREIGN KEY (CityId) REFERENCES Cities(CityId);

--- Task 8 ---
GO
EXEC sp_rename 'Orders.CityId', 'ShipCityId', 'COLUMN'
GO

--- Task 9 ---
UPDATE Orders
SET Orders.ShipCityId = Cities.CityId
FROM Orders JOIN Cities ON ShipCity = Name; 

--- Task 10 ---
ALTER TABLE Orders
DROP COLUMN ShipCity; 

--- Task 11 ---
CREATE TABLE Countries (
CountryId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
Name nvarchar(50) UNIQUE
);

--- Task 12 ---
ALTER TABLE Cities
ADD CountryId INT;

ALTER TABLE Cities
ADD CONSTRAINT FK_Cities_Countries FOREIGN KEY (CountryId) REFERENCES Countries(CountryId);

--- Task 13 ---

INSERT INTO Countries(Name)
SELECT DISTINCT newTable.Country
FROM 
((SELECT Distinct Country
FROM Employees)
UNION
(SELECT DISTINCT Country
FROM Suppliers)
UNION 
(SELECT DISTINCT Country
FROM Customers)
UNION 
(SELECT DISTINCT ShipCountry
FROM Orders )
) AS newTable;


--- Task 14 ---
UPDATE Cities
SET Cities.CountryId = res.CountryId
FROM 
(SELECT DISTINCT newTable.Country , newTable.City, Countries.CountryId
FROM 
((SELECT Distinct Country, City
FROM Employees)
UNION
(SELECT DISTINCT Country, City
FROM Suppliers)
UNION 
(SELECT DISTINCT Country, City
FROM Customers)
) AS newTable JOIN Countries ON Name = Country) AS res JOIN Cities ON res.City = Cities.Name;

--- Task 15 ---
ALTER TABLE Employees
DROP COLUMN City;

ALTER TABLE Suppliers
DROP COLUMN City;

DROP INDEX Customers.City;

ALTER TABLE Customers
DROP COLUMN City;

--- Task 16 ---
ALTER TABLE Employees
DROP COLUMN Country;

ALTER TABLE Suppliers
DROP COLUMN Country;

ALTER TABLE Customers
DROP COLUMN Country;

ALTER TABLE Orders
DROP COLUMN ShipCountry;