using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orkidea.ComisionesMH.Business;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.UI
{
    public partial class FrmParametroVendedor : Form
    {
        List<LOJA_VENDEDORES> lsVendedores = new List<LOJA_VENDEDORES>();
        BizLojaVendedores bizLojaVendedores = new BizLojaVendedores();
        BizParametroVendedor bizParametroVendedor = new BizParametroVendedor();

        public FrmParametroVendedor()
        {
            InitializeComponent();
        }

        private void FrmParametroVendedor_Load(object sender, EventArgs e)
        {
            BizFiliais bizFiliais = new BizFiliais();
            List<FILIAIS> lstTiendas = new List<FILIAIS>();

            lstTiendas.Add(new FILIAIS() { COD_FILIAL = "_0", FILIAL = "" });

            lstTiendas.AddRange(bizFiliais.getFiliaisList().OrderBy(x => x.FILIAL).ToList());

            cmbTienda.DataSource = lstTiendas;
            cmbTienda.DisplayMember = "FILIAL";
            cmbTienda.ValueMember = "COD_FILIAL";
        }

        private void lstVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVendedores.SelectedItem != null && lstVendedores.SelectedValue.ToString() != "Orkidea.ComisionesMH.Entities.LOJA_VENDEDORES")
            {
                CSS_PARAMETRO_VENDEDOR parametroVendedor = bizParametroVendedor.getParametroVendedor(new CSS_PARAMETRO_VENDEDOR() { vendedor = lstVendedores.SelectedValue.ToString() });

                if (parametroVendedor != null)
                {
                    txtComiCumple.Text = parametroVendedor.comisionCumple.ToString();
                    txtComiNoCumple.Text = parametroVendedor.comisionNoCumple.ToString();
                }
                else
                {
                    txtComiCumple.Text = "0";
                    txtComiNoCumple.Text = "0";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            NumberStyles style;
            CultureInfo provider;

            style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            provider = new CultureInfo("en-US");

            CSS_PARAMETRO_VENDEDOR parametroVendedor = new CSS_PARAMETRO_VENDEDOR()
            {
                vendedor = lstVendedores.SelectedValue.ToString(),
                comisionCumple = decimal.Parse(txtComiCumple.Text, style, provider),
                comisionNoCumple = decimal.Parse(txtComiNoCumple.Text, style, provider),
            };

            bizParametroVendedor.SaveParametroVendedor(parametroVendedor);
        }

        private void cmbTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTienda.SelectedValue.ToString().Length <= 6)
            {


                lstVendedores.DataSource = null;
                lsVendedores = bizLojaVendedores.GetVendedorList(new FILIAIS() { COD_FILIAL = cmbTienda.SelectedValue.ToString() }).OrderBy(x => x.NOME_VENDEDOR).ToList();


                lstVendedores.DataSource = lsVendedores;
                lstVendedores.DisplayMember = "NOME_VENDEDOR";
                lstVendedores.ValueMember = "VENDEDOR";

                lstVendedores.SelectedItem = null;
            }
        }

    }
}
