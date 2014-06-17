namespace FrbaCommerce.Generar_Publicacion
{
    partial class frmDetallePublic
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCreacion = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblVisibilidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.chkPregs = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbVisibilidad = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lstRubros = new System.Windows.Forms.CheckedListBox();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnAumentarStock = new System.Windows.Forms.Button();
            this.btnRestarStock = new System.Windows.Forms.Button();
            this.dtFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(478, 230);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 62;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(145, 80);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(108, 20);
            this.txtStock.TabIndex = 60;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(145, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(108, 20);
            this.txtUsuario.TabIndex = 59;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(41, 80);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(35, 13);
            this.lblStock.TabIndex = 58;
            this.lblStock.Text = "Stock";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(41, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 57;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(143, 28);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 20);
            this.txtDescripcion.TabIndex = 56;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(41, 28);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 55;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblCreacion
            // 
            this.lblCreacion.AutoSize = true;
            this.lblCreacion.Location = new System.Drawing.Point(39, 133);
            this.lblCreacion.Name = "lblCreacion";
            this.lblCreacion.Size = new System.Drawing.Size(81, 13);
            this.lblCreacion.TabIndex = 63;
            this.lblCreacion.Text = "Fecha creacion";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(39, 159);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(97, 13);
            this.lblFechaVencimiento.TabIndex = 65;
            this.lblFechaVencimiento.Text = "Fecha vencimiento";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(39, 185);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 67;
            this.lblTipo.Text = "Tipo";
            // 
            // lblVisibilidad
            // 
            this.lblVisibilidad.AutoSize = true;
            this.lblVisibilidad.Location = new System.Drawing.Point(39, 211);
            this.lblVisibilidad.Name = "lblVisibilidad";
            this.lblVisibilidad.Size = new System.Drawing.Size(53, 13);
            this.lblVisibilidad.TabIndex = 69;
            this.lblVisibilidad.Text = "Visibilidad";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(39, 237);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 71;
            this.lblEstado.Text = "Estado";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(143, 106);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(108, 20);
            this.txtPrecio.TabIndex = 77;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(39, 106);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 76;
            this.lblPrecio.Text = "Precio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(478, 201);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 78;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // chkPregs
            // 
            this.chkPregs.AutoSize = true;
            this.chkPregs.Location = new System.Drawing.Point(42, 381);
            this.chkPregs.Name = "chkPregs";
            this.chkPregs.Size = new System.Drawing.Size(74, 17);
            this.chkPregs.TabIndex = 75;
            this.chkPregs.Text = "Preguntas";
            this.chkPregs.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(142, 237);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 80;
            // 
            // cmbVisibilidad
            // 
            this.cmbVisibilidad.FormattingEnabled = true;
            this.cmbVisibilidad.Location = new System.Drawing.Point(143, 210);
            this.cmbVisibilidad.Name = "cmbVisibilidad";
            this.cmbVisibilidad.Size = new System.Drawing.Size(121, 21);
            this.cmbVisibilidad.TabIndex = 81;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(142, 183);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 82;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Location = new System.Drawing.Point(39, 263);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(36, 13);
            this.lblRubro.TabIndex = 73;
            this.lblRubro.Text = "Rubro";
            // 
            // lstRubros
            // 
            this.lstRubros.FormattingEnabled = true;
            this.lstRubros.Location = new System.Drawing.Point(143, 263);
            this.lstRubros.Name = "lstRubros";
            this.lstRubros.Size = new System.Drawing.Size(120, 94);
            this.lstRubros.TabIndex = 79;
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Enabled = false;
            this.dtVencimiento.Location = new System.Drawing.Point(142, 158);
            this.dtVencimiento.Name = "dtVencimiento";
            this.dtVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtVencimiento.TabIndex = 83;
            // 
            // btnAumentarStock
            // 
            this.btnAumentarStock.AutoSize = true;
            this.btnAumentarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAumentarStock.Location = new System.Drawing.Point(258, 80);
            this.btnAumentarStock.Name = "btnAumentarStock";
            this.btnAumentarStock.Size = new System.Drawing.Size(26, 26);
            this.btnAumentarStock.TabIndex = 84;
            this.btnAumentarStock.Text = "+";
            this.btnAumentarStock.UseVisualStyleBackColor = true;
            this.btnAumentarStock.Click += new System.EventHandler(this.btnAumentarStock_Click);
            // 
            // btnRestarStock
            // 
            this.btnRestarStock.AutoSize = true;
            this.btnRestarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestarStock.Location = new System.Drawing.Point(288, 80);
            this.btnRestarStock.Name = "btnRestarStock";
            this.btnRestarStock.Size = new System.Drawing.Size(26, 26);
            this.btnRestarStock.TabIndex = 85;
            this.btnRestarStock.Text = "-";
            this.btnRestarStock.UseVisualStyleBackColor = true;
            this.btnRestarStock.Click += new System.EventHandler(this.btnRestarStock_Click);
            // 
            // dtFechaCreacion
            // 
            this.dtFechaCreacion.Enabled = false;
            this.dtFechaCreacion.Location = new System.Drawing.Point(142, 132);
            this.dtFechaCreacion.Name = "dtFechaCreacion";
            this.dtFechaCreacion.Size = new System.Drawing.Size(200, 20);
            this.dtFechaCreacion.TabIndex = 86;
            // 
            // frmDetallePublic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(597, 410);
            this.Controls.Add(this.dtFechaCreacion);
            this.Controls.Add(this.btnRestarStock);
            this.Controls.Add(this.btnAumentarStock);
            this.Controls.Add(this.dtVencimiento);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbVisibilidad);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lstRubros);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.chkPregs);
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblVisibilidad);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.lblCreacion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Name = "frmDetallePublic";
            this.Text = "Detalle Publicacion";
            this.Load += new System.EventHandler(this.frmDetallePublic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCreacion;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblVisibilidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox chkPregs;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbVisibilidad;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.CheckedListBox lstRubros;
        private System.Windows.Forms.DateTimePicker dtVencimiento;
        private System.Windows.Forms.Button btnAumentarStock;
        private System.Windows.Forms.Button btnRestarStock;
        private System.Windows.Forms.DateTimePicker dtFechaCreacion;
    }
}