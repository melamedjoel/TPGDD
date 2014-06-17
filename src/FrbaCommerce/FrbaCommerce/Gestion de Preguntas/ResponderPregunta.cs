using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Conexion;
using Utilities;
using Excepciones;
using FrbaCommerce.Gestion_de_Preguntas;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class ResponderPregunta : Form
    {
        listadoPreguntas frmPadre = new listadoPreguntas();
        private int id_Pregunta;
        int cod_Publicacion;
        
        public ResponderPregunta()
        {
            InitializeComponent();
        }

        public void AbrirParaResponder(int idPreg, listadoPreguntas frmEnviador, int codigoP)
        {
            frmPadre = frmEnviador;
            id_Pregunta = idPreg;
            cod_Publicacion = codigoP;
            this.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string respuesta = txtRespuesta.Text;
                
                Pregunta.GuardarRespuesta(id_Pregunta,respuesta);
                DialogResult dr = MessageBox.Show("La respuesta ha sido realizada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.cargarListadoPreguntasNoRespondidas(cod_Publicacion);
                }


            }
            catch (EntidadExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ValidarCampos()
        {
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtRespuesta.Text, "Pregunta");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.cargarListadoPreguntasNoRespondidas(cod_Publicacion);
            frmPadre.BringToFront();
            this.Close();
        }


    }
}
