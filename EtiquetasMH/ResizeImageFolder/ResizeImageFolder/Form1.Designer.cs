namespace ResizeImageFolder
{
    partial class Form1
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
            this.txtOriginPath = new System.Windows.Forms.TextBox();
            this.btnBrowseOrigin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseDestiny = new System.Windows.Forms.Button();
            this.txtDestinyPath = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOriginPath
            // 
            this.txtOriginPath.Location = new System.Drawing.Point(12, 35);
            this.txtOriginPath.Name = "txtOriginPath";
            this.txtOriginPath.ReadOnly = true;
            this.txtOriginPath.Size = new System.Drawing.Size(571, 20);
            this.txtOriginPath.TabIndex = 0;
            // 
            // btnBrowseOrigin
            // 
            this.btnBrowseOrigin.AutoSize = true;
            this.btnBrowseOrigin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseOrigin.Location = new System.Drawing.Point(589, 33);
            this.btnBrowseOrigin.Name = "btnBrowseOrigin";
            this.btnBrowseOrigin.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseOrigin.TabIndex = 1;
            this.btnBrowseOrigin.Text = "...";
            this.btnBrowseOrigin.UseVisualStyleBackColor = true;
            this.btnBrowseOrigin.Click += new System.EventHandler(this.btnBrowseOrigin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Carpeta Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Carpeta Destino";
            // 
            // btnBrowseDestiny
            // 
            this.btnBrowseDestiny.AutoSize = true;
            this.btnBrowseDestiny.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseDestiny.Location = new System.Drawing.Point(589, 99);
            this.btnBrowseDestiny.Name = "btnBrowseDestiny";
            this.btnBrowseDestiny.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseDestiny.TabIndex = 4;
            this.btnBrowseDestiny.Text = "...";
            this.btnBrowseDestiny.UseVisualStyleBackColor = true;
            this.btnBrowseDestiny.Click += new System.EventHandler(this.btnBrowseDestiny_Click);
            // 
            // txtDestinyPath
            // 
            this.txtDestinyPath.Location = new System.Drawing.Point(12, 101);
            this.txtDestinyPath.Name = "txtDestinyPath";
            this.txtDestinyPath.ReadOnly = true;
            this.txtDestinyPath.Size = new System.Drawing.Size(571, 20);
            this.txtDestinyPath.TabIndex = 3;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(289, 143);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Procesar";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtAlto
            // 
            this.txtAlto.Location = new System.Drawing.Point(44, 145);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(52, 20);
            this.txtAlto.TabIndex = 7;
            this.txtAlto.Text = "90";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ancho";
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(195, 145);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(52, 20);
            this.txtAncho.TabIndex = 9;
            this.txtAncho.Text = "76";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "px";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "px";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(540, 142);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 195);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAncho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAlto);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseDestiny);
            this.Controls.Add(this.txtDestinyPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowseOrigin);
            this.Controls.Add(this.txtOriginPath);
            this.Name = "Form1";
            this.Text = "Redimensionador de imagenes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOriginPath;
        private System.Windows.Forms.Button btnBrowseOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseDestiny;
        private System.Windows.Forms.TextBox txtDestinyPath;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
    }
}

