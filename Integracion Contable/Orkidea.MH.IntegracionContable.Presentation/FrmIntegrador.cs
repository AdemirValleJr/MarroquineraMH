using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orkidea.MH.IntegracionContable.Business;
using Orkidea.MH.IntegracionContable.Entities;
using System.Configuration;
using System.Globalization;
using System.Timers;

namespace Orkidea.MH.IntegracionContable.Presentation
{
    public partial class FrmIntegrador : Form
    {
        string connStrPos = ConfigurationManager.ConnectionStrings["connStrPos"].ConnectionString;
        string connStrErp = ConfigurationManager.ConnectionStrings["connStrErp"].ConnectionString;

        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();



        //List<Conta_Plano> cuentas;
        //List<CuentasTienda> cuentasTienda;
        List<Filial> filiales;
        List<Asiento> asientos;
        Asiento asientoTrm;

        BizFilial bizFilial;
        //BizCuentasTipoPago bizCuentasTipoPago;
        BizIntegracion bizIntegracion;
        BizTrm bizTrm;
        public FrmIntegrador()
        {
            InitializeComponent();
        }

        private void FrmIntegrador_Load(object sender, EventArgs e)
        {
            bizFilial = new BizFilial(connStrPos);
            bizIntegracion = new BizIntegracion(connStrPos, connStrErp);
            bizTrm = new BizTrm(connStrPos, connStrErp);

            filiales = new List<Filial>();
            filiales.Add(new Filial() { filial = "Seleccione una tienda" });
            filiales.AddRange(bizFilial.GetList());

            List<Filial> filialesCalculo = new List<Filial>();
            filialesCalculo.AddRange(filiales);

            cbTiendaIntegrar.DataSource = filiales;
            cbTiendaIntegrar.DisplayMember = "filial";
            cbTiendaIntegrar.ValueMember = "cod_filial";

            cbTiendaCalcular.DataSource = filialesCalculo;
            cbTiendaCalcular.DisplayMember = "filial";
            cbTiendaCalcular.ValueMember = "cod_filial";
        }

