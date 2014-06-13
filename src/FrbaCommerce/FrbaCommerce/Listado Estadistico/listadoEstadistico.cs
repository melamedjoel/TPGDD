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

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class listadoEstadistico : Form
    {
        Usuario unUsuario = new Usuario();
        
        public listadoEstadistico()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void cmbListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
