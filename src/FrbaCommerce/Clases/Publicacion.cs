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
        private int _Codigo;
        private string _Descripcion;
        private int _Stock;
        private DateTime _Fecha_creacion;
        private DateTime _Fecha_vencimiento;
        private decimal _Precio;
        private bool _permiso_Preguntas;

        private Usuario _usuario;
        private Tipo_Publicacion _tipo_publicacion;
        private Visibilidad _visibilidad;
        private Estado_Publicacion _estado_Publicacion;
        private Rubro _Rubro;

        #endregion

        #region properties
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _Fecha_creacion; }
            set { _Fecha_creacion = value; }
        }
        public DateTime Fecha_vencimiento
        {
            get { return _Fecha_vencimiento; }
            set { _Fecha_vencimiento = value; }
        }
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public bool permiso_Preguntas
        {
            get { return _permiso_Preguntas; }
            set { _permiso_Preguntas = value; }
        }
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public Tipo_Publicacion tipo_publicacion
        {
            get { return _tipo_publicacion; }
            set { _tipo_publicacion = value; }
        }
        public Visibilidad visibilidad
        {
            get { return _visibilidad; }
            set { _visibilidad = value; }
        }
        public Estado_Publicacion estado_Publicacion
        {
            get { return _estado_Publicacion; }
            set { _estado_Publicacion = value; }
        }
        public Rubro Rubro
        {
            get { return _Rubro; }
            set { _Rubro = value; }
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
            this.usuario = new Usuario();
            //this.usuario.Id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            this.Descripcion = dr["Descripcion"].ToString();
            this.Stock = Convert.ToInt32(dr["Stock"]);
            this.Fecha_creacion = Convert.ToDateTime(dr["Fecha_creacion"]);
            this.Fecha_vencimiento = Convert.ToDateTime(dr["Fecha_vencimiento"]);
            this.Precio = Convert.ToDecimal(dr["Precio"]);
            this.tipo_publicacion = new Tipo_Publicacion();
            //this.tipo_publicacion.id_Tipo = Convert.ToInt32(dr["id_Tipo"]);
            this.visibilidad = new Visibilidad();
            //this.visibilidad.cod_Visibilidad = Convert.ToInt32(dr["cod_Visibilidad"]);
            this.estado_Publicacion = new Estado_Publicacion();
            //this.estado_Publicacion.id_Estado = Convert.ToInt32(dr["id_Estado"]);
            this.Rubro = new Rubro();
            //this.Rubro.id_Rubro = Convert.ToInt32(dr["id_Rubro"]);
            this.permiso_Preguntas = Convert.ToBoolean(dr["permiso_Preguntas"]);
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
