using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;
using Utilities;


namespace FrbaCommerce.Generar_Publicacion
{
    public partial class frmCompraInmediata : Form
    {
        Usuario unUsuario = new Usuario();
        public frmCompraInmediata()
        {
            InitializeComponent();
        }

        internal void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }
    }
}
