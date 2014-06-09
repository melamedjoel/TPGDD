﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Clases
{
    public class Funcionalidad : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

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

        public static DataSet ObtenerFuncionalidadesPorRol(int id_Rol)
        {
            Funcionalidad miFunc = new Funcionalidad();
            miFunc.setearListaDeParametrosConIdRol(id_Rol);
            DataSet ds = miFunc.TraerListado(miFunc.parameterList, "PorId_Rol");
            miFunc.parameterList.Clear();
            return ds;
        }

        public static DataSet obtenerTodas()
        {
            Funcionalidad miFunc = new Funcionalidad();
            DataSet ds = miFunc.TraerListado(miFunc.parameterList, "");
            return ds;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConIdRol(int id_Rol)
        {
            parameterList.Add(new SqlParameter("@id_Rol", id_Rol));
        }
        #endregion 

    
    }
}
