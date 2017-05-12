namespace Orkidea.MH.IntegracionContable.Presentation
{
    partial class FrmMain
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
            this.cuentasPorTipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasPorTipoDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRMTiendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrarTiendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascada = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasPorFranquiciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasPorTipoToolStripMenuItem,
            this.transaccionesToolStripMenuItem,
            this.tsmVentanas,
            this.tsmSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentasPorTipoToolStripMenuItem
            // 
            this.cuentasPorTipoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasPorTipoDePagoToolStripMenuItem,
            this.cuentasPorFranquiciaToolStripMenuItem,
            this.tRMTiendasToolStripMenuItem});
            this.cuentasPorTipoToolStripMenuItem.Name = "cuentasPorTipoToolStripMenuItem";
            this.cuentasPorTipoToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.cuentasPorTipoToolStripMenuItem.Text = "Parametros";
            // 
            // cuentasPorTipoDePagoToolStripMenuItem
            // 
            this.cuentasPorTipoDePagoToolStripMenuItem.Name = "cuentasPorTipoDePagoToolStripMenuItem";
            this.cuentasPorTipoDePagoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cuentasPorTipoDePagoToolStripMenuItem.Text = "Cuentas por tipo de pago";
            this.cuentasPorTipoDePagoToolStripMenuItem.Click += new System.EventHandler(this.cuentasPorTipoDePagoToolStripMenuItem_Click);
            // 
            // tRMTiendasToolStripMenuItem
            // 
            this.tRMTiendasToolStripMenuItem.Name = "tRMTiendasToolStripMenuItem";
            this.tRMTiendasToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.tRMTiendasToolStripMenuItem.Text = "TRM tiendas";
            this.tRMTiendasToolStripMenuItem.Click += new System.EventHandler(this.tRMTiendasToolStripMenuItem_Click);
            // 
            // transaccionesToolStripMenuItem
            // 
            this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.integrarTiendasToolStripMenuItem});
            this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
            this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.transaccionesToolStripMenuItem.Text = "Transacciones";
            // 
            // integrarTiendasToolStripMenuItem
            // 
            this.integrarTiendasToolStripMenuItem.Name = "integrarTiendasToolStripMenuItem";
            this.integrarTiendasToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.integrarTiendasToolStripMenuItem.Text = "Integrar tiendas";
            this.integrarTiendasToolStripMenuItem.Click += new System.EventHandler(this.integrarTiendasToolStripMenuItem_Click);
            // 
            // tsmVentanas
            // 
            this.tsmVentanas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCascada,
            this.tsmiVertical,
            this.tsmiHorizontal,
            this.tsmiCerrar});
            this.tsmVentanas.Name = "tsmVentanas";
            this.tsmVentanas.Size = new System.Drawing.Size(67, 20);
            this.tsmVentanas.Text = "Ventanas";
            // 
            // tsmiCascada
            // 
            this.tsmiCascada.Name = "tsmiCascada";
            this.tsmiCascada.Size = new System.Drawing.Size(129, 22);
            this.tsmiCascada.Text = "Cascada";
            this.tsmiCascada.Click += new System.EventHandler(this.tsmiCascada_Click);
            // 
            // tsmiVertical
            // 
            this.tsmiVertical.Name = "tsmiVertical";
            this.tsmiVertical.Size = new System.Drawing.Size(129, 22);
            this.tsmiVertical.Text = "Vertical";
            this.tsmiVertical.Click += new System.EventHandler(this.tsmiVertical_Click);
            // 
            // tsmiHorizontal
            // 
            this.tsmiHorizontal.Name = "tsmiHorizontal";
            this.tsmiHorizontal.Size = new System.Drawing.Size(129, 22);
            this.tsmiHorizontal.Text = "Horizontal";
            this.tsmiHorizontal.Click += new System.EventHandler(this.tsmiHorizontal_Click);
            // 
            // tsmiCerrar
            // 
            this.tsmiCerrar.Name = "tsmiCerrar";
            this.tsmiCerrar.Size = new System.Drawing.Size(129, 22);
            this.tsmiCerrar.Text = "Cerrar";
            this.tsmiCerrar.Click += new System.EventHandler(this.tsmiCerrar_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalir});
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(41, 20);
            this.tsmSalir.Text = "Salir";
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(96, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // cuentasPorFranquiciaToolStripMenuItem
            // 
            this.cuentasPorFranquiciaToolStripMenuItem.Name = "cuentasPorFranquiciaToolStripMenuItem";
            this.cuentasPorFranquiciaToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cuentasPorFranquiciaToolStripMenuItem.Text = "Cuentas por franquicia";
            this.cuentasPorFranquiciaToolStripMenuItem.Click += new System.EventHandler(this.cuentasPorFranquiciaToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 434);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Integración Contable MH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasPorTipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasPorTipoDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRMTiendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integrarTiendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmVentanas;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascada;
        private System.Windows.Forms.ToolStripMenuItem tsmiVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmiHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrar;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem cuentasPorFranquiciaToolStripMenuItem;
    }
}

