using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    class Visibilidad : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _cod_Visibilidad;
        private string _Descripcion;
        private decimal _Precio;
        private decimal _Porcentaje;

        #endregion

        #region properties
        public int cod_Visibilidad
        {
            get { return _cod_Visibilidad; }
            set { _cod_Visibilidad = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public decimal Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Visibilidades";
        }

        public override string NombreEntidad()
        {
            return "Visibilidad";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.cod_Visibilidad = Convert.ToInt32(dr["cod_Visibilidad"]);
            this.Descripcion = dr["Descripcion"].ToString();
            this.Precio = Convert.ToDecimal(dr["Precio"]);
            this.Porcentaje = Convert.ToDecimal(dr["Porcentaje"]);
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
