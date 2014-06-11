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
//using FrbaCommerce.ABM_Empresa;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class frmEmpresa : Form
    {
        listadoEmpresa frmPadre = new listadoEmpresa();
        Empresa empresaDelForm = new Empresa();
        public frmEmpresa()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Empresa unaEmpresa, listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            empresaDelForm = unaEmpresa;
            this.Show();
            txtRazonSocial.Text = unaEmpresa.Razon_social;
            txtCuit.Text = unaEmpresa.Cuit;
            txtNombreContacto.Text = unaEmpresa.Nombre_contacto;
            txtMail.Text = unaEmpresa.Mail;
            txtTelefono.Text = unaEmpresa.Telefono;
            txtCalle.Text = unaEmpresa.Dom_calle;
            txtNumeroCalle.Text = Convert.ToString(unaEmpresa.Dom_nro_calle);
            txtNroPiso.Text = Convert.ToString(unaEmpresa.Dom_piso);
            txtDepto.Text = Convert.ToString(unaEmpresa.Dom_depto);
            txtCodPostal.Text = unaEmpresa.Dom_cod_postal;
            txtLocalidad.Text = unaEmpresa.Dom_ciudad;            
            txtFechaCreacion.Text = Convert.ToString(unaEmpresa.Fecha_creacion);
            chkActivo.Checked = unaEmpresa.Activo;
            
            txtRazonSocial.Enabled = false;
            txtCuit.Enabled = false;
            txtNombreContacto.Enabled = false;
            txtMail.Enabled = false;
            txtTelefono.Enabled = false;
            txtCalle.Enabled = false;
            txtNumeroCalle.Enabled = false;
            txtNroPiso.Enabled = false;
            txtDepto.Enabled = false;
            txtCodPostal.Enabled = false;
            txtLocalidad.Enabled = false;
            txtFechaCreacion.Enabled = false;
            chkActivo.Enabled = false;

            btnAceptarAEmpresa.Visible = false;
            btnAceptarMEmpresa.Visible = false;
        }
        public void AbrirParaModificar(Empresa unaEmpresa, listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            empresaDelForm = unaEmpresa;
            this.Show();
            //ya se que repite mucho codigo, lo voy a arreglar!!!!!!!!

            txtRazonSocial.Text = unaEmpresa.Razon_social;
            txtCuit.Text = unaEmpresa.Cuit;
            txtNombreContacto.Text = unaEmpresa.Nombre_contacto;
            txtMail.Text = unaEmpresa.Mail;
            txtTelefono.Text = unaEmpresa.Telefono;
            txtCalle.Text = unaEmpresa.Dom_calle;
            txtNumeroCalle.Text = Convert.ToString(unaEmpresa.Dom_nro_calle);
            txtNroPiso.Text = Convert.ToString(unaEmpresa.Dom_piso);
            txtDepto.Text = Convert.ToString(unaEmpresa.Dom_depto);
            txtCodPostal.Text = unaEmpresa.Dom_cod_postal;
            txtLocalidad.Text = unaEmpresa.Dom_ciudad;
            txtFechaCreacion.Text = Convert.ToString(unaEmpresa.Fecha_creacion);
            chkActivo.Checked = unaEmpresa.Activo;

            txtRazonSocial.Enabled = true;
            txtCuit.Enabled = true;
            txtNombreContacto.Enabled = true;
            txtMail.Enabled = true;
            txtTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtNumeroCalle.Enabled = true;
            txtNroPiso.Enabled = true;
            txtDepto.Enabled = true;
            txtCodPostal.Enabled = true;
            txtLocalidad.Enabled = true;
            txtFechaCreacion.Enabled = true;
            chkActivo.Enabled = true;

            btnAceptarAEmpresa.Visible = false;
            
        }
        public void AbrirParaAgregar(listadoEmpresa frmEnviador)
        {
            frmPadre = frmEnviador;
            this.Show();
            //"" Es necesario??? 
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            txtNombreContacto.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            txtCalle.Text = "";
            txtNumeroCalle.Text = "";
            txtNroPiso.Text = "";
            txtDepto.Text = "";
            txtCodPostal.Text = "";
            txtLocalidad.Text = "";
            txtFechaCreacion.Text = Convert.ToString(DateTime.Today);
            chkActivo.Visible = false;

            btnAceptarMEmpresa.Visible = false;
            btnAceptarAEmpresa.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeEmpresas();
            frmPadre.BringToFront();
            this.Close();
        }
        private void btnAceptarMEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
               
                empresaDelForm.Razon_social = txtRazonSocial.Text;
                empresaDelForm.Cuit = txtCuit.Text;
                empresaDelForm.Activo = true;
                empresaDelForm.Dom_calle = txtCalle.Text;
                empresaDelForm.Dom_ciudad = txtLocalidad.Text;
                empresaDelForm.Dom_cod_postal = txtCodPostal.Text;
                empresaDelForm.Dom_depto = txtDepto.Text;
                empresaDelForm.Dom_nro_calle = Convert.ToInt32(txtNumeroCalle.Text);
                empresaDelForm.Dom_piso = Convert.ToInt32(txtNroPiso.Text);
                empresaDelForm.Fecha_creacion = Convert.ToDateTime(txtFechaCreacion.Text);
                empresaDelForm.Mail = txtMail.Text;
                empresaDelForm.Nombre_contacto = txtNombreContacto.Text;
                empresaDelForm.Telefono = txtTelefono.Text;
                empresaDelForm.Activo = chkActivo.Checked;

                empresaDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("La Empresa ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeEmpresas();
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
            strErrores = Validator.ValidarNulo(txtRazonSocial.Text, "razon_Social");
            strErrores = strErrores + Validator.ValidarNulo(txtCuit.Text, "Cuit");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
            //FALTA VALIDAR QUE NO EXISTE EMPRESA CON ESTA RAZON SOCIAL Y CUIT
        }

        private void btnAceptarAEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Empresa unaEmpresaNueva = new Empresa();
                unaEmpresaNueva.Razon_social = txtRazonSocial.Text;
                unaEmpresaNueva.Cuit = txtCuit.Text;
                unaEmpresaNueva.Activo = true;
                unaEmpresaNueva.Dom_calle = txtCalle.Text;
                unaEmpresaNueva.Dom_ciudad = txtLocalidad.Text;
                unaEmpresaNueva.Dom_cod_postal = txtCodPostal.Text;
                unaEmpresaNueva.Dom_depto = txtDepto.Text;
                unaEmpresaNueva.Dom_nro_calle = Convert.ToInt32(txtNumeroCalle.Text);
                unaEmpresaNueva.Dom_piso = Convert.ToInt32(txtNroPiso.Text);
                //unaEmpresaNueva.Fecha_creacion = Convert.ToDateTime(txtFechaCreacion.Text);
                unaEmpresaNueva.Mail = txtMail.Text;
                unaEmpresaNueva.Nombre_contacto = txtNombreContacto.Text;
                unaEmpresaNueva.Telefono = txtTelefono.Text;
                unaEmpresaNueva.usuario = new Usuario();
                unaEmpresaNueva.usuario.CrearDefault(empresaDelForm.Cuit);
                unaEmpresaNueva.Activo = true;

                unaEmpresaNueva.guardarDatosDeEmpresaNueva();
                DialogResult dr = MessageBox.Show("La empresa ha sido creada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeEmpresas();

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
