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
        Item_Factura unItemFactura = new Item_Factura();
        Publicacion unaPublicacion = new Publicacion();
        Forma_Pago formaPago = new Forma_Pago();
        List<Publicacion> listaDePublicacionesARendir = new List<Publicacion>();
        List<Item_Factura> listaDeItemsPorFactura = new List<Item_Factura>();

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmFacturar_Load(object sender, EventArgs e)
        {
            DataSet ds = formaPago.obtengoTodas(); 
            DropDownListManager.CargarCombo(cmbFormaDePago, ds.Tables[0], "Descripcion", "Descripción", false, "");
        }

        public frmFacturar()
        {
            InitializeComponent();
        }

        private void cargarListadoDePublicacionesAFacturar()
        {
            lstPublicacionesARendir.Items.Clear();
            DataSet ds = unaPublicacion.obtenerPublisARendir(unUsuario);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                unaPublicacion.DataRowToObject(dr);
                lstPublicacionesARendir.Items.Add(unaPublicacion);
            }
            lstPublicacionesARendir.DisplayMember = "Codigo";
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (lstPublicacionesARendir.CheckedItems.Equals(null))
            {
                MessageBox.Show("Seleccione una cantidad correcta de publicaciones a facturar", "Error!");
            }
            else
            {
                facturarPublicaciones();
            }

        }

        private void facturarPublicaciones()
        {
            foreach (Publicacion unaPubli in lstPublicacionesARendir.CheckedItems)
            {
                listaDePublicacionesARendir.Add(unaPubli);
                var ds = unItemFactura.obtenerItemsPorPublicacion(unaPubli.Codigo);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Item_Factura  itFact = new Item_Factura();
                    itFact.DataRowToObject(dr);
                    listaDeItemsPorFactura.Add(itFact);
                }
                                 
                foreach(Item_Factura itemFactura in listaDeItemsPorFactura)
                {
                    itemFactura.Monto = (unaPubli.Precio * unaPubli.Visibilidad.Porcentaje) + itemFactura.Monto;
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
            DialogResult dr = MessageBox.Show("¿Confirma que desea facturar " + lstPublicacionesARendir.CheckedItems.Count + " publicación/es?", "Atención", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {            
                Factura factura = new Factura();
                factura.nro_Factura = (factura.obtenerUltimoNumFactura() + 1);
                factura.Fecha = DateTime.Now;
                factura.Forma_Pago = formaPago.obtenerPorId(cmbFormaDePago.SelectedIndex + 1);
                factura.id_Usuario = unUsuario;   
                factura.Precio_Total = listaDeItemsPorFactura.Sum(item => item.Cantidad* item.Monto);

                factura.cargarNuevaFactura();

                foreach(Item_Factura itemF in listaDeItemsPorFactura)
                {
                    itemF.cargarNuevoItemFactura();
                }

                MessageBox.Show("Las publicaciones a rendir han sido facturadas correctamente", "Atencion");
            }

        }

    }
}
