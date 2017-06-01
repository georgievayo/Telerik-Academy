--- TASK 1 ---
SELECT Superhero_Id AS Id, Superheroes.Name
FROM Planets JOIN PlanetSuperheroes ON Planets.Id = PlanetSuperheroes.Planet_Id
			JOIN Superheroes ON PlanetSuperheroes.Superhero_Id = Superheroes.Id
WHERE Planets.Name = 'Earth';

--- TASK 2 ---
SELECT Superheroes.Name AS [Superhero], (Powers.Name + ' (' + PowerTypes.Name + ')') AS [Power]
FROM Superheroes JOIN PowerSuperheroes ON Superheroes.Id = PowerSuperheroes.Superhero_Id
				JOIN Powers ON PowerSuperheroes.Power_Id = Powers.Id
				JOIN PowerTypes ON Powers.PowerTypeId = PowerTypes.Id;

--- TASK 3 ---
SELECT TOP(5) Planets.Name, COUNT(case Alignments.Name when 'Good' then 1 end) AS [Protectors]
FROM Superheroes JOIN Alignments ON Alignment_Id = Alignments.Id
		JOIN PlanetSuperheroes ON Superheroes.Id = PlanetSuperheroes.Superhero_Id
		JOIN Planets ON Planet_Id = Planets.Id
GROUP BY Planets.Name
ORDER  BY Protectors DESC;

--- TASK 4 ---
CREATE PROCEDURE usp_UpdateSuperheroBio(
	@Id INT,
	@Bio NTEXT)
AS
UPDATE Superheroes
SET Bio = @Bio
WHERE Id = @Id;
GO

--- TASK 5 ---
CREATE PROCEDURE usp_GetSuperheroInfo
	@SuperheroId INT
AS
BEGIN
	SELECT Superheroes.Id, Superheroes.Name AS [Name], 
			SecretIdentity AS [Secret Identity], 
			Bio, Alignments.Name AS [Alignment], 
			Planets.Name AS [Planet], Powers.Name AS [Power]
	FROM Superheroes JOIN PlanetSuperheroes ON Superheroes.Id = PlanetSuperheroes.Superhero_Id
				JOIN Planets ON PlanetSuperheroes.Planet_Id = Planets.Id
				JOIN Alignments ON Superheroes.Alignment_Id = Alignments.Id
				JOIN PowerSuperheroes ON Superheroes.Id = PowerSuperheroes.Superhero_Id
				JOIN Powers ON Powers.Id = PowerSuperheroes.Power_Id
	WHERE Superheroes.Id = @SuperheroId
END

--- TASK 6 ---
CREATE PROCEDURE usp_GetPlanetsWithHeroesCount
AS
BEGIN
SELECT Planets.Name, 
		COUNT(case Alignments.Name when 'Good' then 1 end) AS [Good heroes],
		COUNT(case Alignments.Name when 'Neutral' then 1 end) AS [Neutral heroes],
		COUNT(case Alignments.Name when 'Evil' then 1 end) AS [Evil heroes]
FROM Superheroes JOIN PlanetSuperheroes ON Superheroes.Id = PlanetSuperheroes.Superhero_Id
			JOIN Planets ON PlanetSuperheroes.Planet_Id = Planets.Id
			JOIN Alignments ON Superheroes.Alignment_Id = Alignments.Id
GROUP BY Planets.Name
END

--- TASK 7 ---
CREATE PROCEDURE usp_CreateSuperhero
	@SuperheroName NVARCHAR(40),
	@SecretIdentity NVARCHAR(40),
	@Bio NTEXT,
	@Alignment NVARCHAR(40),
	@Planet NVARCHAR(40),
	@FirstPower NVARCHAR(40),
	@FirstPowerType NVARCHAR(40),
	@SecondPower NVARCHAR(40),
	@SecondPowerType NVARCHAR(40),
	@ThirdPower NVARCHAR(40),
	@ThirdPowerType NVARCHAR(40)
