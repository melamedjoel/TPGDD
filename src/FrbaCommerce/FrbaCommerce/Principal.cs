using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conexion;
using Clases;
using Utilities;
using FrbaCommerce.ABM_Rol;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Abm_Visibilidad;


namespace FrbaCommerce
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void ABMRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoRoles frmListadoRoles = new listadoRoles();
            frmListadoRoles.Show(this);
        }


        private void AbmEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoEmpresa frmListadoEmpresas = new listadoEmpresa();
            frmListadoEmpresas.Show(this);
        }

        private void AbmVisiblidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoVisibilidad frmListadoVisibilidad = new listadoVisibilidad();
            frmListadoVisibilidad.Show(this);
        }

    }
}
