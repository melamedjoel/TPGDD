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
        private int _id_usuario_registrado;

        public frmCliente()
        {
            InitializeComponent();
        }
        public int id_usuario_registrado
        {
            get { return _id_usuario_registrado; }
            set { _id_usuario_registrado = value; }
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
            cmbTipoDni.Text = unCliente.Tipo_Doc;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            txtLocalidad.Text = unCliente.Dom_ciudad;
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
            btnAceptarRCliente.Visible = false;
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
            cmbTipoDni.Text = unCliente.Tipo_Doc;
            txtDni.Text = Convert.ToString(unCliente.Dni);
            txtFechaNac.Text = Convert.ToString(unCliente.Fecha_nac);
            txtLocalidad.Text = unCliente.Dom_ciudad;
            txtMail.Text = unCliente.Mail;
            txtNombre.Text = unCliente.Nombre;
            txtNroPiso.Text = Convert.ToString(unCliente.Dom_piso);
            txtNumeroCalle.Text = Convert.ToString(unCliente.Dom_nro_calle);
            txtTelefono.Text = unCliente.Telefono;
            chkActivo.Checked = unCliente.Activo;

            btnAceptarACliente.Visible = false;
            btnAceptarRCliente.Visible = false;

        }
        public void AbrirParaAgregar(listadoCliente frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();

            cmbTipoDni.SelectedIndex = 1;
            txtDni.Enabled = false;

            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCodPostal.Text = "";
            txtDepto.Text = "";
            txtCuil.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtLocalidad.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtNroPiso.Text = "";
            txtNumeroCalle.Text = "";
            txtTelefono.Text = "";
            chkActivo.Visible = false;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = true;
            btnAceptarRCliente.Visible = false;
        }
        public void AbrirParaRegistrarNuevoCliente(int id_usuario)
        {
            this.Show();

            cmbTipoDni.SelectedIndex = 1;
            txtDni.Enabled = false;

            txtApellido.Text = "";
            txtCalle.Text = "";
            txtCodPostal.Text = "";
            txtDepto.Text = "";
            txtCuil.Text = "";
            txtFechaNac.Text = Convert.ToString(DateTime.Today);
            txtLocalidad.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtNroPiso.Text = "";
            txtNumeroCalle.Text = "";
            txtTelefono.Text = "";
            chkActivo.Visible = false;

            this.id_usuario_registrado = id_usuario;

            btnAceptarMCliente.Visible = false;
            btnAceptarACliente.Visible = false;
            btnVolver.Visible = false;
            btnAceptarRCliente.Visible = true;
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
                clienteDelForm.Tipo_Doc = cmbTipoDni.Text;
                clienteDelForm.Cuil = txtCuil.Text;
                clienteDelForm.Dom_calle = txtCalle.Text;
                clienteDelForm.Dom_ciudad = txtLocalidad.Text;
                clienteDelForm.Dom_cod_postal = txtCodPostal.Text;
                clienteDelForm.Dom_depto = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtNumeroCalle.Text)) clienteDelForm.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) clienteDelForm.Dom_piso = Int32.Parse(txtNroPiso.Text);
                if (!String.IsNullOrEmpty(txtFechaNac.Text)) clienteDelForm.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
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
                unClienteNuevo.Tipo_Doc = cmbTipoDni.Text;
                unClienteNuevo.Cuil = txtCuil.Text;
                unClienteNuevo.Dom_calle = txtCalle.Text;
                unClienteNuevo.Dom_ciudad = txtLocalidad.Text;
                unClienteNuevo.Dom_cod_postal = txtCodPostal.Text;
                unClienteNuevo.Dom_depto = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtNumeroCalle.Text)) unClienteNuevo.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unClienteNuevo.Dom_piso = Int32.Parse(txtNroPiso.Text);
                if (!String.IsNullOrEmpty(txtFechaNac.Text)) unClienteNuevo.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Telefono = txtTelefono.Text;
                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Dni));
                unClienteNuevo.Activo = true;

                unClienteNuevo.guardarDatosDeClienteNuevo();
                DialogResult dr = MessageBox.Show("El Cliente ha sido creado. Usuario y contraseña del nuevo usuario = " + Convert.ToString(unClienteNuevo.Dni), "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnAceptarRCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Cliente unClienteNuevo = new Cliente();

                unClienteNuevo.Apellido = txtApellido.Text;
                unClienteNuevo.Nombre = txtNombre.Text;
                unClienteNuevo.Dni = Int32.Parse(txtDni.Text);
                unClienteNuevo.Tipo_Doc = cmbTipoDni.Text;
                unClienteNuevo.Cuil = txtCuil.Text;
                unClienteNuevo.Dom_calle = txtCalle.Text;
                unClienteNuevo.Dom_ciudad = txtLocalidad.Text;
                unClienteNuevo.Dom_cod_postal = txtCodPostal.Text;
                unClienteNuevo.Dom_depto = txtDepto.Text;
                if (!String.IsNullOrEmpty(txtNumeroCalle.Text)) unClienteNuevo.Dom_nro_calle = Int32.Parse(txtNumeroCalle.Text);
                if (!String.IsNullOrEmpty(txtNroPiso.Text)) unClienteNuevo.Dom_piso = Int32.Parse(txtNroPiso.Text);
                if (!String.IsNullOrEmpty(txtFechaNac.Text)) unClienteNuevo.Fecha_nac = DateTime.Parse(txtFechaNac.Text);
                unClienteNuevo.Mail = txtMail.Text;
                unClienteNuevo.Telefono = txtTelefono.Text;
                unClienteNuevo.Usuario = new Usuario();
                unClienteNuevo.Usuario.CrearDefault(Convert.ToString(unClienteNuevo.Dni));
                unClienteNuevo.Activo = true;

                unClienteNuevo.guardarDatosDeClienteNuevoRegistrado(this.id_usuario_registrado);
                DialogResult dr = MessageBox.Show("El Usuario ha sido registrado y el Cliente creado.", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    Application.Run(new Inicial());
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
            strErrores += Validator.SoloNumerosPeroOpcional(txtDni.Text, "Dni");
            strErrores += Validator.ValidarNulo(txtCuil.Text, "Cuil");
            strErrores += Validator.SoloNumerosPeroOpcional(txtNroPiso.Text, "Numero de Piso"); 
            strErrores += Validator.SoloNumerosPeroOpcional(txtNumeroCalle.Text, "Numero de Calle"); 
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void cmbTipoDni_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipoDni.Text == "Dni") { txtDni.Enabled = true; }
            if (cmbTipoDni.Text == "Otro")
            {
                txtDni.Text = "";
                txtDni.Enabled = false;
            }

        }

        

      

    }
}
