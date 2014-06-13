namespace FrbaCommerce.Historial_Cliente
{
    partial class listadoHistorialDeOperaciones
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
            this.dtgHistorial = new System.Windows.Forms.DataGridView();
            this.cmbHistorial = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgHistorial
            // 
            this.dtgHistorial.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorial.Location = new System.Drawing.Point(57, 120);
            this.dtgHistorial.Name = "dtgHistorial";
            this.dtgHistorial.Size = new System.Drawing.Size(506, 214);
            this.dtgHistorial.TabIndex = 0;
            // 
            // cmbHistorial
            // 
            this.cmbHistorial.FormattingEnabled = true;
            this.cmbHistorial.Items.AddRange(new object[] {
            "Compras",
            "Ofertas",
            "Calificaciones Recibidas",
            "Calificaciones Otorgadas"});
            this.cmbHistorial.Location = new System.Drawing.Point(57, 38);
            this.cmbHistorial.Name = "cmbHistorial";
            this.cmbHistorial.Size = new System.Drawing.Size(149, 21);
            this.cmbHistorial.TabIndex = 2;
            this.cmbHistorial.Text = "Seleccione el Historial";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(57, 74);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(49, 23);
            this.btnVer.TabIndex = 3;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // listadoHistorialDeOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(619, 357);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.cmbHistorial);
            this.Controls.Add(this.dtgHistorial);
            this.Name = "listadoHistorialDeOperaciones";
            this.Text = "Historial de Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgHistorial;
        private System.Windows.Forms.ComboBox cmbHistorial;
        private System.Windows.Forms.Button btnVer;
    }
}