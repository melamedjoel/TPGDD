﻿using System;
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
            listadoRoles frmRol = new listadoRoles();
            frmRol.Show(this);
        }

    }
}
