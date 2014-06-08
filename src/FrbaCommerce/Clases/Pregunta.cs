using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    class Pregunta : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Pregunta;
        private string _texto_Pregunta;
        private string _Respuesta;
        private DateTime _Fecha_respuesta;

        #endregion

        #region properties
        public int id_Pregunta
        {
            get { return _id_Pregunta; }
            set { _id_Pregunta = value; }
        }
        public string texto_Pregunta
        {
            get { return _texto_Pregunta; }
            set { _texto_Pregunta = value; }
        }
        public string Respuesta
        {
            get { return _Respuesta; }
            set { _Respuesta = value; }
        }
        public DateTime Fecha_respuesta
        {
            get { return _Fecha_respuesta; }
            set { _Fecha_respuesta = value; }
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Preguntas";
        }

        public override string NombreEntidad()
        {
            return "Pregunta";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Pregunta = Convert.ToInt32(dr["id_Pregunta"]);
            this.texto_Pregunta = dr["Pregunta"].ToString();
            this.Respuesta = dr["Respuesta"].ToString();
            this.Fecha_respuesta = Convert.ToDateTime(dr["Fecha_respuesta"]);
        }


        #endregion

        #region metodos privados

        #endregion
    }
}
