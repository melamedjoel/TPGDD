namespace FrbaCommerce.Calificar_Vendedor
{
    partial class calificarVendedor
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
            this.cmbCantidadEstrellas = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtDetalleCalificacion = new System.Windows.Forms.TextBox();
            this.lblCalificacion = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCantidadEstrellas
            // 
            this.cmbCantidadEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantidadEstrellas.FormattingEnabled = true;
            this.cmbCantidadEstrellas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbCantidadEstrellas.Location = new System.Drawing.Point(79, 31);
            this.cmbCantidadEstrellas.Name = "cmbCantidadEstrellas";
            this.cmbCantidadEstrellas.Size = new System.Drawing.Size(57, 21);
            this.cmbCantidadEstrellas.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(195, 98);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 31);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtDetalleCalificacion
            // 
            this.txtDetalleCalificacion.Location = new System.Drawing.Point(78, 58);
            this.txtDetalleCalificacion.Name = "txtDetalleCalificacion";
            this.txtDetalleCalificacion.Size = new System.Drawing.Size(217, 20);
            this.txtDetalleCalificacion.TabIndex = 2;
            // 
            // lblCalificacion
            // 
            this.lblCalificacion.AutoSize = true;
            this.lblCalificacion.Location = new System.Drawing.Point(11, 34);
            this.lblCalificacion.Name = "lblCalificacion";
            this.lblCalificacion.Size = new System.Drawing.Size(61, 13);
            this.lblCalificacion.TabIndex = 3;
            this.lblCalificacion.Text = "Calificacion";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(11, 61);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(40, 13);
            this.lblDetalle.TabIndex = 4;
            this.lblDetalle.Text = "Detalle";
            // 
            // calificarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 139);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.lblCalificacion);
            this.Controls.Add(this.txtDetalleCalificacion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbCantidadEstrellas);
            this.Name = "calificarVendedor";
            this.Text = "Calificar Vendedor";
            this.Load += new System.EventHandler(this.calificarVendedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCantidadEstrellas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtDetalleCalificacion;
        private System.Windows.Forms.Label lblCalificacion;
        private System.Windows.Forms.Label lblDetalle;
    }
}