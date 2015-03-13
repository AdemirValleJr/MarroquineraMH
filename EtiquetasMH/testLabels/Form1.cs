using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace testLabels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DsLabel ds = new DsLabel();

            for (int i = 0; i < 3; i++)
            {
                DsLabel.LabelRow labelRow = ds.Label.NewLabelRow();

                switch (i)
                {
                    case 0:
                        labelRow.code = "DE.CH.1053";
                        labelRow.barcode = "7701749544017";
                        labelRow.descripcion = "CHAQUETA  UNICA";
                        break;
                    case 1:
                        labelRow.code = "DE.CH.1053";
                        labelRow.barcode = "7701749543980";
                        labelRow.descripcion = "CHAQUETA  UNICA";

                        break;

                    case 2:
                        labelRow.code = "DE.CH.1053";
                        labelRow.barcode = "7701749543942";
                        labelRow.descripcion = "CHAQUETA  UNICA";

                        break;

                    case 3:
                        labelRow.code = "DE.CH.1053";
                        labelRow.barcode = "7701749544024";
                        labelRow.descripcion = "CHAQUETA  UNICA";

                        break;
                    default:
                        break;
                }

                ds.Label.AddLabelRow(labelRow);
            }

            string rutaRpt = @"C:\Users\DESARROLLO\Documents\GitHub\EtiquetasMH\EtiquetasMH\testLabels\CrystalReport1.rpt";

            ReportDocument rpt;

            //byte[] response = null;

            rpt = new ReportDocument();
            rpt.Load(rutaRpt);
            rpt.SetDataSource(ds);
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rpt.PrintToPrinter(1, false, 0, 0);

            //            rpt.Export(CrystalDecisions.Shared.ExportOptions.


            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
