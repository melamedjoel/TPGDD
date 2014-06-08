using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace FrbaCommerce.Abm_Rol
{
    public partial class frmRol : Form
    {
        Form frmPadre = new Form();
        Rol rolDelForm = new Rol();
        public frmRol()
        {
            InitializeComponent();
        }

        private void AbrirParaVer(Rol unRol, Form frmEnviador) 
        {
            frmPadre = frmEnviador;
            rolDelForm = unRol;
            this.Show();
            txtNombre.Text = unRol.Nombre;
            lstFuncDelSist.Visible = false;
            btnAgregar.Visible = false;
            btnSacar.Visible = false;
            btnGuardar.Visible = false;
            txtNombre.ReadOnly = true;

            cargarListadoDeFuncionalidadesDelRol();
        }

        private void cargarListadoDeFuncionalidadesDelRol()
        {
            lstFuncDelRol.DataSource = rolDelForm.Funcionalidades;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.BringToFront();
            this.Close();
        }
    }
}
