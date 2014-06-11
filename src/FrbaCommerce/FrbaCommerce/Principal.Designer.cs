namespace FrbaCommerce
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ABMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ABMRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ABMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ABMToolStripMenuItem
            // 
            this.ABMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ABMRolesToolStripMenuItem,
            this.aBMEmpresasToolStripMenuItem});
            this.ABMToolStripMenuItem.Name = "ABMToolStripMenuItem";
            this.ABMToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.ABMToolStripMenuItem.Text = "Administración";
            // 
            // ABMRolesToolStripMenuItem
            // 
            this.ABMRolesToolStripMenuItem.Name = "ABMRolesToolStripMenuItem";
            this.ABMRolesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ABMRolesToolStripMenuItem.Text = "ABM Roles";
            this.ABMRolesToolStripMenuItem.Click += new System.EventHandler(this.ABMRolesToolStripMenuItem_Click);
            // 
            // aBMEmpresasToolStripMenuItem
            // 
            this.aBMEmpresasToolStripMenuItem.Name = "aBMEmpresasToolStripMenuItem";
            this.aBMEmpresasToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aBMEmpresasToolStripMenuItem.Text = "ABM Empresas";
            this.aBMEmpresasToolStripMenuItem.Click += new System.EventHandler(this.aBMEmpresasToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 377);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ABMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ABMRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpresasToolStripMenuItem;

    }
}