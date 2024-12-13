CREATE DATABASE DBControlMigracion;
USE DBControlMigracion;

--Tabla viajeros--
CREATE TABLE VIAJEROS (
    id INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    segundo NVARCHAR(50),
    apellido1 NVARCHAR(50) NOT NULL,
    apellido2 NVARCHAR(50),
    fechaNacimiento DATE NOT NULL,
    nacionalidad NVARCHAR(50) NOT NULL,
    correoElectronico NVARCHAR(100),
    genero NVARCHAR(10) CHECK (genero IN ('Masculino', 'Femenino', 'Otro'))
);

--Tabla documento--
CREATE TABLE DOCUMENTO (
    id INT IDENTITY PRIMARY KEY,
    tipoDocumento NVARCHAR(50) NOT NULL,
    numeroDocumento NVARCHAR(50) UNIQUE NOT NULL,
    fechaExpiracion DATE NOT NULL,
    idViajero INT NOT NULL,
    CONSTRAINT FK_Documento_Viajero FOREIGN KEY (idViajero) REFERENCES VIAJEROS(id)
);

--Tabla usuario--
CREATE TABLE USUARIO (
    idUsuario INT IDENTITY PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    correo NVARCHAR(100) UNIQUE NOT NULL,
    contraseña NVARCHAR(255) NOT NULL,
    rol NVARCHAR(50) NOT NULL
);

--Tabla estados--
CREATE TABLE ESTADOS (
    idEstado INT IDENTITY PRIMARY KEY,
    descripcion NVARCHAR(50),
    tipoEstado NVARCHAR(50),
    fechaCreacion DATETIME DEFAULT GETDATE()
);

--Tabla movimiento--
CREATE TABLE MOVIMIENTO (
    idMovimientoViajero INT IDENTITY PRIMARY KEY,
    fecha DATETIME NOT NULL,
    destino NVARCHAR(100) NOT NULL,
    origen NVARCHAR(100) NOT NULL,
    tipoSolicitud NVARCHAR(10) CHECK (tipoSolicitud IN ('Entrada', 'Salida')),
    idUsuario INT NOT NULL,
    idEstado INT NOT NULL,
	idViajero INT NOT NULL
    CONSTRAINT FK_Movimiento_Usuario FOREIGN KEY (idUsuario) REFERENCES USUARIO(idUsuario),
    CONSTRAINT FK_Movimiento_Estado FOREIGN KEY (idEstado) REFERENCES ESTADOS(idEstado),
	CONSTRAINT FK_Movimiento_Viajero FOREIGN KEY (idViajero) REFERENCES VIAJEROS(id)
);


--Tabla auditoria--
CREATE TABLE AUDITORIA (
    idAuditoria INT IDENTITY PRIMARY KEY,
    idUsuario INT NOT NULL,
    fechaAccion DATETIME DEFAULT GETDATE(),
    descripcion NVARCHAR(255),
    CONSTRAINT FK_Auditoria_Usuario FOREIGN KEY (idUsuario) REFERENCES USUARIO(idUsuario)
);