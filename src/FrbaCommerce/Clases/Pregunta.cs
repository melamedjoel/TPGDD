using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Excepciones;
using Utilities;

namespace Clases
{
    public class Pregunta : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region atributos
        private int _id_Pregunta;
        private string _texto_Pregunta;
        private string _respuesta;
        private DateTime _fecha_respuesta;
        private Publicacion _publicacion = new Publicacion();

        #endregion

        #region properties

        public Publicacion Publicacion
        {
            get { return _publicacion; }
            set { _publicacion = value; }
        }

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
            get { return _respuesta; }
            set { _respuesta = value; }
        }
        public DateTime Fecha_respuesta
        {
            get { return _fecha_respuesta; }
            set { _fecha_respuesta = value; }
        }

        #endregion

        #region constructor
        public Pregunta()
        {
            id_Pregunta = -1;
            texto_Pregunta = "";
            Respuesta = "";

        }

        public Pregunta(string unaPreg,Publicacion unaPublic)
        {
            id_Pregunta = -1;
            texto_Pregunta = unaPreg;
            Respuesta = "";
            Publicacion = unaPublic;
        }

        public Pregunta(string unaRespuesta)
        {
            id_Pregunta = -1;
            Respuesta = "";
            
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
            this.Publicacion = new Publicacion(Convert.ToInt32(dr["cod_Publicacion"]));
        }

        public void GuardarPregunta()
        {
            setearListaDeParametrosConPreguntaYPublicacion();
            DataSet dsNuevaPreg = this.GuardarYObtenerID(parameterList);
            parameterList.Clear();

            if (dsNuevaPreg.Tables[0].Rows.Count > 0)
            {
                id_Pregunta = Convert.ToInt32(dsNuevaPreg.Tables[0].Rows[0]["id_Pregunta"]);
            }
            else
            {
                throw new BadInsertException();
            }

        }

        public void GuardarRespuesta(int id_Pregunta,string respuesta)
        {
            setearListaDeParametrosConPreguntaYRespuesta(id_Pregunta,respuesta);
            this.Modificar(parameterList);
            parameterList.Clear();
        }

        public DataSet obtenerPreguntasConRespuestas(int cod_Publicacion, Usuario unUsuario)
        {
            this.setearListaDeParametrosConUsuarioYPublicacion(cod_Publicacion, unUsuario.Id_Usuario);
            DataSet ds = this.TraerListado(this.parameterList, "ConRespuestasPorUsuarioYPublicacion");
            this.parameterList.Clear();

            return ds;
        }

        public DataSet obtenerPreguntasSinRespuestas(int cod_Publicacion, Usuario unUsuario)
        {
            this.setearListaDeParametrosConUsuarioYPublicacion(unUsuario.Id_Usuario, cod_Publicacion);
            DataSet ds = this.TraerListado(this.parameterList, "SinRespuestasPorUsuarioYPublicacion");
            this.parameterList.Clear();

            return ds;
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConPreguntaYPublicacion()
        {
            parameterList.Add(new SqlParameter("@txtPregunta", texto_Pregunta));
            parameterList.Add(new SqlParameter("@cod_Publicacion", Publicacion.Codigo));    
        }

        private void setearListaDeParametrosConUsuarioYPublicacion(int usuario,int publicacion)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", usuario));
            parameterList.Add(new SqlParameter("@cod_Publicacion", publicacion));
        }

        private void setearListaDeParametrosConPreguntaYRespuesta(int id_pregunta, string respuesta)
        {
            parameterList.Add(new SqlParameter("@id_Pregunta", id_pregunta));
            parameterList.Add(new SqlParameter("@Respuesta", respuesta));
        }

        #endregion


        
    }
}
