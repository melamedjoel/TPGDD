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
            this.lstPublicacionesARendir = new System.Windows.Forms.CheckedListBox();
            this.lblPublicacionesARendir = new System.Windows.Forms.Label();
            this.cmbFormaDePago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPublicacionesARendir
            // 
            this.lstPublicacionesARendir.FormattingEnabled = true;
            this.lstPublicacionesARendir.Location = new System.Drawing.Point(25, 49);
            this.lstPublicacionesARendir.Name = "lstPublicacionesARendir";
            this.lstPublicacionesARendir.Size = new System.Drawing.Size(258, 199);
            this.lstPublicacionesARendir.TabIndex = 32;
            // 
            // lblPublicacionesARendir
            // 
            this.lblPublicacionesARendir.AutoSize = true;
            this.lblPublicacionesARendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicacionesARendir.Location = new System.Drawing.Point(22, 18);
            this.lblPublicacionesARendir.Name = "lblPublicacionesARendir";
            this.lblPublicacionesARendir.Size = new System.Drawing.Size(153, 18);
            this.lblPublicacionesARendir.TabIndex = 33;
            this.lblPublicacionesARendir.Text = "Publicaciones a rendir";
            // 
            // cmbFormaDePago
            // 
            this.cmbFormaDePago.FormattingEnabled = true;
            this.cmbFormaDePago.Location = new System.Drawing.Point(322, 80);
            this.cmbFormaDePago.Name = "cmbFormaDePago";
            this.cmbFormaDePago.Size = new System.Drawing.Size(121, 21);
            this.cmbFormaDePago.TabIndex = 34;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(319, 49);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(146, 13);
            this.lblFormaPago.TabIndex = 35;
            this.lblFormaPago.Text = "Seleccione la Forma de Pago";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(322, 224);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 36;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(574, 336);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbFormaDePago);
            this.Controls.Add(this.lblPublicacionesARendir);
            this.Controls.Add(this.lstPublicacionesARendir);
            this.Name = "frmFacturar";
            this.Text = "Facturar Publicaciones";
            this.Load += new System.EventHandler(this.frmFacturar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstPublicacionesARendir;
        private System.Windows.Forms.Label lblPublicacionesARendir;
        private System.Windows.Forms.ComboBox cmbFormaDePago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Button btnFacturar;


    }
}