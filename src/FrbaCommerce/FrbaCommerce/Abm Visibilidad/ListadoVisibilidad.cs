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

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class listadoVisibilidad : Form
    {
        public listadoVisibilidad()
        {
            InitializeComponent();
        }



        private decimal valorPorcentajeSeleccionado()
        {
            return Convert.ToDecimal(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Porcentaje"]);
        }

        private decimal valorPrecioSeleccionado()
        {
            return Convert.ToDecimal(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Precio"]);
        }

        private bool valorActivoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Activo"]);
        }

        private string valorDescripcionSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Descripcion"].ToString();
        }

        private int valorCodigoSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["cod_Visibilidad"]);
        }

        public void CargarListadoDeVisibilidades()
        {
            try
            {
                DataSet ds = Visibilidad.obtenerTodasLasVisibilidades();
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

            DataGridViewTextBoxColumn clmCod = new DataGridViewTextBoxColumn();
            clmCod.Width = 60;
            clmCod.ReadOnly = true;
            clmCod.DataPropertyName = "cod_Visibilidad";
            clmCod.HeaderText = "Codigo";
            dtgListado.Columns.Add(clmCod);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripcion";
            dtgListado.Columns.Add(clmDescripcion);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgListado.Columns.Add(clmPrecio);

            DataGridViewTextBoxColumn clmPorcentaje = new DataGridViewTextBoxColumn();
            clmPorcentaje.ReadOnly = true;
            clmPorcentaje.DataPropertyName = "Porcentaje";
            clmPorcentaje.HeaderText = "Porcentaje";
            dtgListado.Columns.Add(clmPorcentaje);

            DataGridViewCheckBoxColumn clmActivo = new DataGridViewCheckBoxColumn();
            clmActivo.Width = 60;
            clmActivo.ReadOnly = true;
            clmActivo.DataPropertyName = "Activo";
            clmActivo.HeaderText = "Activo";
            dtgListado.Columns.Add(clmActivo);

            dtgListado.DataSource = ds.Tables[0];
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void listadoVisibilidad_Load(object sender, EventArgs e)
        {
            CargarListadoDeVisibilidades();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtPorcentaje.Text = "";
            txtPrecio.Text = "";
            chkActivo.Checked = false;
            CargarListadoDeVisibilidades();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDeVisibilidadesConFiltros();
        }

        private void CargarListadoDeVisibilidadesConFiltros()
        {
            try
            {
                DataSet ds = Visibilidad.obtenerTodasLasVisibilidadesConFiltros(txtDescripcion.Text, txtPrecio.Text, txtPorcentaje.Text,chkActivo.Checked);
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            frmVisibilidad _frmVisibilidad = new frmVisibilidad();
            Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorActivoSeleccionado());
            _frmVisibilidad.AbrirParaVer(unaVisibilidad, this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmVisibilidad _frmVisibilidad = new frmVisibilidad();
            Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorActivoSeleccionado());
            _frmVisibilidad.AbrirParaModificar(unaVisibilidad, this);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea desactivar la visibilidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Visibilidad unaVisibilidad = new Visibilidad(valorCodigoSeleccionado(), valorDescripcionSeleccionado(), valorPrecioSeleccionado(), valorPorcentajeSeleccionado(), valorActivoSeleccionado());
                unaVisibilidad.Deshabilitar();
                MessageBox.Show("La visibilidad ha quedado desactivada", "Desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeVisibilidades();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmVisibilidad _frmVisib = new frmVisibilidad();
            _frmVisib.AbrirParaAgregar(this);
        }
    }
}
