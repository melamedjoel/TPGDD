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

        private void subastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubasta _frmSubasta = new frmSubasta();
            _frmSubasta.abrirConUsuario(unUsuario);
        }

        private void compraInmediataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompraInmediata _frmCompra = new frmCompraInmediata();
            _frmCompra.abrirConUsuario(unUsuario);
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

    }
}
