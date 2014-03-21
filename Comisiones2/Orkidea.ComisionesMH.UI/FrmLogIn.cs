using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orkidea.ComisionesMH.Business;

namespace Orkidea.ComisionesMH.UI
{
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            BizLogin bizLogin = new BizLogin();

            if (bizLogin.Login(txtUsuario.Text, txtPassword.Text))
            {
                FrmLiquidacion frmLiquidacion = new FrmLiquidacion();
                frmLiquidacion.Show();
                this.Hide();
            }
        }
    }
}
