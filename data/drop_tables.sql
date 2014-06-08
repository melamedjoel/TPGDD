-------drop procedures first thing to do

DROP PROCEDURE [ATJ].[traerListadoRoles] 
DROP PROCEDURE ATJ.traerUsuarioPorUsernameYClave;
DROP PROCEDURE ATJ.traerUsuarioPorUsername;
DROP PROCEDURE [ATJ].[traerListadoRolesPorId_Usuario];
DROP PROCEDURE [ATJ].[deshabilitarUsuario];
DROP PROCEDURE [ATJ].[updateUsuario];

DROP PROCEDURE ATJ.updateCliente;
DROP PROCEDURE ATJ.traerClientePorFiltro;
DROP PROCEDURE ATJ.traerEmpresaPorFiltro;
DROP PROCEDURE ATJ.updateEmpresa;
DROP PROCEDURE ATJ.updateVisibilidad;
DROP PROCEDURE ATJ.traerPublicacionesPorFiltro;
DROP PROCEDURE ATJ.traerPreguntasNoRespondidasPorUsuario;
DROP PROCEDURE ATJ.updatePregunta;
DROP PROCEDURE ATJ.traerPreguntasRespondidasPorUsuario;
DROP PROCEDURE ATJ.traerPublicacionPorCodigo;
DROP PROCEDURE ATJ.traerVendedorPorId_Usuario;



------ drop tables last thing to do


drop table ATJ.Calificaciones
drop table ATJ.Clientes
drop table ATJ.Compras 
drop table ATJ.Empresas  
drop table ATJ.Item_Factura 
drop table ATJ.Ofertas 
drop table ATJ.Pregunta_Publicacion 
drop table ATJ.Preguntas 
drop table ATJ.Publicaciones 
drop table ATJ.Rol_Funcionalidad 
drop table ATJ.Rol_Usuario 
drop table ATJ.Roles 
drop table ATJ.Rubros 
drop table ATJ.Tipos_Publicacion 
drop table ATJ.Usuarios 
drop table ATJ.Visibilidades 
drop table ATJ.Estados_Publicacion 
drop table ATJ.Facturas 
drop table ATJ.Formas_Pago 
drop table ATJ.Funcionalidades
drop schema ATJ