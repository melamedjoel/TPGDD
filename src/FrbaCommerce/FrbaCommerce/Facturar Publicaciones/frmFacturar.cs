﻿using System;
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
        List<Compra> listaDeComprasPorCodPubli = new List<Compra>();

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmFacturar_Load(object sender, EventArgs e)
        {  
            //cargo el Combo Box correspondiente a forma de pago con todas las descripciones posibles de la tabla
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
                //obtengo todas las publicaciones a rendir segun el usuario
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
            clmFechaVencimiento.DataPropertyName = "Fecha_vencimiento";
            clmFechaVencimiento.HeaderText = "Fecha Vencimiento";
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
            //valido que lo ingresado en el campo cantidad no sea distinto a un número ni null
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
            //por cada publicacion a rendir del usuario en el DataSet la convierto a objeto y la sumo a la lista de publicaciones de tipo Publicacion
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Publicacion unaPub = new Publicacion();
                unaPub.DataRowToObject(dr);
                listaDePublicacionesAFacturar.Add(unaPub);
            }

            //si el usuario tiene mas de 10 publicaciones a facturar pendientes, se lo dehabilita
            if (listaDePublicacionesAFacturar.Count > 10) unUsuario.Deshabilitar();

            //si la lista que arme antes está vacia, entonces el usuario no tiene ninguna publicacion a facturar
            if (listaDePublicacionesAFacturar.Count == 0)
            {
                MessageBox.Show("No tiene ninguna publicación pendiente para facturar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }                   
        }

        private void facturarPublicaciones()
        {
            //de acuerdo a la cantidad de publicaciones que el usuario quiere rendir, se llena una lista auxiliar con las mismas
            for (var a = 0; a <= (Convert.ToInt32(txtCantidad.Text) - 1); a++)
            {
                listaDePublicacionesARendir.Add(listaDePublicacionesAFacturar[a]);
            }

            foreach (Publicacion unaPubli in listaDePublicacionesARendir)
            {
                //por cada publicacion de la lista, se obtienen las compras que se realizaron de las mismas
                // y se las convierte en objeto y se las guarda en una lista
                DataSet ds = Compra.obtenerComprasPorCodPubli(unaPubli.Codigo);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Compra unaCompra = new Compra();
                    unaCompra.DataRowToObject(dr);
                    listaDeComprasPorCodPubli.Add(unaCompra);
                }


                foreach (Compra unaCompra in listaDeComprasPorCodPubli)
                {
                    //cada compra que se realizo de esa publicacion va a ser un nuevo item en la factura
                    Item_Factura itFact = new Item_Factura();
                    itFact.Publicacion = unaPubli;
                    itFact.Cantidad = unaCompra.Cantidad;
                    //el monto del item (comisión) corresponde al precio de esa publicación por el porcentaje
                    //visibilidad por la cantidad de compras que se hicieron
                    itFact.Monto = (unaPubli.Precio * unaPubli.Visibilidad.Porcentaje) * unaCompra.Cantidad;

                    listaDeItemsPorFactura.Add(itFact);
                }

                //el último item factura es el de la publicación en si misma según su costo de visibilidad  
                Item_Factura itemPublicacion = new Item_Factura();
                itemPublicacion.Publicacion = unaPubli;
                itemPublicacion.Monto = unaPubli.Visibilidad.Precio;
                itemPublicacion.Cantidad = 1;
                listaDeItemsPorFactura.Add(itemPublicacion);

            }

            armarFactura();
        }
  
        private void armarFactura()
        {
            DialogResult dr = MessageBox.Show("¿Confirma que desea facturar " + txtCantidad.Text + " publicación/es?", "Atención", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {    
                //se crea y arma la factura
                Factura factura = new Factura();
                factura.Fecha = DateTime.Now;
                //la forma de pago de la factura es de acuerdo a lo que el usuario seleccionó en el combo Box
                factura.Forma_Pago = Forma_Pago.obtenerPorId(cmbFormaDePago.SelectedIndex + 1);
                factura.id_Usuario = unUsuario;
                //el precio total equivale a la suma de todos los montos de los items de esa factura
                factura.Precio_Total = listaDeItemsPorFactura.Sum(item => item.Monto);

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
