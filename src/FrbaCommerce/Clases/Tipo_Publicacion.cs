using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    class Tipo_Publicacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Tipo;
        private string _Nombre;

        #endregion

        #region properties
        public int id_Tipo
        {
            get { return _id_Tipo; }
            set { _id_Tipo = value; }
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
            return "Tipos_Publicacion";
        }

        public override string NombreEntidad()
        {
            return "Tipo_Publicacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Tipo = Convert.ToInt32(dr["id_Tipo"]);
            this.Nombre = dr["Nombre"].ToString();
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
