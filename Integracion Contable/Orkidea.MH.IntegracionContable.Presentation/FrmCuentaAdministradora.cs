using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Orkidea.MH.IntegracionContable.Business;
using Orkidea.MH.IntegracionContable.Entities;

namespace Orkidea.MH.IntegracionContable.Presentation
{
    public partial class FrmCuentaAdministradora : Form
    {
        string connStrPos = ConfigurationManager.ConnectionStrings["connStrPos"].ConnectionString;
        string connStrErp = ConfigurationManager.ConnectionStrings["connStrErp"].ConnectionString;
        BizCuentasTipoPago bizCuentasTipoPago;

        List<TipoPgto> tiposPgto;
        List<Conta_Plano> cuentas;
        List<Administradora> administradoras;
        List<CuentaAdministradora> cuentasAdministradoras;

        public FrmCuentaAdministradora()
        {
            InitializeComponent();

            bizCuentasTipoPago = new BizCuentasTipoPago(connStrPos, connStrErp);
        }

        private void FrmCuentaAdministradora_Load(object sender, EventArgs e)
        {
            tiposPgto = new List<TipoPgto>();
            cuentas = new List<Conta_Plano>();
            administradoras = new List<Administradora>();
            cuentasAdministradoras = new List<CuentaAdministradora>();

            tiposPgto.Add(new TipoPgto()
            {
                desc_tipo_pgto = "Seleccione"
            });

            cuentas.Add(new Conta_Plano()
            {
                desc_conta = "Seleccione"
            });

            administradoras.Add(new Administradora()
            {
                administradora = "Seleccione"
            });

            tiposPgto.AddRange(bizCuentasTipoPago.GetPayTypeCardList());
            cuentas.AddRange(bizCuentasTipoPago.GetAccountList());
            administradoras.AddRange(bizCuentasTipoPago.GetCardList());

            cbTipoPago.DataSource = tiposPgto;
            cbTipoPago.ValueMember = "tipo_pgto";
            cbTipoPago.DisplayMember = "desc_tipo_pgto";

            cbCuenta.DataSource = cuentas;
            cbCuenta.ValueMember = "conta_contabil";
            cbCuenta.DisplayMember = "desc_conta";

            cbFranquicia.DataSource = administradoras;
            cbFranquicia.ValueMember = "idAdministradora";
            cbFranquicia.DisplayMember = "administradora";
        }

        private void cbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCuentasTipoPago();
        }

        private void gdCuentasTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (gdCuentasTipo.SelectedRows.Count > 0)
            {                
                string tipo = gdCuentasTipo.SelectedRows[0].Cells[0].Value.ToString();
                string administradora = gdCuentasTipo.SelectedRows[0].Cells[1].Value.ToString();
                string cuenta = gdCuentasTipo.SelectedRows[0].Cells[3].Value.ToString();

                cbTipoPago.SelectedValue = tipo;
                cbFranquicia.SelectedValue = administradora;
                cbCuenta.SelectedValue = cuenta;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedValue != null && cbFranquicia.SelectedValue != null && cbCuenta.SelectedValue != null)
            {
                string tipoLancamento = ConfigurationManager.AppSettings["tipoLancTarjetas"].ToString();

                CuentaAdministradora administradora = new CuentaAdministradora()
                {
                    tipo_pgto = cbTipoPago.SelectedValue.ToString(),
                    idAdministradora = cbFranquicia.SelectedValue.ToString(),
                    conta_contabil = cbCuenta.SelectedValue.ToString(),
                    tipoLancamento = tipoLancamento
                };

                if (cuentasAdministradoras.Where(x => x.tipo_pgto == cbTipoPago.SelectedValue.ToString() && x.idAdministradora == cbFranquicia.SelectedValue.ToString()).Count() == 0)
                    bizCuentasTipoPago.Add(administradora);
                else
                    bizCuentasTipoPago.Edit(administradora);

                bindCuentasTipoPago();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedValue != null && cbFranquicia.SelectedValue != null && cbCuenta.SelectedValue != null)
            {
                string tipoLancamento = ConfigurationManager.AppSettings["tipoLancTarjetas"].ToString();

                CuentaAdministradora administradora = new CuentaAdministradora()
                {
                    tipo_pgto = cbTipoPago.SelectedValue.ToString(),
                    idAdministradora = cbFranquicia.SelectedValue.ToString(),
                    conta_contabil = cbCuenta.SelectedValue.ToString(),
                    tipoLancamento = tipoLancamento
                };

                bizCuentasTipoPago.Remove(administradora);

                bindCuentasTipoPago();
            }
        }

        private void bindCuentasTipoPago()
        {
            if (cbTipoPago.SelectedValue != null)
            {
                cuentasAdministradoras = bizCuentasTipoPago.GetAccountCardList(cbTipoPago.SelectedValue.ToString());

                foreach (CuentaAdministradora item in cuentasAdministradoras)
                {
                    item.administradora = administradoras.Where(x => x.idAdministradora == item.idAdministradora).FirstOrDefault().administradora;
                }

                gdCuentasTipo.DataSource = null;
                gdCuentasTipo.AutoGenerateColumns = false;
                gdCuentasTipo.Columns.Clear();

                gdCuentasTipo.Columns.Add("tipo_pgto", "Tipo Pago");
                gdCuentasTipo.Columns.Add("idAdministradora", "idAdministradora");
                gdCuentasTipo.Columns.Add("administradora", "Administradora");
                gdCuentasTipo.Columns.Add("conta_contabil", "Cuenta");                

                gdCuentasTipo.Columns[0].DataPropertyName = "tipo_pgto";
                gdCuentasTipo.Columns[1].DataPropertyName = "idAdministradora";
                gdCuentasTipo.Columns[2].DataPropertyName = "administradora";
                gdCuentasTipo.Columns[3].DataPropertyName = "conta_contabil";                

                gdCuentasTipo.Columns[0].Visible = false;
                gdCuentasTipo.Columns[1].Visible = false;

                gdCuentasTipo.DataSource = cuentasAdministradoras;

                gdCuentasTipo.AutoResizeColumns();
            }
        }        
    }
}
