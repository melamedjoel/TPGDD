namespace FrbaCommerce.Calificar_Vendedor
{
    partial class vendedoresSinCalificar
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
            this.dtgVendedoresSinCalificar = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVendedoresSinCalificar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVendedoresSinCalificar
            // 
            this.dtgVendedoresSinCalificar.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgVendedoresSinCalificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVendedoresSinCalificar.Location = new System.Drawing.Point(12, 42);
            this.dtgVendedoresSinCalificar.Name = "dtgVendedoresSinCalificar";
            this.dtgVendedoresSinCalificar.Size = new System.Drawing.Size(720, 284);
            this.dtgVendedoresSinCalificar.TabIndex = 44;
            this.dtgVendedoresSinCalificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVendedoresSinCalificar_CellContentClick);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl.Location = new System.Drawing.Point(12, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(272, 20);
            this.lbl.TabIndex = 45;
            this.lbl.Text = "Vendedores que no ha calificado aún";
            // 
            // vendedoresSinCalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 338);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dtgVendedoresSinCalificar);
            this.Name = "vendedoresSinCalificar";
            this.Text = "Calificar Vendedores";
            this.Load += new System.EventHandler(this.calificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVendedoresSinCalificar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgVendedoresSinCalificar;
        private System.Windows.Forms.Label lbl;
    }
}