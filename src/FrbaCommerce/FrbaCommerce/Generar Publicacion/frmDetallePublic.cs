using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Excepciones;
using Utilities;
using FrbaCommerce.Editar_Publicacion;
namespace FrbaCommerce.Generar_Publicacion
{
    public partial class frmDetallePublic : Form
    {
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        Publicacion publicDelForm = new Publicacion();
        public frmDetallePublic()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDePublicaciones();
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaModificarBorrador(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();

            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;
            txtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            dtVencimiento.Text = unaPublic.Fecha_vencimiento.ToString();
            txtStock.Text = unaPublic.Stock.ToString();
            txtUsuario.Text = unaPublic.Usuario.Username;
            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            txtPrecio.Text = unaPublic.Precio.ToString();
            chkPregs.Checked = unaPublic.Permiso_Preguntas;
            int index = 0;
            foreach (Rubro item in lstRubros.Items)
            {
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);

                index++;
            }
        }

        public void AbrirParaModificarPublicada(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();

            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;
            txtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            dtVencimiento.Text = unaPublic.Fecha_vencimiento.ToString();
            txtStock.Text = unaPublic.Stock.ToString();
            txtUsuario.Text = unaPublic.Usuario.Username;
            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            txtPrecio.Text = unaPublic.Precio.ToString();
            chkPregs.Checked = unaPublic.Permiso_Preguntas;

            for (int index=0; index < lstRubros.Items.Count; index++ )
            {
                Rubro item = (Rubro)lstRubros.Items[index];
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);

            }
        }

        public void AbrirParaModificarPausada(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();

            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;
            txtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            dtVencimiento.Text = unaPublic.Fecha_vencimiento.ToString();
            txtStock.Text = unaPublic.Stock.ToString();
            txtUsuario.Text = unaPublic.Usuario.Username;
            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            txtPrecio.Text = unaPublic.Precio.ToString();
            chkPregs.Checked = unaPublic.Permiso_Preguntas;

            int index = 0;
            foreach (Rubro item in lstRubros.Items)
            {
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);

                index++;
            }

        }


        private void frmDetallePublic_Load(object sender, EventArgs e)
        {

        }


        public void cargarListados()
        {
            cmbEstado.Items.Clear();
            cmbTipo.Items.Clear();
            cmbVisibilidad.Items.Clear();
            cargarTipos();
            cargarEstados();
            cargarVisibilidades();
            cargarRubros();
        }
        private void cargarVisibilidades()
        {
            DataSet ds = Visibilidad.obtenerTodasLasVisibilidades();
            DropDownListManager.CargarCombo(cmbVisibilidad, ds.Tables[0], "cod_Visibilidad", "Descripcion", false, "");
        }

        private void cargarEstados()
        {
            DataSet ds = Estado_Publicacion.obtenerTodos();
            DropDownListManager.CargarCombo(cmbEstado, ds.Tables[0], "id_Estado", "Nombre", false, "");
        }

        private void cargarTipos()
        {
            DataSet ds = Tipo_Publicacion.obtenerTodos();
            DropDownListManager.CargarCombo(cmbTipo, ds.Tables[0], "id_Tipo", "Nombre", false, "");
        }
        
        public void cargarRubros()
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //ValidarCampos();
                publicDelForm.Descripcion = txtDescripcion.Text;
                publicDelForm.Stock = Convert.ToInt32(txtStock.Text);
                publicDelForm.Precio = Convert.ToDecimal(txtPrecio.Text);
                publicDelForm.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(cmbTipo.SelectedValue));
                publicDelForm.Visibilidad = new Visibilidad(Convert.ToInt32(cmbVisibilidad.SelectedValue));
                publicDelForm.Fecha_vencimiento = Convert.ToDateTime(dtVencimiento.Text);
                publicDelForm.Rubros.Clear();
                foreach (Rubro unRubro in lstRubros.CheckedItems)
                {
                    publicDelForm.Rubros.Add(unRubro);
                }

                publicDelForm.ModificarDatosYRubros();
                DialogResult dr = MessageBox.Show("La publicacion ha sido modificada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    frmPadre.BringToFront();
                }

                frmPadre.CargarListadoDePublicaciones();
            }
            catch (ErrorConsultaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadInsertException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos()
        {
            throw new NotImplementedException();
        }

        private void btnAumentarStock_Click(object sender, EventArgs e)
        {
            txtStock.Text = (Convert.ToInt32(txtStock.Text) + 1).ToString();
        }

        private void btnRestarStock_Click(object sender, EventArgs e)
        {
            txtStock.Text = (Convert.ToInt32(txtStock.Text) - 1).ToString();
        }

    }
}
