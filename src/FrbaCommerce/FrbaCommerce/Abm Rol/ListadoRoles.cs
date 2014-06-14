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
using FrbaCommerce.Abm_Rol;
using Excepciones;

namespace FrbaCommerce.ABM_Rol
{
    public partial class listadoRoles : Form
    {
        public listadoRoles()
        {
            InitializeComponent();
        }

        private void listadoRoles_Load(object sender, EventArgs e)
        {
            CargarListadoDeRoles();
        }

        private void configurarGrilla(DataSet ds)
        {

            dtgListado.Columns.Clear();
            dtgListado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmID = new DataGridViewTextBoxColumn();
            clmID.Width = 30;
            clmID.ReadOnly = true;
            clmID.DataPropertyName = "id_Rol";
            clmID.HeaderText = "ID";
            dtgListado.Columns.Add(clmID);

            DataGridViewTextBoxColumn clmNombre = new DataGridViewTextBoxColumn();
            clmNombre.ReadOnly = true;
            clmNombre.DataPropertyName = "Nombre";
            clmNombre.HeaderText = "Nombre";
            dtgListado.Columns.Add(clmNombre);

            DataGridViewCheckBoxColumn clmHabilitado = new DataGridViewCheckBoxColumn();
            clmHabilitado.Width = 60;
            clmHabilitado.ReadOnly = true;
            clmHabilitado.DataPropertyName = "Habilitado";
            clmHabilitado.HeaderText = "Habilitado";
            dtgListado.Columns.Add(clmHabilitado);

            dtgListado.DataSource = ds.Tables[0];
        }

        public void CargarListadoDeRoles()
        {

            try
            {
                DataSet ds = Rol.obtenerTodosLosRoles();
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

        public void CargarListadoDeRolesConFiltros()
        {

            try
            {
                DataSet ds = Rol.obtenerTodosLosRolesConFiltros(txtNombre.Text, chkHabilitado.Checked);
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
            frmRol _frmRol = new frmRol();
            Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
            _frmRol.AbrirParaVer(unRol, this);
            
        }

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["id_Rol"]);
        }
        private string valorNombreSeleccionado()
        {
            return ((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Nombre"].ToString();
        }
        private bool valorHabilitadoSeleccionado()
        {
            return Convert.ToBoolean(((DataRowView)dtgListado.CurrentRow.DataBoundItem)["Habilitado"]);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmRol _frmRol = new frmRol();            
            _frmRol.AbrirParaAgregar(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmRol _frmRol = new frmRol();
            Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
            _frmRol.AbrirParaModificar(unRol, this);
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea deshabilitar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                unRol.Deshabilitar();
                MessageBox.Show("El rol ha quedado deshabilitado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoDeRoles();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDeRolesConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            chkHabilitado.Checked = false;
            CargarListadoDeRoles();
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro que desea eliminar el rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    Rol unRol = new Rol(valorIdSeleccionado(), valorNombreSeleccionado(), valorHabilitadoSeleccionado());
                    unRol.Eliminar();
                    MessageBox.Show("El rol ha quedado eliminado", "Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDeRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
