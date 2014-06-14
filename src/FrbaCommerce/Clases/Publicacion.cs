using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _codigo;
        private string _descripcion;
        private int _stock;
        private DateTime _fecha_creacion;
        private DateTime _fecha_vencimiento;
        private decimal _precio;
        private bool _permiso_Preguntas;
        private Usuario _usuario;
        private Tipo_Publicacion _tipo_publicacion;
        private Visibilidad _visibilidad;
        private Estado_Publicacion _estado_Publicacion;
        private Rubro _rubro;

        #endregion
        #region constructor
        public Publicacion(){
            this.Codigo = -1;
            this.Descripcion = "";
            this.Stock = -1;
            this.Fecha_vencimiento = DateTime.Now;
            this.Fecha_creacion = DateTime.Now;
            this.Precio = -1;
            this.Permiso_Preguntas = false;
        }

        public Publicacion(int unCodigo)
        {
            this.Codigo = unCodigo;
            DataSet ds = Publicacion.ObtenerPublicacionPorId(this.Codigo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }

        }
        
        #endregion



        #region properties
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        public DateTime Fecha_vencimiento
        {
            get { return _fecha_vencimiento; }
            set { _fecha_vencimiento = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public bool Permiso_Preguntas
        {
            get { return _permiso_Preguntas; }
            set { _permiso_Preguntas = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public Tipo_Publicacion Tipo_Publicacion
        {
            get { return _tipo_publicacion; }
            set { _tipo_publicacion = value; }
        }
        public Visibilidad Visibilidad
        {
            get { return _visibilidad; }
            set { _visibilidad = value; }
        }
        public Estado_Publicacion Estado_Publicacion
        {
            get { return _estado_Publicacion; }
            set { _estado_Publicacion = value; }
        }
        public Rubro Rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Publicaciones";
        }

        public override string NombreEntidad()
        {
            return "Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Codigo = Convert.ToInt32(dr["Codigo"]);
            this.Usuario = new Usuario(Convert.ToInt32(dr["id_Usuario"]));
            this.Descripcion = dr["Descripcion"].ToString();
            this.Stock = Convert.ToInt32(dr["Stock"]);
            this.Fecha_creacion = Convert.ToDateTime(dr["Fecha_creacion"]);
            this.Fecha_vencimiento = Convert.ToDateTime(dr["Fecha_vencimiento"]);
            this.Precio = Convert.ToDecimal(dr["Precio"]);
            this.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(dr["id_Tipo"]));
            this.Visibilidad = new Visibilidad(Convert.ToInt32(dr["cod_Visibilidad"]));
            this.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(dr["id_Estado"]));
            this.Rubro = new Rubro(Convert.ToInt32(dr["id_Rubro"]));
            this.Permiso_Preguntas = Convert.ToBoolean(dr["permiso_Preguntas"]);
        }

        public static DataSet obtenerTodas(Usuario unUsuario)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConIdUsuario(unUsuario.Id_Usuario);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorId_Usuario");
            unaPublic.parameterList.Clear();

            return ds;
        }

        public static DataSet ObtenerPublicacionPorId(int unCodigo)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConCodigoPublic(unCodigo);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorCod_Publicacion");
            unaPublic.parameterList.Clear();

            return ds;
        }

        public static DataSet obtenerTodasConFiltros(Usuario unUsuario, string unaDesc)
        {
            Publicacion unaPublic = new Publicacion();
            unaPublic.setearListaDeParametrosConIdUsuarioYFiltros(unUsuario.Id_Usuario, unaDesc);
            DataSet ds = unaPublic.TraerListado(unaPublic.parameterList, "PorId_UsuarioYFiltros");
            unaPublic.parameterList.Clear();

            return ds;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdUsuario(int unIdUsuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", unIdUsuario));
        }

        private void setearListaDeParametrosConCodigoPublic(int unCodigo)
        {
            parameterList.Add(new SqlParameter("@cod_Publicacion", unCodigo));
        }

        private void setearListaDeParametrosConIdUsuarioYFiltros(int unIdUsuario, string unaDesc)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", unIdUsuario));
            parameterList.Add(new SqlParameter("@Descripcion", unaDesc));
        }
        #endregion

        public static DataSet obtenerTodas()
        {
            throw new NotImplementedException();
        }
    }
}
