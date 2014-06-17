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
using System.Configuration;
namespace FrbaCommerce.Generar_Publicacion
{
    public partial class frmDetallePublic : Form
    {
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        Usuario unUsuario = new Usuario();
        Publicacion publicDelForm = new Publicacion();
        public frmDetallePublic()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaModificarBorrador(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            btnGuardar.Visible = true;
            btnGenerar.Visible = false;

            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();
            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtDescripcion.Enabled = true;

            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;

            dtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();

            txtStock.Text = unaPublic.Stock.ToString();
            btnAumentarStock.Enabled = true;
            btnRestarStock.Enabled = true;


            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbVisibilidad.Enabled = true;

            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            cmbTipo.Enabled = true;

            txtPrecio.Text = unaPublic.Precio.ToString();
            txtPrecio.Enabled = true;

            chkPregs.Checked = unaPublic.Permiso_Preguntas;
            chkPregs.Enabled = true;

            for (int index = 0; index < lstRubros.Items.Count; index++)
            {
                Rubro item = (Rubro)lstRubros.Items[index];
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);
            }
            lstRubros.Enabled = true;
        }

        public void AbrirParaModificarPublicada(Publicacion unaPublic, frmMisPublicaciones frmEnviador)
        {
            btnGuardar.Visible = true;
            btnGenerar.Visible = false;

            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.Show();
            cargarListados();

            txtDescripcion.Text = unaPublic.Descripcion;
            txtDescripcion.Enabled = false;

            cargarEstadosParaEdicionPublicada();
            cmbEstado.SelectedValue = unaPublic.Estado_Publicacion.id_Estado;

            dtFechaCreacion.Text = unaPublic.Fecha_creacion.ToString();
            
            txtStock.Text = unaPublic.Stock.ToString();
            if (unaPublic.Tipo_Publicacion.Nombre == "Subasta")
            {
                btnAumentarStock.Enabled = false;
                btnRestarStock.Enabled = false;
            }


            cmbVisibilidad.SelectedValue = unaPublic.Visibilidad.cod_Visibilidad;
            cmbVisibilidad.Enabled = false;

            cmbTipo.SelectedValue = unaPublic.Tipo_Publicacion.id_Tipo;
            cmbTipo.Enabled = false;
            
            txtPrecio.Text = unaPublic.Precio.ToString();
            txtPrecio.Enabled = false;
            
            chkPregs.Checked = unaPublic.Permiso_Preguntas;
            chkPregs.Enabled = false;

            for (int index=0; index < lstRubros.Items.Count; index++ )
            {
                Rubro item = (Rubro)lstRubros.Items[index];
                if (publicDelForm.Rubros.Any(unRubro => unRubro.Descripcion == item.Descripcion))
                    lstRubros.SetItemChecked(index, true);
                else
                    lstRubros.SetItemChecked(index, false);
            }
            lstRubros.Enabled = false;
        }

        public void AbrirParaGenerar()
        {
            btnGuardar.Visible = false;
            btnGenerar.Visible = true;

            cargarListados();

            txtDescripcion.Text = "";
            txtDescripcion.Enabled = true;

            txtStock.Text = "0";

            dtFechaCreacion.Text = ConfigurationManager.AppSettings["Fecha"];

            btnAumentarStock.Enabled = true;
            btnRestarStock.Enabled = true;

            cmbVisibilidad.Enabled = true;

            cmbTipo.Enabled = true;

            txtPrecio.Text = "";
            txtPrecio.Enabled = true;

            chkPregs.Enabled = true;

            lstRubros.Enabled = true;
        }



        private void cargarEstadosParaEdicionPublicada()
        {
            DataSet ds = Estado_Publicacion.obtenerTodosLosEditablesConPublicada();
            DropDownListManager.CargarCombo(cmbEstado, ds.Tables[0], "id_Estado", "Nombre", false, "");
            
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
            AbrirParaGenerar();
        }

        public void cargarListados()
        {
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
                ValidarCampos();
                publicDelForm.Descripcion = txtDescripcion.Text;
                publicDelForm.Stock = Convert.ToInt32(txtStock.Text);
                publicDelForm.Precio = Convert.ToDecimal(txtPrecio.Text);
                publicDelForm.Visibilidad = new Visibilidad(Convert.ToInt32(cmbVisibilidad.SelectedValue));
                publicDelForm.Fecha_vencimiento = (publicDelForm.Estado_Publicacion.Nombre != "Publicada") ? Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]).AddDays(publicDelForm.Visibilidad.Duracion) : publicDelForm.Fecha_vencimiento;
                publicDelForm.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(cmbTipo.SelectedValue));
                publicDelForm.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(cmbEstado.SelectedValue));
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
            string strErrores = "";
            strErrores += Validator.ValidarNulo(txtDescripcion.Text, "Descripcion");
            strErrores += Validator.SoloNumerosODecimales(txtPrecio.Text, "Precio");
            strErrores += Validator.MayorACero(txtStock.Text, "Stock");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnAumentarStock_Click(object sender, EventArgs e)
        {
            txtStock.Text = (Convert.ToInt32(txtStock.Text) + 1).ToString();
        }

        private void btnRestarStock_Click(object sender, EventArgs e)
        {
            txtStock.Text = (Convert.ToInt32(txtStock.Text) - 1).ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                publicDelForm.Usuario = unUsuario;
                publicDelForm.Descripcion = txtDescripcion.Text;
                publicDelForm.Stock = Convert.ToInt32(txtStock.Text);
                publicDelForm.Precio = Convert.ToDecimal(txtPrecio.Text);
                publicDelForm.Visibilidad = new Visibilidad(Convert.ToInt32(cmbVisibilidad.SelectedValue));
                publicDelForm.Fecha_vencimiento = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]).AddDays(publicDelForm.Visibilidad.Duracion);
                publicDelForm.Tipo_Publicacion = new Tipo_Publicacion(Convert.ToInt32(cmbTipo.SelectedValue));
                publicDelForm.Estado_Publicacion = new Estado_Publicacion(Convert.ToInt32(cmbEstado.SelectedValue));
                foreach (Rubro unRubro in lstRubros.CheckedItems)
                {
                    publicDelForm.Rubros.Add(unRubro);
                }

                publicDelForm.GenerarDatosYRubros();
                DialogResult dr = MessageBox.Show("La publicacion ha sido generada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.AbrirParaGenerar();
                }

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

    }
}
