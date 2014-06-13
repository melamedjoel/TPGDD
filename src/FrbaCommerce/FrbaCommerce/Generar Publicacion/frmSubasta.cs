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
    public partial class frmSubasta : Form
    {
        Usuario unUsuario = new Usuario();
        public frmSubasta()
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
