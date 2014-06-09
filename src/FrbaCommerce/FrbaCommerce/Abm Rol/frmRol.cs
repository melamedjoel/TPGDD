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

        public void AbrirParaVer(Rol unRol, Form frmEnviador) 
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
            lstFuncDelRol.DisplayMember = "Nombre";
            
        }

        private void cargarListadoDeFuncionalidadesDelSistema()
        {
            DataSet ds = Funcionalidad.obtenerTodas();
            ListManager.CargarLista(lstFuncDelSist, ds, "id_Rol", "Nombre");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.BringToFront();
            this.Close();
        }
    }
}
