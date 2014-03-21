using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orkidea.ComisionesMH.Business;
using Orkidea.ComisionesMH.Entities;
using Orkidea.ComisionesMH.UI.Model;

namespace Orkidea.ComisionesMH.UI
{
    public partial class FrmLiquidacion : Form
    {
        List<FILIAIS> lstTiendas = new List<FILIAIS>();
        List<LOJA_VENDA> lstLojaVenda = new List<LOJA_VENDA>();
        List<LojaVenda> lstVentas = new List<LojaVenda>();
        List<LojaDefinition> lstLojaDefinition = new List<LojaDefinition>();
        DateTime dtDesde;
        DateTime dtHasta;
        int numVentas;

        BizFiliais bizFiliais = new BizFiliais();


        public FrmLiquidacion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstTiendas.Add(new FILIAIS() { COD_FILIAL = "_0", FILIAL = "Todas las tiendas" });

            List<FILIAIS> lstFiliais = bizFiliais.getFiliaisList().OrderBy(x => x.FILIAL).ToList();

            foreach (FILIAIS item in lstFiliais)
            {
                lstTiendas.Add(item);
                lstLojaDefinition.Add(new LojaDefinition(new CADASTRO_CLI_FOR() { CLIFOR = item.COD_FILIAL }));
            }

            cmbTienda.DataSource = lstTiendas;
            cmbTienda.DisplayMember = "FILIAL";
            cmbTienda.ValueMember = "COD_FILIAL";

            txtAño.Text = DateTime.Now.Year.ToString();
            cmbMes.SelectedItem = ((DateTime.Now.Month)).ToString();

            btnBuscar.BackColor = Color.Linen;
            btnCalcular.BackColor = Color.Linen;
            btnComission.BackColor = Color.Linen;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            BizLojaVenda bizLojaVenda = new BizLojaVenda();
            int num;
            if (!int.TryParse(txtAño.Text, out num))
            {
                MessageBox.Show("No se ingreso un año valido");
                return;
            }

            if (!int.TryParse(cmbMes.SelectedItem.ToString(), out num))
            {
                MessageBox.Show("No se ingreso un mes valido");
                return;
            }

            btnBuscar.BackColor = Color.LightSteelBlue;



            dtDesde = DateTime.Parse(txtAño.Text + "/" + cmbMes.SelectedItem.ToString() + "/01");
            dtHasta = (dtDesde.AddMonths(1)).AddDays(-1);

            /*Filtro de ventas por tienda*/
            if (cmbTienda.SelectedValue.ToString() == "_0")
                lstLojaVenda = bizLojaVenda.getLojaVendaList(dtDesde, dtHasta);
            else
                lstLojaVenda = bizLojaVenda.getLojaVendaList(dtDesde, dtHasta, new FILIAIS() { COD_FILIAL = cmbTienda.SelectedValue.ToString() });

            numVentas = lstLojaVenda.Count;

            lblResultados.Text = "Se encontraron " + numVentas + " tickets ";
            lblResultados.Visible = true;

            btnCalcular.Enabled = true;
            btnCalcular.BackColor = Color.LightSalmon;

            btnCalcular.Enabled = false;
            SearchWorker.DoWork += new DoWorkEventHandler(searchDoWork);
            SearchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(searchWorkerCompleted);
            SearchWorker.ProgressChanged += new ProgressChangedEventHandler(searchWorker_ProgressChanged);
            SearchWorker.RunWorkerAsync();



        }

        private void btnDefComision_Click(object sender, EventArgs e)
        {
            FrmParametroVendedor form = new FrmParametroVendedor();
            form.Show();
        }

        private void searchDoWork(object sender, DoWorkEventArgs e)
        {

            /*Búsqueda de ventas y detalle productos y pagos*/

            for (int i = 0; i < numVentas; i++)
            {
                LojaDefinition lojaDefinition = lstLojaDefinition
                    .Where(x => x.COD_FILIAL == lstLojaVenda[i].CODIGO_FILIAL).FirstOrDefault();

                lstVentas.Add(new LojaVenda(lstLojaVenda[i], lojaDefinition));

                SearchWorker.ReportProgress((i * 100) / numVentas, lstLojaVenda[i].TICKET + " de la tienda " + lojaDefinition.COD_FILIAL);
            }
        }

