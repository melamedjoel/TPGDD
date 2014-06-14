USE GD1C2014;
GO

--Procedure traerUsuarioPorUsernameYClave
CREATE PROCEDURE ATJ.traerUsuarioPorUsernameYClave 
    @Username nvarchar(255), 
    @Clave nvarchar(255) 
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username AND Clave = @Clave;
GO

--Procedure traerUsuarioPorUsuarname
CREATE PROCEDURE ATJ.traerUsuarioPorUsername
    @Username nvarchar(255)
AS 
    SELECT *
    FROM ATJ.Usuarios
    WHERE Username = @Username
GO

--Procedure traerListadoRolesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoRolesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT R.id_Rol AS id_Rol, R.Nombre AS Nombre, R.Habilitado as Habilitado from ATJ.Roles R 
	INNER JOIN ATJ.Rol_Usuario RU ON RU.id_Rol = R.id_Rol
	INNER JOIN ATJ.Usuarios U ON U.id_Usuario = RU.id_Usuario
	WHERE U.id_Usuario = @id_Usuario AND R.Habilitado = 1 AND R.Eliminado = 0
GO

--Procedure deshabilitarUsuario
CREATE PROCEDURE [ATJ].[deshabilitarUsuario]
	@id_Usuario numeric(18,0)
AS
	UPDATE ATJ.Usuarios SET Activo = 0 where id_Usuario=@id_Usuario	
GO


--Procedure updateUsuario
CREATE PROCEDURE [ATJ].[updateUsuario]
	@id_Usuario numeric(18,0),
	@Username nvarchar(255),
	@Clave nvarchar(255),
	@ClaveAutoGenerada bit,
	@Activo bit
AS
	UPDATE ATJ.Usuarios SET Username=@Username, Clave=@Clave, ClaveAutoGenerada = @ClaveAutoGenerada, Activo = @Activo where id_Usuario=@id_Usuario	
GO


--Procedure traerListadoRoles
CREATE PROCEDURE [ATJ].[traerListadoRoles] 
AS 
    SELECT * FROM ATJ.ROLES WHERE Eliminado = 0;
GO


--Procedure traerListadoFuncionalidadesPorId_Rol
CREATE PROCEDURE ATJ.traerListadoFuncionalidadesPorId_Rol
	@id_Rol numeric(18,0)
AS	
	SELECT F.* FROM ATJ.Rol_Funcionalidad RF 
	INNER JOIN ATJ.Funcionalidades F ON F.id_Funcionalidad = RF.id_Funcionalidad
	WHERE RF.id_Rol = @id_Rol
GO

--Procedure traerListadoFuncionalidades
CREATE PROCEDURE ATJ.traerListadoFuncionalidades
AS	
	SELECT * FROM ATJ.Funcionalidades
GO

--Procedure traerListadoRubros
CREATE PROCEDURE ATJ.traerListadoRubros
AS	
	SELECT * FROM ATJ.Rubros
GO


--Procedure insertRol_RetornarID
CREATE PROCEDURE ATJ.insertRol_RetornarID
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	INSERT INTO ATJ.Roles
	(Nombre, Habilitado)
	VALUES 
	(@Nombre, @Habilitado)
	
	SELECT @@IDENTITY AS id_Rol;
GO

--Procedure insertRol_Funcionalidad
CREATE PROCEDURE [ATJ].[insertRol_Funcionalidad]
	@id_Rol int,
	@id_Funcionalidad int
AS
	INSERT INTO ATJ.Rol_Funcionalidad
	(id_Rol, id_Funcionalidad)
	VALUES 
	(@id_Rol, @id_Funcionalidad)
GO
	
--Procedure deleteRol_FuncionalidadPorIdRol
CREATE PROCEDURE ATJ.deleteRol_Funcionalidad_PorIdRol
	@id_Rol int
AS
	DELETE FROM ATJ.Rol_Funcionalidad WHERE id_Rol = @id_Rol
GO

--Procedure updateRol
CREATE PROCEDURE ATJ.updateRol
	@id_Rol int,
	@Nombre nvarchar(255),
	@Habilitado bit
AS
	UPDATE ATJ.Roles SET Nombre=@Nombre, Habilitado=@Habilitado
	WHERE id_Rol = @id_Rol
GO

--Procedure deshabilitarRol
CREATE PROCEDURE ATJ.deshabilitarRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Habilitado=0
	WHERE id_Rol = @id_Rol
GO

--Procedure deleteRol
CREATE PROCEDURE ATJ.deleteRol
	@id_Rol int
AS
	UPDATE ATJ.Roles SET Eliminado=1
	WHERE id_Rol = @id_Rol
GO

--Procedure validarVisibilidadEnPublicacion
CREATE PROCEDURE ATJ.validarVisibilidadEnPublicacion
	@cod_Visibilidad int
