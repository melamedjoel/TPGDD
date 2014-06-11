USE GD1C2014;
GO

--Procedure traerListadoClientesConFiltros
CREATE PROCEDURE ATJ.traerListadoClientesConFiltros 
    @Nombre nvarchar(255), 
    @Apellido nvarchar(255),
    @Tipo_Dni nvarchar(50),
    @Dni numeric(18,0),
    @Mail nvarchar(255)
AS 
    SELECT *
    FROM ATJ.Clientes
    WHERE	Nombre = @Nombre AND 
			Apellido = @Apellido AND
			Tipo_Dni = @Tipo_Dni AND
			Dni = @Dni AND
			Mail = @Mail
			
GO

--Procedure updateCliente
CREATE PROCEDURE ATJ.updateCliente
	@id_Cliente int,
	@Tipo_Dni nvarchar(50),
	@Dni numeric(18,0),
	@Apellido nvarchar(255),
	@Nombre nvarchar(255),
	@Fecha_nac datetime,
	@Mail nvarchar(255),
	@Telefono nvarchar(255),
	@Dom_calle nvarchar(255),
	@Dom_nro_calle numeric(18,0),
	@Dom_piso numeric(18,0),
	@Dom_depto nvarchar(50),
	@Dom_cod_postal nvarchar(50),
	@Activo bit
AS
	UPDATE ATJ.Clientes SET Tipo_Dni = @Tipo_Dni,
							Dni = @Dni,
							Apellido = @Apellido,
							Nombre = @Nombre,
							Fecha_nac = @Fecha_nac,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Activo = @Activo
							where id_Cliente = @id_Cliente
GO


--Procedure traerListadoEmpresasConFiltros 
CREATE PROCEDURE ATJ.traerListadoEmpresas
    
AS 
    SELECT *, (Dom_calle+' '+Convert(nvarchar(50),Dom_nro_calle)+' '+Convert(nvarchar(50),Dom_piso)+'° '+Dom_depto) AS Direccion
    FROM ATJ.Empresas
    
			
GO

--Procedure traerEmpresaConId 
CREATE PROCEDURE ATJ.traerEmpresaConId
    @id_Empresa int
AS 
    SELECT *
    FROM ATJ.Empresas
    WHERE	id_Empresa = @id_Empresa  
			
GO

--Procedure updateEmpresa
CREATE PROCEDURE ATJ.updateEmpresa
	@id_empresa int,
	@Razon_social nvarchar(255),
	@Cuit nvarchar(50),
	@Mail nvarchar(50),
	@Fecha_creacion datetime,
	@Telefono nvarchar(255),
	@Dom_calle nvarchar(100),
	@Dom_nro_calle numeric(18,0),
	@Dom_piso numeric(18,0),
	@Dom_depto nvarchar(50),
	@Dom_cod_postal nvarchar(50),
	@Dom_ciudad nvarchar(255),
	@Nombre_contacto nvarchar(255),
	@Activo bit
AS
	UPDATE ATJ.Empresas SET Razon_social = @Razon_social,
							Cuit = @Cuit,
							Fecha_creacion = @Fecha_creacion,
							Mail = @Mail,
							Telefono = @Telefono,
							Dom_calle = @Dom_calle,
							Dom_nro_calle = @Dom_nro_calle,
							Dom_piso = @Dom_piso,
							Dom_depto = @Dom_depto,
							Dom_cod_postal = @Dom_cod_postal,
							Dom_ciudad = @Dom_ciudad,
							Nombre_contacto = @Nombre_contacto,
							Activo = @Activo
							where id_Empresa = @id_empresa
GO
--Procedure insertEmpresa
CREATE PROCEDURE ATJ.insertEmpresa
	@Razon_social nvarchar(255),
	@Cuit nvarchar(50),
	@Mail nvarchar(50),
	@Fecha_creacion datetime,
	@Telefono nvarchar(255),
	@Dom_calle nvarchar(100),
	@Dom_nro_calle numeric(18,0),
	@Dom_piso numeric(18,0),
	@Dom_depto nvarchar(50),
	@Dom_cod_postal nvarchar(50),
	@Dom_ciudad nvarchar(255),
	@Nombre_contacto nvarchar(255),
	@Activo bit
AS
	INSERT INTO ATJ.Empresas 
	(Razon_social, Cuit, Fecha_creacion, Mail, Telefono, Dom_calle, Dom_nro_calle,
	Dom_piso, Dom_depto, Dom_cod_postal, Dom_ciudad, Nombre_contacto, Activo)
	VALUES
	(@Razon_social, @Cuit, @Fecha_creacion, @Mail, @Telefono, @Dom_calle, @Dom_nro_calle,
	@Dom_piso, @Dom_depto, @Dom_cod_postal, @Dom_ciudad, @Nombre_contacto,@Activo)

