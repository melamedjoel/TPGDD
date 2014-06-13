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
using System.Globalization;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class listadoEstadistico : Form
    {
        Usuario unUsuario = new Usuario();

        private void listadoEstadistico_Load(object sender, EventArgs e)
        {
            configuracionInicial();
        }

        public void configuracionInicial()
        {
            lblAño.Visible = true;
            txtAño.Visible = true;
            lblTrimestre.Visible = false;
            cmbTrimestre.Visible = false;
            cmbListado.Visible = false;
            grpFiltros.Visible = false;
            dtgTop5.Visible = false;
        }

        public listadoEstadistico()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    ValidarCampos();
                    lblTrimestre.Visible = true;
                    cmbTrimestre.Visible = true;
                }

                catch (Exception ex)
                {
                    configuracionInicial();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    
                }

            }
        }

        private void ValidarCampos()
        {
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtAño.Text, "Año");
            strErrores += Validator.SoloNumeros(txtAño.Text, "Año");
            strErrores += Validator.EsAño(txtAño.Text, "Año");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // CargarListadoDeVendedoresConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtGradoVisibilidad.Text = "";
            txtMesAño.Text = "";
            // CargarListadoDeVendedores();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (cmbListado.SelectedIndex == 0) cargarListadoDeVendedoresConMayorCantProdNoVendidos();
            if (cmbListado.SelectedIndex == 1) cargarListadoDeVendedoresConMayorFacturacion();
            if (cmbListado.SelectedIndex == 2) cargarListadoDeVendedoresConMayorCalificacion();
            if (cmbListado.SelectedIndex == 3) cargarListadoDeClientesConMayorCantPubliSinClasificar();
        }

        private void cargarListadoDeVendedoresConMayorCantProdNoVendidos()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCompras();
                // configurarGrillaVendedores(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cargarListadoDeVendedoresConMayorFacturacion()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCompras();
                // configurarGrillaVendedores(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarListadoDeVendedoresConMayorCalificacion()
        {
            try
            {
                DataSet ds = unUsuario.obtenerTodasLasCompras();
                // configurarGrillaVendedores(ds);
            }

            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarListadoDeClientesConMayorCantPubliSinClasificar()
         {
             try
             {
                 DataSet ds = unUsuario.obtenerTodasLasCompras();
                 // configurarGrillaCliente(ds);
             }

             catch (ErrorConsultaException ex)
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
