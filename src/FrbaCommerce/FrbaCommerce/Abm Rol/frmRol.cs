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
using FrbaCommerce.ABM_Rol;

namespace FrbaCommerce.Abm_Rol
{
    public partial class frmRol : Form
    {
        listadoRoles frmPadre = new listadoRoles();
        Rol rolDelForm = new Rol();
        public frmRol()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Rol unRol, listadoRoles frmEnviador) 
        {
            frmPadre = frmEnviador;
            rolDelForm = unRol;
            this.Show();
            
            chkHabilitado.Visible = true;
            chkHabilitado.Checked = unRol.Habilitado;
            chkHabilitado.Enabled = false;

            
            txtNombre.Text = unRol.Nombre;
            txtNombre.Enabled = false;

            lstFuncDelSist.Visible = false;
            
            btnAgregar.Visible = false;
            btnSacar.Visible = false;
            btnCrear.Visible = false;
            btnGuardar.Visible = false;

            cargarListadoDeFuncionalidadesDelRol();
        }

        public void AbrirParaModificar(Rol unRol, listadoRoles frmEnviador)
        {
            frmPadre = frmEnviador;
            rolDelForm = unRol;
            
            this.Show();
            
            chkHabilitado.Visible = true;
            chkHabilitado.Checked = unRol.Habilitado;
            chkHabilitado.Enabled = true;
            
            txtNombre.Text = unRol.Nombre;
            txtNombre.Enabled = true;
            
            lstFuncDelSist.Visible = true;
            
            btnAgregar.Visible = true;
            btnSacar.Visible = true;
            btnCrear.Visible = false;
            btnGuardar.Visible = true;
            
            cargarListadoDeFuncionalidadesDelRol();
            cargarListadoDeFuncionalidadesDelSistema();
        }

        public void AbrirParaAgregar(listadoRoles frmEnviador)
        {
            this.Show();
            
            txtNombre.Text = "";
            txtNombre.Enabled = true;

            chkHabilitado.Checked = false;
            chkHabilitado.Visible = true;
            chkHabilitado.Enabled = true;
            
            lstFuncDelSist.Visible = true;
            lstFuncDelRol.Visible = true;
            
            btnSacar.Visible = true;
            btnAgregar.Visible = true;
            btnCrear.Visible = true;
            btnVolver.Visible = true;
            btnGuardar.Visible = false;

            frmPadre = frmEnviador;

            lstFuncDelRol.Items.Clear();
            cargarListadoDeFuncionalidadesDelSistema();
            
        }

        private void cargarListadoDeFuncionalidadesDelRol()
        {
            lstFuncDelRol.Items.Clear();
            foreach (Funcionalidad unaFunc in rolDelForm.Funcionalidades)
            {
                lstFuncDelRol.Items.Add(unaFunc);
            }
            lstFuncDelRol.DisplayMember = "Nombre";
            
        }

        private void cargarListadoDeFuncionalidadesDelSistema()
        {
            lstFuncDelSist.Items.Clear();
            DataSet ds = Funcionalidad.obtenerTodas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Funcionalidad unaFunc = new Funcionalidad();
                unaFunc.DataRowToObject(dr);
                if(!(contieneLaListaDeFuncionalidadDeRoles(unaFunc)))
                    lstFuncDelSist.Items.Add(unaFunc);
            }
            lstFuncDelSist.DisplayMember = "Nombre";
        }

        private bool contieneLaListaDeFuncionalidadDeRoles(Funcionalidad unaFunc)
        {
            foreach (Funcionalidad item in lstFuncDelRol.Items)
            {
                if (item.Nombre == unaFunc.Nombre)
                {
                    return true;
                }
            }
            return false;
        }
        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDeRoles();
            frmPadre.BringToFront();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstFuncDelSist.SelectedItem != null)
            {
                lstFuncDelRol.Items.Add(lstFuncDelSist.SelectedItem);
                lstFuncDelSist.Items.Remove(lstFuncDelSist.SelectedItem);
                lstFuncDelRol.DisplayMember = "Nombre";
            }

        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (lstFuncDelRol.SelectedItem != null)
            {
                lstFuncDelSist.Items.Add(lstFuncDelRol.SelectedItem);
                lstFuncDelRol.Items.Remove(lstFuncDelRol.SelectedItem);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string nombre = txtNombre.Text;
                bool habilitado = chkHabilitado.Checked;

                Rol unRolNuevo = new Rol(nombre, habilitado);

                foreach (Funcionalidad unaFunc in lstFuncDelRol.Items)
                {
                    unRolNuevo.Funcionalidades.Add(unaFunc);
                }

                unRolNuevo.guardarDatosDeRolNuevo();
                DialogResult dr = MessageBox.Show("El rol ha sido creado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeRoles();

            }
            catch (EntidadExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(BadInsertException ex){
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
            strErrores = Validator.ValidarNulo(txtNombre.Text, "Nombre");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string nombre = txtNombre.Text;
                bool habilitado = chkHabilitado.Checked;

                rolDelForm.Nombre = nombre;
                rolDelForm.Habilitado = habilitado;

                rolDelForm.Funcionalidades.Clear();
                foreach (Funcionalidad unaFunc in lstFuncDelRol.Items)
                {
                    rolDelForm.Funcionalidades.Add(unaFunc);
                }

                rolDelForm.ModificarDatos();
                DialogResult dr = MessageBox.Show("El rol ha sido modificado", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDeRoles();
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

        private void lstFuncDelRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRol_Load(object sender, EventArgs e)
        {

        }

    }
}