AS
	SELECT * FROM ATJ.Publicaciones WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure validarRolEnUsuarios
CREATE PROCEDURE ATJ.validarRolEnUsuarios
	@id_Rol int
AS
	SELECT * FROM ATJ.Rol_Usuario WHERE id_Rol = @id_Rol
GO



--Procedure deleteVisibilidad
CREATE PROCEDURE ATJ.deleteVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Eliminado=1
	WHERE cod_Visibilidad = @cod_Visibilidad
GO



--Procedure traerListadoRolesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoRolesConFiltros] 
    @Nombre nvarchar(255),
	@Habilitado bit
AS 
	IF(@Nombre = '' Or @Nombre IS NULL)
		BEGIN
			SELECT * FROM ATJ.Roles where Habilitado = @Habilitado AND Eliminado = 0;
		END	
	ELSE
		SELECT * FROM ATJ.Roles 
			WHERE Nombre LIKE '%' + @Nombre + '%' AND Habilitado = @Habilitado AND Eliminado = 0;

GO


--Procedure deshabilitarVisibilidad
CREATE PROCEDURE ATJ.deshabilitarVisibilidad
	@cod_Visibilidad int
AS
	UPDATE ATJ.Visibilidades SET Activo=0
	WHERE cod_Visibilidad = @cod_Visibilidad
GO

--Procedure traerListadoVisibilidades
CREATE PROCEDURE [ATJ].[traerListadoVisibilidades] 
AS 
    SELECT * FROM ATJ.Visibilidades WHERE Eliminado = 0;
GO

--Procedure traerListadoVisibilidadesConFiltros
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesConFiltros] 
    @Descripcion nvarchar(255) = null,
	@Precio nvarchar(20)= null,
	@Porcentaje nvarchar(20) =null,
	@Activo bit
AS 

	--El activo no lo valido porque siempre va a venir 1 o 0, asi que lo filtro por eso tambien. 
	--No existe que el valor de activo no se filtre
	IF((@Precio = '' Or @Precio IS NULL) AND (@Porcentaje = '' Or @Porcentaje IS NULL) AND (@Descripcion <> '' Or @Descripcion IS NOT NULL))
		BEGIN
			--Significa que estoy filtrando por descripcion y activo
			SELECT * FROM ATJ.Visibilidades WHERE Descripcion LIKE '%' + @Descripcion + '%' AND Activo = @Activo AND Eliminado = 0
		END 
	IF((@Porcentaje = '' Or @Porcentaje IS NULL) AND (@Precio <> '' Or @Precio IS NOT NULL) AND (@Descripcion <> '' Or @Descripcion IS NOT NULL))
		BEGIN
		--Significa que estoy filtrando por descripcion, precio y activo
			SELECT * FROM ATJ.Visibilidades WHERE Descripcion LIKE '%' + @Descripcion + '%' AND Activo = @Activo AND Precio = CAST(@Precio AS NUMERIC(18,2)) AND Eliminado = 0
		END
	IF((@Precio = '' Or @Precio IS NULL) AND (@Porcentaje <> '' Or @Porcentaje IS NOT NULL) AND (@Descripcion <> '' Or @Descripcion IS NOT NULL))
		BEGIN
		--Significa que estoy filtrando por descripcion, porcentaje y activo
			SELECT * FROM ATJ.Visibilidades WHERE Descripcion LIKE '%' + @Descripcion + '%' AND Activo = @Activo AND Porcentaje = CAST(@Porcentaje AS NUMERIC(18,2)) AND Eliminado = 0
		END
	IF((@Descripcion = '' Or @Descripcion IS NULL) AND (@Precio <> '' Or @Precio IS NOT NULL) AND (@Porcentaje <> '' Or @Porcentaje IS NOT NULL))
		BEGIN
		--Significa que estoy filtrando por porcentaje, precio y activo
		SELECT * FROM ATJ.Visibilidades WHERE Porcentaje = CAST(@Porcentaje AS NUMERIC(18,2)) AND Activo = @Activo AND Precio = CAST(@Precio AS NUMERIC(18,2)) AND Eliminado = 0
		END
	IF((@Descripcion = '' Or @Descripcion IS NULL) AND (@Precio = '' Or @Precio IS NULL) AND (@Porcentaje <> '' Or @Porcentaje IS NOT NULL))
		BEGIN
		--Significa que estoy filtrando por porcentaje y activo
		SELECT * FROM ATJ.Visibilidades WHERE Porcentaje = CAST(@Porcentaje AS NUMERIC(18,2)) AND Activo = @Activo AND Eliminado = 0
		END
	IF((@Descripcion = '' Or @Descripcion IS NULL) AND (@Porcentaje = '' Or @Porcentaje IS NULL) AND (@Precio <> '' Or @Precio IS NOT NULL))
		BEGIN
		--Significa que estoy filtrando por precio y activo
		SELECT * FROM ATJ.Visibilidades WHERE Precio = CAST(@Precio AS NUMERIC(18,2)) AND Activo = @Activo AND Eliminado = 0
		END
	IF((@Descripcion <> '' Or @Descripcion IS NOT NULL) AND (@Porcentaje <> '' Or @Porcentaje IS NOT NULL) AND (@Precio <> '' Or @Precio IS NOT NULL))
		BEGIN
		--Si no se cumplio ningun if, es porque el filtro es por todos los datos. Filtro por descripcion, precio, porcentaje y activo
		SELECT * FROM ATJ.Visibilidades WHERE Porcentaje = CAST(@Porcentaje AS NUMERIC(18,2)) AND Activo = @Activo AND Precio = CAST(@Precio AS NUMERIC(18,2)) AND Descripcion LIKE '%' + @Descripcion + '%' AND Eliminado = 0
		END
	IF((@Descripcion = '' Or @Descripcion IS NULL) AND (@Porcentaje = '' Or @Porcentaje IS NULL) AND (@Precio = '' Or @Precio IS NULL))
		BEGIN
		--Sino, solo filtro por activo
		SELECT * FROM ATJ.Visibilidades WHERE Activo = @Activo AND Eliminado = 0
		END
	
