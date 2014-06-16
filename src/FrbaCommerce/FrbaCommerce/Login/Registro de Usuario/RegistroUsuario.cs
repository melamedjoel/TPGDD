using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic;
using Clases;
using Excepciones;
using Utilities;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class registroUsuario : Form
    {
        public registroUsuario()
        {
            InitializeComponent();
        }
        private void registroUsuario_Load(object sender, EventArgs e)
        {
            cmdRol.SelectedIndex = 0;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                Usuario unUsuarioNuevo = new Usuario();

                unUsuarioNuevo.Username = txtUsername.Text;
                unUsuarioNuevo.Clave = Encryptor.GetSHA256(txtPassword.Text);
                unUsuarioNuevo.ClaveAutoGenerada = false;
                unUsuarioNuevo.Activo = true;

                unUsuarioNuevo.guardarDatosDeUsuarioNuevo();

                if (cmdRol.Text == "Empresa")
                {
                    frmEmpresa _frmEmpresa = new frmEmpresa();
                    _frmEmpresa.AbrirParaRegistrarNuevaEmpresa(unUsuarioNuevo.Id_Usuario);
                    this.Hide();
                }
                if (cmdRol.Text == "Cliente")
                {
                    frmCliente _frmCliente = new frmCliente();
                    _frmCliente.AbrirParaRegistrarNuevoCliente(unUsuarioNuevo.Id_Usuario);
                    this.Hide();
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
            strErrores += Validator.ValidarNulo(txtUsername.Text, "Username");
            strErrores += Validator.ValidarNulo(txtPassword.Text, "Password");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
            
        }

      
    }
}
