using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excepciones;
using Conexion;


namespace Clases
{
    public class Rol : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Rol;
        private string _nombre;
        private bool _habilitado;
        List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        #endregion

        #region properties
        public int Id_Rol
        {
            get { return _id_Rol; }
            set { _id_Rol = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        public List<Funcionalidad> Funcionalidades
        {
            get { return funcionalidades; }
            set { funcionalidades = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Roles";
        }

        public override string NombreEntidad()
        {
            return "Rol";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Id_Rol = Convert.ToInt32(dr["id_Rol"]);
            this.Nombre = dr["Nombre"].ToString();
            this.Habilitado = Convert.ToBoolean(dr["Habilitado"]);
        }

        public static DataSet ObtenerRolesPorUsuario(int id_Usuario)
        {
            Rol unRol = new Rol();
            unRol.setearListaDeParametrosConIdUsuario(id_Usuario);
            DataSet ds = unRol.TraerListado(unRol.parameterList, "PorId_Usuario");
            unRol.parameterList.Clear();

            return ds;
        }


        public static DataSet obtenerTodosLosRoles()
        {
            Rol unRol = new Rol();
            return unRol.TraerListado(unRol.parameterList, "");
        }
        #endregion

        #region metodos privados
        public void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", id_Usuario));
        }

        #endregion
    }
}
