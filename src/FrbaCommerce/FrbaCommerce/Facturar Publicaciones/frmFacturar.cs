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


namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class frmFacturar : Form
    {
        public Usuario unUsuario = new Usuario();
        List<Publicacion> listaDePublicacionesARendir = new List<Publicacion>();
        List<Publicacion> listaDePublicacionesAFacturar = new List<Publicacion>();
        List<Item_Factura> listaDeItemsPorFactura = new List<Item_Factura>();

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmFacturar_Load(object sender, EventArgs e)
        {
            DataSet ds = Forma_Pago.obtengoTodas(); 
            DropDownListManager.CargarCombo(cmbFormaDePago, ds.Tables[0], "id_Forma_Pago", "Descripcion", false, "");
            cargarListadoDePublicacionesAFacturar();
        }

        public frmFacturar()
        {
            InitializeComponent();
        }

        private void cargarListadoDePublicacionesAFacturar()
        {
            try
            {
                DataSet ds = Publicacion.obtenerPublisARendir(unUsuario);
                configurarGrillaPublicacionesAFacturar(ds);
                llenarListadoDePublicaciones(ds);
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

        private void configurarGrillaPublicacionesAFacturar(DataSet ds)
        {
            dtgPublicacionesARendir.Columns.Clear();
            dtgPublicacionesARendir.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCod = new DataGridViewTextBoxColumn();
            clmCod.Width = 65;
            clmCod.ReadOnly = true;
            clmCod.DataPropertyName = "Codigo";
            clmCod.HeaderText = "Código";
            dtgPublicacionesARendir.Columns.Add(clmCod);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.Width = 130;
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripción";
            dtgPublicacionesARendir.Columns.Add(clmDescripcion);

            DataGridViewTextBoxColumn clmStock = new DataGridViewTextBoxColumn();
            clmStock.Width = 60;
            clmStock.ReadOnly = true;
            clmStock.DataPropertyName = "Stock";
            clmStock.HeaderText = "Stock";
            dtgPublicacionesARendir.Columns.Add(clmStock);

            DataGridViewTextBoxColumn clmFechaCreacion = new DataGridViewTextBoxColumn();
            clmFechaCreacion.Width = 80;
            clmFechaCreacion.ReadOnly = true;
            clmFechaCreacion.DataPropertyName = "Fecha_Creacion";
            clmFechaCreacion.HeaderText = "Fecha Creación";
            dtgPublicacionesARendir.Columns.Add(clmFechaCreacion);

            DataGridViewTextBoxColumn clmFechaVencimiento = new DataGridViewTextBoxColumn();
            clmFechaVencimiento.Width = 80;
            clmFechaVencimiento.ReadOnly = true;
            clmFechaVencimiento.DataPropertyName = "Fecha_Creacion";
            clmFechaVencimiento.HeaderText = "Fecha Creación";
            dtgPublicacionesARendir.Columns.Add(clmFechaVencimiento);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.Width = 60;
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgPublicacionesARendir.Columns.Add(clmPrecio);

            dtgPublicacionesARendir.DataSource = ds.Tables[0];
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                facturarPublicaciones();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void ValidarCampos()
        {
            string strErrores = "";
            strErrores += Validator.SoloNumeros(txtCantidad.Text, "Cantidad");
            strErrores += Validator.ValidarNulo(txtCantidad.Text, "Cantidad");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void llenarListadoDePublicaciones(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Publicacion unaPub = new Publicacion();
                unaPub.DataRowToObject(dr);
                listaDePublicacionesAFacturar.Add(unaPub);
            }

            if (listaDePublicacionesAFacturar.Count > 10) unUsuario.Deshabilitar();

            if (listaDePublicacionesAFacturar.Count == 0)
            {
                MessageBox.Show("No tiene ninguna publicación pendiente para facturar", "Atención!");
                this.Close();
            }                   
        }

        private void facturarPublicaciones()
        {
            for (var a = 0; a <= Convert.ToInt16(txtCantidad.Text) - 1; a++)
            {
                listaDePublicacionesARendir.Add(listaDePublicacionesAFacturar[a]);
            }
            
            foreach (Publicacion unaPubli in listaDePublicacionesARendir)
            {
                int cantidadCompras = Compra.obtenerCantidadPorUsuario(unaPubli.Codigo);
               
                for (int a = 0; a <= cantidadCompras; a++)
                {
                    Item_Factura itFact = new Item_Factura();
                    itFact.Publicacion = unaPubli;
                    itFact.Cantidad = cantidadCompras;
                    itFact.Monto = (unaPubli.Precio * unaPubli.Visibilidad.Porcentaje) ;

                    listaDeItemsPorFactura.Add(itFact);
                }
                                 
                Item_Factura itemPublicacion = new Item_Factura();
                itemPublicacion.Publicacion = unaPubli;
                itemPublicacion.Monto = unaPubli.Visibilidad.Precio;
                itemPublicacion.Cantidad = 1;
                listaDeItemsPorFactura.Add(itemPublicacion);

                armarFactura();

            }
        }
  
        private void armarFactura()
        {
            DialogResult dr = MessageBox.Show("¿Confirma que desea facturar " + txtCantidad.Text + " publicación/es?", "Atención", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {            
                Factura factura = new Factura();
                factura.Fecha = DateTime.Now;
                factura.Forma_Pago = Forma_Pago.obtenerPorId(cmbFormaDePago.SelectedIndex + 1);
                factura.id_Usuario = unUsuario;   
                factura.Precio_Total = listaDeItemsPorFactura.Sum(item => item.Cantidad* item.Monto);

                int nroFact = factura.GuardarYObtenerID();

                foreach(Item_Factura itemF in listaDeItemsPorFactura)
                {
                    itemF.nro_Factura = nroFact;
                    itemF.cargarNuevoItemFactura();
                }

                MessageBox.Show("Las publicaciones a rendir han sido facturadas correctamente", "Atencion");
                cargarListadoDePublicacionesAFacturar();
                txtCantidad.Clear();
            }

        }

    }
}
