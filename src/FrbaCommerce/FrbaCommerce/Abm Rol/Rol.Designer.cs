namespace FrbaCommerce.Abm_Rol
{
    partial class Rol
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
            this.lblFuncionalidades = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAceptarRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(36, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblFuncionalidades
            // 
            this.lblFuncionalidades.AutoSize = true;
            this.lblFuncionalidades.Location = new System.Drawing.Point(36, 63);
            this.lblFuncionalidades.Name = "lblFuncionalidades";
            this.lblFuncionalidades.Size = new System.Drawing.Size(84, 13);
            this.lblFuncionalidades.TabIndex = 1;
            this.lblFuncionalidades.Text = "Funcionalidades";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // btnAceptarRol
            // 
            this.btnAceptarRol.Location = new System.Drawing.Point(162, 109);
            this.btnAceptarRol.Name = "btnAceptarRol";
            this.btnAceptarRol.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarRol.TabIndex = 4;
            this.btnAceptarRol.Text = "Aceptar";
            this.btnAceptarRol.UseVisualStyleBackColor = true;
            // 
            // Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 149);
            this.Controls.Add(this.btnAceptarRol);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblFuncionalidades);
            this.Controls.Add(this.lblNombre);
            this.Name = "Rol";
            this.Text = "Rol";
            this.Load += new System.EventHandler(this.Rol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFuncionalidades;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAceptarRol;
    }
}