        private void searchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = "Obteniendo informacion del ticket " + e.UserState.ToString();
        }

        private void searchWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //btnComission.Enabled = true;
            btnComission.BackColor = Color.LimeGreen;
            toolStripProgressBar1.Value = 0;


            toolStripStatusLabel1.Text = "Calculando cumplimiento de las tiendas...";

            List<string> lsTienda = lstLojaVenda.Select(x => x.CODIGO_FILIAL).Distinct().ToList();

            foreach (string item in lsTienda)
            {
                LojaDefinition lojaDef = lstLojaDefinition.Where(x => x.COD_FILIAL == item).FirstOrDefault();
                lojaDef.ventasLoja = lstVentas.Where(x => x.CODIGO_FILIAL == lojaDef.COD_FILIAL).Sum(x => x.SellOutBruto);
                lojaDef.calculaCumplimiento(int.Parse(cmbMes.SelectedItem.ToString()));
            }

            calculateWorker.DoWork += new DoWorkEventHandler(calculateDoWork);
            calculateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(calculateWorkerCompleted);
            calculateWorker.ProgressChanged += new ProgressChangedEventHandler(calculateWorker_ProgressChanged);
            calculateWorker.RunWorkerAsync();
        }

        private void calculateDoWork(object sender, DoWorkEventArgs e)
        {
            BizParametroVendedor bizParametroVendedor = new BizParametroVendedor();

            /*Búsqueda de ventas y detalle productos y pagos*/

            int numItems = lstVentas.Count;

            for (int i = 0; i < numItems; i++)
            {
                LojaDefinition lojaDefinition = lstLojaDefinition
                    .Where(x => x.COD_FILIAL == lstVentas[i].CODIGO_FILIAL).FirstOrDefault();

                CSS_PARAMETRO_VENDEDOR parametroVendedor = bizParametroVendedor.getParametroVendedor(new CSS_PARAMETRO_VENDEDOR() { vendedor = lstVentas[i].VENDEDOR });
                CSS_PARAMETRO_VENDEDOR parametroAdministrador = bizParametroVendedor.getParametroVendedor(new CSS_PARAMETRO_VENDEDOR() { vendedor = lstVentas[i].GERENTE_PERIODO });

                decimal porComisionVendedor;
                decimal porComisionAdministrador;

                if (lojaDefinition.cumplePresupuesto)
                {
                    porComisionAdministrador = parametroAdministrador != null ? parametroAdministrador.comisionCumple : 0;
                    porComisionVendedor = parametroVendedor != null ? parametroVendedor.comisionCumple : 0;
                }
                else
                {
                    porComisionAdministrador = parametroAdministrador != null ? parametroAdministrador.comisionNoCumple : 0;
                    porComisionVendedor = parametroVendedor != null ? parametroVendedor.comisionNoCumple : 0;
                }

                decimal sellOutBrutoSinIvaSinComisionTarjetas = lstVentas[i].SellOutBruto - (lstVentas[i].vlrImpuestos + lstVentas[i].comisionTarjetas);
                decimal ventaBonosSinIva = (lstVentas[i].bonosVendidos - lstVentas[i].ivaBonosVendidos) / 2;
                decimal redencionBonosSinIva = (lstVentas[i].bonosRedimidos - lstVentas[i].ivaBonosRedimidos) / 2;

                lstVentas[i].sellOutNeto = sellOutBrutoSinIvaSinComisionTarjetas + ventaBonosSinIva + redencionBonosSinIva;
                lstVentas[i].comisionAdministrador = (lstVentas[i].sellOutNeto * porComisionAdministrador) / 100;
                lstVentas[i].comisionVendedor = (lstVentas[i].sellOutNeto * porComisionVendedor) / 100;

                calculateWorker.ReportProgress((i * 100) / numVentas, lojaDefinition.COD_FILIAL);//+ " -> Ticket " + lstLojaVenda[i].TICKET);


            }


            //List<LojaVenda> lstTest = lstVentas.Where(x => x.VENDEDOR == null).ToList();

        }

        private void calculateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = "Analizando informacion de la tienda " + e.UserState.ToString();
        }

        private void calculateWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnComission.Enabled = true;
            btnComission.BackColor = Color.LimeGreen;

            grdTienda.DataSource = lstLojaDefinition.Where(x => x.ventasLoja > 0).OrderBy(x => x.COD_FILIAL).ToList();
            grdTienda.Columns["COD_FILIAL"].HeaderText = "Tienda";
            grdTienda.Columns["UF"].Visible = false;
            grdTienda.Columns["IVA"].Visible = false;
            grdTienda.Columns["porComisionAdministrador"].Visible = false;
            grdTienda.Columns["porComisionVendedor"].Visible = false;

            grdTienda.Columns["P_01"].Visible = cmbMes.SelectedItem.ToString() == "1" ? true : false;
            grdTienda.Columns["P_02"].Visible = cmbMes.SelectedItem.ToString() == "2" ? true : false;
            grdTienda.Columns["P_03"].Visible = cmbMes.SelectedItem.ToString() == "3" ? true : false;
            grdTienda.Columns["P_04"].Visible = cmbMes.SelectedItem.ToString() == "4" ? true : false;
            grdTienda.Columns["P_05"].Visible = cmbMes.SelectedItem.ToString() == "5" ? true : false;
            grdTienda.Columns["P_06"].Visible = cmbMes.SelectedItem.ToString() == "6" ? true : false;
            grdTienda.Columns["P_07"].Visible = cmbMes.SelectedItem.ToString() == "7" ? true : false;
            grdTienda.Columns["P_08"].Visible = cmbMes.SelectedItem.ToString() == "8" ? true : false;
            grdTienda.Columns["P_09"].Visible = cmbMes.SelectedItem.ToString() == "9" ? true : false;
            grdTienda.Columns["P_10"].Visible = cmbMes.SelectedItem.ToString() == "10" ? true : false;
            grdTienda.Columns["P_11"].Visible = cmbMes.SelectedItem.ToString() == "11" ? true : false;
            grdTienda.Columns["P_12"].Visible = cmbMes.SelectedItem.ToString() == "12" ? true : false;

            grdTienda.Columns["P_01"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_02"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_03"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_04"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_05"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_06"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_07"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_08"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_09"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_10"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_11"].HeaderText = "Presupuesto mes";
            grdTienda.Columns["P_12"].HeaderText = "Presupuesto mes";

            grdTienda.Columns["P_01"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_02"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_03"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_04"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_05"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_06"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_07"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_08"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_09"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_10"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_11"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["P_12"].DefaultCellStyle.Format = "n2";
            grdTienda.Columns["ventasLoja"].DefaultCellStyle.Format = "n2";
            


            //grdTienda.Columns["porComisionAdministrador"].HeaderText = "% Comision Admon";
            //grdTienda.Columns["porComisionVendedor"].HeaderText = "% Comision Vendedor";

            grdTienda.Columns["ventasLoja"].HeaderText = "Ventas";
            grdTienda.Columns["cumplePresupuesto"].HeaderText = "Cumple Presupuesto";

            toolStripStatusLabel1.Text = "Proceso terminado";
        }

        private void btnExportaDetalle_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(grdDetalle, sfd.FileName); // Here dataGridview1 is your grid view name 
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void grdTienda_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


                BizLojaVendedores bizLojaVendedores = new BizLojaVendedores();
                List<LOJA_VENDEDORES> lstVendedores = bizLojaVendedores.GetVendedorList();

                List<LojaResumenVendaVendedor> lstVtasAdmin = new List<LojaResumenVendaVendedor>();
                List<LojaResumenVendaVendedor> lstVtasVendedor = new List<LojaResumenVendaVendedor>();
                List<LojaVenda> lstVtasTienda = new List<LojaVenda>();

                grdAdmin.DataSource = null;
                grdVendedor.DataSource = null;
                grdDetalle.DataSource = null;

                foreach (DataGridViewRow selectedRow in grdTienda.SelectedRows)
                {
                    string tienda = selectedRow.Cells["COD_FILIAL"].Value.ToString();
                    List<string> lsAdmin = lstVentas.Where(x => x.CODIGO_FILIAL == tienda).Select(x => x.GERENTE_LOJA).Distinct().ToList();
                    List<string> lsVendedor = lstVentas.Where(x => x.CODIGO_FILIAL == tienda).Select(x => x.VENDEDOR).Distinct().ToList();

                    #region Ventas Admin
                    foreach (string item in lsAdmin)
                    {
                        List<LojaVenda> tmpVtasAdmin = lstVentas.Where(x => x.GERENTE_LOJA == item && x.CODIGO_FILIAL == tienda).ToList();

                        LojaResumenVendaVendedor vtasAdmin = new LojaResumenVendaVendedor()
                        {
                            CODIGO_FILIAL = tienda,
                            VENDEDOR = item,
                            VENDEDOR_NOME = lstVendedores.Where(x => x.VENDEDOR == item).Select(x => x.NOME_VENDEDOR).FirstOrDefault(),
                            SellOutBruto = tmpVtasAdmin.Sum(x => x.SellOutBruto),
                            sellOutNeto = tmpVtasAdmin.Sum(x => x.sellOutNeto),
                            bonosRedimidos = tmpVtasAdmin.Sum(x => x.bonosRedimidos),
                            bonosVendidos = tmpVtasAdmin.Sum(x => x.bonosVendidos),
                            comisionTarjetas = tmpVtasAdmin.Sum(x => x.comisionTarjetas),
                            descuentoTotal = tmpVtasAdmin.Sum(x => x.descuentoTotal),
                            ivaBonosRedimidos = tmpVtasAdmin.Sum(x => x.ivaBonosRedimidos),
                            ivaBonosVendidos = tmpVtasAdmin.Sum(x => x.ivaBonosVendidos),
                            pagosTarjeta = tmpVtasAdmin.Sum(x => x.pagosTarjeta),
                            vlrImpuestos = tmpVtasAdmin.Sum(x => x.vlrImpuestos),
                            comision = tmpVtasAdmin.Sum(x => x.comisionVendedor)
                        };

                        lstVtasAdmin.Add(vtasAdmin);
                    }



                    #endregion

                    #region Ventas Vendedor
                    foreach (string item in lsVendedor)
                    {
                        List<LojaVenda> tmpVtasVendedor = lstVentas.Where(x => x.VENDEDOR == item && x.CODIGO_FILIAL == tienda).ToList();

                        LojaResumenVendaVendedor vtasVendedor = new LojaResumenVendaVendedor()
                        {
                            CODIGO_FILIAL = tienda,
                            VENDEDOR = item,
                            VENDEDOR_NOME = lstVendedores.Where(x => x.VENDEDOR == item).Select(x => x.NOME_VENDEDOR).FirstOrDefault(),
                            SellOutBruto = tmpVtasVendedor.Sum(x => x.SellOutBruto),
                            sellOutNeto = tmpVtasVendedor.Sum(x => x.sellOutNeto),
                            bonosRedimidos = tmpVtasVendedor.Sum(x => x.bonosRedimidos),
                            bonosVendidos = tmpVtasVendedor.Sum(x => x.bonosVendidos),
                            comisionTarjetas = tmpVtasVendedor.Sum(x => x.comisionTarjetas),
                            descuentoTotal = tmpVtasVendedor.Sum(x => x.descuentoTotal),
                            ivaBonosRedimidos = tmpVtasVendedor.Sum(x => x.ivaBonosRedimidos),
                            ivaBonosVendidos = tmpVtasVendedor.Sum(x => x.ivaBonosVendidos),
                            pagosTarjeta = tmpVtasVendedor.Sum(x => x.pagosTarjeta),
                            vlrImpuestos = tmpVtasVendedor.Sum(x => x.vlrImpuestos),
                            comision = tmpVtasVendedor.Sum(x => x.comisionVendedor)
                        };

                        lstVtasVendedor.Add(vtasVendedor);
                    }
                    #endregion

                    #region Ventas detalladas por tienda
                    lstVtasTienda.AddRange(lstVentas.Where(x => x.CODIGO_FILIAL == tienda).ToList());
                    #endregion
                }

                #region Grid Admin
                grdAdmin.AutoGenerateColumns = false;
                grdAdmin.Columns.Clear();

                grdAdmin.Columns.Add("CODIGO_FILIAL", "Tienda");
                grdAdmin.Columns.Add("VENDEDOR", "Cod. Vendedor");
                grdAdmin.Columns.Add("VENDEDOR_NOME", "Vendedor");
                grdAdmin.Columns.Add("SellOutBruto", "Sell Out Bruto");
                grdAdmin.Columns.Add("sellOutNeto", "Sell Out Neto");
                grdAdmin.Columns.Add("vlrImpuestos", "Impuestos");
                grdAdmin.Columns.Add("bonosVendidos", "Bonos Vendidos");
                grdAdmin.Columns.Add("bonosRedimidos", "Bonos Redimidos");
                grdAdmin.Columns.Add("descuentoTotal", "Descuentos");
                grdAdmin.Columns.Add("pagosTarjeta", "Pagos Tarjeta");
                grdAdmin.Columns.Add("comisionTarjetas", "Comision Tarjeta");
                grdAdmin.Columns.Add("ivaBonosRedimidos", "Iva Bonos Redimidos");
                grdAdmin.Columns.Add("ivaBonosVendidos", "Iva Bonos Vendidos");
                grdAdmin.Columns.Add("comision", "Comision");

                grdAdmin.Columns[0].DataPropertyName = "CODIGO_FILIAL";
                grdAdmin.Columns[1].DataPropertyName = "VENDEDOR";
                grdAdmin.Columns[2].DataPropertyName = "VENDEDOR_NOME";
                grdAdmin.Columns[3].DataPropertyName = "SellOutBruto";
                grdAdmin.Columns[4].DataPropertyName = "sellOutNeto";
                grdAdmin.Columns[5].DataPropertyName = "vlrImpuestos";
                grdAdmin.Columns[6].DataPropertyName = "bonosVendidos";
                grdAdmin.Columns[7].DataPropertyName = "bonosRedimidos";
                grdAdmin.Columns[8].DataPropertyName = "descuentoTotal";
                grdAdmin.Columns[9].DataPropertyName = "pagosTarjeta";
                grdAdmin.Columns[10].DataPropertyName = "comisionTarjetas";
                grdAdmin.Columns[11].DataPropertyName = "ivaBonosRedimidos";
                grdAdmin.Columns[12].DataPropertyName = "ivaBonosVendidos";
                grdAdmin.Columns[13].DataPropertyName = "comision";

                grdAdmin.Columns[4].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[5].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[6].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[7].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[8].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[9].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[10].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[11].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[12].DefaultCellStyle.Format = "n2";
                grdAdmin.Columns[13].DefaultCellStyle.Format = "n2";
                
                grdAdmin.DataSource = lstVtasAdmin.OrderBy(x => x.CODIGO_FILIAL).ToList(); 
                #endregion

                #region Grid Vendedor
                grdVendedor.AutoGenerateColumns = false;
                grdVendedor.Columns.Clear();

                grdVendedor.Columns.Add("CODIGO_FILIAL", "Tienda");
                grdVendedor.Columns.Add("VENDEDOR", "Cod. Vendedor");
                grdVendedor.Columns.Add("VENDEDOR_NOME", "Vendedor");
                grdVendedor.Columns.Add("SellOutBruto", "Sell Out Bruto");
                grdVendedor.Columns.Add("sellOutNeto", "Sell Out Neto");
                grdVendedor.Columns.Add("vlrImpuestos", "Impuestos");
                grdVendedor.Columns.Add("bonosVendidos", "Bonos Vendidos");
                grdVendedor.Columns.Add("bonosRedimidos", "Bonos Redimidos");
                grdVendedor.Columns.Add("descuentoTotal", "Descuentos");
                grdVendedor.Columns.Add("pagosTarjeta", "Pagos Tarjeta");
                grdVendedor.Columns.Add("comisionTarjetas", "Comision Tarjeta");
                grdVendedor.Columns.Add("ivaBonosRedimidos", "Iva Bonos Redimidos");
                grdVendedor.Columns.Add("ivaBonosVendidos", "Iva Bonos Vendidos");
                grdVendedor.Columns.Add("comision", "Comision");

                grdVendedor.Columns[0].DataPropertyName = "CODIGO_FILIAL";
                grdVendedor.Columns[1].DataPropertyName = "VENDEDOR";
                grdVendedor.Columns[2].DataPropertyName = "VENDEDOR_NOME";
                grdVendedor.Columns[3].DataPropertyName = "SellOutBruto";
                grdVendedor.Columns[4].DataPropertyName = "sellOutNeto";
                grdVendedor.Columns[5].DataPropertyName = "vlrImpuestos";
                grdVendedor.Columns[6].DataPropertyName = "bonosVendidos";
                grdVendedor.Columns[7].DataPropertyName = "bonosRedimidos";
                grdVendedor.Columns[8].DataPropertyName = "descuentoTotal";
                grdVendedor.Columns[9].DataPropertyName = "pagosTarjeta";
                grdVendedor.Columns[10].DataPropertyName = "comisionTarjetas";
                grdVendedor.Columns[11].DataPropertyName = "ivaBonosRedimidos";
                grdVendedor.Columns[12].DataPropertyName = "ivaBonosVendidos";
                grdVendedor.Columns[13].DataPropertyName = "comision";

                grdVendedor.Columns[4].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[5].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[6].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[7].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[8].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[9].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[10].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[11].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[12].DefaultCellStyle.Format = "n2";
                grdVendedor.Columns[13].DefaultCellStyle.Format = "n2";

                grdVendedor.DataSource = lstVtasVendedor.OrderBy(x => x.CODIGO_FILIAL).ToList(); 
                #endregion

                #region Grid Detalle
                grdDetalle.AutoGenerateColumns = false;
                grdDetalle.Columns.Clear();

                grdDetalle.Columns.Add("CODIGO_FILIAL", "Tienda");
                grdDetalle.Columns.Add("TICKET", "Ticket");
                grdDetalle.Columns.Add("DATA_VENDA", "Fecha");
                grdDetalle.Columns.Add("VENDEDOR", "Vendedor");
                grdDetalle.Columns.Add("SellOutBruto", "Sell Out Bruto");
                grdDetalle.Columns.Add("sellOutNeto", "Sell Out Neto");
                grdDetalle.Columns.Add("vlrImpuestos", "Impuestos");
                grdDetalle.Columns.Add("bonosVendidos", "Bonos Vendidos");
                grdDetalle.Columns.Add("bonosRedimidos", "Bonos Redimidos");
                grdDetalle.Columns.Add("descuentoTotal", "Descuentos");
                grdDetalle.Columns.Add("pagosTarjeta", "Pagos Tarjeta");
                grdDetalle.Columns.Add("comisionTarjetas", "Comision Tarjeta");
                grdDetalle.Columns.Add("ivaBonosRedimidos", "Iva Bonos Redimidos");
                grdDetalle.Columns.Add("ivaBonosVendidos", "Iva Bonos Vendidos");
                grdDetalle.Columns.Add("comisionVendedor", "Comision Vendedor");
                grdDetalle.Columns.Add("comisionAdministrador", "Comision Administrador");

                grdDetalle.Columns[0].DataPropertyName = "CODIGO_FILIAL";
                grdDetalle.Columns[1].DataPropertyName = "TICKET";
                grdDetalle.Columns[2].DataPropertyName = "DATA_VENDA";
                grdDetalle.Columns[3].DataPropertyName = "VENDEDOR";
                grdDetalle.Columns[4].DataPropertyName = "SellOutBruto";
                grdDetalle.Columns[5].DataPropertyName = "sellOutNeto";
                grdDetalle.Columns[6].DataPropertyName = "vlrImpuestos";
                grdDetalle.Columns[7].DataPropertyName = "bonosVendidos";
                grdDetalle.Columns[8].DataPropertyName = "bonosRedimidos";
                grdDetalle.Columns[9].DataPropertyName = "descuentoTotal";
                grdDetalle.Columns[10].DataPropertyName = "pagosTarjeta";
                grdDetalle.Columns[11].DataPropertyName = "comisionTarjetas";
                grdDetalle.Columns[12].DataPropertyName = "ivaBonosRedimidos";
                grdDetalle.Columns[13].DataPropertyName = "ivaBonosVendidos";
                grdDetalle.Columns[14].DataPropertyName = "comisionVendedor";
                grdDetalle.Columns[15].DataPropertyName = "comisionAdministrador";

                grdDetalle.Columns[4].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[5].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[6].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[7].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[8].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[9].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[10].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[11].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[12].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[13].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[14].DefaultCellStyle.Format = "n2";
                grdDetalle.Columns[15].DefaultCellStyle.Format = "n2";

                grdDetalle.DataSource = lstVtasTienda.OrderBy(x => x.CODIGO_FILIAL).ToList(); 
                #endregion

            }
            catch (Exception) { }
        }

        private void FrmLiquidacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }        
    }
}
