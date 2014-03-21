using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orkidea.ComisionesMH.Business;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.UI
{
    public partial class FrmPresupuestoVentas : Form
    {
        BizPresupuestoTendas bizPresupuestoTendas = new BizPresupuestoTendas();

        public FrmPresupuestoVentas()
        {
            InitializeComponent();
        }

        private void FrmPresupuestoVentas_Load(object sender, EventArgs e)
        {
            BizLojasRede bizLojasRede = new BizLojasRede();
            List<LOJAS_REDE> lstLojasRede = bizLojasRede.GetRedeLojasList();

            cmbRedDeTiendas.DataSource = lstLojasRede;
            cmbRedDeTiendas.DisplayMember = "DESC_REDE_LOJAS";
            cmbRedDeTiendas.ValueMember = "REDE_LOJAS";
            
        }

        private void cmbRedDeTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BizFiliais bizFiliais = new BizFiliais();
            List<FILIAIS> lstTiendas = new List<FILIAIS>();

            cmbTienda.DataSource = null;

            if (cmbRedDeTiendas.SelectedValue.ToString().Length <= 6)
            {
                lstTiendas.Clear();
                lstTiendas.Add(new FILIAIS() { COD_FILIAL = "_0", FILIAL = "Todas las tiendas" });

                List<FILIAIS> lstFiliais = bizFiliais.getFiliaisList(new LOJAS_REDE() { REDE_LOJAS = cmbRedDeTiendas.SelectedValue.ToString() }).OrderBy(x => x.FILIAL).ToList();

                foreach (FILIAIS item in lstFiliais)
                    lstTiendas.Add(item);
                

                cmbTienda.DataSource = lstTiendas;
                cmbTienda.DisplayMember = "FILIAL";
                cmbTienda.ValueMember = "COD_FILIAL";
            }
            else
                cmbRedDeTiendas.Text = "";
        }

        private void btnBuscarPresupuesto_Click(object sender, EventArgs e)
        {
            List<CSS_PRESUPUESTO_TIENDAS> lstPresupuesto = bizPresupuestoTendas.getPresupuestoVentasList(new FILIAIS() { COD_FILIAL = cmbTienda.SelectedValue.ToString() }, int.Parse(txtAno.Text));

            if (lstPresupuesto.Count== 0)
            {
                lstPresupuesto = new List<CSS_PRESUPUESTO_TIENDAS>();

                for (int i = 0; i < 12; i++)
                    lstPresupuesto.Add(new CSS_PRESUPUESTO_TIENDAS() { tienda = cmbTienda.SelectedValue.ToString(), ano = int.Parse(txtAno.Text), mes = i+1, presupuesto = 0 });
            }

            grdPresupuesto.DataSource = lstPresupuesto;
            grdPresupuesto.Columns["mes"].HeaderText = "Mes";
            grdPresupuesto.Columns["presupuesto"].HeaderText = "Presupuesto";
            
            grdPresupuesto.Columns["tienda"].Visible = false;
            grdPresupuesto.Columns["ano"].Visible = false;

            grdPresupuesto.Columns["mes"].ReadOnly = true;

            //grdPresupuesto.Columns["presupuesto"].
        }

        private void btnGuardarPresupuesto_Click(object sender, EventArgs e)
        {            
            foreach (DataGridViewRow item in grdPresupuesto.Rows)            
                bizPresupuestoTendas.SavePresupuestoVentas(new CSS_PRESUPUESTO_TIENDAS() { tienda = item.Cells["tienda"].Value.ToString(), ano = (int)item.Cells["ano"].Value, mes = (int)item.Cells["mes"].Value, presupuesto = (decimal)item.Cells["presupuesto"].Value });

            MessageBox.Show("Presupuesto guardado");
        }     
    }
}
