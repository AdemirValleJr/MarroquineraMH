namespace Orkidea.MH.IntegracionContable.Presentation
{
    partial class FrmCuentaAdministradora
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCuenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFranquicia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gdCuentasTipo = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdCuentasTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCuenta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbFranquicia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBorrar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.cbTipoPago);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 100);
            this.panel1.TabIndex = 3;
            // 
            // cbCuenta
            // 
            this.cbCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCuenta.FormattingEnabled = true;
            this.cbCuenta.Location = new System.Drawing.Point(485, 36);
            this.cbCuenta.Name = "cbCuenta";
            this.cbCuenta.Size = new System.Drawing.Size(369, 21);
            this.cbCuenta.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cuenta contable";
            // 
            // cbFranquicia
            // 
            this.cbFranquicia.FormattingEnabled = true;
            this.cbFranquicia.Location = new System.Drawing.Point(88, 36);
            this.cbFranquicia.Name = "cbFranquicia";
            this.cbFranquicia.Size = new System.Drawing.Size(296, 21);
            this.cbFranquicia.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Franquicia";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Location = new System.Drawing.Point(779, 64);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(674, 64);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoPago.FormattingEnabled = true;
            this.cbTipoPago.Location = new System.Drawing.Point(88, 9);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(766, 21);
            this.cbTipoPago.TabIndex = 3;
            this.cbTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbTipoPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de pago";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // gdCuentasTipo
            // 
            this.gdCuentasTipo.AllowUserToAddRows = false;
            this.gdCuentasTipo.AllowUserToDeleteRows = false;
            this.gdCuentasTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdCuentasTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdCuentasTipo.Location = new System.Drawing.Point(0, 100);
            this.gdCuentasTipo.Name = "gdCuentasTipo";
            this.gdCuentasTipo.ReadOnly = true;
            this.gdCuentasTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdCuentasTipo.Size = new System.Drawing.Size(867, 309);
            this.gdCuentasTipo.TabIndex = 5;
            this.gdCuentasTipo.SelectionChanged += new System.EventHandler(this.gdCuentasTipo_SelectionChanged);
            // 
            // FrmCuentaAdministradora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 431);
            this.Controls.Add(this.gdCuentasTipo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCuentaAdministradora";
            this.Text = "FrmCuentaAdministradora";
            this.Load += new System.EventHandler(this.FrmCuentaAdministradora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdCuentasTipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.ComboBox cbFranquicia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gdCuentasTipo;
    }
}