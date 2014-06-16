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

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class vendedoresSinCalificar : Form
    {
        Usuario unUsuario = new Usuario();
        public vendedoresSinCalificar()
        {
            InitializeComponent();
        }
        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void calificar_Load(object sender, EventArgs e)
        {
            cargarListadoVendedoresSinCalificar();
        }
        private void configurarGrilla(DataSet ds)
        {

            dtgVendedoresSinCalificar.Columns.Clear();
            dtgVendedoresSinCalificar.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCodPublicacion = new DataGridViewTextBoxColumn();
            clmCodPublicacion.Visible = false;
            clmCodPublicacion.ReadOnly = true;
            clmCodPublicacion.DataPropertyName = "cod_Publicacion";
            clmCodPublicacion.HeaderText = "Cod_Publ";
            dtgVendedoresSinCalificar.Columns.Add(clmCodPublicacion);

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 30;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgVendedoresSinCalificar.Columns.Add(clmVendedor);
            
            DataGridViewTextBoxColumn clmTipoPublicacion = new DataGridViewTextBoxColumn();
            clmTipoPublicacion.ReadOnly = true;
            clmTipoPublicacion.DataPropertyName = "Nombre";
            clmTipoPublicacion.HeaderText = "Tipo de Publicacion";
            dtgVendedoresSinCalificar.Columns.Add(clmTipoPublicacion);

            DataGridViewTextBoxColumn clmPublicacion = new DataGridViewTextBoxColumn();
            clmPublicacion.Width = 30;
            clmPublicacion.ReadOnly = true;
            clmPublicacion.DataPropertyName = "Descripcion";
            clmPublicacion.HeaderText = "Publicacion";
            dtgVendedoresSinCalificar.Columns.Add(clmPublicacion);

            DataGridViewTextBoxColumn clmFecha = new DataGridViewTextBoxColumn();
            clmFecha.ReadOnly = true;
            clmFecha.DataPropertyName = "Fecha";
            clmFecha.HeaderText = "Fecha";
            dtgVendedoresSinCalificar.Columns.Add(clmFecha);

            dtgVendedoresSinCalificar.DataSource = ds.Tables[0];
            dtgVendedoresSinCalificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            agregarBotonCalificar();
        }

        private void agregarBotonCalificar()
        {
            var nuevaClm = new DataGridViewButtonColumn
            {
                Text = "Calificar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dtgVendedoresSinCalificar.Columns.Add(nuevaClm);
        }
        private void dtgVendedoresSinCalificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
                return;
            
            calificarVendedor _frmCalificarVendedor = new calificarVendedor();
            _frmCalificarVendedor.AbrirParaCalificar(this, unUsuario.Id_Usuario, valorCodSeleccionado());
        }
        public void cargarListadoVendedoresSinCalificar()
        {
            try
            {
                DataSet ds = unUsuario.obtenerVendedoresSinCalificar();
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

        private int valorCodSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgVendedoresSinCalificar.CurrentRow.DataBoundItem)["cod_Publicacion"]);
        }

        
    }
}
