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
using System.Configuration;



namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class frmVerPublicaciones : Form
    {
        Usuario unUsuario = new Usuario();

        public frmVerPublicaciones()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        public void CargarListadoDePublicaciones()
        {
            try
            {
                DataSet ds = Publicacion.obtenerTodas(Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]));
                configurarGrilla(ds);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarGrilla(DataSet ds)
        {
            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 60;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "Codigo";
            clmID.HeaderText = "Codigo";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombreUsuario = new DataGridViewTextBoxColumn();
            clmNombreUsuario.Width = 100;
            clmNombreUsuario.ReadOnly = true;
            clmNombreUsuario.DataPropertyName = "Username";
            clmNombreUsuario.HeaderText = "Usuario";
            dtgListado.Columns.Add(clmNombreUsuario);

            DataGridViewTextBoxColumn clmDesc = new DataGridViewTextBoxColumn();
            clmDesc.Width = 200;
            clmDesc.ReadOnly = true;
            clmDesc.DataPropertyName = "Descripcion";
            clmDesc.HeaderText = "Descripcion";
            dtgListado.Columns.Add(clmDesc);

            DataGridViewTextBoxColumn clmStock = new DataGridViewTextBoxColumn();
            clmStock.Width = 60;
            clmStock.ReadOnly = true;
            clmStock.DataPropertyName = "Stock";
            clmStock.HeaderText = "Stock";
            dtgListado.Columns.Add(clmStock);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.Width = 60;
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgListado.Columns.Add(clmPrecio);

            DataGridViewTextBoxColumn clmCreacion = new DataGridViewTextBoxColumn();
            clmCreacion.Width = 100;
            clmCreacion.ReadOnly = true;
            clmCreacion.DataPropertyName = "Fecha_creacion";
            clmCreacion.HeaderText = "Fecha_creacion";
            dtgListado.Columns.Add(clmCreacion);


            DataGridViewTextBoxColumn clmVencimiento = new DataGridViewTextBoxColumn();
            clmVencimiento.Width = 100;
            clmVencimiento.ReadOnly = true;
            clmVencimiento.DataPropertyName = "Fecha_vencimiento";
            clmVencimiento.HeaderText = "Fecha_vencimiento";
            dtgListado.Columns.Add(clmVencimiento);

            DataGridViewTextBoxColumn clmTipo = new DataGridViewTextBoxColumn();
            clmTipo.Width = 100;
            clmTipo.ReadOnly = true;
            clmTipo.DataPropertyName = "NombreTipo";
            clmTipo.HeaderText = "Tipo";
            dtgListado.Columns.Add(clmTipo);

            DataGridViewTextBoxColumn clmVisib = new DataGridViewTextBoxColumn();
            clmVisib.Width = 100;
            clmVisib.ReadOnly = true;
            clmVisib.DataPropertyName = "DescVisibilidad";
            clmVisib.HeaderText = "Visibilidad";
            dtgListado.Columns.Add(clmVisib);

            DataGridViewTextBoxColumn clmEstado = new DataGridViewTextBoxColumn();
            clmEstado.Width = 100;
            clmEstado.ReadOnly = true;
            clmEstado.DataPropertyName = "NombreEstado";
            clmEstado.HeaderText = "Estado";
            dtgListado.Columns.Add(clmEstado);

            DataGridViewTextBoxColumn clmRubro = new DataGridViewTextBoxColumn();
            clmRubro.Width = 100;
            clmRubro.ReadOnly = true;
            clmRubro.DataPropertyName = "NombreRubro";
            clmRubro.HeaderText = "Rubro";
            dtgListado.Columns.Add(clmRubro);

            DataGridViewCheckBoxColumn clmPregs = new DataGridViewCheckBoxColumn();
            clmPregs.Width = 30;
            clmPregs.ReadOnly = true;
            clmPregs.DataPropertyName = "permiso_Preguntas";
            clmPregs.HeaderText = "Permiso Preguntas";
            dtgListado.Columns.Add(clmPregs);

            dtgListado.DataSource = ds.Tables[0];
        }

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Codigo"]);
        }


        public void CargarListadoDePublicacionesConFiltros()
        {
            try
            {
                DataSet ds = Publicacion.obtenerTodasConFiltros(unUsuario, txtDescripcion.Text);
                configurarGrilla(ds);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVerPublicaciones_Load(object sender, EventArgs e)
        {
            CargarListadoDePublicaciones();
            CargarListadoDeRubros();

        }

        public void CargarListadoDeRubros()
        {
            lstRubros.Items.Clear();
            DataSet ds = Rubro.obtenerTodas();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Rubro unRubro = new Rubro();
                unRubro.DataRowToObject(dr);
                lstRubros.Items.Add(unRubro);
            }
            lstRubros.DisplayMember = "Descripcion";
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {

                frmDetallePublicGeneral _frmDetalle = new frmDetallePublicGeneral();
                Publicacion unaPublic = new Publicacion(valorIdSeleccionado());
                _frmDetalle.AbrirParaVer(unaPublic, this, unUsuario);
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDePublicacionesConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            CargarListadoDePublicaciones();
        }
    }
}
