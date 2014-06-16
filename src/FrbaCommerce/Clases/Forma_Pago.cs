using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Forma_Pago : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Forma_Pago;
        private string _Descripcion;

        #endregion

        #region properties
        public int id_Forma_Pago
        {
            get { return _id_Forma_Pago; }
            set { _id_Forma_Pago = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Formas_Pago";
        }

        public override string NombreEntidad()
        {
            return "Forma_Pago";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Forma_Pago = Convert.ToInt32(dr["id_Forma_Pago"]);
            this.Descripcion = dr["Descripcion"].ToString();
        }

        public DataSet obtengoTodas()
        {
            DataSet ds = this.TraerListado(this.parameterList, "");
            return ds;
        }

        public Forma_Pago obtenerPorId(int id_FormaPago)
        {
            setearListaDeParametros(id_FormaPago);
            DataSet ds = this.TraerListado(this.parameterList, "PorID");
            parameterList.Clear();
            Forma_Pago formaPago = new Forma_Pago();
            formaPago.id_Forma_Pago = Convert.ToInt32(ds.Tables[0].Rows[0]);
            formaPago.Descripcion = Convert.ToString(ds.Tables[1].Rows[0]);
            return formaPago;
        }

        #endregion

        #region metodos privados

        private void setearListaDeParametros(int id_FormaPago)
        {
            parameterList.Add(new SqlParameter("@id_Forma_Pago", id_FormaPago));
            
        }

        #endregion

        
    }
}
