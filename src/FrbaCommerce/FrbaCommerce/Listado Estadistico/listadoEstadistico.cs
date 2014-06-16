﻿using System;
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

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class listadoEstadistico : Form
    {
        Usuario unUsuario = new Usuario();
        private DateTime Fecha_Hasta;
        private DateTime Fecha_Desde;
        private string Año;
        private string Mes;
        private string GradoVisibilidad;
       
        private void listadoEstadistico_Load(object sender, EventArgs e)
        {
            configuracionInicial();
        }

        public void configuracionInicial()
        {
            lblAño.Visible = true;
            txtAño.Visible = true;
            btnVer.Visible = false;
            btnSeleccionar.Visible = false;
            lblTrimestre.Visible = false;
            cmbTrimestre.Visible = false;
            cmbListado.Visible = false;
            grpFiltros.Visible = false;
            dtgTop5.Visible = false;
        }

        public listadoEstadistico()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    ValidarCampos();
                    Año = txtAño.Text;
                    lblTrimestre.Visible = true;
                    cmbTrimestre.Visible = true;
                    cmbTrimestre.SelectedIndex = 0;
                    btnSeleccionar.Visible = true;
                }

                catch (Exception ex)
                {
                    configuracionInicial();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    
                }

            }
        }

        private void ValidarCampos()
        {
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtAño.Text, "Año");
            strErrores += Validator.SoloNumeros(txtAño.Text, "Año");
            strErrores += Validator.EsAño(txtAño.Text, "Año");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Mes = txtMes.Text;
            GradoVisibilidad = txtVisibilidad.Text;
            cargarListadoDeVendedoresConMayorCantProdNoVendidosConFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtVisibilidad.Text = "";
            txtMes.Text = "";
            cargarListadoDeVendedoresConMayorCantProdNoVendidos();
        }
        
        private void cargarListadoDeVendedoresConMayorCantProdNoVendidos()
        {
            try
            {
                DataSet ds = unUsuario.obtenerVendedoresConMayorCantProdNoVendidos(Fecha_Hasta, Fecha_Desde, Año);
                configurarGrillaVendedoresMayorCantPubliNoVendidas(ds);
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

        private void cargarListadoDeVendedoresConMayorCantProdNoVendidosConFiltros()
        {
            try
            {
                DataSet ds = unUsuario.obtenerVendedoresConMayorCantProdNoVendidosConFiltros(Fecha_Hasta, Fecha_Desde, Año, Mes, GradoVisibilidad);
                configurarGrillaVendedoresMayorCantPubliNoVendidas(ds);
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

        private void cargarListadoDeVendedoresConMayorFacturacion()
        {
            try
            {
                DataSet ds = unUsuario.obtenerVendedoresConMayorFacturacion(Fecha_Hasta, Fecha_Desde, Año);
                configurarGrillaVendedoresMayorFacturacion(ds);
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

        private void cargarListadoDeVendedoresConMayorCalificacion()
        {
            try
            {
                DataSet ds = unUsuario.obtenerVendedoresMayorCalificacion(Fecha_Hasta, Fecha_Desde, Año);
                configurarGrillaVendedoresMayorCalificacion(ds);
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

        private void cargarListadoDeClientesConMayorCantPubliSinClasificar()
         {
             try
             {
                 DataSet ds = unUsuario.obtenerClientesMayorCantPubliSinClasificar(Fecha_Hasta, Fecha_Desde, Año);
                 configurarGrillaVendedoresMayorPubliSinClasificar(ds);
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

        private void configurarGrillaVendedoresMayorCantPubliNoVendidas(DataSet ds)
        {
            dtgTop5.Columns.Clear();
            dtgTop5.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 120;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgTop5.Columns.Add(clmVendedor);

            DataGridViewTextBoxColumn clmCantPubliNoVendidas = new DataGridViewTextBoxColumn();
            clmCantPubliNoVendidas.Width = 200;
            clmCantPubliNoVendidas.ReadOnly = true;
            clmCantPubliNoVendidas.DataPropertyName = "CantPublicNoVendidos";
            clmCantPubliNoVendidas.HeaderText = "Cantidad de Publicaciones no vendidas";
            dtgTop5.Columns.Add(clmCantPubliNoVendidas);

            dtgTop5.DataSource = ds.Tables[0];
        }

        private void configurarGrillaVendedoresMayorFacturacion(DataSet ds)
        {
            dtgTop5.Columns.Clear();
            dtgTop5.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 120;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgTop5.Columns.Add(clmVendedor);

            DataGridViewTextBoxColumn clmFacturacion = new DataGridViewTextBoxColumn();
            clmFacturacion.Width = 200;
            clmFacturacion.ReadOnly = true;
            clmFacturacion.DataPropertyName = "Facturacion";
            clmFacturacion.HeaderText = "Facturacion";
            dtgTop5.Columns.Add(clmFacturacion);

            dtgTop5.DataSource = ds.Tables[0];
        }

        private void configurarGrillaVendedoresMayorCalificacion(DataSet ds)
        {
            dtgTop5.Columns.Clear();
            dtgTop5.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmVendedor = new DataGridViewTextBoxColumn();
            clmVendedor.Width = 120;
            clmVendedor.ReadOnly = true;
            clmVendedor.DataPropertyName = "Vendedor";
            clmVendedor.HeaderText = "Vendedor";
            dtgTop5.Columns.Add(clmVendedor);

            DataGridViewTextBoxColumn clmFacturacion = new DataGridViewTextBoxColumn();
            clmFacturacion.Width = 200;
            clmFacturacion.ReadOnly = true;
            clmFacturacion.DataPropertyName = "PromedioCalificaciones";
            clmFacturacion.HeaderText = "Promedio de Califiaciones";
            dtgTop5.Columns.Add(clmFacturacion);

            dtgTop5.DataSource = ds.Tables[0];
        }

        private void configurarGrillaVendedoresMayorPubliSinClasificar(DataSet ds)
        {
            dtgTop5.Columns.Clear();
            dtgTop5.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmCliente = new DataGridViewTextBoxColumn();
            clmCliente.Width = 120;
            clmCliente.ReadOnly = true;
            clmCliente.DataPropertyName = "Cliente";
            clmCliente.HeaderText = "Cliente";
            dtgTop5.Columns.Add(clmCliente);

            DataGridViewTextBoxColumn clmCantPubliSinClasificar = new DataGridViewTextBoxColumn();
            clmCantPubliSinClasificar.Width = 200;
            clmCantPubliSinClasificar.ReadOnly = true;
            clmCantPubliSinClasificar.DataPropertyName = "CantPubliSinClasificar";
            clmCantPubliSinClasificar.HeaderText = "Cantidad publicaciones sin clasificar";
            dtgTop5.Columns.Add(clmCantPubliSinClasificar);

            dtgTop5.DataSource = ds.Tables[0];
        }

        private void configuracionListadoVisible()
        {
            dtgTop5.Visible = true;
        }

        private void configuracionTop5Visible()
        {
            cmbListado.Visible = true;
            cmbListado.SelectedIndex = 0;
            btnVer.Visible = true;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (cmbTrimestre.SelectedIndex == 0) cargarParametrosPrimerTrimestre();
            if (cmbTrimestre.SelectedIndex == 1) cargarParametrosSegundoTrimestre();
            if (cmbTrimestre.SelectedIndex == 2) cargarParametrosTercerTrimestre();
            if (cmbTrimestre.SelectedIndex == 3) cargarParametrosCuartoTrimestre();
            configuracionTop5Visible();
        }

        private void cargarParametrosCuartoTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 10, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 12, 31); 
        }

        private void cargarParametrosSegundoTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 4, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 6, 30); 
        }

        private void cargarParametrosTercerTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 7, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 9, 30); 
        }

        private void cargarParametrosPrimerTrimestre()
        {
            Fecha_Desde = new DateTime(Convert.ToInt32(Año), 1, 1);
            Fecha_Hasta = new DateTime(Convert.ToInt32(Año), 3, 31); 
        }

        private void btnVer_Click_1(object sender, EventArgs e)
        {
            if (cmbListado.SelectedIndex == 0)
            {
                grpFiltros.Visible = true;
                cargarListadoDeVendedoresConMayorCantProdNoVendidos();
            }
            if (cmbListado.SelectedIndex == 1)
            {
                grpFiltros.Visible = false;
                cargarListadoDeVendedoresConMayorFacturacion();
            }
            if (cmbListado.SelectedIndex == 2)
            {
                grpFiltros.Visible = false;
                cargarListadoDeVendedoresConMayorCalificacion();
            }
            if (cmbListado.SelectedIndex == 3)
            {
                grpFiltros.Visible = false;
                cargarListadoDeClientesConMayorCantPubliSinClasificar();
            }
            configuracionListadoVisible();
        }
              
    }
}
