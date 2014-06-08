using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Clases
{
    class Cliente : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();
    
        #region atributos
        private int _id_Cliente;
        private string _Tipo_Dni;
        private int _Dni;
        private string _Cuil;
        private string _Apellido;
        private string _Nombre;
        private DateTime _Fecha_nac;
        private string _Mail;
        private string _Telefono;
        private string _Dom_calle;
        private int _Dom_nro_calle;
        private int _Dom_piso;
        private string _Dom_depto;
        private string _Dom_cod_postal;
        private bool _Activo;
        private decimal _Reputacion;

        private Usuario _usuario;
        #endregion

        #region properties
        public int id_Cliente
        {
            get { return _id_Cliente; }
            set { _id_Cliente = value; }
        }
        public string Tipo_Dni
        {
            get { return _Tipo_Dni; }
            set { _Tipo_Dni = value; }
        }
        public int Dni
        {
            get { return _Dni; }
            set { _Dni = value; }
        }
        public string Cuil
        {
            get { return _Cuil; }
            set { _Cuil = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public DateTime Fecha_nac
        {
            get { return _Fecha_nac; }
            set { _Fecha_nac = value; }
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
            return "Clientes";
        }

        public override string NombreEntidad()
        {
            return "Cliente";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Cliente = Convert.ToInt32(dr["id_Cliente"]);
            this.Tipo_Dni = dr["Tipo_Dni"].ToString();
            this.Dni = Convert.ToInt32(dr["Dni"]);
            this.Cuil = dr["Cuil"].ToString();
            this.Apellido = dr["Apellido"].ToString();
            this.Nombre = dr["Nombre"].ToString();
            this.Fecha_nac = Convert.ToDateTime(dr["Fecha_nac"]);
            this.Mail = dr["Mail"].ToString();
            this.Telefono = dr["Telefono"].ToString();
            this.Dom_calle = dr["Dom_calle"].ToString();
            this.Dom_nro_calle = Convert.ToInt32(dr["Dom_nro_calle"]);
            this.Dom_piso = Convert.ToInt32(dr["Dom_piso"]);
            this.Dom_depto = dr["Dom_depto"].ToString();
            this.Dom_cod_postal = dr["Dom_cod_postal"].ToString();
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
