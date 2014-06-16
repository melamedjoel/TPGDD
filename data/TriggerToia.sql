CREATE TRIGGER UpdateReputacion
   ON  ATJ.Calificaciones
   FOR INSERT
AS 

BEGIN
	DECLARE @id_usuario int;
	SET @id_usuario = (SELECT id_Usuario FROM inserted i INNER JOIN atj.Publicaciones P ON P.Codigo = I.cod_Publicacion)
	----DECLARE @CantEstrellas numeric(18,0);
	----SET @CantEstrellas = (SELECT Cant_Estrellas FROM inserted)
	--- NOTA: SI YA LO INSERTE, ENTONCES NO LO NECESITO.
	DECLARE @cantidadDeEstrellasObtenidas int;	
	SET @cantidadDeEstrellasObtenidas = (SELECT SUM(C.Cant_Estrellas) 
										FROM ATJ.Usuarios U
										INNER JOIN ATJ.Publicaciones P ON U.id_Usuario = P.id_Usuario 
										INNER JOIN ATJ.Calificaciones C ON P.Codigo = C.cod_Publicacion
										WHERE U.id_Usuario = @id_usuario)
	DECLARE @CantidadDeCalificaciones int;
	SET @CantidadDeCalificaciones = (SELECT COUNT(*)
									FROM ATJ.Calificaciones C
									INNER JOIN ATJ.Publicaciones P ON C.cod_Publicacion = p.Codigo
									WHERE p.id_Usuario = 12 )										 
	IF EXISTS (SELECT id_usuario FROM ATJ.Clientes WHERE id_Usuario = @id_usuario)
    UPDATE ATJ.Clientes	SET Reputacion = CAST((@cantidadDeEstrellasObtenidas)/(@CantidadDeCalificaciones) AS NUMERIC(18,2))
						WHERE id_Usuario = @id_usuario
	ELSE
	UPDATE ATJ.Empresas SET Reputacion = CAST((@cantidadDeEstrellasObtenidas)/(@CantidadDeCalificaciones) AS NUMERIC(18,2))
						WHERE id_Usuario = @id_usuario

END
GO