GO


--Procedure updateVisibilidad
CREATE PROCEDURE ATJ.updateVisibilidad
	@cod_Visibilidad int,
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Activo bit
AS
	UPDATE ATJ.Visibilidades SET Descripcion = @Descripcion, Precio = @Precio, Porcentaje = @Porcentaje, Activo = @Activo
	WHERE cod_Visibilidad = @cod_Visibilidad
GO


--Procedure insertVisibilidad_RetornarID
CREATE PROCEDURE ATJ.insertVisibilidad_RetornarID
	@Descripcion nvarchar(255),
	@Precio numeric(18,2),
	@Porcentaje numeric(18,2),
	@Activo bit
AS
	INSERT INTO ATJ.Visibilidades
	(Descripcion, Precio, Porcentaje, Activo)
	VALUES 
	(@Descripcion, @Precio, @Porcentaje, @Activo)
	
	SELECT @@IDENTITY AS cod_Visibilidad;
GO

--Procedure insertOferta_RetornarID
CREATE PROCEDURE ATJ.insertOferta_RetornarID
	@cod_Publicacion numeric (18,0),
	@id_Usuario_Vendedor int,
	@id_Usuario_Comprador int,
	@Fecha datetime,
	@Monto numeric(18,2)
AS
	INSERT INTO ATJ.Ofertas
	(cod_Publicacion, id_Usuario_Vendedor, id_Usuario_Comprador, Fecha, Monto)
	VALUES 
	(@cod_Publicacion, @id_Usuario_Vendedor, @id_Usuario_Comprador, @Fecha, @Monto)
	
	SELECT @@IDENTITY AS id_Oferta;
GO

--Procedure insertPregunta_RetornarID
CREATE PROCEDURE ATJ.insertPregunta_RetornarID
	@txtPregunta nvarchar(255),
	@cod_Publicacion numeric(18,0)
AS
	INSERT INTO ATJ.Preguntas
	(Pregunta)
	VALUES 
	(@txtPregunta)
	
	DECLARE @idNuevo int;
	SELECT @idNuevo = @@IDENTITY;
	
	INSERT INTO ATJ.Pregunta_Publicacion
	(id_Pregunta, cod_Publicacion) VALUES
	(@idNuevo, @cod_Publicacion)
	
	select @idNuevo as id_Pregunta;
GO


--traerListadoFuncionalidadesPorNombre
CREATE PROCEDURE ATJ.traerListadoVisibilidadesPorDescripcion
	@Descripcion nvarchar(255)
AS
	SELECT * FROM ATJ.Visibilidades where Descripcion = @Descripcion AND Eliminado = 0
GO

--traerListadoRolesPorNombre
CREATE PROCEDURE ATJ.traerListadoRolesPorNombre
	@Nombre nvarchar(255)
AS
	SELECT * FROM ATJ.Roles where Nombre LIKE '%' + @Nombre + '%' AND Eliminado = 0
GO


--Procedure traerListadoRubrosPorId_Rubro
CREATE PROCEDURE [ATJ].[traerListadoRubrosPorId_Rubro] 
    @id_Rubro numeric(18,0) 
AS 
    SELECT * FROM ATJ.Rubros
	WHERE id_Rubro = @id_Rubro
GO

--Procedure traerListadoVisibilidadesPorCod_Visibilidad
CREATE PROCEDURE [ATJ].[traerListadoVisibilidadesPorCod_Visibilidad] 
    @cod_Visibilidad numeric(18,0) 
