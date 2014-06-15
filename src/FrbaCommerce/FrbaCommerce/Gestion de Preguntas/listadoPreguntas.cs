using System;
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
using FrbaCommerce.Editar_Publicacion;
using FrbaCommerce.Gestion_de_Preguntas;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class listadoPreguntas : Form
    {
        Usuario unUsuario = new Usuario();
        Pregunta unaPregunta = new Pregunta();
        frmMisPublicaciones frmPadre = new frmMisPublicaciones();
        private int id_Pregunta;
        private int cod_Publicacion;

        public listadoPreguntas()
        {
            InitializeComponent();
        }

        public void abrirConUsuario(Usuario user)
        {
            unUsuario = user;
            this.Show();
        }

        private int valorIdSeleccionado()
        {
            return Convert.ToInt32(((DataRowView)dtgPreguntas.CurrentRow.DataBoundItem)["id_Pregunta"]);
        }

        public void AbrirParaVer(int codigo, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            cod_Publicacion = codigo;
            cargarListadoRespuestas(cod_Publicacion);
        }

        public void cargarListadoRespuestas(int cod_P)
        {
            try
            {
                DataSet ds = unaPregunta.obtenerPreguntasConRespuestas(cod_P, unUsuario);
                configurarGrillaPreguntasYRespuestas(ds);
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

        private void configurarGrillaPreguntasYRespuestas(DataSet ds)
        {
            dtgPreguntas.Columns.Clear();
            dtgPreguntas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn clmIDPregunta = new DataGridViewTextBoxColumn();
            clmIDPregunta.Width = 65;
            clmIDPregunta.ReadOnly = true;
            clmIDPregunta.DataPropertyName = "id_Pregunta";
            clmIDPregunta.HeaderText = "ID Pregunta";
            dtgPreguntas.Columns.Add(clmIDPregunta);
            
            DataGridViewTextBoxColumn clmPregunta = new DataGridViewTextBoxColumn();
            clmPregunta.Width = 200;
            clmPregunta.ReadOnly = true;
            clmPregunta.DataPropertyName = "Pregunta";
            clmPregunta.HeaderText = "Pregunta";
            dtgPreguntas.Columns.Add(clmPregunta);

            DataGridViewTextBoxColumn clmRespuesta = new DataGridViewTextBoxColumn();
            clmRespuesta.Width = 200;
            clmRespuesta.ReadOnly = true;
            clmRespuesta.DataPropertyName = "Respuesta";
            clmRespuesta.HeaderText = "Respuesta";
            dtgPreguntas.Columns.Add(clmRespuesta);

            DataGridViewTextBoxColumn clmFechaRta = new DataGridViewTextBoxColumn();
            clmFechaRta.Width = 65;
            clmFechaRta.ReadOnly = true;
            clmFechaRta.DataPropertyName = "Fecha_respuesta";
            clmFechaRta.HeaderText = "Fecha Respuesta";
            dtgPreguntas.Columns.Add(clmFechaRta);

            DataGridViewTextBoxColumn clmCodigo = new DataGridViewTextBoxColumn();
            clmCodigo.Width = 70;
            clmCodigo.ReadOnly = true;
            clmCodigo.DataPropertyName = "Codigo";
            clmCodigo.HeaderText = "Código Publicación";
            dtgPreguntas.Columns.Add(clmCodigo);

            DataGridViewTextBoxColumn clmDescripcion = new DataGridViewTextBoxColumn();
            clmDescripcion.Width = 200;
            clmDescripcion.ReadOnly = true;
            clmDescripcion.DataPropertyName = "Descripcion";
            clmDescripcion.HeaderText = "Descripción Publicación";
            dtgPreguntas.Columns.Add(clmDescripcion);

            DataGridViewTextBoxColumn clmStock = new DataGridViewTextBoxColumn();
            clmStock.Width = 60;
            clmStock.ReadOnly = true;
            clmStock.DataPropertyName = "Stock";
            clmStock.HeaderText = "Stock";
            dtgPreguntas.Columns.Add(clmStock);

            DataGridViewTextBoxColumn clmFechaCreacion = new DataGridViewTextBoxColumn();
            clmFechaCreacion.Width = 80;
            clmFechaCreacion.ReadOnly = true;
            clmFechaCreacion.DataPropertyName = "Fecha_creacion";
            clmFechaCreacion.HeaderText = "Fecha Creación";
            dtgPreguntas.Columns.Add(clmFechaCreacion);

            DataGridViewTextBoxColumn clmFechaVencimiento = new DataGridViewTextBoxColumn();
            clmFechaVencimiento.Width = 80;
            clmFechaVencimiento.ReadOnly = true;
            clmFechaVencimiento.DataPropertyName = "Fecha_vencimiento";
            clmFechaVencimiento.HeaderText = "Fecha Vencimiento";
            dtgPreguntas.Columns.Add(clmFechaVencimiento);

            DataGridViewTextBoxColumn clmPrecio = new DataGridViewTextBoxColumn();
            clmPrecio.Width = 60;
            clmPrecio.ReadOnly = true;
            clmPrecio.DataPropertyName = "Precio";
            clmPrecio.HeaderText = "Precio";
            dtgPreguntas.Columns.Add(clmPrecio);

            dtgPreguntas.DataSource = ds.Tables[0];
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPadre.CargarListadoDePublicaciones();
            frmPadre.BringToFront();
            this.Close();
        }

        public void AbrirParaResponder(int codigo, frmMisPublicaciones frmEnviador)
        {
            frmPadre = frmEnviador;
            cod_Publicacion = codigo;
            cargarListadoPreguntasNoRespondidas(cod_Publicacion);
        }

        public void cargarListadoPreguntasNoRespondidas(int codP)
        {
            try
            {
                DataSet ds = unaPregunta.obtenerPreguntasSinRespuestas(codP, unUsuario);
                configurarGrillaPreguntasYRespuestas(ds);
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

        private void btnResponder_Click(object sender, EventArgs e)
        {
            ResponderPregunta _frmResponderPregunta = new ResponderPregunta();
            id_Pregunta = valorIdSeleccionado();
            _frmResponderPregunta.AbrirParaResponder(id_Pregunta, this, cod_Publicacion);
        }

    }
}
