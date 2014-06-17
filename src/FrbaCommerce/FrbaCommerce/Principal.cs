using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conexion;
using Clases;
using Utilities;
using FrbaCommerce.ABM_Rol;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Historial_Cliente;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Listado_Estadistico;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Comprar_Ofertar;
using FrbaCommerce.Facturar_Publicaciones;
using FrbaCommerce.Calificar_Vendedor;
	
namespace FrbaCommerce
{
    public partial class Principal : Form
    {
        public Usuario unUsuario = new Usuario();

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void ABMRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoRoles frmListadoRoles = new listadoRoles();
            frmListadoRoles.Show(this);
        }


        private void AbmEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoEmpresa frmListadoEmpresas = new listadoEmpresa();
            frmListadoEmpresas.Show(this);
        }

        private void AbmVisiblidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoVisibilidad frmListadoVisibilidad = new listadoVisibilidad();
            frmListadoVisibilidad.Show(this);
        }

        private void historialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           listadoHistorialDeOperaciones frmListadoHistorial = new listadoHistorialDeOperaciones();
           frmListadoHistorial.abrirConUsuario(unUsuario);           
        }


        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        
        private void listadoEstadísticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoEstadistico frmListadoEstadistico = new listadoEstadistico();
            frmListadoEstadistico.abrirConUsuario(unUsuario);
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoCliente frmListadoClientes = new listadoCliente();
            frmListadoClientes.Show(this);
        }

        private void misPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMisPublicaciones misPublic = new frmMisPublicaciones();
            misPublic.abrirConUsuario(unUsuario);
        }

        private void verPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerPublicaciones lasPublic = new frmVerPublicaciones();
            lasPublic.abrirConUsuario(unUsuario);
        }

        private void facturarPublicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturar frmFacturarPublicaciones = new frmFacturar();
            frmFacturarPublicaciones.abrirConUsuario(unUsuario);
        }

        private void calificarVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendedoresSinCalificar frmListadoVendedores = new vendedoresSinCalificar();
            frmListadoVendedores.abrirConUsuario(unUsuario);
        }

        private void generarPublicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetallePublic frmDetalle = new frmDetallePublic();
            frmDetalle.abrirConUsuario(unUsuario);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicial frmInicial = new Inicial();
            frmInicial.Show();
            this.Close();
        }

    }
}
