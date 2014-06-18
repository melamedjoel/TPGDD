﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excepciones;
using Conexion;

namespace Clases
{
    public class Factura : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _nro_Factura;
        private DateTime _Fecha;
        private decimal _Precio_Total;
        private Forma_Pago _Forma_Pago;
        private Usuario _id_Usuario;

        #endregion

        #region properties
        public int nro_Factura
        {
            get { return _nro_Factura; }
            set { _nro_Factura = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public decimal Precio_Total
        {
            get { return _Precio_Total; }
            set { _Precio_Total = value; }
        }
        public Forma_Pago Forma_Pago
        {
            get { return _Forma_Pago; }
            set { _Forma_Pago = value; }
        }

        public Usuario id_Usuario
        {
            get { return _id_Usuario; }
            set { _id_Usuario = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Facturas";
        }

        public override string NombreEntidad()
        {
            return "Factura";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.nro_Factura = Convert.ToInt32(dr["nro_Factura"]);
            this.Fecha = Convert.ToDateTime(dr["Fecha"]);
            this.Precio_Total = Convert.ToDecimal(dr["Precio_Total"]);
            this.Forma_Pago = new Forma_Pago();
            this.Forma_Pago.id_Forma_Pago = Convert.ToInt32(dr["id_Forma_Pago"]);
        }

        public int GuardarYObtenerID()
        {
            //se guarda una nueva factura y devuelve el numero de factura que se le asignó
            this.setearListaDeParametros();
            DataSet dsNuevaFactura = this.GuardarYObtenerID(this.parameterList);
            this.nro_Factura = Convert.ToInt32(dsNuevaFactura.Tables[0].Rows[0]["nro_Factura"]);
            return this.nro_Factura;
        }
        
        #endregion

        #region metodos privados
        
        private void setearListaDeParametros()
        {
            parameterList.Add(new SqlParameter("@Fecha", this.Fecha));
            parameterList.Add(new SqlParameter("@Precio_Total", this.Precio_Total));
            parameterList.Add(new SqlParameter("@id_Forma_Pago", this.Forma_Pago.id_Forma_Pago));
            parameterList.Add(new SqlParameter("@id_Usuario", this.id_Usuario.Id_Usuario));
        }

        #endregion

        
    }
}
