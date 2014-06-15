namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class listadoPreguntas
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
            this.dtgPreguntas = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnResponder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPreguntas
            // 
            this.dtgPreguntas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPreguntas.Location = new System.Drawing.Point(12, 31);
            this.dtgPreguntas.Name = "dtgPreguntas";
            this.dtgPreguntas.Size = new System.Drawing.Size(794, 263);
            this.dtgPreguntas.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(724, 316);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnResponder
            // 
            this.btnResponder.Location = new System.Drawing.Point(630, 316);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(75, 23);
            this.btnResponder.TabIndex = 3;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // listadoPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(818, 351);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dtgPreguntas);
            this.Name = "listadoPreguntas";
            this.Text = "Listado de Preguntas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPreguntas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnResponder;

    }
}