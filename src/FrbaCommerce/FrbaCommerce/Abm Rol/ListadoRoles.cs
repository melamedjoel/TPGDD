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

        private void CargarListadoDeRoles()
        {
            dtgListado.Columns.Clear();

            try
            {
                DataSet ds = Rol.obtenerTodosLosRoles();

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
    }
}
