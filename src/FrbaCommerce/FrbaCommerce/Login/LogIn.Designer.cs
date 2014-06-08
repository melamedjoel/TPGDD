namespace FrbaCommerce.Login
{
    partial class LogIn
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
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.grpLogIn = new System.Windows.Forms.GroupBox();
            this.grpRol = new System.Windows.Forms.GroupBox();
            this.btnSelecRol = new System.Windows.Forms.Button();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.grpLogIn.SuspendLayout();
            this.grpRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.SystemColors.Window;
            this.txtClave.Location = new System.Drawing.Point(96, 45);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 16;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(29, 48);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 15;
            this.lblPass.Text = "Contraseña";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(96, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 14;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(47, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "Usuario";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Location = new System.Drawing.Point(76, 71);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 12;
            this.btnLogIn.Text = "Ingresar";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // grpLogIn
            // 
            this.grpLogIn.Controls.Add(this.txtUser);
            this.grpLogIn.Controls.Add(this.txtClave);
            this.grpLogIn.Controls.Add(this.btnLogIn);
            this.grpLogIn.Controls.Add(this.lblPass);
            this.grpLogIn.Controls.Add(this.lblUser);
            this.grpLogIn.Location = new System.Drawing.Point(30, 12);
            this.grpLogIn.Name = "grpLogIn";
            this.grpLogIn.Size = new System.Drawing.Size(244, 103);
            this.grpLogIn.TabIndex = 17;
            this.grpLogIn.TabStop = false;
            this.grpLogIn.Text = "Log In";
            // 
            // grpRol
            // 
            this.grpRol.Controls.Add(this.btnSelecRol);
            this.grpRol.Controls.Add(this.cmbRoles);
            this.grpRol.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpRol.Location = new System.Drawing.Point(30, 31);
            this.grpRol.Name = "grpRol";
            this.grpRol.Size = new System.Drawing.Size(244, 55);
            this.grpRol.TabIndex = 18;
            this.grpRol.TabStop = false;
            this.grpRol.Text = "Seleccionar rol";
            // 
            // btnSelecRol
            // 
            this.btnSelecRol.Location = new System.Drawing.Point(156, 19);
            this.btnSelecRol.Name = "btnSelecRol";
            this.btnSelecRol.Size = new System.Drawing.Size(75, 23);
            this.btnSelecRol.TabIndex = 1;
            this.btnSelecRol.Text = "Seleccionar";
            this.btnSelecRol.UseVisualStyleBackColor = true;
            this.btnSelecRol.Click += new System.EventHandler(this.btnSelecRol_Click);
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(20, 19);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(120, 21);
            this.cmbRoles.TabIndex = 0;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(292, 132);
            this.Controls.Add(this.grpRol);
            this.Controls.Add(this.grpLogIn);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.grpLogIn.ResumeLayout(false);
            this.grpLogIn.PerformLayout();
            this.grpRol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.GroupBox grpLogIn;
        private System.Windows.Forms.GroupBox grpRol;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnSelecRol;
    }
}