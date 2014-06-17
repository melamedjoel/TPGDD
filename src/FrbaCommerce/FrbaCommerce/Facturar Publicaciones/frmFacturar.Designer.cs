namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class frmFacturar
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
            this.lblPublicacionesARendir = new System.Windows.Forms.Label();
            this.cmbFormaDePago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dtgPublicacionesARendir = new System.Windows.Forms.DataGridView();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPublicacionesARendir)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPublicacionesARendir
            // 
            this.lblPublicacionesARendir.AutoSize = true;
            this.lblPublicacionesARendir.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicacionesARendir.Location = new System.Drawing.Point(25, 35);
            this.lblPublicacionesARendir.Name = "lblPublicacionesARendir";
            this.lblPublicacionesARendir.Size = new System.Drawing.Size(176, 19);
            this.lblPublicacionesARendir.TabIndex = 33;
            this.lblPublicacionesARendir.Text = "Publicaciones a rendir";
            // 
            // cmbFormaDePago
            // 
            this.cmbFormaDePago.FormattingEnabled = true;
            this.cmbFormaDePago.Location = new System.Drawing.Point(654, 238);
            this.cmbFormaDePago.Name = "cmbFormaDePago";
            this.cmbFormaDePago.Size = new System.Drawing.Size(140, 23);
            this.cmbFormaDePago.TabIndex = 34;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(651, 206);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(175, 15);
            this.lblFormaPago.TabIndex = 35;
            this.lblFormaPago.Text = "Seleccione la Forma de Pago";
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFacturar.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturar.Location = new System.Drawing.Point(654, 338);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(87, 27);
            this.btnFacturar.TabIndex = 36;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // dtgPublicacionesARendir
            // 
            this.dtgPublicacionesARendir.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtgPublicacionesARendir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgPublicacionesARendir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPublicacionesARendir.Location = new System.Drawing.Point(29, 83);
            this.dtgPublicacionesARendir.Name = "dtgPublicacionesARendir";
            this.dtgPublicacionesARendir.Size = new System.Drawing.Size(589, 283);
            this.dtgPublicacionesARendir.TabIndex = 37;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(654, 112);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 23);
            this.txtCantidad.TabIndex = 38;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(651, 82);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(279, 15);
            this.lblCantidad.TabIndex = 39;
            this.lblCantidad.Text = "Ingrese la cantidad de publicaciones a rendir";
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(943, 408);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.dtgPublicacionesARendir);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbFormaDePago);
            this.Controls.Add(this.lblPublicacionesARendir);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFacturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturar Publicaciones";
            this.Load += new System.EventHandler(this.frmFacturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPublicacionesARendir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPublicacionesARendir;
        private System.Windows.Forms.ComboBox cmbFormaDePago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridView dtgPublicacionesARendir;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;


    }
}