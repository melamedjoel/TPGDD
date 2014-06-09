using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using System.Configuration;
using Excepciones;

namespace Clases
{
    public class Usuario : Base
    {
        
        #region variables 
        List<SqlParameter> parameterList = new List<SqlParameter>();
        #endregion

        #region atributos

        private int _id_Usuario;
        private string _username;
        private string _clave;
        private bool _claveAutoGenerada;
        private bool _activo;
        private Rol _rol;
        
        #endregion

        #region properties

        public int Id_Usuario
        {
            get { return _id_Usuario; }
            set { _id_Usuario = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        

        public bool ClaveAutoGenerada
        {
            get { return _claveAutoGenerada; }
            set { _claveAutoGenerada = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
        #endregion 

        #region metodos publicos

        public override string NombreTabla()
        {
            return "Usuarios";
        }

        public override string NombreEntidad()
        {
            return "Usuario";
        }
        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.Id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            this.Username = dr["Username"].ToString();
            this.Clave =  dr["Clave"].ToString();
            this.ClaveAutoGenerada = Convert.ToBoolean(dr["ClaveAutoGenerada"]);
            this.Activo = Convert.ToBoolean(dr["Activo"]);
        }

        public bool IntentarLogIn()
        {
            setearListaDeParametrosConUsuarioYClave();
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioPorUsernameYClave", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
                if(this.Activo)
                    return true;   
            }
            
            return false;
        }

        public void AsignarRol(DataSet ds)
        {
            this.Rol = new Rol();
            this.Rol.DataRowToObject(ds.Tables[0].Rows[0]);
        }

        public void Deshabilitar()
        {
            setearListaDeParametrosConUsuario();
            DataSet ds = SQLHelper.ExecuteDataSet("traerUsuarioPorUsername", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new NoEntidadException();
            }

            this.Id_Usuario = Convert.ToInt32(ds.Tables[0].Rows[0]["id_Usuario"]);

            setearListaDeParametrosSoloConIdUsuario();
            base.Deshabilitar(parameterList);
            parameterList.Clear();
        }

        public bool CambiarClave(string claveNueva)
        {
            this.Clave = claveNueva;
            this.ClaveAutoGenerada = false;
            setearListaDeParametrosCompleta();
            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
                return true;
            }
            return false;
        }
        
        #endregion

        #region metodos privados
        private void setearListaDeParametrosSoloConIdUsuario()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.Id_Usuario));
        }

        private void setearListaDeParametrosCompleta()
        {
            parameterList.Add(new SqlParameter("@id_Usuario", this.Id_Usuario));
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Clave));
            parameterList.Add(new SqlParameter("@ClaveAutoGenerada", this.ClaveAutoGenerada));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));
        }

        private void setearListaDeParametrosConUsuarioYClave()
        {
            parameterList.Add(new SqlParameter("@Username", this.Username));
            parameterList.Add(new SqlParameter("@Clave", this.Clave));
        }

        private void setearListaDeParametrosConUsuario()
        {
            parameterList.Add(new SqlParameter("@Username", this.Username));
        }
        #endregion
    }
}
