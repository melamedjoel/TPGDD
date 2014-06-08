using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Oferta : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Oferta;
        private bool _gano_Subasta;
        private DateTime _Fecha;
        private decimal _Monto;

        private Publicacion _Publicacion;
        private Usuario _usuario_Vendedor;
        private Usuario _usuario_Comprador;

        #endregion

        #region properties
        public int id_Oferta
        {
            get { return _id_Oferta; }
            set { _id_Oferta = value; }
        }
        public bool gano_Subasta
        {
            get { return _gano_Subasta; }
            set { _gano_Subasta = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
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
            return "Ofertas";
        }

        public override string NombreEntidad()
        {
            return "Oferta";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Oferta = Convert.ToInt32(dr["id_Oferta"]);
            this.Publicacion = new Publicacion();
            //this.Publicacion.Codigo = Convert.ToInt32(dr["cod_Publicacion"]);
            this.usuario_Vendedor = new Usuario();
            //this.usuario_Vendedor.Id_Usuario = Convert.ToInt32(dr["id_Usuario_Vendedor"]);
            this.usuario_Comprador = new Usuario();
            //this.usuario_Comprador.Id_Usuario = Convert.ToInt32(dr["id_Usuario_Comprador"]);
            this.gano_Subasta = Convert.ToBoolean(dr["gano_Subasta"]);
            this.Fecha = Convert.ToDateTime(dr["Fecha"]);
            this.Monto = Convert.ToDecimal(dr["Monto"]);
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
