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
namespace FrbaCommerce.Editar_Publicacion
{
    public partial class frmDetallePublic : Form
    {
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        Publicacion publicDelForm = new Publicacion();
        public frmDetallePublic()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDePublicaciones();
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaVer(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtEstado.Text = unaPublic.Estado_Publicacion.Nombre;
            txtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            txtFechaVencimiento.Text = unaPublic.Fecha_vencimiento.ToString();
            txtRubro.Text = unaPublic.Rubro.Descripcion;
            txtStock.Text = unaPublic.Stock.ToString();
            txtUsuario.Text = unaPublic.Usuario.Username;
            txtVisibilidad.Text = unaPublic.Visibilidad.Descripcion;
            txtTipo.Text = unaPublic.Tipo_Publicacion.Nombre;
            txtPrecio.Text = unaPublic.Precio.ToString();
            chkPregs.Checked = unaPublic.Permiso_Preguntas;

        }
    }
}