AS
BEGIN
	DECLARE @AlignmentId NVARCHAR(40);
	IF ((SELECT COUNT(*) FROM Alignments WHERE Name = @Alignment) = 0)
		BEGIN
			INSERT INTO Alignments
			VALUES (@Alignment)
		END

	SET @AlignmentId = (SELECT Id FROM Alignments WHERE Name = @Alignment);

	DECLARE @PlanetId INT;
	IF ((SELECT COUNT(*) FROM Planets WHERE Name = @Planet) = 0)
		BEGIN
			INSERT INTO Planets
			VALUES (@Planet)
		END

	SET @PlanetId = (SELECT Id FROM Planets WHERE Name = @Planet);

	DECLARE @FirstPowerTypeId INT;
	IF ((SELECT COUNT(*) FROM PowerTypes WHERE Name = @FirstPowerType) = 0)
		BEGIN 
			INSERT INTO PowerTypes
			VALUES (@FirstPowerType)
		END
	SET @FirstPowerTypeId = (SELECT Id FROM PowerTypes WHERE Name = @FirstPowerType);

	DECLARE @SecondPowerTypeId INT;
	IF ((SELECT COUNT(*) FROM PowerTypes WHERE Name = @SecondPowerType) = 0)
		BEGIN 
			INSERT INTO PowerTypes
			VALUES (@SecondPowerType)
		END
	SET @SecondPowerTypeId = (SELECT Id FROM PowerTypes WHERE Name = @SecondPowerType);

	DECLARE @ThirdPowerTypeId INT;
	IF ((SELECT COUNT(*) FROM PowerTypes WHERE Name = @ThirdPowerType) = 0)
		BEGIN 
			INSERT INTO PowerTypes
			VALUES (@ThirdPowerType)
		END
	SET @ThirdPowerTypeId = (SELECT Id FROM PowerTypes WHERE Name = @ThirdPowerType);

	DECLARE @FirstPowerId INT;
	IF ((SELECT COUNT(*) FROM Powers WHERE Name = @FirstPower) = 0)
		BEGIN 
			INSERT INTO Powers
			VALUES (@FirstPower, @FirstPowerTypeId)
		END
	SET @FirstPowerId = (SELECT Id FROM Powers WHERE Name = @FirstPower);

	DECLARE @SecondPowerId INT;
	IF ((SELECT COUNT(*) FROM Powers WHERE Name = @SecondPower) = 0)
		BEGIN 
			INSERT INTO Powers
			VALUES (@SecondPower, @SecondPowerTypeId)
		END
	SET @SecondPowerId = (SELECT Id FROM Powers WHERE Name = @SecondPower);

	DECLARE @ThirdPowerId INT;
	IF ((SELECT COUNT(*) FROM Powers WHERE Name = @ThirdPower) = 0)
		BEGIN 
			INSERT INTO Powers
			VALUES (@ThirdPower, @ThirdPowerTypeId)
		END
	SET @ThirdPowerId = (SELECT Id FROM Powers WHERE Name = @ThirdPower);

	INSERT INTO Superheroes
	VALUES (@SuperheroName, @SecretIdentity, @AlignmentId, @Bio);

	DECLARE @SuperheroId INT;
	SET @SuperheroId = (SELECT Id FROM Superheroes WHERE Name = @SuperheroName);

	INSERT INTO PlanetSuperheroes
	VALUES (@PlanetId, @SuperheroId);

	INSERT INTO PowerSuperheroes
	VALUES (@FirstPowerId, @SuperheroId),
			(@SecondPowerId, @SuperheroId),
			(@ThirdPowerId, @SuperheroId);
END

--- TASK 8 ---
CREATE PROCEDURE usp_PowersUsageByAlignment
AS
	SELECT Alignments.Name AS [Alignment], COUNT(Powers.Name) AS [Powers Count]
	FROM Superheroes JOIN Alignments ON Superheroes.Alignment_Id = Alignments.Id
			JOIN PowerSuperheroes ON Superheroes.Id = PowerSuperheroes.Superhero_Id
			JOIN Powers ON Powers.Id = PowerSuperheroes.Power_Id
	GROUP BY Alignments.Name
GO
--- Ако трябва да се преброят уникалните сили на всеки вид alignment, 
--- то ще се извежда COUNT(DISTINCT Powers.Name).

--- Test procedures ---
EXEC usp_UpdateSuperheroBio 1, 'NEW Bio';
EXEC usp_GetSuperheroInfo 1;
EXEC usp_PowersUsageByAlignment;
EXEC usp_GetPlanetsWithHeroesCount;
EXEC usp_CreateSuperhero 'New hero', 'identity', 'New Bio text', 'Neutral', 'Venus', 'First Power', 'First Type', 'Second Power', 'Second Type', 'Third Power', 'Third Type'
EXEC usp_CreateSuperhero 'HERO', 'identity2', NULL, 'Evil', 'Earth', 'Genius', 'God', 'Second Power', 'Second Type', 'Third Power', 'Third Type'