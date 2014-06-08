namespace FrbaCommerce.Generar_Publicacion
{
    partial class GenerarPublicación
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAceptarTipoPubli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(29, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(85, 13);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "Tipo publicación";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(120, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAceptarTipoPubli
            // 
            this.btnAceptarTipoPubli.Location = new System.Drawing.Point(165, 68);
            this.btnAceptarTipoPubli.Name = "btnAceptarTipoPubli";
            this.btnAceptarTipoPubli.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarTipoPubli.TabIndex = 25;
            this.btnAceptarTipoPubli.Text = "Aceptar";
            this.btnAceptarTipoPubli.UseVisualStyleBackColor = true;
            // 
            // GenerarPublicación
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 103);
            this.Controls.Add(this.btnAceptarTipoPubli);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblNombre);
            this.Name = "GenerarPublicación";
            this.Text = "Generar Publiación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAceptarTipoPubli;

    }
}