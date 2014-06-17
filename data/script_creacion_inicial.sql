USE GD1C2014;


BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

BEGIN TRANSACTION
GO

-- Creacion tabla de datos Clientes
CREATE TABLE [ATJ].[Clientes]
	(
	id_Cliente int NOT NULL IDENTITY (1, 1),
	Tipo_Dni nvarchar(50) NOT NULL DEFAULT 'DNI',
	Dni numeric(18, 0) NOT NULL,
	Cuil nvarchar(50) NULL,
	Apellido nvarchar(255) NULL,
	Nombre nvarchar(255) NULL,
	Fecha_nac datetime NULL,
	Mail nvarchar(255) NULL,
	Telefono nvarchar(255) NULL,
	Dom_calle nvarchar(255) NULL,
	Dom_nro_calle numeric(18, 0) NULL,
	Dom_piso numeric(18, 0) NULL,
	Dom_depto nvarchar(50) NULL,
	Dom_cod_postal nvarchar(50) NULL,
	Dom_ciudad nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1,
	id_Usuario int NULL,
	Reputacion numeric(18, 2) NULL,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE [ATJ].[Clientes] ADD CONSTRAINT
	PK_Clientes PRIMARY KEY CLUSTERED 
	(
	id_Cliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [ATJ].[Clientes] SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Empresas

CREATE TABLE [ATJ].[Empresas]
	(
	id_Empresa int NOT NULL IDENTITY (1, 1),
	Cuit nvarchar(50) NULL,
	Razon_social nvarchar(255) NULL,
	Mail nvarchar(50) NULL,
	Fecha_creacion datetime NULL,
	Telefono nvarchar(255) NULL,
	Dom_calle nvarchar(100) NULL,
	Dom_nro_calle numeric(18, 0) NULL,
	Dom_piso numeric(18, 0) NULL,
	Dom_depto nvarchar(50) NULL,
	Dom_cod_postal nvarchar(50) NULL,
	Dom_ciudad nvarchar(255) NULL,
	Nombre_contacto nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1,
	id_Usuario int NULL,
	Reputacion numeric(18, 2) NULL,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE [ATJ].[Empresas] ADD CONSTRAINT
	PK_Empresas PRIMARY KEY CLUSTERED 
	(
	id_Empresa
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE [ATJ].[Empresas] SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Usuarios


CREATE TABLE ATJ.Usuarios
	(
	id_Usuario int NOT NULL IDENTITY (1, 1),
	Username nvarchar(255) NOT NULL,
	Clave nvarchar(255) NOT NULL,
	ClaveAutoGenerada bit NOT NULL DEFAULT 1,
	Activo bit NOT NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Usuarios ADD CONSTRAINT
	PK_Usuarios PRIMARY KEY CLUSTERED 
	(
	id_Usuario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Usuarios ADD UNIQUE (Username)
GO
ALTER TABLE ATJ.Usuarios SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Publicaciones

CREATE TABLE ATJ.Publicaciones
	(
	Codigo numeric(18, 0) NOT NULL IDENTITY (1, 1),
	id_Usuario int NOT NULL,
	Descripcion nvarchar(255) NULL,
	Stock numeric(18, 0) NULL DEFAULT 0,
	Fecha_creacion datetime NULL DEFAULT GETDATE(),
	Fecha_vencimiento datetime NULL,
	Precio numeric(18, 2) NULL DEFAULT 0.00,
	id_Tipo int NULL,
	cod_Visibilidad numeric(18, 0) NULL,
	id_Estado int NULL,
	permiso_Preguntas bit NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Publicaciones ADD CONSTRAINT
	PK_Publicaciones PRIMARY KEY CLUSTERED 
	(
	Codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Publicaciones SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ATJ.Publicaciones WITH NOCHECK ADD CONSTRAINT CK_STOCK CHECK(Stock>-1)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Tipos_Publicacion

CREATE TABLE ATJ.Tipos_Publicacion
	(
	id_Tipo int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Tipos_Publicacion ADD CONSTRAINT
	PK_Tipos_Publicacion PRIMARY KEY CLUSTERED 
	(
	id_Tipo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Tipos_Publicacion SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Visibilidades

CREATE TABLE ATJ.Visibilidades
	(
	cod_Visibilidad numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL,
	Precio numeric(18, 2) NULL DEFAULT 0.00,
	Porcentaje numeric(18, 2) NULL,
	Duracion int NULL,
	Activo bit NULL DEFAULT 1,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Visibilidades ADD CONSTRAINT
	PK_Visibilidades PRIMARY KEY CLUSTERED 
	(
	cod_Visibilidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Visibilidades SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rubros

CREATE TABLE ATJ.Rubros
	(
	id_Rubro int NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL,
	Activo bit NULL DEFAULT 1
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rubros ADD CONSTRAINT
	PK_Rubros PRIMARY KEY CLUSTERED 
	(
	id_Rubro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Rubros SET (LOCK_ESCALATION = TABLE)
GO

-----------------------------------------------------------------------------------------------------------------------------
--Creacion de tabla de datos Rubros_Publicacion
CREATE TABLE [ATJ].[Rubros_Publicacion] (
	[id_Rubros_Publicacion] int IDENTITY (1,1),
	[id_Rubro] int NOT NULL,
	[cod_Publicacion] numeric(18,0) NOT NULL
);

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Preguntas

CREATE TABLE ATJ.Preguntas
	(
	id_Pregunta int NOT NULL IDENTITY (1, 1),
	Pregunta nvarchar(255) NULL,
	Respuesta nvarchar(255) NULL,
	Fecha_respuesta datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Preguntas ADD CONSTRAINT
	PK_Preguntas PRIMARY KEY CLUSTERED 
	(
	id_Pregunta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Preguntas SET (LOCK_ESCALATION = TABLE)
GO


------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Preguntas_Publicacion

CREATE TABLE ATJ.Pregunta_Publicacion
	(
	id_Pregunta int NOT NULL,
	cod_Publicacion numeric(18, 0) NOT NULL,
	PRIMARY KEY (id_Pregunta, cod_Publicacion)
	)  ON [PRIMARY]
GO

ALTER TABLE ATJ.Pregunta_Publicacion SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Estados_Publicacion

CREATE TABLE ATJ.Estados_Publicacion
	(
	id_Estado int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Estados_Publicacion ADD CONSTRAINT
	PK_Estados_Publicacion PRIMARY KEY CLUSTERED 
	(
	id_Estado
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Estados_Publicacion SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Roles

CREATE TABLE ATJ.Roles
	(
	id_Rol int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL,
	Habilitado bit NULL DEFAULT 1,
	Eliminado bit NULL DEFAULT 0
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Roles ADD CONSTRAINT
	PK_Roles PRIMARY KEY CLUSTERED 
	(
	id_Rol
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Roles SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rol_Usuario

CREATE TABLE ATJ.Rol_Usuario
	(
	id_Rol int NOT NULL,
	id_Usuario int NOT NULL,
	PRIMARY KEY (id_Rol, id_Usuario)
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rol_Usuario SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Funcionalidades

CREATE TABLE ATJ.Funcionalidades
	(
	id_Funcionalidad int NOT NULL IDENTITY (1, 1),
	Nombre nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Funcionalidades ADD CONSTRAINT
	PK_Funcionalidades PRIMARY KEY CLUSTERED 
	(
	id_Funcionalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Funcionalidades SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Rol_Funcionalidad

CREATE TABLE ATJ.Rol_Funcionalidad
	(
	id_Rol int NOT NULL,
	id_Funcionalidad int NOT NULL,
	PRIMARY KEY (id_Rol, id_Funcionalidad)
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Rol_Funcionalidad SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Facturas

CREATE TABLE ATJ.Facturas
	(
	nro_Factura numeric(18, 0) NOT NULL IDENTITY (1, 1),
	Fecha datetime NULL DEFAULT GETDATE(),
	Precio_Total numeric(18, 2) NULL,
	id_Forma_Pago int NULL,
	id_Usuario int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Facturas ADD CONSTRAINT
	PK_Facturas PRIMARY KEY CLUSTERED 
	(
	nro_Factura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Facturas SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Item_Factura

CREATE TABLE ATJ.Item_Factura
	(
	id_Item_Factura int NOT NULL IDENTITY (1, 1),
	nro_Factura numeric(18, 0) NOT NULL,
	cod_Publicacion numeric(18, 0) NOT NULL,
	Monto numeric(18, 2) NULL,
	Cantidad numeric(18, 0) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Item_Factura ADD CONSTRAINT
	PK_Item_Factura PRIMARY KEY CLUSTERED 
	(
	id_Item_Factura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Item_Factura SET (LOCK_ESCALATION = TABLE)
GO

------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Formas_Pago
CREATE TABLE ATJ.Formas_Pago
	(
	id_Forma_Pago int NOT NULL IDENTITY (1, 1),
	Descripcion nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Formas_Pago ADD CONSTRAINT
	PK_Formas_pago PRIMARY KEY CLUSTERED 
	(
	id_Forma_Pago
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Formas_Pago SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Compras
CREATE TABLE ATJ.Compras
	(
	id_Compra int NOT NULL IDENTITY (1, 1),
	cod_Publicacion numeric(18, 0) NOT NULL,
	id_Usuario_Vendedor int NOT NULL,
	id_Usuario_Comprador int NOT NULL,
	Fecha datetime NULL,
	Cantidad numeric(18, 0) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Compras ADD CONSTRAINT
	PK_Compras PRIMARY KEY CLUSTERED 
	(
	id_Compra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Compras SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Ofertas
CREATE TABLE ATJ.Ofertas
	(
	id_Oferta int NOT NULL IDENTITY (1, 1),
	cod_Publicacion numeric(18, 0) NOT NULL,
	id_Usuario_Vendedor int NOT NULL,
	id_Usuario_Comprador int NOT NULL,
	gano_Subasta bit NULL DEFAULT 0,
	Fecha datetime NULL,
	Monto numeric(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Ofertas ADD CONSTRAINT
	PK_Ofertas PRIMARY KEY CLUSTERED 
	(
	id_Oferta
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Ofertas SET (LOCK_ESCALATION = TABLE)
GO
------------------------------------------------------------------------------------------------------------------------------
-- Creacion tabla de datos Calificaciones
CREATE TABLE ATJ.Calificaciones
	(
	cod_Calificacion numeric(18, 0) NOT NULL IDENTITY (1, 1),
	id_Usuario_Calificador int NOT NULL,
	cod_Publicacion int NOT NULL,
	Cant_Estrellas numeric(18, 0) NULL,
	Descripcion nvarchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ATJ.Calificaciones ADD CONSTRAINT
	PK_Calificaciones PRIMARY KEY CLUSTERED 
	(
	cod_Calificacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ATJ.Calificaciones SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

-------------------------------------------------------------------------------------------------------------------------------
--- Creacion de foreign keys


BEGIN TRANSACTION
GO
--Creacion foreign key Cliente-Usuario
ALTER TABLE ATJ.Clientes 
ADD CONSTRAINT FK_Cliente_Usuario FOREIGN KEY (id_Usuario) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreign key Empresa-Usuario
ALTER TABLE ATJ.Empresas 
ADD CONSTRAINT FK_Empresa_Usuario FOREIGN KEY (id_Usuario) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreing key usuario calificador
ALTER TABLE ATJ.Calificaciones
ADD CONSTRAINT FK_Calificador_Usuario FOREIGN KEY (id_Usuario_Calificador) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO


--Creacion foreing key usuario vendedor compras
ALTER TABLE ATJ.Compras
ADD CONSTRAINT FK_Vendedor_Usuario FOREIGN KEY (id_Usuario_Vendedor) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO

--Creacion foreing key usuario comprador compras
ALTER TABLE ATJ.Compras
ADD CONSTRAINT FK_Comprador_Usuario FOREIGN KEY (id_Usuario_Comprador) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO

--Creacion foreing key forma de pago
ALTER TABLE ATJ.Facturas
ADD CONSTRAINT FK_Forma_Pago FOREIGN KEY (id_Forma_Pago) 
    REFERENCES ATJ.Formas_Pago (id_Forma_Pago) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO 

--Creacion foreing key Item Factura
ALTER TABLE ATJ.Item_Factura
ADD CONSTRAINT FK_Item_Factura FOREIGN KEY (nro_Factura) 
    REFERENCES ATJ.Facturas (nro_Factura) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO 

--Creacion foreing key usuario vendedor oferta
ALTER TABLE ATJ.Ofertas
ADD CONSTRAINT FK_Oferta_Vendedor_Usuario FOREIGN KEY (id_Usuario_Vendedor) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO

--Creacion foreing key usuario comprador oferta
ALTER TABLE ATJ.Ofertas
ADD CONSTRAINT FK_Oferta_Comprador_Usuario FOREIGN KEY (id_Usuario_Comprador) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
;
GO

--Creacion foreing key pregunta por publicacion
ALTER TABLE ATJ.Pregunta_Publicacion
ADD CONSTRAINT FK_Pregunta_Publicacion FOREIGN KEY (cod_Publicacion) 
    REFERENCES ATJ.Publicaciones (Codigo) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreing key publicacion usuario
ALTER TABLE ATJ.Publicaciones
ADD CONSTRAINT FK_Usuario_Publicacion FOREIGN KEY (id_Usuario) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO


--Creacion foreing key publicacion tipos
ALTER TABLE ATJ.Publicaciones
ADD CONSTRAINT FK_Tipos_Publicacion FOREIGN KEY (id_Tipo) 
    REFERENCES ATJ.Tipos_Publicacion (id_Tipo) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreing key publicacion tipos
ALTER TABLE ATJ.Publicaciones
ADD CONSTRAINT FK_Visibilidad_Publicacion FOREIGN KEY (cod_Visibilidad) 
    REFERENCES ATJ.Visibilidades (cod_visibilidad) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreing key publicacion estados
ALTER TABLE ATJ.Publicaciones
ADD CONSTRAINT FK_Estados_Publicacion FOREIGN KEY (id_Estado) 
    REFERENCES ATJ.Estados_Publicacion (id_Estado) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO


--Creacion foreing key rol por funcionalidad
ALTER TABLE ATJ.Rol_Funcionalidad
ADD CONSTRAINT FK_Rol_Funcionalidad FOREIGN KEY (id_Funcionalidad) 
    REFERENCES ATJ.Funcionalidades (id_Funcionalidad) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

--Creacion foreing key rol por usuario
ALTER TABLE ATJ.Rol_Usuario
ADD CONSTRAINT FK_Rol_Usuario FOREIGN KEY (id_Usuario) 
    REFERENCES ATJ.Usuarios (id_Usuario) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO


-- Migracion de datos
--------------------------------------------------------------------------------------------------------------------

DECLARE @number AS INT


-- Migracion de datos tabla Clientes
INSERT INTO ATJ.Clientes (Apellido, Dom_cod_postal, Dom_depto, Dni, Dom_calle, Fecha_nac, Mail,
 Nombre, Dom_nro_calle, Dom_piso )
(SELECT DISTINCT Publ_Cli_Apeliido, Publ_Cli_Cod_Postal, Publ_Cli_Depto, Publ_Cli_Dni, Publ_Cli_Dom_Calle, 
Publ_Cli_Fecha_Nac, Publ_Cli_Mail, Publ_Cli_Nombre, Publ_Cli_Nro_Calle, Publ_Cli_Piso
  FROM [gd_esquema].[Maestra] where Publ_Cli_Dni is not null)
  
  UNION 
  (
  SELECT DISTINCT Cli_Apeliido, Cli_Cod_Postal, Cli_Depto, Cli_Dni, Cli_Dom_Calle, 
  Cli_Fecha_Nac, Cli_Mail, Cli_Nombre, Cli_Nro_Calle, Cli_Piso
  FROM [gd_esquema].[Maestra] where Cli_Dni is not null)
--------------------------------------------------------------------------------------------------------------------  
 --Migracion de datos tabla Empresas
 INSERT INTO ATJ.Empresas 
(Dom_cod_postal, Cuit, Dom_depto, Dom_calle, Fecha_creacion, Mail, Dom_nro_calle, Dom_piso, Razon_social)
(
SELECT DISTINCT Publ_Empresa_Cod_Postal, Publ_Empresa_Cuit, Publ_Empresa_Depto, Publ_Empresa_Dom_Calle, 
Publ_Empresa_Fecha_Creacion, Publ_Empresa_Mail, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, 
Publ_Empresa_Razon_Social 
from gd_esquema.Maestra where Publ_Empresa_Cuit is not null)

--------------------------------------------------------------------------------------------------------------------

--Creacion Usuario DEFAULT
--Password del admin: w23e
INSERT INTO ATJ.Usuarios (Username, Clave, ClaveAutoGenerada, Activo) VALUES ('Admin', '52D77462B24987175C8D7DAB901A5967E927FFC8D0B6E4A234E07A4AEC5E3724', 0, 1)

--migracion de datos Usuarios de clientes
--Password general: admin
INSERT INTO ATJ.USUARIOS (Username, Clave, ClaveAutoGenerada, Activo)
 (
 SELECT DISTINCT DNI AS USERNAME, '7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00' AS Clave, 1 as ClaveAutoGenerada, 1 as Activo
 from ATJ.Clientes)
--------------------------------------------------------------------------------------------------------------------
-- Migracion de datos Usuarios de Empresas
--Password general: admin
INSERT INTO ATJ.USUARIOS (Username, Clave, ClaveAutoGenerada, Activo)
 (
 SELECT DISTINCT Cuit AS USERNAME, '7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00' AS Clave, 1 as ClaveAutoGenerada, 1 as Activo
 from ATJ.Empresas) 
-------------------------------------------------------------------------------------------------------------------- 
 -- Agrego los id_Usuario a las tablas Clientes y Empresas
 UPDATE ATJ.Clientes
SET id_Usuario = (SELECT id_Usuario FROM ATJ.Usuarios AS "U" WHERE U.Username = CAST(Clientes.Dni AS NVARCHAR(50)))

UPDATE ATJ.Empresas 
SET id_Usuario = (SELECT id_Usuario FROM ATJ.Usuarios AS "U" WHERE U.Username = CAST(Empresas.Cuit AS NVARCHAR(50)))
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Rubros
INSERT INTO ATJ.Rubros (Descripcion, Activo) (SELECT DISTINCT Publicacion_Rubro_Descripcion, 1 as ACTIVO FROM [gd_esquema].[Maestra] where Publicacion_Rubro_Descripcion is not null)
 --------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Visibilidades
SET IDENTITY_INSERT ATJ.Visibilidades ON

INSERT INTO ATJ.Visibilidades (cod_Visibilidad, Descripcion, Porcentaje, Precio, Duracion)
(SELECT DISTINCT [Publicacion_Visibilidad_Cod]
				,[Publicacion_Visibilidad_Desc]
				,[Publicacion_Visibilidad_Precio]
				,[Publicacion_Visibilidad_Porcentaje]
				,(SELECT DISTINCT DATEDIFF(day,Publicacion_Fecha,Publicacion_Fecha_Venc)
				  FROM gd_esquema.Maestra
				  WHERE Publicacion_Visibilidad_Cod = [Publicacion_Visibilidad_Cod])
FROM gd_esquema.Maestra 
WHERE Publicacion_Visibilidad_Cod is not null)

SET IDENTITY_INSERT ATJ.Visibilidades OFF

SELECT @number = MAX(Publicacion_Visibilidad_Cod) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Visibilidades', RESEED, @number);

 --------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Tipos_Publicacion
INSERT INTO ATJ.Tipos_Publicacion(Nombre)
(SELECT DISTINCT Publicacion_tipo FROM [gd_esquema].[Maestra] where Publicacion_Cod is not null)

--------------------------------------------------------------------------------------------------------------------
--Migracion de Estados_Publicacion
INSERT INTO ATJ.Estados_Publicacion (Nombre)
SELECT DISTINCT Publicacion_Estado
FROM gd_esquema.Maestra where Publicacion_Estado is not null
  
INSERT INTO ATJ.Estados_Publicacion
(Nombre)
VALUES
('Borrador'),
('Pausada'),
('Finalizada')

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla Publicaciones

SET IDENTITY_INSERT ATJ.Publicaciones ON

INSERT INTO ATJ.Publicaciones(Codigo,Descripcion, Fecha_creacion, Fecha_vencimiento, Precio, Stock,id_Tipo, 
cod_Visibilidad, id_Usuario, id_Estado)
(SELECT DISTINCT M.Publicacion_Cod, M.Publicacion_Descripcion, M.Publicacion_Fecha, M.Publicacion_Fecha_Venc,
M.Publicacion_Precio, M.Publicacion_Stock, TP.id_Tipo, M.Publicacion_Visibilidad_Cod, 
Entidad = (CASE WHEN Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END), E.id_Estado
FROM [gd_esquema].[Maestra] as "M" 
INNER JOIN ATJ.Tipos_Publicacion as "TP" ON TP.Nombre = M.Publicacion_tipo
INNER JOIN ATJ.Estados_Publicacion AS "E" ON E.Nombre = 'Finalizada'
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
WHERE M.Publicacion_Cod is not null)

SET IDENTITY_INSERT ATJ.Publicaciones OFF

SELECT @number = MAX(Publicacion_Cod) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Publicaciones', RESEED, @number);

--------------------------------------------------------
--Migracion de Funcionalidades
INSERT INTO ATJ.Funcionalidades
(Nombre)
VALUES
('ABM_Clientes'),
('ABM_Empresas'),
('Eliminar_Usuarios'),
('Cambiar_Clave'),
('ABM_Rol'),
('ABM_Visibilidad'),
('Generar_Publicaciones'),
('Mis_Publicaciones'),
('Comprar_Ofertar'),
('Calificar'),
('Facturar'),
('Historial_clientes'),
('Estadisticas')
---------------------------------------------------
--Migracion de datos Calificaciones

SET IDENTITY_INSERT ATJ.Calificaciones ON

	INSERT INTO ATJ.Calificaciones (cod_Calificacion, cod_Publicacion, id_Usuario_Calificador, Cant_Estrellas, Descripcion) (
		SELECT [Calificacion_Codigo],
			   [Publicacion_Cod],
			   (SELECT id_Usuario FROM ATJ.Usuarios U WHERE CONVERT(nvarchar(255), Cli_Dni) = U.Username),
		       CAST(ROUND([Calificacion_Cant_Estrellas]/2,0) AS INT),
		       [Calificacion_Descripcion]
		FROM gd_esquema.Maestra
		WHERE [Calificacion_Codigo] IS NOT NULL)
		
	SET IDENTITY_INSERT ATJ.Calificaciones OFF

	DECLARE @maxIdCalificacion numeric(18,0);
	SELECT @maxIdCalificacion = MAX(Calificacion_Codigo) FROM gd_esquema.Maestra DBCC CHECKIDENT ('ATJ.Calificaciones', RESEED, @maxIdCalificacion);
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Roles
INSERT INTO ATJ.Roles(Nombre) VALUES ('Administrativo'),('Cliente'),('Empresa')

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Rubros_Publicacion
INSERT INTO [ATJ].[Rubros_Publicacion] (id_Rubro, cod_Publicacion) (
	SELECT DISTINCT
	(SELECT id_Rubro FROM ATJ.Rubros R WHERE R.Descripcion = Publicacion_Rubro_Descripcion),
	(SELECT P.Codigo FROM ATJ.Publicaciones P WHERE P.Codigo = Publicacion_Cod)
	FROM gd_esquema.Maestra
	WHERE Publicacion_Cod IS NOT NULL)

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Compras
INSERT INTO ATJ.Compras(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Cantidad)
(select distinct M.Publicacion_Cod, usuario_vende = (CASE WHEN M.Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END),
Ucomprador.id_Usuario, M.Compra_Fecha, M.Compra_Cantidad 
from gd_esquema.Maestra as "M"
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucomprador" ON Ucomprador.Username = CAST(M.Cli_Dni AS NVARCHAR(50))
where Publicacion_Tipo = 'Compra Inmediata' AND Cli_Dni is not null AND Compra_Fecha IS NOT NULL)
--------------------------------------------------------------------------------------------------------------------
--Migracion de datos de tabla Ofertas
INSERT INTO ATJ.Ofertas(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Monto)
(select distinct M.Publicacion_Cod, usuario_vende = (CASE WHEN M.Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END),
Ucomprador.id_Usuario, M.Oferta_Fecha, M.Oferta_Monto
from gd_esquema.Maestra as "M"
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucomprador" ON Ucomprador.Username = CAST(M.Cli_Dni AS NVARCHAR(50))
where Publicacion_Tipo = 'Subasta' AND Cli_Dni is not nulL AND Oferta_Monto IS not NULL AND Oferta_Fecha IS NOT NULL)

UPDATE ATJ.Ofertas  
SET gano_Subasta = (CASE WHEN Monto = (SELECT MAX(Oferta_Monto) FROM gd_esquema.Maestra AS "M" WHERE M.Publicacion_Cod = Ofertas.cod_Publicacion)
THEN '1' ELSE '0' END)

--------------------------------------------------------------------------------------------------------------------

--Migracion de datos de tabla Rol_Usuario
INSERT INTO ATJ.Rol_Usuario 
(id_Rol, id_Usuario)
VALUES
(1, 1)

INSERT INTO ATJ.Rol_Usuario
(id_Usuario,id_Rol)
SELECT DISTINCT id_Usuario as idU, R.id_Rol as idR 
FROM ATJ.Usuarios U 
INNER JOIN gd_esquema.Maestra MCli ON U.Username = CAST(MCli.Publ_Cli_Dni AS NVARCHAR(50))
LEFT JOIN ATJ.Roles R ON R.Nombre = 'Cliente'

INSERT INTO ATJ.Rol_Usuario
(id_Usuario,id_Rol)
SELECT DISTINCT id_Usuario as idU, R.id_Rol as idR 
FROM ATJ.Usuarios U 
INNER JOIN gd_esquema.Maestra MEmpr ON U.Username = CAST(MEmpr.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Roles R ON R.Nombre = 'Empresa'

--------------------------------------------------------------------------------------------------------------------
--Migracion de datos tabla rol_Funcionalidad
INSERT INTO ATJ.Rol_Funcionalidad(id_Rol, id_Funcionalidad)
SELECT 1, id_Funcionalidad FROM ATJ.Funcionalidades

INSERT INTO ATJ.Rol_Funcionalidad (id_Rol, id_Funcionalidad)
SELECT R.id_Rol, F.id_Funcionalidad  
FROM ATJ.Roles R
LEFT JOIN ATJ.Funcionalidades F ON F.Nombre 
In ('ABM_Clientes','ABM_Empresas','Eliminar_Usuarios','Cambiar_Clave','ABM_Rol','ABM_Visibilidad','Generar_Publicaciones','Mis_Publicaciones','Comprar_Ofertar','Calificar','Facturar','Historial_clientes','Estadisticas')
WHERE R.Nombre = 'Cliente'

INSERT INTO ATJ.Rol_Funcionalidad (id_Rol, id_Funcionalidad)
SELECT R.id_Rol, F.id_Funcionalidad  
FROM ATJ.Roles R
LEFT JOIN ATJ.Funcionalidades F ON F.Nombre 
In ('ABM_Empresas','ABM_Usuarios', 'ABM_Publicacion','Preguntar', 'Facturar','Historial_clientes', 'Estadisticas')
WHERE R.Nombre = 'Empresa'

-------------------------------------------------

--Migracion de datos tabla Facturas y Formas de pago

INSERT INTO ATJ.Formas_Pago
SELECT DISTINCT M.Forma_Pago_Desc FROM gd_esquema.Maestra M where M.Factura_Nro is not null

SET IDENTITY_INSERT ATJ.Facturas ON

INSERT INTO ATJ.Facturas
(nro_Factura, Fecha, Precio_Total, id_Forma_Pago, id_Usuario)
SELECT distinct M.Factura_Nro, M.Factura_Fecha, M.Factura_Total, FP.id_Forma_Pago, Entidad = (CASE WHEN Publ_Cli_Dni IS null THEN Uempresa.id_Usuario ELSE Ucliente.id_Usuario END)
FROM gd_esquema.Maestra M 
LEFT JOIN ATJ.Formas_Pago FP ON FP.Descripcion = M.Forma_Pago_Desc
LEFT JOIN ATJ.Usuarios AS "Uempresa" ON Uempresa.Username = CAST(M.Publ_Empresa_Cuit AS NVARCHAR(50))
LEFT JOIN ATJ.Usuarios AS "Ucliente" ON Ucliente.Username = CAST(M.Publ_Cli_Dni AS NVARCHAR(50))
where M.Factura_Nro is not null

SET IDENTITY_INSERT ATJ.Facturas OFF

SELECT @number = MAX(Factura_Nro) FROM gd_esquema.Maestra
DBCC CHECKIDENT ('ATJ.Facturas', RESEED, @number);

-------------------------------------------------

--Migracion de datos tabla Item_Factura
INSERT INTO ATJ.Item_Factura (nro_Factura, cod_Publicacion, Monto, Cantidad)
SELECT F.nro_Factura, P.Codigo, M.Item_Factura_Monto, M.Item_Factura_Cantidad
FROM gd_esquema.Maestra M 
INNER JOIN ATJ.Facturas F ON F.nro_Factura = M.Factura_Nro
INNER JOIN ATJ.Publicaciones P ON P.Codigo = M.Publicacion_Cod 

--Seteo la Reputacion en la Tabla Clientes con los datos ya migrados
UPDATE ATJ.Clientes	
SET Reputacion = CAST(
				(SELECT SUM(C.Cant_Estrellas) 
				FROM ATJ.Usuarios U
				INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
				INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
				WHERE u.id_Usuario = Clientes.id_Usuario)/
				(SELECT COUNT(*)
				FROM ATJ.Calificaciones C
				INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
				WHERE p.id_Usuario = Clientes.id_Usuario) 
				AS NUMERIC(18,2))
	
--Seteo la Reputacion en la Tabla Empresas con los datos ya migrados
UPDATE ATJ.Empresas 
SET Reputacion = CAST(
				(SELECT SUM(C.Cant_Estrellas) 
				FROM ATJ.Usuarios U
				INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
				INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
				WHERE u.id_Usuario = Empresas.id_Usuario)/
				(SELECT COUNT(*)
				FROM ATJ.Calificaciones C
				INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
				WHERE p.id_Usuario = Empresas.id_Usuario) 
				AS NUMERIC(18,2))
				
COMMIT