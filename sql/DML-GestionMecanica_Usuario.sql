--USE GestionMecanica;
--GO
CREATE UNIQUE INDEX IX_Usuario_Email ON Usuario(Email);
GO
--Insercion de usuario
CREATE PROCEDURE Sp_Usuario_Create
	@Nombre VARCHAR(100),
	@Email VARCHAR(100),
	@Pwd VARCHAR(100),
	@RolID INT,
	@Telefono NVARCHAR(20) = NULL,
	@Direccion NVARCHAR(200) = NULL,
	@Ciudad NVARCHAR(100) = NULL,
	@Estado NVARCHAR(100) = NULL,
	@CodigoPostal NVARCHAR(20) = NULL,
	@Pais NVARCHAR(50) = NULL,
	@Area NVARCHAR(100) = NULL,
	@EspecialidadID INT = NULL
AS
BEGIN 
	INSERT INTO Usuario (Nombre, Email, Pwd, RolID, Telefono, Direccion, Ciudad, Estado, CodigoPostal, Pais, Area, EspecialidadID)
	VALUES (
		@Nombre, @Email,@Pwd,@RolID, 
		@Telefono, @Direccion, @Ciudad, @Estado, 
		@CodigoPostal, @Pais, @Area,@EspecialidadID
	)
END;
GO

--Actualizacion de usuario
CREATE PROCEDURE Sp_Usuario_Update
	@ID INT,
	@Nombre VARCHAR(100),
	@Email VARCHAR(100),
	@Pwd VARCHAR(100),
	@RolId INT,
	@Telefono NVARCHAR(20) = NULL,
	@Direccion NVARCHAR(200) = NULL,
	@Ciudad NVARCHAR(100) = NULL,
	@Estado NVARCHAR(100) = NULL,
	@CodigoPostal NVARCHAR(20) = NULL,
	@Pais NVARCHAR(50) = NULL,
	@Area NVARCHAR(100) = NULL,
	@EspecialidadID INT = NULL
AS
--Actualizacion de usuario
BEGIN
	UPDATE Usuario
	SET 
		Nombre = @Nombre,
		Email = @Email,
		Pwd = @Pwd,
		RolID = @RolId,
		Telefono = @Telefono,
		Direccion = @Direccion,
		Ciudad = @Ciudad,
		Estado = @Estado,
		CodigoPostal = @CodigoPostal,
		Pais = @Pais,
		Area = @Area,
		EspecialidadID = @EspecialidadID
	WHERE ID = @ID
END;
GO

CREATE PROCEDURE Sp_Usuario_Delete
	@ID INT
--Borrado logico
AS
BEGIN 
	UPDATE Usuario SET
	Activo = 0
	WHERE ID = @ID
END;
GO

CREATE PROCEDURE Sp_Usuario_GetAll
AS
--Listar todos los usuarios
BEGIN
	SELECT * FROM Usuario
END;
GO

--Listar usuario activos
CREATE PROCEDURE Sp_Usuario_GetActivos
AS
BEGIN
	SELECT * FROM Usuario WHERE Activo = 1
END;
GO
--Listar usuario inactivos
CREATE PROCEDURE Sp_Usuario_GetInactivos
AS
BEGIN
	SELECT * FROM Usuario WHERE Activo = 0
END;
GO
--Listar usuario por ID
CREATE PROCEDURE Sp_Usuario_GetByID
	@ID INT
AS
BEGIN
	SELECT * FROM Usuario WHERE ID = @ID
END;
GO

--Listar usuario por Email
CREATE PROCEDURE Sp_Usuario_GetByEmail
	@Email VARCHAR(100)
AS
BEGIN
	SELECT * FROM Usuario WHERE Email = @Email
END;
GO

--Listar usuario por Rol
CREATE PROCEDURE Sp_Usuario_GetByRol
	@RolID int
AS
BEGIN
	SELECT * FROM Usuario WHERE RolID = @RolID
END;
GO

--Listar usuario por Especialidad
CREATE PROCEDURE Sp_Usuario_GetByEspecialidad
	@EspecialidadID INT
AS
BEGIN
	SELECT * FROM Usuario WHERE EspecialidadID = @EspecialidadID
END;
GO


CREATE PROCEDURE Sp_Roles_GetIDByNombre
    @Nombre NVARCHAR(50)
AS
BEGIN
    SELECT Id FROM Roles WHERE Nombre = @Nombre;
END;
GO


CREATE PROCEDURE Sp_Usuario_Exists
	@Email VARCHAR(100)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Usuario WHERE Email = @Email)
	BEGIN
		RAISERROR('El usuario ya existe.',16,1)
		RETURN
	END
END;
GO
--USE master;