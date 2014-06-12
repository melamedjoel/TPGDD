using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Utilities;
using Excepciones;


namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class frmVisibilidad : Form
    {
        listadoVisibilidad frmPadre = new listadoVisibilidad();
        Visibilidad visibilidadDelForm = new Visibilidad();
        public frmVisibilidad()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Visibilidad unaVisibilidad, listadoVisibilidad frmEnviador)
        {
            frmPadre = frmEnviador;
            visibilidadDelForm = unaVisibilidad;
            
            this.Show();
            
            chkActivo.Visible = true;
            chkActivo.Checked = unaVisibilidad.Activo;
            chkActivo.Enabled = false;

            txtDescripcion.Text = unaVisibilidad.Descripcion;
            txtDescripcion.Enabled = false;
            
            txtPrecioPorPublicar.Text = unaVisibilidad.Precio.ToString();
            txtPrecioPorPublicar.Enabled = false;
            
            txtPorcentaje.Text = unaVisibilidad.Porcentaje.ToString();
            txtPorcentaje.Enabled = false;
            
            btnCrear.Visible = false;
            btnGuardar.Visible = false;
        }

        public void AbrirParaModificar(Visibilidad unaVisibilidad, listadoVisibilidad frmEnviador)
        {
            frmPadre = frmEnviador;
            visibilidadDelForm = unaVisibilidad;
            
            this.Show();
            
            chkActivo.Visible = true;
            chkActivo.Checked = unaVisibilidad.Activo;
            chkActivo.Enabled = true;
            
            txtDescripcion.Text = unaVisibilidad.Descripcion;
            txtDescripcion.Enabled = true;

            txtPrecioPorPublicar.Text = unaVisibilidad.Precio.ToString();
            txtPrecioPorPublicar.Enabled = true;

            txtPorcentaje.Text = unaVisibilidad.Porcentaje.ToString();
            txtPorcentaje.Enabled = true;

            btnCrear.Visible = false;
            btnGuardar.Visible = true;
            
        }

        public void AbrirParaAgregar(listadoVisibilidad frmEnviador)
        {
            this.Show();

            txtDescripcion.Text = "";
            txtDescripcion.Enabled = true;

            txtPrecioPorPublicar.Text = "";
            txtPrecioPorPublicar.Enabled = true;

            txtPorcentaje.Text = "";
            txtPorcentaje.Enabled = true;

            chkActivo.Checked = false;
            chkActivo.Visible = true;
            chkActivo.Enabled = true;

            btnCrear.Visible = true;
            btnVolver.Visible = true;
            btnGuardar.Visible = false;

            frmPadre = frmEnviador;


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeVisibilidades();
            frmPadre.BringToFront();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string descripcion = txtDescripcion.Text;
                var precio = Convert.ToDecimal(txtPrecioPorPublicar.Text.Replace(".", ","));
                var porcentaje = Convert.ToDecimal(txtPorcentaje.Text.Replace(".", ","));
                bool activo = chkActivo.Checked;

                visibilidadDelForm.Descripcion= descripcion;
                visibilidadDelForm.Precio = precio;
                visibilidadDelForm.Porcentaje = porcentaje;
                visibilidadDelForm.Activo = activo;


                visibilidadDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("La visibilidad ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeVisibilidades();
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
            strErrores += Validator.ValidarNulo(txtDescripcion.Text, "Descripcion");
            strErrores += Validator.SoloNumerosODecimales(txtPrecioPorPublicar.Text, "Precio");
            strErrores += Validator.SoloNumerosODecimales(txtPorcentaje.Text, "Porcentaje");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                var precio = Convert.ToDecimal(txtPrecioPorPublicar.Text.Replace(".", ","));
                var porcentaje = Convert.ToDecimal(txtPorcentaje.Text.Replace(".", ","));
                string descripcion = txtDescripcion.Text;
                bool activo = chkActivo.Checked;

                Visibilidad unaVisibNueva = new Visibilidad(descripcion, precio, porcentaje, activo);
                unaVisibNueva.guardarDatosDeVisibilidadNueva();
                DialogResult dr = MessageBox.Show("La visibilidad ha sido creada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeVisibilidades();

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
    }
}
