namespace FrbaCommerce.Listado_Estadistico
{
    partial class listadoEstadistico
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
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.txtAño = new System.Windows.Forms.MaskedTextBox();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblMesAño = new System.Windows.Forms.Label();
            this.txtGradoVisibilidad = new System.Windows.Forms.TextBox();
            this.lblGradoDeVisibilidad = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMesAño = new System.Windows.Forms.MaskedTextBox();
            this.dtgTop5 = new System.Windows.Forms.DataGridView();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTop5)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbListado
            // 
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Items.AddRange(new object[] {
            "Vendedores con mayor cantidad de productos no vendidos.",
            "Vendedores con mayor facturación.",
            "Vendedores con mayores calificaciones.",
            "Clientes con mayor cantidad de publicaciones sin calificar."});
            this.cmbListado.Location = new System.Drawing.Point(310, 27);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(346, 21);
            this.cmbListado.TabIndex = 0;
            this.cmbListado.Text = "Top 5 de ...";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(79, 10);
            this.txtAño.Mask = "9999";
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(44, 20);
            this.txtAño.TabIndex = 1;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(10, 11);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(63, 13);
            this.lblAño.TabIndex = 3;
            this.lblAño.Text = "Ingrese año";
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Location = new System.Drawing.Point(10, 46);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(102, 13);
            this.lblTrimestre.TabIndex = 4;
            this.lblTrimestre.Text = "Seleccione trimestre";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Ene - Mar",
            "Abr - Jun",
            "Jul - Sep",
            "Oct - Dic"});
            this.cmbTrimestre.Location = new System.Drawing.Point(118, 46);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(121, 21);
            this.cmbTrimestre.TabIndex = 5;
            this.cmbTrimestre.Text = "Trimestre";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.txtMesAño);
            this.grpFiltros.Controls.Add(this.lblMesAño);
            this.grpFiltros.Controls.Add(this.txtGradoVisibilidad);
            this.grpFiltros.Controls.Add(this.lblGradoDeVisibilidad);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Location = new System.Drawing.Point(12, 73);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(397, 83);
            this.grpFiltros.TabIndex = 42;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // lblMesAño
            // 
            this.lblMesAño.AutoSize = true;
            this.lblMesAño.Location = new System.Drawing.Point(271, 19);
            this.lblMesAño.Name = "lblMesAño";
            this.lblMesAño.Size = new System.Drawing.Size(49, 13);
            this.lblMesAño.TabIndex = 33;
            this.lblMesAño.Text = "Mes-Año";
            // 
            // txtGradoVisibilidad
            // 
            this.txtGradoVisibilidad.Location = new System.Drawing.Point(121, 16);
            this.txtGradoVisibilidad.MaxLength = 255;
            this.txtGradoVisibilidad.Name = "txtGradoVisibilidad";
            this.txtGradoVisibilidad.Size = new System.Drawing.Size(120, 20);
            this.txtGradoVisibilidad.TabIndex = 30;
            // 
            // lblGradoDeVisibilidad
            // 
            this.lblGradoDeVisibilidad.AutoSize = true;
            this.lblGradoDeVisibilidad.Location = new System.Drawing.Point(16, 16);
            this.lblGradoDeVisibilidad.Name = "lblGradoDeVisibilidad";
            this.lblGradoDeVisibilidad.Size = new System.Drawing.Size(99, 13);
            this.lblGradoDeVisibilidad.TabIndex = 29;
            this.lblGradoDeVisibilidad.Text = "Grado de visibilidad";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(76, 53);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(78, 23);
            this.btnLimpiar.TabIndex = 26;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(19, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(51, 23);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtMesAño
            // 
            this.txtMesAño.Location = new System.Drawing.Point(326, 19);
            this.txtMesAño.Mask = "99/9999";
            this.txtMesAño.Name = "txtMesAño";
            this.txtMesAño.Size = new System.Drawing.Size(55, 20);
            this.txtMesAño.TabIndex = 34;
            // 
            // dtgTop5
            // 
            this.dtgTop5.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTop5.Location = new System.Drawing.Point(98, 162);
            this.dtgTop5.Name = "dtgTop5";
            this.dtgTop5.Size = new System.Drawing.Size(504, 189);
            this.dtgTop5.TabIndex = 43;
            // 
            // listadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(712, 363);
            this.Controls.Add(this.dtgTop5);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.cmbListado);
            this.Name = "listadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            this.Load += new System.EventHandler(this.listadoEstadistico_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTop5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.MaskedTextBox txtAño;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblMesAño;
        private System.Windows.Forms.TextBox txtGradoVisibilidad;
        private System.Windows.Forms.Label lblGradoDeVisibilidad;
        public System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.MaskedTextBox txtMesAño;
        private System.Windows.Forms.DataGridView dtgTop5;
    }
}