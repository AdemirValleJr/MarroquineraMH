namespace Orkidea.MH.IntegracionContable.Presentation
{
    partial class FrmTrm
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtEuros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDolares = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdTrm = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdTrm)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
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
            this.panel1.Controls.Add(this.btnBorrar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtEuros);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDolares);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dpFecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 71);
            this.panel1.TabIndex = 1;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Location = new System.Drawing.Point(397, 40);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 13;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(292, 40);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtEuros
            // 
            this.txtEuros.Location = new System.Drawing.Point(372, 12);
            this.txtEuros.Name = "txtEuros";
            this.txtEuros.Size = new System.Drawing.Size(99, 20);
            this.txtEuros.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Euros";
            // 
            // txtDolares
            // 
            this.txtDolares.Location = new System.Drawing.Point(218, 13);
            this.txtDolares.Name = "txtDolares";
            this.txtDolares.Size = new System.Drawing.Size(99, 20);
            this.txtDolares.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dolares";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(64, 14);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(99, 20);
            this.dpFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdTrm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 304);
            this.panel2.TabIndex = 2;
            // 
            // gdTrm
            // 
            this.gdTrm.AllowUserToAddRows = false;
            this.gdTrm.AllowUserToDeleteRows = false;
            this.gdTrm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdTrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdTrm.Location = new System.Drawing.Point(0, 0);
            this.gdTrm.Name = "gdTrm";
            this.gdTrm.ReadOnly = true;
            this.gdTrm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdTrm.Size = new System.Drawing.Size(484, 304);
            this.gdTrm.TabIndex = 0;
            // 
            // FrmTrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmTrm";
            this.Text = "TRM tiendas";
            this.Load += new System.EventHandler(this.FrmTrm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdTrm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEuros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDolares;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gdTrm;
    }
}