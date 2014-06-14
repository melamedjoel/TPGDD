using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;
using Utilities;
using System.Configuration;
namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class frmDetallePublicGeneral : Form
    {
        frmVerPublicaciones frmPadre = new frmVerPublicaciones();
        Publicacion publicDelForm = new Publicacion();
        public frmDetallePublicGeneral()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Publicacion unaPublic, frmVerPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtEstado.Text = unaPublic.Estado_Publicacion.Nombre;
            txtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            txtFechaVencimiento.Text = unaPublic.Fecha_vencimiento.ToString();
            txtRubro.Text = unaPublic.Rubro.Descripcion;
            txtStock.Text = unaPublic.Stock.ToString();
            txtUsuario.Text = unaPublic.Usuario.Username;
            txtVisibilidad.Text = unaPublic.Visibilidad.Descripcion;
            txtTipo.Text = unaPublic.Tipo_Publicacion.Nombre;
            txtPrecio.Text = unaPublic.Precio.ToString();
            grpPreguntas.Visible = unaPublic.Permiso_Preguntas;

            if (publicDelForm.Tipo_Publicacion.Nombre == "Subasta")
            {
                btnComprar.Visible = false;
                btnOfertar.Visible = true;
            }
            else
            {
                btnComprar.Visible = true;
                btnOfertar.Visible = false;
            }

        }

        private void frmDetallePublicGeneral_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDePublicaciones();
            frmPadre.CargarListadoDeRubros();
            frmPadre.Show();
            this.Close();
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string pregunta = txtPreguntas.Text;

                Pregunta unaPregunta = new Pregunta(pregunta, publicDelForm);

                unaPregunta.GuardarPregunta();
                DialogResult dr = MessageBox.Show("La pregunta ha sido realizada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    txtPreguntas.Text = "";   
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
            strErrores += Validator.ValidarNulo(txtPreguntas.Text, "Pregunta");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }
    }
}
