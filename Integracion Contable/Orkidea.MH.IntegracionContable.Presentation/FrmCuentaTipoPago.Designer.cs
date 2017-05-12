namespace Orkidea.MH.IntegracionContable.Presentation
{
    partial class FrmCuentaTipoPago
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
            this.txtTipoLancamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAsignado = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCuenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdCuentasTipo = new System.Windows.Forms.DataGridView();
            this.chLineaTercero = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdCuentasTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chLineaTercero);
            this.panel1.Controls.Add(this.txtTipoLancamento);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAsignado);
            this.panel1.Controls.Add(this.btnBorrar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtPeso);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbCuenta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbTipoPago);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 100);
            this.panel1.TabIndex = 2;
            // 
            // txtTipoLancamento
            // 
            this.txtTipoLancamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoLancamento.Location = new System.Drawing.Point(741, 36);
            this.txtTipoLancamento.Name = "txtTipoLancamento";
            this.txtTipoLancamento.Size = new System.Drawing.Size(60, 20);
            this.txtTipoLancamento.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo Lanzamiento";
            // 
            // txtAsignado
            // 
            this.txtAsignado.AutoSize = true;
            this.txtAsignado.Location = new System.Drawing.Point(12, 69);
            this.txtAsignado.Name = "txtAsignado";
            this.txtAsignado.Size = new System.Drawing.Size(80, 13);
            this.txtAsignado.TabIndex = 10;
            this.txtAsignado.Text = "Tiene asignado";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Location = new System.Drawing.Point(843, 64);
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
            this.btnGuardar.Location = new System.Drawing.Point(738, 64);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtPeso
            // 
            this.txtPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeso.Location = new System.Drawing.Point(542, 37);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(99, 20);
            this.txtPeso.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Peso";
            // 
            // cbCuenta
            // 
            this.cbCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCuenta.FormattingEnabled = true;
            this.cbCuenta.Location = new System.Drawing.Point(110, 36);
            this.cbCuenta.Name = "cbCuenta";
            this.cbCuenta.Size = new System.Drawing.Size(389, 21);
            this.cbCuenta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cuenta contable";
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoPago.FormattingEnabled = true;
            this.cbTipoPago.Location = new System.Drawing.Point(110, 9);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(808, 21);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdCuentasTipo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 338);
            this.panel2.TabIndex = 4;
            // 
            // gdCuentasTipo
            // 
            this.gdCuentasTipo.AllowUserToAddRows = false;
            this.gdCuentasTipo.AllowUserToDeleteRows = false;
            this.gdCuentasTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdCuentasTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdCuentasTipo.Location = new System.Drawing.Point(0, 0);
            this.gdCuentasTipo.Name = "gdCuentasTipo";
            this.gdCuentasTipo.ReadOnly = true;
            this.gdCuentasTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdCuentasTipo.Size = new System.Drawing.Size(931, 338);
            this.gdCuentasTipo.TabIndex = 0;
            this.gdCuentasTipo.SelectionChanged += new System.EventHandler(this.gdCuentasTipo_SelectionChanged);
            // 
            // chLineaTercero
            // 
            this.chLineaTercero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chLineaTercero.AutoSize = true;
            this.chLineaTercero.Location = new System.Drawing.Point(813, 35);
            this.chLineaTercero.Name = "chLineaTercero";
            this.chLineaTercero.Size = new System.Drawing.Size(106, 17);
            this.chLineaTercero.TabIndex = 13;
            this.chLineaTercero.Text = "Linea por tercero";
            this.chLineaTercero.UseVisualStyleBackColor = true;
            // 
            // FrmCuentaTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 460);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCuentaTipoPago";
            this.Text = "Cuentas por tipo de pago";
            this.Load += new System.EventHandler(this.FrmCuentaTipoPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdCuentasTipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gdCuentasTipo;
        private System.Windows.Forms.Label txtAsignado;
        private System.Windows.Forms.TextBox txtTipoLancamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chLineaTercero;

    }
}