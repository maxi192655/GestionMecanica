--USE GestionMecanica;
--GO
INSERT INTO Roles(Nombre)
VALUES
	('Cliente'),
	('Administrador'),
	('Mecanico');
GO
--Crear un nuevo rol
CREATE PROCEDURE Sp_Roles_Create
	@Nombre NVARCHAR(20)
AS
BEGIN
	INSERT INTO Roles(Nombre)
	VALUES(@Nombre);

END;
GO
CREATE PROCEDURE Sp_Roles_Delete
	@ID INT,
	@Nombre NVARCHAR(20)
AS
BEGIN
	DELETE FROM Roles
	WHERE ID = @ID;
END;
GO
--USE master;