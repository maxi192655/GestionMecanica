USE GestionMecanica;
GO

--Insercion de usuario
CREATE PROCEDURE Sp_Usuario_Create
	@Nombre VARCHAR(100),
	@Email VARCHAR(100),
	@Pwd VARCHAR(100),
	@Rol NVARCHAR(20),
	@Telefono NVARCHAR(20) = NULL,
	@Diereccion NVARCHAR(200) = NULL,
	@Ciudad NVARCHAR(100) = NULL,
	@Estado NVARCHAR(100) = NULL,
	@CodigoPostal NVARCHAR(20) = NULL,
	@Pais NVARCHAR(50) = NULL,
	@Area NVARCHAR(100) = NULL,
	@EspecialidadID INT = NULL
AS
BEGIN 
	INSERT INTO Usuario (Nombre, Email, Pwd, Rol, Telefono, Diereccion, Ciudad, Estado, CodigoPostal, Pais, Area, EspecialidadID)
	VALUES (
		@Nombre, @Email,@Pwd,@Rol, 
		@Telefono, @Direccion, @Ciudad, @Estado, 
		@CodigoPostal, @Pais, @Area,@Especialidad
	)
END;
GO

--Actualizacion de usuario
CREATE PROCEDURE Sp_Usuario_Update
	@ID INT,
	@Nombre VARCHAR(100),
	@Email VARCHAR(100),
	@Pwd VARCHAR(100),
	@Rol NVARCHAR(20),
	@Telefono NVARCHAR(20) = NULL,
	@Diereccion NVARCHAR(200) = NULL,
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
		Rol = @Rol,
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
	@Rol NVARCHAR(20)
AS
BEGIN
	SELECT * FROM Usuario WHERE Rol = @Rol
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