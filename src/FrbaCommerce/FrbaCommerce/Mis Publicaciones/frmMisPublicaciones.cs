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



namespace FrbaCommerce.Mis_Publicaciones
{
    public partial class frmMisPublicaciones : Form
    {
        Usuario unUsuario = new Usuario();

        public frmMisPublicaciones()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }
    }
}
