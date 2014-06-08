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
	WHERE U.id_Usuario = @id_Usuario AND R.Habilitado = 1
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
    SELECT * FROM ATJ.ROLES
GO


--Procedure traerListadoFuncionalidadesPorId_Rol
CREATE PROCEDURE ATJ.traerListadoFuncionalidadesPorId_Rol
	@id_Rol numeric(18,0)
AS	
	SELECT F.* FROM ATJ.Rol_Funcionalidad RF 
	INNER JOIN ATJ.Funcionalidades F ON F.id_Funcionalidad = RF.id_Funcionalidad
	WHERE RF.id_Rol = id_Rol
GO