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
using System.Configuration;
namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class frmDetallePublicGeneral : Form
    {
        frmVerPublicaciones frmPadre = new frmVerPublicaciones();
        Publicacion publicDelForm = new Publicacion();
        Usuario unUsuario = new Usuario();
        public frmDetallePublicGeneral()
        {
            InitializeComponent();
        }

        public void AbrirParaVer(Publicacion unaPublic, frmVerPublicaciones frmEnviador, Usuario user)
        {
            frmPadre = frmEnviador;
            publicDelForm = unaPublic;

            this.abrirConUsuario(user);

            lblDescripcionACompletar.Text = unaPublic.Descripcion;
            lblFechaCreacionACompletar.Text = unaPublic.Fecha_creacion.ToString();
            lblFechaVencimientoACompletar.Text = unaPublic.Fecha_vencimiento.ToString();
            lblStockACompletar.Text = unaPublic.Stock.ToString();
            lblUsuarioACompletar.Text = unaPublic.Usuario.Username;
            lblTipoACompletar.Text = unaPublic.Tipo_Publicacion.Nombre;
            lblPrecioACompletar.Text = unaPublic.Precio.ToString();
            if (puedeComprarUOfertar())
            {
                grpPreguntas.Visible = unaPublic.Permiso_Preguntas;
                if (publicDelForm.Tipo_Publicacion.Nombre == "Subasta")
                {
                    btnComprar.Visible = false;
                    btnOfertar.Visible = true;
                }
                else
                {
                    btnComprar.Visible = true;
                    btnOfertar.Visible = false;
                }
            }

        }

        private bool puedeComprarUOfertar()
        {
            return (unUsuario.Rol.Nombre == "Cliente");
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private void frmDetallePublicGeneral_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            frmPadre.Show();
            this.Close();
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarAutoCompra();
                string montoOfertado = "";
                while (montoOfertado == "")
                {
                    montoOfertado = DialogManager.ShowDialogCommonText("Por favor, ingrese un monto a ofertar", "Ofertar");

                    if (string.IsNullOrEmpty(montoOfertado))
                    {
                        MessageBox.Show("Debe ingresar un monto válido", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (montoOfertado != "cancel")
                    {
                        string error = ValidarMontoOfertado(montoOfertado);
                        if (error != "")
                        {
                            MessageBox.Show(error, "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            montoOfertado = "";
                        }else{
                            Oferta nuevaOferta = new Oferta(Convert.ToDecimal(montoOfertado), Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]) ,publicDelForm, unUsuario);
                            nuevaOferta.guardarNuevaOferta();
                            MessageBox.Show("La oferta ha sido realizada", "Oferta realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private string ValidarMontoOfertado(string montoOfertado)
        {
            string strErrores = "";
            strErrores += (publicDelForm.Precio >= Convert.ToDecimal(montoOfertado)) ? "No se puede realizar esta acción dado que el precio de la subasta es mayor al ingresado" : "";
            if (strErrores.Length > 0)
            {
                return strErrores;
            }
            return "";
            
        }

        private void ValidarAutoCompra()
        {
            string strErrores = "";
            strErrores += (publicDelForm.Usuario.Id_Usuario == unUsuario.Id_Usuario) ? "No se puede realizar esta acción sobre su propia publicación" : "";
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            DetalleVendedorParaComprar frmDetalleVendedor = new DetalleVendedorParaComprar();
            Cliente unCli = new Cliente(publicDelForm.Usuario);
            if (unCli.id_Cliente ==0)
                frmDetalleVendedor.abrirConEmpresaComoVendedor(unUsuario, this, publicDelForm, frmPadre);
            else
                frmDetalleVendedor.abrirConClienteComoVendedor(unUsuario, this, publicDelForm, frmPadre);

        }

        private void btnRegistrarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
                string pregunta = txtPreguntas.Text;

                Pregunta unaPregunta = new Pregunta(pregunta, publicDelForm);

                unaPregunta.GuardarPregunta();
                DialogResult dr = MessageBox.Show("La pregunta ha sido realizada", "Perfecto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    txtPreguntas.Text = "";   
                }
                

            }
            catch (EntidadExistenteException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            strErrores += Validator.ValidarNulo(txtPreguntas.Text, "Pregunta");
            if (strErrores.Length > 0)
            {
                throw new Exception(strErrores);
            }
        }
    }
}
