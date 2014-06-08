using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Estado_Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Estado;
        private string _Nombre;
       
        #endregion

        #region properties
        public int id_Estado
        {
            get { return _id_Estado; }
            set { _id_Estado = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Estados_Publicacion";
        }

        public override string NombreEntidad()
        {
            return "Estado_Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Estado = Convert.ToInt32(dr["id_Estado"]);
            this.Nombre = dr["Nombre"].ToString();
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
