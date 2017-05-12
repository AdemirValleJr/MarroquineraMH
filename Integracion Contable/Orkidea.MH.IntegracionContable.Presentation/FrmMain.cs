using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Orkidea.MH.IntegracionContable.Presentation
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCuentaTipoPago frm = new FrmCuentaTipoPago();

            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmTrm frm = new FrmTrm();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIntegrador frm = new FrmIntegrador();
            frm.Show();
        }

        private void cuentasPorTipoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuentaTipoPago newMDIChild = new FrmCuentaTipoPago();            
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;            
            newMDIChild.Show();
        }

        private void cuentasPorFranquiciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuentaAdministradora newMDIChild = new FrmCuentaAdministradora();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void tRMTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrm newMDIChild = new FrmTrm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void integrarTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIntegrador newMDIChild = new FrmIntegrador();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void tsmiCascada_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tsmiVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tsmiHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tsmiCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form miFormularioHijo in this.MdiChildren)
                {
                    miFormularioHijo.Close();
                }
            }
            catch (Exception miExcepcion)
            {
                MessageBox.Show(miExcepcion.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        
    }
}
