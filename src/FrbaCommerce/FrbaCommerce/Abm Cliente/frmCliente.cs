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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class frmCliente : Form
    {
        listadoCliente frmPadre = new listadoCliente();
        Cliente clienteDelForm = new Cliente();
        public frmCliente()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Cliente unCliente, listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;

            this.Show();

            txtApellido.Text = unCliente.Apellido;
            txtCalle.Text = unCliente.Dom_calle;
            txtCodPostal.Text = unCliente.Dom_cod_postal;
            txtDepto.Text = unCliente.Dom_depto;
            txtCuil.Text = unCliente.Cuil;
            cmbTipoDni.Text = unCliente.Tipo_Dni;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            //txtLocalidad.Text = unCliente.Dom_ciudad;
            txtMail.Text = unCliente.Mail;
            txtNombre.Text = unCliente.Nombre;
            txtNroPiso.Text = Convert.ToString(unCliente.Dom_piso);
            txtNumeroCalle.Text = Convert.ToString(unCliente.Dom_nro_calle);
            txtTelefono.Text = unCliente.Telefono;
            chkActivo.Checked = unCliente.Activo;

            txtApellido.Enabled = false;
            txtCalle.Enabled = false;
            txtCodPostal.Enabled = false;
            txtDepto.Enabled = false;
            txtCuil.Enabled = false;
            txtDni.Enabled = false;
            txtFechaNac.Enabled = false;
            txtLocalidad.Enabled = false;
            txtMail.Enabled = false;
            txtNombre.Enabled = false;
            txtNroPiso.Enabled = false;
            txtNumeroCalle.Enabled = false;
            txtTelefono.Enabled = false;
            chkActivo.Enabled = false;
            cmbTipoDni.Enabled = false;

            btnAceptarACliente.Visible = false;
            btnAceptarMCliente.Visible = false;
        }
        public void AbrirParaModificar(Cliente unCliente, listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            clienteDelForm = unCliente;
            this.Show();
            //ya se que repite mucho codigo, lo voy a arreglar!!!!!!!!

            txtApellido.Text = unCliente.Apellido;
            txtCalle.Text = unCliente.Dom_calle;
            txtCodPostal.Text = unCliente.Dom_cod_postal;
            txtDepto.Text = unCliente.Dom_depto;
            txtCuil.Text = unCliente.Cuil;
            cmbTipoDni.Text = unCliente.Tipo_Dni;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            //txtLocalidad.Text = unCliente.Dom_ciudad;
            txtMail.Text = unCliente.Mail;
            txtNombre.Text = unCliente.Nombre;
            txtNroPiso.Text = Convert.ToString(unCliente.Dom_piso);
            txtNumeroCalle.Text = Convert.ToString(unCliente.Dom_nro_calle);
            txtTelefono.Text = unCliente.Telefono;
            chkActivo.Checked = unCliente.Activo;

            btnAceptarACliente.Visible = false;

        }
        public void AbrirParaAgregar(listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();
            //"" Es necesario??? 
            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCodPostal.Text = "";
            txtDepto.Text = "";
            txtCuil.Text = "";
            txtDni.Text = Convert.ToString(0);
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            //txtLocalidad.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtNroPiso.Text = Convert.ToString(0);
            txtNumeroCalle.Text = Convert.ToString(0);
            txtTelefono.Text = "";
            chkActivo.Visible = false;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeClientes();
            frmPadre.BringToFront();
            this.Close();
        }
        private void btnAceptarMCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                clienteDelForm.Apellido = txtApellido.Text;
                clienteDelForm.Nombre = txtNombre.Text;
                clienteDelForm.Dni = Int32.Parse(txtDni.Text);
                //clienteDelForm.Tipo_Dni = cmbTipoDni.GetItemText;
                clienteDelForm.Cuil = txtCuil.Text;
                clienteDelForm.Dom_calle = txtCalle.Text;
                //clienteDelForm.Dom_ciudad = txtLocalidad.Text;
                clienteDelForm.Dom_cod_postal = txtCodPostal.Text;
                clienteDelForm.Dom_depto = txtDepto.Text;
                clienteDelForm.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                clienteDelForm.Dom_piso = Int32.Parse(txtNroPiso.Text);
                clienteDelForm.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                clienteDelForm.Mail = txtMail.Text;
                clienteDelForm.Telefono = txtTelefono.Text;
                clienteDelForm.Activo = chkActivo.Checked;

                clienteDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("El Cliente ha sido modificado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeClientes();
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
        private void btnAceptarACliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Cliente unClienteNuevo = new Cliente();

                unClienteNuevo.Apellido = txtApellido.Text;
                unClienteNuevo.Nombre = txtNombre.Text;
                unClienteNuevo.Dni = Int32.Parse(txtDni.Text);
                //unClienteNuevo.Tipo_Dni = cmbTipoDni.GetItemText;
                unClienteNuevo.Cuil = txtCuil.Text;
                unClienteNuevo.Dom_calle = txtCalle.Text;
                unClienteNuevo.Dom_ciudad = txtLocalidad.Text;
                unClienteNuevo.Dom_cod_postal = txtCodPostal.Text;
                unClienteNuevo.Dom_depto = txtDepto.Text;
                unClienteNuevo.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                unClienteNuevo.Dom_piso = Int32.Parse(txtNroPiso.Text);
                unClienteNuevo.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Telefono = txtTelefono.Text;
                unClienteNuevo.usuario = new Usuario();
                unClienteNuevo.usuario.CrearDefault(Convert.ToString(unClienteNuevo.Dni));
                unClienteNuevo.Activo = true;

                unClienteNuevo.guardarDatosDeClienteNuevo();
                DialogResult dr = MessageBox.Show("El Cliente ha sido creado. Usuario y contraseña del nuevo usuario =" + Convert.ToString(unClienteNuevo.Dni), "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeClientes();

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
            strErrores = Validator.ValidarNulo(txtDni.Text, "Dni");
            strErrores = strErrores + Validator.ValidarNulo(txtCuil.Text, "Cuil");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }

            //FALTA VALIDAR QUE NO EXISTA CLIENTE CON ESE TIPO Y NRODEDOC
            //NO PUEDE HABER TMP MISMO TELEFONO Y ¿CUIL?
        }

        private void cmbTipoDni_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipoDni.Text != "Dni") { txtDni.Enabled = false; }

        }

    }
}
