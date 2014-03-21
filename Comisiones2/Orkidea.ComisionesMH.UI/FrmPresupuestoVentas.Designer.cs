namespace Orkidea.ComisionesMH.UI
{
    partial class FrmPresupuestoVentas
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
            this.cmbRedDeTiendas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTienda = new System.Windows.Forms.ComboBox();
            this.lblTienda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.btnBuscarPresupuesto = new System.Windows.Forms.Button();
            this.btnGuardarPresupuesto = new System.Windows.Forms.Button();
            this.grdPresupuesto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRedDeTiendas
            // 
            this.cmbRedDeTiendas.FormattingEnabled = true;
            this.cmbRedDeTiendas.Location = new System.Drawing.Point(14, 30);
            this.cmbRedDeTiendas.Name = "cmbRedDeTiendas";
            this.cmbRedDeTiendas.Size = new System.Drawing.Size(256, 21);
            this.cmbRedDeTiendas.TabIndex = 117;
            this.cmbRedDeTiendas.SelectedIndexChanged += new System.EventHandler(this.cmbRedDeTiendas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Red de tiendas";
            // 
            // cmbTienda
            // 
            this.cmbTienda.FormattingEnabled = true;
            this.cmbTienda.Location = new System.Drawing.Point(275, 30);
            this.cmbTienda.Name = "cmbTienda";
            this.cmbTienda.Size = new System.Drawing.Size(256, 21);
            this.cmbTienda.TabIndex = 115;
            // 
            // lblTienda
            // 
            this.lblTienda.AutoSize = true;
            this.lblTienda.Location = new System.Drawing.Point(272, 14);
            this.lblTienda.Name = "lblTienda";
            this.lblTienda.Size = new System.Drawing.Size(40, 13);
            this.lblTienda.TabIndex = 116;
            this.lblTienda.Text = "Tienda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Año";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(13, 70);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 120;
            // 
            // btnBuscarPresupuesto
            // 
            this.btnBuscarPresupuesto.Location = new System.Drawing.Point(119, 68);
            this.btnBuscarPresupuesto.Name = "btnBuscarPresupuesto";
            this.btnBuscarPresupuesto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPresupuesto.TabIndex = 121;
            this.btnBuscarPresupuesto.Text = "Buscar";
            this.btnBuscarPresupuesto.UseVisualStyleBackColor = true;
            this.btnBuscarPresupuesto.Click += new System.EventHandler(this.btnBuscarPresupuesto_Click);
            // 
            // btnGuardarPresupuesto
            // 
            this.btnGuardarPresupuesto.Location = new System.Drawing.Point(456, 70);
            this.btnGuardarPresupuesto.Name = "btnGuardarPresupuesto";
            this.btnGuardarPresupuesto.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPresupuesto.TabIndex = 122;
            this.btnGuardarPresupuesto.Text = "Guardar";
            this.btnGuardarPresupuesto.UseVisualStyleBackColor = true;
            this.btnGuardarPresupuesto.Click += new System.EventHandler(this.btnGuardarPresupuesto_Click);
            // 
            // grdPresupuesto
            // 
            this.grdPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPresupuesto.Location = new System.Drawing.Point(14, 97);
            this.grdPresupuesto.Name = "grdPresupuesto";
            this.grdPresupuesto.Size = new System.Drawing.Size(517, 307);
            this.grdPresupuesto.TabIndex = 123;
            // 
            // FrmPresupuestoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 416);
            this.Controls.Add(this.grdPresupuesto);
            this.Controls.Add(this.btnGuardarPresupuesto);
            this.Controls.Add(this.btnBuscarPresupuesto);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRedDeTiendas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTienda);
            this.Controls.Add(this.lblTienda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPresupuestoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presupuesto Ventas";
            this.Load += new System.EventHandler(this.FrmPresupuestoVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPresupuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRedDeTiendas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTienda;
        private System.Windows.Forms.Label lblTienda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Button btnBuscarPresupuesto;
        private System.Windows.Forms.Button btnGuardarPresupuesto;
        private System.Windows.Forms.DataGridView grdPresupuesto;
    }
}