GO
--Procedure updateVisibilidad
CREATE PROCEDURE ATJ.updateVisibilidad
	@cod_Visibilidad numeric(18,0),
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2)
AS
	UPDATE ATJ.Visibilidades SET --cod_Visibilidad = @cod_Visibilidad, --modificable?
							Descripcion = @Descripcion,
							Precio = @Precio,
							Porcentaje = @Porcentaje
							where cod_Visibilidad = @cod_Visibilidad
	
GO

--Procedure updatePublicacion
CREATE PROCEDURE ATJ.updatePublicacion
	@Codigo numeric(18,0),
	@id_Usuario int,
	@Descripcion nvarchar(255),
	@Stock numeric(18, 0),
	@Fecha_creacion datetime,
	@Fecha_vencimiento datetime,
	@Precio numeric(18, 2),
	@id_Tipo int,
	@cod_Visibilidad numeric(18, 0),
	@id_Estado int,
	@id_Rubro int,
	@permiso_Preguntas bit
AS
	UPDATE ATJ.Publicaciones SET Descripcion = @Descripcion,
							Stock = @Stock,
							Fecha_creacion = @Fecha_creacion,
							Fecha_vencimiento = @Fecha_vencimiento,
							Precio = @Precio,
							id_Tipo = @id_Tipo,
							cod_Visibilidad = cod_Visibilidad,
							id_Estado = @id_Estado,
							id_Rubro = @id_Rubro,
							permiso_Preguntas = @permiso_Preguntas
							where Codigo = @Codigo
	
GO

--Procedure traerListadoPublicacionesConFiltros
CREATE PROCEDURE ATJ.traerListadoPublicacionesConFiltros 
    @id_Rubro int, 
    @Descripcion nvarchar(255),
    @FechaDeHoy datetime

AS 
    SELECT *
    FROM ATJ.Publicaciones 
    WHERE	id_Estado = 1 
    AND		Fecha_vencimiento > @FechaDeHoy 
    AND		id_Rubro = @id_Rubro 
    AND		Descripcion = @Descripcion 
    AND ( id_Tipo = 1 AND Stock >= 1 OR id_tipo <> 1)	
    ORDER BY cod_Visibilidad 	
GO


--Procedure traerPreguntasNoRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasNoRespondidasPorUsuario
    @id_Usuario int

AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Pregunta_Publicacion PP ON PP.cod_Publicacion = P.Codigo 
    INNER JOIN ATJ.Preguntas R ON R.id_Pregunta = PP.id_Pregunta 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario		
GO

--Procedure updatePregunta
CREATE PROCEDURE ATJ.updatePregunta
    
	@id_Pregunta int,
	@Respuesta nvarchar(255)
AS
	UPDATE ATJ.Preguntas SET Respuesta = @Respuesta,
							Fecha_respuesta = GETDATE()
							where id_Pregunta = @id_Pregunta 
	
GO


--Procedure traerPreguntasRespondidasPorUsuario
CREATE PROCEDURE ATJ.traerPreguntasRespondidasPorUsuario
    @id_Usuario int

AS 
    SELECT *
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Pregunta_Publicacion PP ON PP.cod_Publicacion = P.Codigo 
    INNER JOIN ATJ.Preguntas R ON R.id_Pregunta = PP.id_Pregunta 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario		
GO


--Procedure traerListadoPublicacionesConCodigo
CREATE PROCEDURE ATJ.traerListadoPublicacionesConCodigo
    @id_Publicacion int

AS 
    SELECT *
    FROM ATJ.Publicaciones 
    WHERE	Codigo = @id_Publicacion 
GO

--Procedure traerVendedorPorId_Usuario 
CREATE PROCEDURE ATJ.traerVendedorPorId_Usuario 
    @id_Usuario int
AS 
  
DECLARE @id_Rol int
SET @id_Rol = (SELECT id_Rol FROM atj.Rol_Usuario Where id_Usuario = @id_Usuario)
IF @id_rol = 2 
SELECT	C.*
    FROM ATJ.Usuarios U
    INNER JOIN ATJ.Clientes C ON u.id_Usuario = c.id_Cliente 
    WHERE u.id_Usuario = @id_Usuario
ELSE
SELECT E.*
	FROM ATJ.Usuarios U
	INNER JOIN ATJ.Empresas E ON U.id_Usuario = E.id_Usuario
	WHERE U.id_Usuario = @id_Usuario

GO

--Procedure deshabilitarEmpresa
CREATE PROCEDURE ATJ.deshabilitarEmpresa
	@id_Empresa int
AS
	UPDATE ATJ.Empresas SET Activo = 0 where id_Empresa = @id_Empresa	
GO

--Procedure deshabilitarCliente
CREATE PROCEDURE ATJ.deshabilitarCliente
	@id_Cliente int
AS
	UPDATE ATJ.Clientes SET Activo = 0 where id_Cliente = @id_Cliente	
GO
--Procedure insertUsuario
CREATE PROCEDURE ATJ.insertUsuario
	@Username int,
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	INSERT INTO ATJ.Usuarios
	(Username, Clave, ClaveAutoGenerada, Activo)
	VALUES
	(@Username, @Clave, @ClaveAutoGenerada, @Activo)

GO