        private void cbTiendaIntegrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTiendaIntegrar.SelectedValue != null)
            {
                try
                {
                    lbFechaIntegracion.DataSource = bizIntegracion.GetPendingPeriods(cbTiendaIntegrar.SelectedValue.ToString(), "I");
                }
                catch (Exception ex)
                {
                    txtStatus.Text = ex.Message;
                }
            }
        }

        private void lbFechaIntegracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFechaIntegracion.SelectedItems.Count > 0)
            {
                btnLiquidar.Enabled = true;

                cbDiaLiquidado.DataSource = null;
                cbDiaLiquidado.Enabled = false;
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {

            string codFilial = cbTiendaIntegrar.SelectedValue.ToString();
            List<string> diasIntegracion = new List<string>();
            asientos = new List<Asiento>();

            diasIntegracion.Add("Seleccione...");

            try
            {
                foreach (string fecha in lbFechaIntegracion.SelectedItems)
                {

                    diasIntegracion.Add(fecha.ToString());

                    Filial filial = filiales.Where(x => x.cod_filial == codFilial).FirstOrDefault();
                    //asientos.AddRange(bizIntegracion.LiquidateStoreSales(filial, fecha));
                    asientos.AddRange(bizIntegracion.GenerateJournalEntry(filial, fecha));
                }

                cbDiaLiquidado.Enabled = true;
                cbDiaLiquidado.DataSource = diasIntegracion;

                gestionarMensaje("Proceso finalizado con exito", true);
                btnIntegraContabilidad.Enabled = true;

            }
            catch (Exception ex)
            {
                gestionarMensaje(ex.Message, false);
            }
        }

        private void btnIntegraContabilidad_Click(object sender, EventArgs e)
        {
            foreach (Asiento asiento in asientos)
            {
                string[] mensaje = bizIntegracion.SaveJournalEntry(asiento).Split('|');

                if (mensaje[1] == "0")
                    MessageBox.Show(mensaje[0], "Integracion Contable", MessageBoxButtons.OK);
                else
                {
                    if (MessageBox.Show(mensaje[0], "Integracion Contable", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        MessageBox.Show(bizIntegracion.DeleteJournalEntry(mensaje[2], asiento), "Integracion contable");
                    else
                        MessageBox.Show(string.Format("El asiento {0} se guardó en Linx con errores", mensaje[2]), "Integracion contable");
                }

                btnIntegraContabilidad.Enabled = false;
            }

            try
            {
                lbFechaIntegracion.DataSource = bizIntegracion.GetPendingPeriods(cbTiendaIntegrar.SelectedValue.ToString(), "I");
            }
            catch (Exception ex)
            {
                txtStatus.Text = ex.Message;
            }
        }

        private void cbDiaLiquidado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiaLiquidado.SelectedItem != null)
            {
                List<Asiento> asientosFecha = asientos.Where(x => x.fecha == cbDiaLiquidado.SelectedItem.ToString()).ToList();

                dgEncabezadoPreview.DataSource = null;
                dgEncabezadoPreview.AutoGenerateColumns = false;
                dgEncabezadoPreview.Columns.Clear();

                dgEncabezadoPreview.Columns.Add("codigoFilial", "Tienda");
                dgEncabezadoPreview.Columns.Add("fecha", "Fecha");
                dgEncabezadoPreview.Columns.Add("terminal", "Terminal");

                dgEncabezadoPreview.Columns[0].DataPropertyName = "codigoFilial";
                dgEncabezadoPreview.Columns[1].DataPropertyName = "fecha";
                dgEncabezadoPreview.Columns[2].DataPropertyName = "terminal";

                dgEncabezadoPreview.DataSource = asientosFecha;
            }
        }

        private void dgEncabezadoPreview_SelectionChanged(object sender, EventArgs e)
        {
            if (dgEncabezadoPreview.SelectedRows.Count > 0)
            {
                CultureInfo elES = CultureInfo.CreateSpecificCulture("es-CO");

                Asiento asiento = asientos.Where(x => x.fecha == cbDiaLiquidado.SelectedItem.ToString() &&
                    x.terminal == dgEncabezadoPreview.SelectedRows[0].Cells["terminal"].Value.ToString()).FirstOrDefault();

                dgDetallePreview.DataSource = null;
                dgDetallePreview.AutoGenerateColumns = false;
                dgDetallePreview.Columns.Clear();

                dgDetallePreview.Columns.Add("desConta", "Cuenta");
                dgDetallePreview.Columns.Add("nombreCliente", "Tercero");
                dgDetallePreview.Columns.Add("debito", "Debito");
                dgDetallePreview.Columns.Add("credto", "Credito");

                dgDetallePreview.Columns[0].DataPropertyName = "desConta";
                dgDetallePreview.Columns[1].DataPropertyName = "nombreCliente";
                dgDetallePreview.Columns[2].DataPropertyName = "debito";
                dgDetallePreview.Columns[3].DataPropertyName = "credito";

                dgDetallePreview.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDetallePreview.Columns[2].DefaultCellStyle.Format = "n";
                dgDetallePreview.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDetallePreview.Columns[3].DefaultCellStyle.Format = "n";

                dgDetallePreview.DataSource = asiento.lineas;
                dgDetallePreview.AutoResizeColumns();



                string deb = asiento.lineas.Sum(x => x.debito).ToString("0,0", elES);
                string cre = asiento.lineas.Sum(x => x.credito).ToString("0,0", elES);
                string fecha = cbDiaLiquidado.SelectedItem.ToString();

                txtStatus.Text = string.Format("Totales para {0} .::. Débitos: {1} .::. Créditos: {2}", fecha, deb, cre);
                txtStatus.BackColor = Color.Transparent;
                txtStatus.ForeColor = Color.Black;

                t.Stop();
            }
        }

        private void btnCalculaDifCambio_Click(object sender, EventArgs e)
        {
            try
            {
                string filial = cbTiendaCalcular.SelectedValue.ToString();
                DateTime fecha = dpFecha.Value;

                Trm trm = new Trm()
                {
                    fecha = fecha,
                    dolar = double.Parse(txtDolares.Text),
                    euro = double.Parse(txtEuros.Text)
                };

                asientoTrm = bizTrm.LiquidateDifferenceOnChange(filial, trm);

                dgDifCambio.DataSource = null;
                dgDifCambio.AutoGenerateColumns = false;
                dgDifCambio.Columns.Clear();

                dgDifCambio.Columns.Add("desConta", "Cuenta");
                dgDifCambio.Columns.Add("nombreCliente", "Tercero");
                dgDifCambio.Columns.Add("debito", "Debito");
                dgDifCambio.Columns.Add("credto", "Credito");

                dgDifCambio.Columns[0].DataPropertyName = "desConta";
                dgDifCambio.Columns[1].DataPropertyName = "nombreCliente";
                dgDifCambio.Columns[2].DataPropertyName = "debito";
                dgDifCambio.Columns[3].DataPropertyName = "credito";

                dgDifCambio.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDifCambio.Columns[2].DefaultCellStyle.Format = "n";
                dgDifCambio.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDifCambio.Columns[3].DefaultCellStyle.Format = "n";

                dgDifCambio.DataSource = asientoTrm.lineas;
                dgDifCambio.AutoResizeColumns();

                CultureInfo elES = CultureInfo.CreateSpecificCulture("es-CO");

                string deb = asientoTrm.lineas.Sum(x => x.debito).ToString("0,0", elES);
                string cre = asientoTrm.lineas.Sum(x => x.credito).ToString("0,0", elES);
                string strFecha = dpFecha.Value.ToString("yyyy-MM-dd");

                txtStatus.Text = string.Format("Totales para {0} .::. Débitos: {1} .::. Créditos: {2}", fecha, deb, cre);
                txtStatus.BackColor = Color.Transparent;
                txtStatus.ForeColor = Color.Black;

                btnIntegraDifCambio.Enabled = true;
            }
            catch (Exception ex)
            {
                gestionarMensaje(ex.Message, false);
            }
        }

        private void btnIntegraDifCambio_Click(object sender, EventArgs e)
        {
            string[] mensaje = bizTrm.SaveJournalEntry(asientoTrm).Split('|');

            if (mensaje[1] == "0")
                MessageBox.Show(mensaje[0], "Diferencia en cambio", MessageBoxButtons.OK);
            else
            {
                if (MessageBox.Show(mensaje[0], "Diferencia en cambio", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    MessageBox.Show(bizIntegracion.DeleteJournalEntry(mensaje[2], asientoTrm), "Diferencia en cambio");
                else
                    MessageBox.Show(string.Format("El asiento {0} se guardó en Linx con errores", mensaje[2]), "Diferencia en cambio");
            }

            btnIntegraDifCambio.Enabled = false;
        }

        private void gestionarMensaje(string mensaje, bool tipo)
        {
            if (tipo)
                txtStatus.BackColor = System.Drawing.Color.MediumSeaGreen;
            else
                txtStatus.BackColor = System.Drawing.Color.Red;

            txtStatus.ForeColor = Color.White;
            txtStatus.Text = mensaje;

            t.Interval = 5000; // specify interval time as you want
            t.Tick += new EventHandler(OnTimedEvent);
            t.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            txtStatus.BackColor = System.Drawing.Color.Transparent;
            txtStatus.Text = "";

            t.Stop();
        }




    }
}
