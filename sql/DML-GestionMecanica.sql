--CREATE DATABASE GestionMecanica
USE GestionMecanica

CREATE TABLE Cliente (
	ID INT IDENTITY(1,1),
	Name varchar(100) NOT NULL,
	Email nvarchar(50) NOT NULL,
	PhoneNumber varchar(50) NOT NULL
	CONSTRAINT PK_Cliente PRIMARY KEY (ID)
);

CREATE TABLE Marca (
	ID int IDentity(1,1) NOT NULL,
	Nombre varchar(100) NOT NULL,
	CONSTRAINT PK_MarcaID PRIMARY KEY (ID)
);

CREATE TABLE Modelo (
	ID int IDentity(1,1) NOT NULL,
	Modelo varchar(100) NOT NULL,
	MarcaID int NOT NULL
	CONSTRAINT PK_ModeloID PRIMARY KEY(ID),
	CONSTRAINT FK_MarcaModelo FOREIGN KEY (MarcaID) REFERENCES Marca(ID)
);

CREATE TABLE Vehiculo(
	VehiculoID int IDentity (1,1) NOT NULL,
	ClienteID int NOT NULL, 
	ModeloID int NOT NULL,
	Anio INT NOT NULL CHECK(Anio BETWEEN 1900 AND YEAR(GETDATE())),
	CONSTRAINT Pk_VehiculoID PRIMARY KEY(VehiculoID),
	CONSTRAINT FK_VehiculoID_ModeloID FOREIGN KEY (ModeloID) REFERENCES Modelo(ID),
	CONSTRAINT FK_VEhiculo_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente(ID)
);

CREATE TABLE Especialidad(
	ID int IDentity(1,1) NOT NULL,
	Nombre varchar(100) NOT NULL,
	CONSTRAINT PK_Especialidad PRIMARY KEY (ID)
);

CREATE TABLE Mecanico(
	ID int IDentity(1,1) NOT NULL, 
	Nombre varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	EspecialidadID int NOT NULL
	CONSTRAINT PK_Mecanico PRIMARY KEY (ID)
	CONSTRAINT FK_EspecialIDa_Mecanico FOREIGN KEY (EspecialidadID) REFERENCES Especialidad(ID)
);

CREATE TABLE Repuesto(
	ID INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Stock int NOT NULL,
	Precio decimal(18,2) NOT NULL,
	CONSTRAINT PK_Repuesto PRIMARY KEY (ID)
);

CREATE TABLE Reparacion(
	ID INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(MAX),
	Fecha DateTime,
	CONSTRAINT PK_Reparacion PRIMARY KEY (ID)
);

CREATE TABLE Estado(
	ID INT IDENTITY(1,1) NOT NULL,
	Estado VARCHAR(20) CHECK (Estado IN ('Pendiente', 'Iniciado', 'Finalizado')),
	CONSTRAINT PK_Estado PRIMARY KEY (ID)
);

CREATE TABLE Orden(
	ID int IDentity(1,1) NOT NULL, 
	FechaIngreso DATETIME NOT NULL,
	VehiculoID INT NOT NULL,
	EstadoID INT not null,
	DetalleOrden varchar(max) Not null,
	ReparacionID int,
	CONSTRAINT PK_Orden PRIMARY KEY (ID),
	CONSTRAINT FK_Reparacion_Orden FOREIGN KEY (ReparacionID) REFERENCES Reparacion(ID),
	CONSTRAINT FK_Estado_Orden FOREIGN KEY (EstadoID) REFERENCES Estado(ID)
);

CREATE TABLE DetalleOrden (
	ID int IDentity(1,1) not null,
	RepuestoID int NOT NULL,
	Cantidad Int NOT NULL,
	SubTotal decimal (18,2) NOT NULL,
	OrdenID INT NOT NULL,
	CONSTRAINT PK_DetalleOrden PRIMARY KEY (ID),
	CONSTRAINT FK_Repuesto_DetalleOrden FOREIGN KEY (RepuestoID) REFERENCES REPUESTO(ID),
	CONSTRAINT FK_DetalleOrden_Orden FOREIGN KEY (OrdenID) REFERENCES Orden(ID)
);

CREATE TABLE ORDEN_MECANICO(
	MecanicoID INT NOT NULL,
	OrdenID INT NOT NULL,
	CONSTRAINT PK_OrdenMecanico PRIMARY KEY (OrdenID, MecanicoID),
	CONSTRAINT FK_Mecanico_OrdenMecanico FOREIGN KEY (MecanicoID) REFERENCES Mecanico(ID),
	CONSTRAINT FK_Orden_OrdenMecanico FOREIGN KEY (OrdenID) REFERENCES Orden(ID)
);

CREATE TABLE Factura(
	ID INT IDENTITY(1,1) NOT NULL,
	OrdenID INT NOT NULL,
	Total DECIMAL(18,2) NOT NULL,
	FechaDeEmision DATETIME NOT NULL,
	EstadoID INT NOT NULL, 
	CONSTRAINT PK_Factura PRIMARY KEY(ID),
	CONSTRAINT FK_Estado FOREIGN KEY(EstadoID) REFERENCES Estado(ID)
);

CREATE TABLE MetodoPago(
	ID INT IDENTITY(1,1) NOT NULL,
	Metodo VARCHAR(100)
	CONSTRAINT PK_MetodoPago PRIMARY KEY (ID)
);

CREATE TABLE Pago (
	ID INT IDENTITY(1,1) NOT NULL,
	FacturaID INT NOT NULL,
	MontoTotal DECIMAL(18,2) NOT NULL,
	FechaPago DATETIME NOT NULL,
	MetodoPagoID INT NOT NULL,
	CONSTRAINT PK_Pago PRIMARY KEY (ID),
	CONSTRAINT FK_Factura_PAGO FOREIGN KEY (FacturaID) REFERENCES Factura(ID),
	CONSTRAINT FK_MetodoPago_PAGO FOREIGN KEY (MetodoPagoID) REFERENCES MetodoPago(ID)
);