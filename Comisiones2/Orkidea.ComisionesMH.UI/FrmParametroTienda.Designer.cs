namespace Orkidea.ComisionesMH.UI
{
    partial class FrmParametroTienda
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
            this.cmbTienda = new System.Windows.Forms.ComboBox();
            this.lblTienda = new System.Windows.Forms.Label();
            this.cmbAdmin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbTienda
            // 
            this.cmbTienda.FormattingEnabled = true;
            this.cmbTienda.Location = new System.Drawing.Point(11, 38);
            this.cmbTienda.Name = "cmbTienda";
            this.cmbTienda.Size = new System.Drawing.Size(361, 21);
            this.cmbTienda.TabIndex = 105;
            this.cmbTienda.SelectedIndexChanged += new System.EventHandler(this.cmbTienda_SelectedIndexChanged);
            // 
            // lblTienda
            // 
            this.lblTienda.AutoSize = true;
            this.lblTienda.Location = new System.Drawing.Point(8, 22);
            this.lblTienda.Name = "lblTienda";
            this.lblTienda.Size = new System.Drawing.Size(40, 13);
            this.lblTienda.TabIndex = 106;
            this.lblTienda.Text = "Tienda";
            // 
            // cmbAdmin
            // 
            this.cmbAdmin.FormattingEnabled = true;
            this.cmbAdmin.Location = new System.Drawing.Point(11, 78);
            this.cmbAdmin.Name = "cmbAdmin";
            this.cmbAdmin.Size = new System.Drawing.Size(361, 21);
            this.cmbAdmin.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Vendedor";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(297, 105);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 109;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmParametroTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 138);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTienda);
            this.Controls.Add(this.lblTienda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmParametroTienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros tienda";
            this.Load += new System.EventHandler(this.FrmParametroTienda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTienda;
        private System.Windows.Forms.Label lblTienda;
        private System.Windows.Forms.ComboBox cmbAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
    }
}