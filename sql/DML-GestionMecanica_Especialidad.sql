USE GestionMecanica;
GO
INSERT INTO Especialidad(Nombre)
VALUES
	('Motor'),
	('Freno'),
	('Electricidad'),
	('Transmision');
GO

CREATE PROCEDURE SP_Especialidad_Create
	@Nombre NVARCHAR(100)
AS
BEGIN
	INSERT INTO Especialidad(Nombre)
	VALUES(@Nombre);
END;
GO

CREATE PROCEDURE SP_Especialidad_Update
	@ID INT,
	@Nombre NVARCHAR(100)
AS
BEGIN
	UPDATE Especialidad
	SET Nombre = @Nombre
	WHERE ID = @ID;
END;
GO
----Borrar
--CREATE PROCEDURE SP_Especialidad_Delete
--	@ID INT
--AS
--BEGIN
--	DELETE FROM Especialidad
--	WHERE ID = @ID;
--END;
--GO


USE MASTER;