AS 
    SELECT * FROM ATJ.Visibilidades
	WHERE cod_Visibilidad = @cod_Visibilidad AND Eliminado = 0
GO

--Procedure traerListadoEstados_PublicacionPorId_Estado
CREATE PROCEDURE [ATJ].[traerListadoEstados_PublicacionPorId_Estado] 
    @id_Estado numeric(18,0) 
AS 
    SELECT * FROM ATJ.Estados_Publicacion
	WHERE id_Estado = @id_Estado
GO

--Procedure traerListadoTipos_PublicacionPorId_Tipo
CREATE PROCEDURE [ATJ].[traerListadoTipos_PublicacionPorId_Tipo] 
    @id_Tipo numeric(18,0) 
AS 
    SELECT * FROM ATJ.Tipos_Publicacion
	WHERE id_Tipo = @id_Tipo
GO

--Procedure traerListadoUsuariosPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoUsuariosPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT * FROM ATJ.Usuarios
	WHERE id_Usuario = @id_Usuario
GO

--Procedure traerListadoPublicacionesPorCod_Publicacion
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorCod_Publicacion] 
    @cod_Publicacion numeric(18,0) 
AS 
    SELECT * FROM ATJ.Publicaciones
	WHERE Codigo = @cod_Publicacion
GO

--Procedure traerListadoPublicacionesPorId_Usuario
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_Usuario] 
    @id_Usuario numeric(18,0) 
AS 
    SELECT P.Codigo as Codigo, P.Descripcion as Descripcion, U.Username as Username, P.Stock as Stock, P.Precio Precio,
    P.Fecha_creacion Fecha_creacion, P.Fecha_Vencimiento Fecha_vencimiento, 
    TP.Nombre NombreTipo, V.Descripcion DescVisibilidad, E.Nombre NombreEstado,
    R.Descripcion NombreRubro, P.permiso_Preguntas permiso_Preguntas
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Usuarios U ON U.id_Usuario = P.id_Usuario
    INNER JOIN ATJ.Tipos_Publicacion TP on TP.id_Tipo = P.id_Tipo
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
    INNER JOIN ATJ.Rubros R on R.id_Rubro = P.id_Rubro
	WHERE P.id_Usuario = @id_Usuario
GO


--Procedure traerListadoPublicaciones
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesNoVendidasOrdenadoPorVisibilidad] 
	@Fecha_Vencimiento datetime
AS 
    SELECT P.Codigo as Codigo, P.Descripcion as Descripcion, U.Username as Username, P.Stock as Stock, P.Precio Precio,
    P.Fecha_creacion Fecha_creacion, P.Fecha_Vencimiento Fecha_vencimiento, 
    TP.Nombre NombreTipo, V.Descripcion DescVisibilidad, E.Nombre NombreEstado,
    R.Descripcion NombreRubro, P.permiso_Preguntas permiso_Preguntas
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Usuarios U ON U.id_Usuario = P.id_Usuario
    INNER JOIN ATJ.Tipos_Publicacion TP on TP.id_Tipo = P.id_Tipo
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
    INNER JOIN ATJ.Rubros R on R.id_Rubro = P.id_Rubro
	WHERE P.Fecha_Vencimiento > @Fecha_Vencimiento AND P.Stock > 0 AND E.Nombre IN ('Publicada', 'Pausada')
	ORDER BY V.Precio DESC
GO

--Procedure traerListadoPublicacionesPorId_UsuarioYFiltros
CREATE PROCEDURE [ATJ].[traerListadoPublicacionesPorId_UsuarioYFiltros] 
    @id_Usuario numeric(18,0),
	@Descripcion nvarchar(255)
AS 
    SELECT P.Codigo as Codigo, P.Descripcion as Descripcion, U.Username as Username, P.Stock as Stock, P.Precio Precio,
    P.Fecha_creacion Fecha_creacion, P.Fecha_Vencimiento Fecha_vencimiento, 
    TP.Nombre NombreTipo, V.Descripcion DescVisibilidad, E.Nombre NombreEstado,
    R.Descripcion NombreRubro, P.permiso_Preguntas permiso_Preguntas
    FROM ATJ.Publicaciones P
    INNER JOIN ATJ.Usuarios U ON U.id_Usuario = P.id_Usuario
    INNER JOIN ATJ.Tipos_Publicacion TP on TP.id_Tipo = P.id_Tipo
    INNER JOIN ATJ.Visibilidades V on V.cod_Visibilidad = P.cod_Visibilidad
    INNER JOIN ATJ.Estados_Publicacion E on E.id_Estado = P.id_Estado
    INNER JOIN ATJ.Rubros R on R.id_Rubro = P.id_Rubro
	WHERE P.id_Usuario = @id_Usuario AND P.Descripcion LIKE '%' + @Descripcion + '%'
GO