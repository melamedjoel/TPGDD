using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    class Empresa:Base 
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Empresa;
        private string _Cuit;
        private string _Razon_social;
        private DateTime _Fecha_creacion;
        private string _Mail;
        private string _Telefono;
        private string _Dom_calle;
        private int _Dom_nro_calle;
        private int _Dom_piso;
        private string _Dom_depto;
        private string _Dom_cod_postal;
        private string _Dom_ciudad;
        private string _Nombre_contacto;
        private bool _Activo;
        private decimal _Reputacion;

        private Usuario _usuario;
        #endregion

        #region properties
        public int id_Empresa
        {
            get { return _id_Empresa; }
            set { _id_Empresa = value; }
        }
        public string Cuit
        {
            get { return _Cuit; }
            set { _Cuit = value; }
        }
        public string Razon_social
        {
            get { return _Razon_social; }
            set { _Razon_social = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _Fecha_creacion; }
            set { _Fecha_creacion = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Dom_calle
        {
            get { return _Dom_calle; }
            set { _Dom_calle = value; }
        }
        public int Dom_nro_calle
        {
            get { return _Dom_nro_calle; }
            set { _Dom_nro_calle = value; }
        }
        public int Dom_piso
        {
            get { return _Dom_piso; }
            set { _Dom_piso = value; }
        }
        public string Dom_depto
        {
            get { return _Dom_depto; }
            set { _Dom_depto = value; }
        }
        public string Dom_cod_postal
        {
            get { return _Dom_cod_postal; }
            set { _Dom_cod_postal = value; }
        }
        public string Dom_ciudad
        {
            get { return _Dom_ciudad; }
            set { _Dom_ciudad = value; }
        }
        public string Nombre_contacto
        {
            get { return _Nombre_contacto; }
            set { _Nombre_contacto = value; }
        }
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
        public decimal Reputacion
        {
            get { return _Reputacion; }
            set { _Reputacion = value; }
        }
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Empresas";
        }

        public override string NombreEntidad()
        {
            return "Empresa";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Empresa = Convert.ToInt32(dr["id_Empresa"]);
            this.Cuit = dr["Cuit"].ToString();
            this.Razon_social = dr["Razon_social"].ToString();
            this.Mail = dr["Mail"].ToString();
            this.Fecha_creacion = Convert.ToDateTime(dr["Fecha_creacion"]);
            this.Telefono = dr["Telefono"].ToString();
            this.Dom_calle = dr["Dom_calle"].ToString();
            this.Dom_nro_calle = Convert.ToInt32(dr["Dom_nro_calle"]);
            this.Dom_piso = Convert.ToInt32(dr["Dom_piso"]);
            this.Dom_depto = dr["Dom_depto"].ToString();
            this.Dom_cod_postal = dr["Dom_cod_postal"].ToString();
            this.Dom_ciudad = dr["Dom_ciudad"].ToString();
            this.Nombre_contacto = dr["Nombre_contacto"].ToString();
            this.Activo = Convert.ToBoolean(dr["Activo"]);
            this.usuario = new Usuario();
            //this.usuario.Id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            this.Reputacion = Convert.ToDecimal(dr["Reputacion"]);

        }


        #endregion

        #region metodos privados

        #endregion
    }
}
