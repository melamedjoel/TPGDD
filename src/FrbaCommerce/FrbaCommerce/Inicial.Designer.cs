namespace FrbaCommerce
{
    partial class Inicial
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
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.lblRegistrarUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.AutoSize = true;
            this.lblIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciarSesion.ForeColor = System.Drawing.Color.Blue;
            this.lblIniciarSesion.Location = new System.Drawing.Point(124, 35);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(122, 24);
            this.lblIniciarSesion.TabIndex = 3;
            this.lblIniciarSesion.Text = "Iniciar Sesión";
            this.lblIniciarSesion.Click += new System.EventHandler(this.lblIniciarSesion_Click);
            // 
            // lblRegistrarUsuario
            // 
            this.lblRegistrarUsuario.AutoSize = true;
            this.lblRegistrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegistrarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarUsuario.ForeColor = System.Drawing.Color.Blue;
            this.lblRegistrarUsuario.Location = new System.Drawing.Point(111, 76);
            this.lblRegistrarUsuario.Name = "lblRegistrarUsuario";
            this.lblRegistrarUsuario.Size = new System.Drawing.Size(153, 24);
            this.lblRegistrarUsuario.TabIndex = 4;
            this.lblRegistrarUsuario.Text = "Registrar Usuario";
            this.lblRegistrarUsuario.Click += new System.EventHandler(this.lblRegistrarUsuario_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(371, 180);
            this.Controls.Add(this.lblRegistrarUsuario);
            this.Controls.Add(this.lblIniciarSesion);
            this.Name = "Inicial";
            this.Text = "Frba Commerce";
            this.Load += new System.EventHandler(this.Inicial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.Label lblRegistrarUsuario;
    }
}