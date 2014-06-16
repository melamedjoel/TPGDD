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
        Dictionary<int, Publicacion> publicaciones = new Dictionary<int, Publicacion>();
        List<Publicacion> listaDePubs = new List<Publicacion>();
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
                llenarPublicaciones(ds);
                configurarGrilla();
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

        private void llenarPublicaciones(DataSet ds)
        {
            listaDePubs.Clear();
            publicaciones.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Publicacion unaPub = new Publicacion();
                unaPub.DataRowToObject(dr);
                listaDePubs.Add(unaPub);
            }

            publicaciones = listaDePubs.ToDictionary(unaPub => unaPub.Codigo, unaPub => unaPub);
        }

        private void configurarGrilla()
        {
            dtgListado.Columns.Clear();

            var listadoABindear = publicaciones.Values.Select(unaPub => new
            {
                Codigo = unaPub.Codigo,
                Descripcion = unaPub.Descripcion,
                Creacion = unaPub.Fecha_creacion,
                Vencimiento = unaPub.Fecha_vencimiento,
                Stock = unaPub.Stock,
                Precio = unaPub.Precio,
                Preguntas = unaPub.Permiso_Preguntas,
                Tipo = unaPub.Tipo_Publicacion.Nombre,
                Visibilidad = unaPub.Visibilidad.Descripcion,
                Rubros = unaPub.obtenerRubrosEnTexto()
            });

            dtgListado.DataSource = listadoABindear.ToList();
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            agregarBotonVer();

        }

        private void agregarBotonVer()
        {
            var nuevaClm = new DataGridViewButtonColumn
            {
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dtgListado.Columns.Add(nuevaClm);
        }



        public void CargarListadoDePublicacionesConFiltros()
        {
            try
            {
                string filtroDeRubros = "";
                foreach (Rubro unRubro in lstRubros.CheckedItems)
                {
                    filtroDeRubros += unRubro.Descripcion;
                }
                DataSet ds = Publicacion.obtenerTodasConFiltros(Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]),txtDescripcion.Text, filtroDeRubros);
                llenarPublicaciones(ds);
                configurarGrilla();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarListadoDePublicacionesConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            while (lstRubros.CheckedIndices.Count > 0)
            {
                lstRubros.SetItemChecked(lstRubros.CheckedIndices[0], false);
            }
            CargarListadoDePublicaciones();
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //10 es la columna que contiene el boton de ver, las demas no deberian tener accion alguna
            if (e.ColumnIndex != 10)
                return;

            Publicacion unaPub = listaDePubs.Find(pub => pub.Codigo == (int)dtgListado.Rows[e.RowIndex].Cells[0].Value);
            frmDetallePublicGeneral _frmDetalle = new frmDetallePublicGeneral();
            _frmDetalle.AbrirParaVer(unaPub, this, unUsuario);
        }
    }
}
