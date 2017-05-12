namespace Orkidea.MH.IntegracionContable.Presentation
{
    partial class FrmIntegrador
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabIntegracion = new System.Windows.Forms.TabControl();
            this.tabtendas = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgDetallePreview = new System.Windows.Forms.DataGridView();
            this.cbDiaLiquidado = new System.Windows.Forms.ComboBox();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.btnIntegraContabilidad = new System.Windows.Forms.Button();
            this.dgEncabezadoPreview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbFechaIntegracion = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTiendaIntegrar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabDifCambio = new System.Windows.Forms.TabPage();
            this.dgDifCambio = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCalculaDifCambio = new System.Windows.Forms.Button();
            this.txtEuros = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDolares = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTiendaCalcular = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIntegraDifCambio = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabIntegracion.SuspendLayout();
            this.tabtendas.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetallePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEncabezadoPreview)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabDifCambio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDifCambio)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(942, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 21);
            this.panel1.TabIndex = 1;
            // 
            // tabIntegracion
            // 
            this.tabIntegracion.Controls.Add(this.tabtendas);
            this.tabIntegracion.Controls.Add(this.tabDifCambio);
            this.tabIntegracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIntegracion.Location = new System.Drawing.Point(0, 21);
            this.tabIntegracion.Name = "tabIntegracion";
            this.tabIntegracion.SelectedIndex = 0;
            this.tabIntegracion.Size = new System.Drawing.Size(942, 504);
            this.tabIntegracion.TabIndex = 2;
            // 
            // tabtendas
            // 
            this.tabtendas.Controls.Add(this.panel5);
            this.tabtendas.Controls.Add(this.panel3);
            this.tabtendas.Controls.Add(this.panel2);
            this.tabtendas.Location = new System.Drawing.Point(4, 22);
            this.tabtendas.Name = "tabtendas";
            this.tabtendas.Padding = new System.Windows.Forms.Padding(3);
            this.tabtendas.Size = new System.Drawing.Size(934, 478);
            this.tabtendas.TabIndex = 0;
            this.tabtendas.Text = "Integrar tiendas";
            this.tabtendas.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgDetallePreview);
            this.panel5.Controls.Add(this.cbDiaLiquidado);
            this.panel5.Controls.Add(this.btnLiquidar);
            this.panel5.Controls.Add(this.btnIntegraContabilidad);
            this.panel5.Controls.Add(this.dgEncabezadoPreview);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(130, 57);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(801, 418);
            this.panel5.TabIndex = 2;
            // 
            // dgDetallePreview
            // 
            this.dgDetallePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetallePreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetallePreview.Location = new System.Drawing.Point(4, 142);
            this.dgDetallePreview.Name = "dgDetallePreview";
            this.dgDetallePreview.ReadOnly = true;
            this.dgDetallePreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetallePreview.Size = new System.Drawing.Size(792, 269);
            this.dgDetallePreview.TabIndex = 13;
            // 
            // cbDiaLiquidado
            // 
            this.cbDiaLiquidado.Enabled = false;
            this.cbDiaLiquidado.FormattingEnabled = true;
            this.cbDiaLiquidado.Location = new System.Drawing.Point(231, 10);
            this.cbDiaLiquidado.Name = "cbDiaLiquidado";
            this.cbDiaLiquidado.Size = new System.Drawing.Size(119, 21);
            this.cbDiaLiquidado.TabIndex = 8;
            this.cbDiaLiquidado.SelectedIndexChanged += new System.EventHandler(this.cbDiaLiquidado_SelectedIndexChanged);
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Enabled = false;
            this.btnLiquidar.Location = new System.Drawing.Point(6, 8);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(75, 23);
            this.btnLiquidar.TabIndex = 12;
            this.btnLiquidar.Text = "Liquidar";
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // btnIntegraContabilidad
            // 
            this.btnIntegraContabilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIntegraContabilidad.Enabled = false;
            this.btnIntegraContabilidad.Location = new System.Drawing.Point(721, 8);
            this.btnIntegraContabilidad.Name = "btnIntegraContabilidad";
            this.btnIntegraContabilidad.Size = new System.Drawing.Size(75, 23);
            this.btnIntegraContabilidad.TabIndex = 11;
            this.btnIntegraContabilidad.Text = "Integrar";
            this.btnIntegraContabilidad.UseVisualStyleBackColor = true;
            this.btnIntegraContabilidad.Click += new System.EventHandler(this.btnIntegraContabilidad_Click);
            // 
            // dgEncabezadoPreview
            // 
            this.dgEncabezadoPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEncabezadoPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEncabezadoPreview.Location = new System.Drawing.Point(4, 43);
            this.dgEncabezadoPreview.Name = "dgEncabezadoPreview";
            this.dgEncabezadoPreview.ReadOnly = true;
            this.dgEncabezadoPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEncabezadoPreview.Size = new System.Drawing.Size(792, 93);
            this.dgEncabezadoPreview.TabIndex = 10;
            this.dgEncabezadoPreview.SelectionChanged += new System.EventHandler(this.dgEncabezadoPreview_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vista preliminar para el dia";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbFechaIntegracion);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(127, 418);
            this.panel3.TabIndex = 1;
            // 
            // lbFechaIntegracion
            // 
            this.lbFechaIntegracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFechaIntegracion.FormattingEnabled = true;
            this.lbFechaIntegracion.Location = new System.Drawing.Point(8, 43);
            this.lbFechaIntegracion.Name = "lbFechaIntegracion";
            this.lbFechaIntegracion.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFechaIntegracion.Size = new System.Drawing.Size(113, 368);
            this.lbFechaIntegracion.TabIndex = 9;
            this.lbFechaIntegracion.SelectedIndexChanged += new System.EventHandler(this.lbFechaIntegracion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Periodos a integrar";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbTiendaIntegrar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 54);
            this.panel2.TabIndex = 0;
            // 
            // cbTiendaIntegrar
            // 
            this.cbTiendaIntegrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTiendaIntegrar.FormattingEnabled = true;
            this.cbTiendaIntegrar.Location = new System.Drawing.Point(51, 12);
            this.cbTiendaIntegrar.Name = "cbTiendaIntegrar";
            this.cbTiendaIntegrar.Size = new System.Drawing.Size(872, 21);
            this.cbTiendaIntegrar.TabIndex = 7;
            this.cbTiendaIntegrar.SelectedIndexChanged += new System.EventHandler(this.cbTiendaIntegrar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tienda";
            // 
            // tabDifCambio
            // 
            this.tabDifCambio.Controls.Add(this.dgDifCambio);
            this.tabDifCambio.Controls.Add(this.panel4);
            this.tabDifCambio.Location = new System.Drawing.Point(4, 22);
            this.tabDifCambio.Name = "tabDifCambio";
            this.tabDifCambio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDifCambio.Size = new System.Drawing.Size(934, 478);
            this.tabDifCambio.TabIndex = 1;
            this.tabDifCambio.Text = "Diferencia en cambio";
            this.tabDifCambio.UseVisualStyleBackColor = true;
            // 
            // dgDifCambio
            // 
            this.dgDifCambio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDifCambio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDifCambio.Location = new System.Drawing.Point(3, 104);
            this.dgDifCambio.Name = "dgDifCambio";
            this.dgDifCambio.ReadOnly = true;
            this.dgDifCambio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDifCambio.Size = new System.Drawing.Size(928, 371);
            this.dgDifCambio.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnIntegraDifCambio);
            this.panel4.Controls.Add(this.btnCalculaDifCambio);
            this.panel4.Controls.Add(this.txtEuros);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtDolares);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dpFecha);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbTiendaCalcular);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(928, 95);
            this.panel4.TabIndex = 1;
            // 
            // btnCalculaDifCambio
            // 
            this.btnCalculaDifCambio.Location = new System.Drawing.Point(309, 40);
            this.btnCalculaDifCambio.Name = "btnCalculaDifCambio";
            this.btnCalculaDifCambio.Size = new System.Drawing.Size(75, 23);
            this.btnCalculaDifCambio.TabIndex = 14;
            this.btnCalculaDifCambio.Text = "Calcular";
            this.btnCalculaDifCambio.UseVisualStyleBackColor = true;
            this.btnCalculaDifCambio.Click += new System.EventHandler(this.btnCalculaDifCambio_Click);
            // 
            // txtEuros
            // 
            this.txtEuros.Location = new System.Drawing.Point(203, 42);
            this.txtEuros.Name = "txtEuros";
            this.txtEuros.Size = new System.Drawing.Size(100, 20);
            this.txtEuros.TabIndex = 13;
            this.txtEuros.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Euros";
            // 
            // txtDolares
            // 
            this.txtDolares.Location = new System.Drawing.Point(51, 42);
            this.txtDolares.Name = "txtDolares";
            this.txtDolares.Size = new System.Drawing.Size(100, 20);
            this.txtDolares.TabIndex = 11;
            this.txtDolares.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dolares";
            // 
            // dpFecha
            // 
            this.dpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(815, 13);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(98, 20);
            this.dpFecha.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(772, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha";
            // 
            // cbTiendaCalcular
            // 
            this.cbTiendaCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTiendaCalcular.FormattingEnabled = true;
            this.cbTiendaCalcular.Location = new System.Drawing.Point(51, 12);
            this.cbTiendaCalcular.Name = "cbTiendaCalcular";
            this.cbTiendaCalcular.Size = new System.Drawing.Size(715, 21);
            this.cbTiendaCalcular.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tienda";
            // 
            // btnIntegraDifCambio
            // 
            this.btnIntegraDifCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIntegraDifCambio.Enabled = false;
            this.btnIntegraDifCambio.Location = new System.Drawing.Point(838, 40);
            this.btnIntegraDifCambio.Name = "btnIntegraDifCambio";
            this.btnIntegraDifCambio.Size = new System.Drawing.Size(75, 23);
            this.btnIntegraDifCambio.TabIndex = 15;
            this.btnIntegraDifCambio.Text = "Integrar";
            this.btnIntegraDifCambio.UseVisualStyleBackColor = true;
            this.btnIntegraDifCambio.Click += new System.EventHandler(this.btnIntegraDifCambio_Click);
            // 
            // FrmIntegrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 547);
            this.Controls.Add(this.tabIntegracion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmIntegrador";
            this.Text = "Integracion Contable";
            this.Load += new System.EventHandler(this.FrmIntegrador_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabIntegracion.ResumeLayout(false);
            this.tabtendas.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetallePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEncabezadoPreview)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabDifCambio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDifCambio)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabIntegracion;
        private System.Windows.Forms.TabPage tabtendas;
        private System.Windows.Forms.TabPage tabDifCambio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbTiendaIntegrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnIntegraContabilidad;
        private System.Windows.Forms.DataGridView dgEncabezadoPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCalculaDifCambio;
        private System.Windows.Forms.TextBox txtEuros;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDolares;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTiendaCalcular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbFechaIntegracion;
        private System.Windows.Forms.Button btnLiquidar;
        private System.Windows.Forms.ComboBox cbDiaLiquidado;
        private System.Windows.Forms.DataGridView dgDetallePreview;
        private System.Windows.Forms.DataGridView dgDifCambio;
        private System.Windows.Forms.Button btnIntegraDifCambio;
    }
}