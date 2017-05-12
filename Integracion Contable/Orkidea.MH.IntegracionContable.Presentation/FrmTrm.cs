using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orkidea.MH.IntegracionContable.Business;
using System.Configuration;
using Orkidea.MH.IntegracionContable.Entities;

namespace Orkidea.MH.IntegracionContable.Presentation
{
    public partial class FrmTrm : Form
    {
        string connStrPos = ConfigurationManager.ConnectionStrings["connStrPos"].ConnectionString;
        string connStrErp = ConfigurationManager.ConnectionStrings["connStrErp"].ConnectionString;

        BizFilial bizFilial;
        BizTrm bizTrm;

        public FrmTrm()
        {
            InitializeComponent();
        }

        private void FrmTrm_Load(object sender, EventArgs e)
        {
            bizFilial = new BizFilial(connStrPos);
            bizTrm = new BizTrm(connStrPos, connStrErp);

            List<Filial> filiales = bizFilial.GetList();

            refreshTrm();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            double dolares = 0;
            double euros = 0;

            txtStatus.Text = "";

            if (double.TryParse(txtDolares.Text.Replace('.', ','), out dolares))
            {
                if (double.TryParse(txtEuros.Text.Replace('.', ','), out euros))
                {
                    bizTrm.Add(new Trm()
                    {
                        fecha = dpFecha.Value,
                        dolar = dolares,
                        euro = euros
                    });

                    refreshTrm();
                }
                else             
                    txtStatus.Text = "Ingrese la TRM para Euro";
             
            }
            else
                txtStatus.Text = "Ingrese la TRM para Dolar";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in gdTrm.SelectedRows)
            {
                DateTime fecha = DateTime.Parse(item.Cells[0].Value.ToString());
                string filial = item.Cells[1].Value.ToString();

                bizTrm.Remove(new Trm() { fecha = fecha });
            }

            refreshTrm();
        }

        public void refreshTrm()
        {
            List<Trm> list = bizTrm.GetList();
            gdTrm.DataSource = list;
        }
    }
}
