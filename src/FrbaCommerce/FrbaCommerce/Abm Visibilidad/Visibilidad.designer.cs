namespace FrbaCommerce.Abm_Visibilidad
{
    partial class Visibilidad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtPrecioPorPublicar = new System.Windows.Forms.TextBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAceptarVisibilidad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(99, 52);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 45;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(87, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 44;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(30, 55);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 43;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(30, 29);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(40, 13);
            this.lbCodigo.TabIndex = 42;
            this.lbCodigo.Text = "Código";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(156, 104);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(43, 20);
            this.txtPorcentaje.TabIndex = 49;
            // 
            // txtPrecioPorPublicar
            // 
            this.txtPrecioPorPublicar.Location = new System.Drawing.Point(134, 78);
            this.txtPrecioPorPublicar.Name = "txtPrecioPorPublicar";
            this.txtPrecioPorPublicar.Size = new System.Drawing.Size(53, 20);
            this.txtPrecioPorPublicar.TabIndex = 48;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(30, 107);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(114, 13);
            this.lblPorcentaje.TabIndex = 47;
            this.lblPorcentaje.Text = "Porcentaje de la venta";
            this.lblPorcentaje.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(30, 81);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(95, 13);
            this.lblPrecio.TabIndex = 46;
            this.lblPrecio.Text = "Precio por publicar";
            this.lblPrecio.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAceptarVisibilidad
            // 
            this.btnAceptarVisibilidad.Location = new System.Drawing.Point(193, 141);
            this.btnAceptarVisibilidad.Name = "btnAceptarVisibilidad";
            this.btnAceptarVisibilidad.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarVisibilidad.TabIndex = 50;
            this.btnAceptarVisibilidad.Text = "Aceptar";
            this.btnAceptarVisibilidad.UseVisualStyleBackColor = true;
            // 
            // Visibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 172);
            this.Controls.Add(this.btnAceptarVisibilidad);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.txtPrecioPorPublicar);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lbCodigo);
            this.Name = "Visibilidad";
            this.Text = "Visibilidad";
            this.Load += new System.EventHandler(this.Visibilidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.TextBox txtPrecioPorPublicar;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAceptarVisibilidad;
    }
}