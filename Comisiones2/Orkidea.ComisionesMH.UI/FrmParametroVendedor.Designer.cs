namespace Orkidea.ComisionesMH.UI
{
    partial class FrmParametroVendedor
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
            this.lstVendedores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComiCumple = new System.Windows.Forms.TextBox();
            this.txtComiNoCumple = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbTienda = new System.Windows.Forms.ComboBox();
            this.lblTienda = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClifor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstVendedores
            // 
            this.lstVendedores.FormattingEnabled = true;
            this.lstVendedores.Location = new System.Drawing.Point(12, 89);
            this.lstVendedores.Name = "lstVendedores";
            this.lstVendedores.Size = new System.Drawing.Size(361, 368);
            this.lstVendedores.TabIndex = 0;
            this.lstVendedores.SelectedIndexChanged += new System.EventHandler(this.lstVendedores_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comisión si cumple";
            // 
            // txtComiCumple
            // 
            this.txtComiCumple.Location = new System.Drawing.Point(394, 146);
            this.txtComiCumple.Name = "txtComiCumple";
            this.txtComiCumple.Size = new System.Drawing.Size(60, 20);
            this.txtComiCumple.TabIndex = 3;
            // 
            // txtComiNoCumple
            // 
            this.txtComiNoCumple.Location = new System.Drawing.Point(394, 197);
            this.txtComiNoCumple.Name = "txtComiNoCumple";
            this.txtComiNoCumple.Size = new System.Drawing.Size(60, 20);
            this.txtComiNoCumple.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comisión si no cumple";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(556, 438);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbTienda
            // 
            this.cmbTienda.FormattingEnabled = true;
            this.cmbTienda.Location = new System.Drawing.Point(12, 34);
            this.cmbTienda.Name = "cmbTienda";
            this.cmbTienda.Size = new System.Drawing.Size(361, 21);
            this.cmbTienda.TabIndex = 103;
            this.cmbTienda.SelectedIndexChanged += new System.EventHandler(this.cmbTienda_SelectedIndexChanged);
            // 
            // lblTienda
            // 
            this.lblTienda.AutoSize = true;
            this.lblTienda.Location = new System.Drawing.Point(13, 18);
            this.lblTienda.Name = "lblTienda";
            this.lblTienda.Size = new System.Drawing.Size(40, 13);
            this.lblTienda.TabIndex = 104;
            this.lblTienda.Text = "Tienda";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(394, 301);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(109, 20);
            this.txtCedula.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Documento";
            // 
            // txtClifor
            // 
            this.txtClifor.Location = new System.Drawing.Point(394, 250);
            this.txtClifor.Name = "txtClifor";
            this.txtClifor.Size = new System.Drawing.Size(109, 20);
            this.txtClifor.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Código de Fornecedor";
            // 
            // FrmParametroVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 473);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClifor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTienda);
            this.Controls.Add(this.lblTienda);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtComiNoCumple);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComiCumple);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstVendedores);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmParametroVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros de vendedores";
            this.Load += new System.EventHandler(this.FrmParametroVendedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstVendedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComiCumple;
        private System.Windows.Forms.TextBox txtComiNoCumple;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbTienda;
        private System.Windows.Forms.Label lblTienda;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClifor;
        private System.Windows.Forms.Label label5;
    }
}