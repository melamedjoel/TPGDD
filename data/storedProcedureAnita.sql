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

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVender
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVender]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END), 
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C)
AND P.Codigo NOT IN (SELECT O.cod_Publicacion FROM ATJ.Ofertas O WHERE O.gano_Subasta = 1))
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoUsuariosConMayorFacturacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorFacturacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
SUM(P.Precio) AS Facturacion
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND P.id_Usuario IN (SELECT F.id_Usuario FROM ATJ.Facturas F)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY Facturacion DESC
GO

-- Procedure traerListadoUsuariosConMayorCalificacion
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCalificacion]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
CAST(AVG(C.Cant_Estrellas) AS numeric(18,2)) AS PromedioCalificaciones
FROM ATJ.Calificaciones C
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = C.id_Usuario_Calificado
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = C.id_Usuario_Calificado
INNER JOIN ATJ.Publicaciones P ON P.Codigo = C.cod_Publicacion
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
GROUP BY C.id_Usuario_Calificado, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY PromedioCalificaciones DESC
GO

-- Procedure traerListadoUsuariosConMayorCantDePublicacionesSinClasificar
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantDePublicacionesSinClasificar]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4)

AS

SELECT TOP 5 Cliente = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END),
COUNT(P.Codigo) AS CantPubliSinClasificar
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
INNER JOIN ATJ.Calificaciones C ON P.id_Usuario = C.id_Usuario_Calificado 
WHERE 
MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND (P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Calificaciones C))
AND P.id_Usuario = C.id_Usuario_Calificado
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY CantPubliSinClasificar DESC
GO

--Procedure traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros
CREATE PROCEDURE [ATJ].[traerListadoUsuariosConMayorCantidadDeProductosSinVenderConFiltros]
	@Fecha_Hasta datetime,
	@Fecha_Desde datetime,
	@Año nvarchar(4),
	@Mes nvarchar(2),
	@GradoVisibilidad nvarchar
	
AS

SELECT TOP 5 Vendedor = (CASE WHEN  E.id_Usuario IS NULL THEN S.Nombre+' '+S.Apellido ELSE E.Razon_social END), 
COUNT(P.Codigo) AS CantPublicNoVendidos
FROM ATJ.Publicaciones P
LEFT JOIN ATJ.Empresas E ON E.id_Usuario = P.id_Usuario
LEFT JOIN ATJ.Clientes S ON S.id_Usuario = P.id_Usuario
INNER JOIN ATJ.Visibilidades V ON P.cod_Visibilidad = V.cod_Visibilidad
WHERE MONTH(P.Fecha_creacion) BETWEEN MONTH(@Fecha_Desde) AND MONTH(@Fecha_Hasta)
AND YEAR(P.Fecha_creacion) = @Año
AND(P.Codigo NOT IN (SELECT C.cod_Publicacion FROM ATJ.Compras C)
AND P.Codigo NOT IN (SELECT O.cod_Publicacion FROM ATJ.Ofertas O WHERE O.gano_Subasta = 1))
AND V.Descripcion = (CASE WHEN @GradoVisibilidad <> '' THEN @GradoVisibilidad ELSE V.Descripcion END) 
AND MONTH(P.Fecha_creacion) = (CASE WHEN 2 <> '' THEN 2 ELSE MONTH(P.Fecha_creacion) END)
GROUP BY P.id_Usuario, E.id_Usuario, S.Nombre, S.Apellido, E.Razon_social
ORDER BY CantPublicNoVendidos DESC
GO

--Procedure traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasConRespuestasPorUsuarioYPublicacion
    @id_Usuario int,
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, R.Fecha_respuesta AS Fecha_respuesta, 
    P.Codigo AS Codigo, P.Descripcion AS Descripcion, P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Pregunta_Publicacion PP ON PP.cod_Publicacion = P.Codigo 
    INNER JOIN ATJ.Preguntas R ON R.id_Pregunta = PP.id_Pregunta 
    WHERE	R.Respuesta IS NOT NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
CREATE PROCEDURE ATJ.traerListadoPreguntasSinRespuestasPorUsuarioYPublicacion
    @id_Usuario numeric(18,0),
    @cod_Publicacion numeric(18,0)

AS 
    SELECT R.id_Pregunta AS id_Pregunta, R.Pregunta AS Pregunta, R.Respuesta AS Respuesta, 
    R.Fecha_respuesta AS Fecha_respuesta, P.Codigo AS Codigo, P.Descripcion AS Descripcion, 
    P.Stock AS Stock,P.Fecha_creacion AS Fecha_creacion, P.Fecha_vencimiento AS Fecha_Vencimiento, 
    P.Precio AS Precio
    FROM ATJ.Usuarios U 
    INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
    INNER JOIN ATJ.Pregunta_Publicacion PP ON PP.cod_Publicacion = P.Codigo 
    INNER JOIN ATJ.Preguntas R ON R.id_Pregunta = PP.id_Pregunta 
    WHERE	R.Respuesta IS NULL
	AND		U.id_Usuario = @id_Usuario
	AND		P.Codigo = @cod_Publicacion
GO

--Procedure updatePreguntaConRespuesta
CREATE PROCEDURE ATJ.updatePreguntaConRespuesta
	@id_Pregunta int,
	@Respuesta nvarchar(255)
	
AS

	UPDATE ATJ.Preguntas SET	Respuesta = @Respuesta,
								Fecha_respuesta = GETDATE()
	WHERE id_Pregunta = @id_Pregunta 
	
GO