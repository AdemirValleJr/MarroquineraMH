using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orkidea.ComisionesMH.Entities;
using Orkidea.ComisionesMH.Business;

namespace Orkidea.ComisionesMH.UI
{
    public partial class FrmParametroTienda : Form
    {
        public FrmParametroTienda()
        {
            InitializeComponent();
        }

        List<LOJA_VENDEDORES> lsVendedores = new List<LOJA_VENDEDORES>();
        BizFiliais bizFiliais = new BizFiliais();
        BizLojaVendedores bizLojaVendedores = new BizLojaVendedores();
        BizParametroTienda bizParametroTienda = new BizParametroTienda();

        private void FrmParametroTienda_Load(object sender, EventArgs e)
        {
            List<FILIAIS> lstTiendas = new List<FILIAIS>();

            lstTiendas.Add(new FILIAIS() { COD_FILIAL = "_0", FILIAL = "" });

            lstTiendas.AddRange(bizFiliais.getFiliaisList().OrderBy(x => x.FILIAL).ToList());

            cmbTienda.DataSource = lstTiendas;
            cmbTienda.DisplayMember = "FILIAL";
            cmbTienda.ValueMember = "COD_FILIAL";



        }

        private void cmbTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTienda.SelectedValue.ToString().Length <= 6)
            {
                string tienda = cmbTienda.SelectedValue.ToString();

                List<LOJA_VENDEDORES> lstVendedores = new List<LOJA_VENDEDORES>();
                lstVendedores.Add(new LOJA_VENDEDORES() { VENDEDOR = "_0", NOME_VENDEDOR = "" });
                lstVendedores.AddRange(bizLojaVendedores.GetVendedorList(new FILIAIS() { COD_FILIAL = tienda }).OrderBy(x => x.NOME_VENDEDOR).ToList());

                cmbAdmin.DataSource = null;

                cmbAdmin.DataSource = lstVendedores;
                cmbAdmin.DisplayMember = "NOME_VENDEDOR";
                cmbAdmin.ValueMember = "VENDEDOR";

                CSS_PARAMETRO_TIENDA parametroTienda = bizParametroTienda.getParametroTienda(new CSS_PARAMETRO_TIENDA() { tienda = tienda });

                if (parametroTienda != null)
                {
                    cmbAdmin.SelectedValue = parametroTienda.admin;
                    //for (int i = 0; i < cmbAdmin.Items.Count; i++)
                    //{
                    //    if (((LOJA_VENDEDORES)cmbAdmin.Items[i]).VENDEDOR == parametroTienda.admin)
                    //        cmbAdmin.SelectedItem = i;
                    //}
                }
                else
                {
                    cmbAdmin.SelectedItem = null;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string tienda = cmbTienda.SelectedValue.ToString();

            if (tienda != "_0")
            {
                if (cmbAdmin.SelectedValue.ToString() != "_0")
                {
                    CSS_PARAMETRO_TIENDA parametroTienda = new CSS_PARAMETRO_TIENDA() { tienda = tienda, admin = cmbAdmin.SelectedValue.ToString() };
                    bizParametroTienda.SaveParametroVendedor(parametroTienda);
                }
                else
                    MessageBox.Show("Seleccione un vendedor");
            }
            else
                MessageBox.Show("Seleccione una tienda");
        }
    }
}
