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
    public partial class FrmCuentaTipoPago : Form
    {
        string connStrPos = ConfigurationManager.ConnectionStrings["connStrPos"].ConnectionString;
        string connStrErp = ConfigurationManager.ConnectionStrings["connStrErp"].ConnectionString;
        BizCuentasTipoPago bizCuentasTipoPago;

        List<TipoPgto> tiposPgto;
        List<Conta_Plano> cuentas;
        List<CuentaTipoPago> cuentaTipoPago;
        List<CuentaTipoPago> _cuentaTipoPago;

        public FrmCuentaTipoPago()
        {
            InitializeComponent();
            bizCuentasTipoPago = new BizCuentasTipoPago(connStrPos, connStrErp);

            cuentaTipoPago = bizCuentasTipoPago.GetList();
        }

        private void FrmCuentaTipoPago_Load(object sender, EventArgs e)
        {
            tiposPgto = new List<TipoPgto>();
            cuentas = new List<Conta_Plano>();

            tiposPgto.Add(new TipoPgto()
            {
                desc_tipo_pgto = "Seleccione"
            });

            cuentas.Add(new Conta_Plano()
            {
                desc_conta = "Seleccione"
            });

            tiposPgto.AddRange(bizCuentasTipoPago.GetPayTypeNoCardList());
            cuentas.AddRange(bizCuentasTipoPago.GetAccountList());

            cbTipoPago.DataSource = tiposPgto;
            cbTipoPago.ValueMember = "tipo_pgto";
            cbTipoPago.DisplayMember = "desc_tipo_pgto";

            cbCuenta.DataSource = cuentas;
            cbCuenta.ValueMember = "conta_contabil";
            cbCuenta.DisplayMember = "desc_conta";


        }

        private void cbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedValue != null)
            {
                cuentasTipo();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbCuenta.SelectedValue != null && cbTipoPago.SelectedValue != null && !string.IsNullOrEmpty( txtTipoLancamento.Text))
            {
                string cuenta = cbCuenta.SelectedValue.ToString();
                string tipoPago = cbTipoPago.SelectedValue.ToString();
                string tipoLancamento = txtTipoLancamento.Text;

                double pesoAsignado = 0;
                double pendienteAsignar = 0;

                pendienteAsignar = 100 - _cuentaTipoPago.Where(x => x.tipo_pgto == tipoPago).Sum(x => x.peso);

                if (double.TryParse(txtPeso.Text.Replace('.',','), out pesoAsignado))
                {
                    if (pendienteAsignar >= pesoAsignado)
                    {
                        CuentaTipoPago registro = new CuentaTipoPago()
                        {
                            conta_contabil = cbCuenta.SelectedValue.ToString(),
                            tipo_pgto = cbTipoPago.SelectedValue.ToString(),
                            peso = pesoAsignado,
                            tipoLancamento = txtTipoLancamento.Text,
                            lineaPorTercero = chLineaTercero.Checked
                        };

                        if (_cuentaTipoPago.Where(x => x.conta_contabil == cuenta && x.tipo_pgto == tipoPago).Count() == 0)
                            bizCuentasTipoPago.Add(registro);
                        else
                            bizCuentasTipoPago.Edit(registro);

                        cuentasTipo();
                    }
                    else
                        txtStatus.Text = string.Format("La distribucion por cuentas no puede superar el 100% está intentando asignar {0}%", ((100 - pendienteAsignar) + pesoAsignado));
                }
                else
                    txtStatus.Text = "El peso debe ser numerico";
            }
            else
                txtStatus.Text = "Todos los campos son obligatorios";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbTipoPago.SelectedValue.ToString()))
            {
                if (!string.IsNullOrEmpty(cbCuenta.SelectedValue.ToString()))
                {
                    bizCuentasTipoPago.Remove(new CuentaTipoPago()
                    {
                        tipo_pgto = cbTipoPago.SelectedValue.ToString(),
                        conta_contabil = cbCuenta.SelectedValue.ToString()
                    });

                    cuentasTipo();
                }
                else
                {
                    txtStatus.Text = "Ingrese una cuenta";
                }
            }
            else
            {
                txtStatus.Text = "Ingrese un tipo de pago";
            }
        }

        private void gdCuentasTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (gdCuentasTipo.SelectedRows.Count > 0)
            {
                string cuenta = gdCuentasTipo.SelectedRows[0].Cells[1].Value.ToString();                
                string tipo = gdCuentasTipo.SelectedRows[0].Cells[2].Value.ToString();                
                string peso = gdCuentasTipo.SelectedRows[0].Cells[3].Value.ToString();
                bool lineaPorTercero = bool.Parse(gdCuentasTipo.SelectedRows[0].Cells[4].Value.ToString());

                cbCuenta.SelectedValue = cuenta;
                txtPeso.Text = peso;
                txtTipoLancamento.Text = tipo;
                chLineaTercero.Checked = lineaPorTercero;
            }
        }

        private void cuentasTipo()
        {
            cuentaTipoPago = bizCuentasTipoPago.GetList();
            _cuentaTipoPago = cuentaTipoPago.Where(x => x.tipo_pgto == cbTipoPago.SelectedValue.ToString()).ToList();


            gdCuentasTipo.DataSource = null;
            gdCuentasTipo.AutoGenerateColumns = false;
            gdCuentasTipo.Columns.Clear();

            gdCuentasTipo.Columns.Add("tipo_pgto", "Tipo Pago");
            gdCuentasTipo.Columns.Add("conta_contabil", "Cuenta");
            gdCuentasTipo.Columns.Add("tipoLancamento", "Tipo lanzamiento");
            gdCuentasTipo.Columns.Add("peso", "Peso");
            gdCuentasTipo.Columns.Add("lineaPorTercero", "Linea por tercero");         
            
            gdCuentasTipo.Columns[0].DataPropertyName = "tipo_pgto";
            gdCuentasTipo.Columns[1].DataPropertyName = "conta_contabil";
            gdCuentasTipo.Columns[2].DataPropertyName = "tipoLancamento";
            gdCuentasTipo.Columns[3].DataPropertyName = "peso";
            gdCuentasTipo.Columns[4].DataPropertyName = "lineaPorTercero";

            gdCuentasTipo.Columns[0].Visible = false;

            gdCuentasTipo.DataSource = _cuentaTipoPago;
            gdCuentasTipo.AutoResizeColumns();

            double pesoAsignado = 0;
            double pendienteAsignar = 0;
            string tipoPago = cbTipoPago.SelectedValue.ToString();

            pendienteAsignar = 100 - _cuentaTipoPago.Where(x => x.tipo_pgto == tipoPago).Sum(x => x.peso);
            pesoAsignado = 100 - pendienteAsignar;

            txtAsignado.Text = string.Format("Tiene asignado {0}%, tiene pendiente por asignar {1}%", pesoAsignado, pendienteAsignar);
        }
    }
}
