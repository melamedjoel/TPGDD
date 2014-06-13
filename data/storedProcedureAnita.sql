-- Procedure traerListadoUsuariosCompras
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCompras] 
    @id_Usuario numeric(18,0)
AS
SELECT C.id_Compra AS id_Compra,C.cod_Publicacion AS cod_Publicacion,
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END), 
C.Fecha AS Fecha, C.Cantidad AS Cantidad
FROM ATJ.Compras C
LEFT JOIN ATJ.Empresas E ON C.id_Usuario_Vendedor = E.id_Usuario
LEFT JOIN ATJ.Clientes S ON C.id_Usuario_Vendedor = S.id_Usuario
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Prodedure traerListadoUsuariosOfertas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosOfertas]
	@id_Usuario numeric(18,0)
AS
SELECT O.id_Oferta AS id_Oferta, O.cod_Publicacion AS cod_Publicacion, 
Vendedor = (CASE WHEN E.id_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_social END),
O.gano_Subasta AS gano_Subasta, O.Fecha AS Fecha, O.Monto AS Monto
FROM ATJ.Ofertas O 
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = O.id_Usuario_Vendedor
LEFT JOIN ATJ.Clientes C ON C.id_Usuario = O.id_Usuario_Vendedor
WHERE id_Usuario_Comprador = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesRecibidas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesRecibidas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificador = (S.Nombre+' '+S.Apellido),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
INNER JOIN ATJ.Clientes S ON S.id_Usuario = C.id_Usuario_Calificador
WHERE id_Usuario_Calificado = @id_Usuario
GO

--Procedure traerListadoUsuariosCalificacionesOtorgadas
CREATE PROCEDURE [ATJ].[traerListadoUsuariosCalificacionesOtorgadas]
	@id_Usuario numeric(18,0)
AS
SELECT C.cod_Calificacion AS cod_Calificacion, 
Calificado = (CASE WHEN E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
C.Cant_Estrellas AS cant_Estrellas, C.Descripcion AS Descripcion
FROM ATJ.Calificaciones C
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = C.id_Usuario_Calificado
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = C.id_Usuario_Calificado
WHERE id_Usuario_Calificador = @id_Usuario
GO