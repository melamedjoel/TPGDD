namespace FrbaCommerce.Abm_Empresa
{
    partial class frmEmpresa
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
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtNroPiso = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblNroPiso = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblNombreContacto = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lbRazonSocial = new System.Windows.Forms.Label();
            this.txtFechaCreacion = new System.Windows.Forms.MaskedTextBox();
            this.btnAceptarEmpresa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Location = new System.Drawing.Point(376, 128);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(44, 20);
            this.txtCodPostal.TabIndex = 46;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(357, 102);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 45;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(341, 76);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(39, 20);
            this.txtDepto.TabIndex = 44;
            // 
            // txtNroPiso
            // 
            this.txtNroPiso.Location = new System.Drawing.Point(352, 50);
            this.txtNroPiso.Name = "txtNroPiso";
            this.txtNroPiso.Size = new System.Drawing.Size(43, 20);
            this.txtNroPiso.TabIndex = 43;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(357, 24);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 42;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(86, 155);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 41;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(63, 129);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(144, 20);
            this.txtMail.TabIndex = 40;
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.Location = new System.Drawing.Point(142, 103);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.Size = new System.Drawing.Size(100, 20);
            this.txtNombreContacto.TabIndex = 39;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(63, 77);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 38;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(69, 51);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(100, 20);
            this.txtCuit.TabIndex = 37;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(107, 25);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(100, 20);
            this.txtRazonSocial.TabIndex = 36;
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(298, 157);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(97, 13);
            this.lblFechaCreacion.TabIndex = 35;
            this.lblFechaCreacion.Text = "Fecha de Creación";
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.AutoSize = true;
            this.lblCodPostal.Location = new System.Drawing.Point(298, 134);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(72, 13);
            this.lblCodPostal.TabIndex = 34;
            this.lblCodPostal.Text = "Código Postal";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(298, 106);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 33;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(299, 79);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(36, 13);
            this.lblDepto.TabIndex = 32;
            this.lblDepto.Text = "Depto";
            // 
            // lblNroPiso
            // 
            this.lblNroPiso.AutoSize = true;
            this.lblNroPiso.Location = new System.Drawing.Point(299, 53);
            this.lblNroPiso.Name = "lblNroPiso";
            this.lblNroPiso.Size = new System.Drawing.Size(47, 13);
            this.lblNroPiso.TabIndex = 31;
            this.lblNroPiso.Text = "Nro Piso";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(299, 27);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 30;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(31, 158);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 29;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(31, 134);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 28;
            this.lblMail.Text = "Mail";
            // 
            // lblNombreContacto
            // 
            this.lblNombreContacto.AutoSize = true;
            this.lblNombreContacto.Location = new System.Drawing.Point(31, 107);
            this.lblNombreContacto.Name = "lblNombreContacto";
            this.lblNombreContacto.Size = new System.Drawing.Size(105, 13);
            this.lblNombreContacto.TabIndex = 27;
            this.lblNombreContacto.Text = "Nombre de Contacto";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(31, 80);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 26;
            this.lblDni.Text = "DNI";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(31, 54);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(32, 13);
            this.lblCuit.TabIndex = 25;
            this.lblCuit.Text = "CUIT";
            this.lblCuit.Click += new System.EventHandler(this.lblApellido_Click);
            // 
            // lbRazonSocial
            // 
            this.lbRazonSocial.AutoSize = true;
            this.lbRazonSocial.Location = new System.Drawing.Point(31, 28);
            this.lbRazonSocial.Name = "lbRazonSocial";
            this.lbRazonSocial.Size = new System.Drawing.Size(70, 13);
            this.lbRazonSocial.TabIndex = 24;
            this.lbRazonSocial.Text = "Razón Social";
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.Location = new System.Drawing.Point(402, 154);
            this.txtFechaCreacion.Mask = "99/99/9999";
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.Size = new System.Drawing.Size(74, 20);
            this.txtFechaCreacion.TabIndex = 47;
            // 
            // btnAceptarEmpresa
            // 
            this.btnAceptarEmpresa.Location = new System.Drawing.Point(401, 197);
            this.btnAceptarEmpresa.Name = "btnAceptarEmpresa";
            this.btnAceptarEmpresa.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarEmpresa.TabIndex = 48;
            this.btnAceptarEmpresa.Text = "Aceptar";
            this.btnAceptarEmpresa.UseVisualStyleBackColor = true;
            // 
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 232);
            this.Controls.Add(this.btnAceptarEmpresa);
            this.Controls.Add(this.txtFechaCreacion);
            this.Controls.Add(this.txtCodPostal);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtNroPiso);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtNombreContacto);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.lblFechaCreacion);
            this.Controls.Add(this.lblCodPostal);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblDepto);
            this.Controls.Add(this.lblNroPiso);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblNombreContacto);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lbRazonSocial);
            this.Name = "Empresa";
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.Empresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtNroPiso;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblCodPostal;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblNroPiso;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblNombreContacto;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lbRazonSocial;
        private System.Windows.Forms.MaskedTextBox txtFechaCreacion;
        private System.Windows.Forms.Button btnAceptarEmpresa;
    }
}