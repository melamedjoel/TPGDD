using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    class Compra : Base 
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Compra;
        private DateTime _Fecha;
        private int _Cantidad;

        private Publicacion _Publicacion;
        private Usuario _usuario_Vendedor;
        private Usuario _usuario_Comprador;

        #endregion

        #region properties
        public int id_Compra
        {
            get { return _id_Compra; }
            set { _id_Compra = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public Publicacion Publicacion
        {
            get { return _Publicacion; }
            set { _Publicacion = value; }
        }
        public Usuario usuario_Vendedor
        {
            get { return _usuario_Vendedor; }
            set { _usuario_Vendedor = value; }
        }
        public Usuario usuario_Comprador
        {
            get { return _usuario_Comprador; }
            set { _usuario_Comprador = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Compras";
        }

        public override string NombreEntidad()
        {
            return "Compra";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Compra = Convert.ToInt32(dr["id_Compra"]);
            this.Publicacion = new Publicacion();
            //this.Publicacion.Codigo = Convert.ToInt32(dr["cod_Publicacion"]);
            this.usuario_Vendedor = new Usuario();
            //this.usuario_Vendedor.Id_Usuario = Convert.ToInt32(dr["id_Usuario_Vendedor"]);
            this.usuario_Comprador = new Usuario();
            //this.usuario_Comprador.Id_Usuario = Convert.ToInt32(dr["id_Usuario_Comprador"]);
            this.Fecha = Convert.ToDateTime(dr["Fecha"]);
            this.Cantidad = Convert.ToInt32(dr["Cantidad"]);

        }


        #endregion

        #region metodos privados

        #endregion
    }
}
