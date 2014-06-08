using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Funcionalidad : Base
    {
        #region atributos
        private int _id_Funcionalidad;
        private string _nombre;
        #endregion

        #region properties
        public int id_Funcionalidad
        {
            get { return _id_Funcionalidad; }
            set { _id_Funcionalidad = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Funcionalidades";
        }

        public override string NombreEntidad()
        {
            return "Funcionalidad";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Funcionalidad = Convert.ToInt32(dr["id_Funcionalidad"]);
            this.Nombre = dr["Nombre"].ToString();
        }


        #endregion

    }
}
