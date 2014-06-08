using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Calificacion : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _cod_Calificacion;
        private int _Cant_Estrellas;
        private string _Descripcion;

        private Usuario _usuario_Calificador;
        private Usuario _usuario_Calificado;

        #endregion

        #region properties
        public int cod_Calificacion
        {
            get { return _cod_Calificacion; }
            set { _cod_Calificacion = value; }
        }
        public int Cant_Estrellas
        {
            get { return _Cant_Estrellas; }
            set { _Cant_Estrellas = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public Usuario usuario_Calificador
        {
            get { return _usuario_Calificador; }
            set { _usuario_Calificador = value; }
        }
        public Usuario usuario_Calificado
        {
            get { return _usuario_Calificado; }
            set { _usuario_Calificado = value; }
        }
        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Calificaciones";
        }

        public override string NombreEntidad()
        {
            return "Calificacion";
        }

        public override void DataRowToObject(DataRow dr)
        {
            //Esto es tal cual lo devuelve el stored de la DB
            this.cod_Calificacion = Convert.ToInt32(dr["cod_Calificacion"]);
            this.usuario_Calificador = new Usuario();
            //this.usuario_Calificador.Id_Usuario = Convert.ToInt32(dr["id_usuario_Calificador"]);
            this.usuario_Calificado = new Usuario();
            //this.usuario_Calificado.Id_Usuario = Convert.ToInt32(dr["id_usuario_Calificado"]);
            this.Cant_Estrellas = Convert.ToInt32(dr["Cant_Estrellas"]);
            this.Descripcion = dr["Descripcion"].ToString();
            
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
