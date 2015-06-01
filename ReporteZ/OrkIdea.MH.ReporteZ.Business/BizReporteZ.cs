using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace OrkIdea.MH.ReporteZ.Business
{
    public static class BizReporteZ
    {
        public static void ImprimirReporte(string tienda, DateTime fecha, string terminal, string impresora)
        {

            string oConnStr = ConfigurationManager.ConnectionStrings["Linx"].ToString();
            System.Data.SqlClient.SqlConnectionStringBuilder oConnBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(oConnStr);

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = oConnBuilder.InitialCatalog;
            connectionInfo.UserID = oConnBuilder.UserID;
            connectionInfo.Password = oConnBuilder.Password;
            connectionInfo.ServerName = oConnBuilder.DataSource;

            using (ReportDocument rpt = new ReportDocument())
            {
                try
                {
                    string rutaRpt = AppDomain.CurrentDomain.BaseDirectory + @"\z.rpt";

                    rpt.Load(rutaRpt);

                    ParameterDiscreteValue TiendaDiscreteValue = new ParameterDiscreteValue();
                    TiendaDiscreteValue.Value = tienda;
                    rpt.SetParameterValue("Tienda", TiendaDiscreteValue);

                    ParameterDiscreteValue fechaDiscreteValue = new ParameterDiscreteValue();
                    fechaDiscreteValue.Value = fecha;
                    rpt.SetParameterValue("fecha", fechaDiscreteValue);

                    ParameterDiscreteValue TerminalDiscreteValue = new ParameterDiscreteValue();
                    TerminalDiscreteValue.Value = terminal;
                    rpt.SetParameterValue("Terminal", TerminalDiscreteValue);

                    Tables tables = rpt.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                    {
                        CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                        tableLogonInfo.ConnectionInfo = connectionInfo;
                        table.ApplyLogOnInfo(tableLogonInfo);
                    }

                    for (int i = 0; i < rpt.DataSourceConnections.Count; i++)
                    {
                        rpt.DataSourceConnections[i].SetConnection(oConnBuilder.DataSource, oConnBuilder.InitialCatalog, oConnBuilder.UserID, oConnBuilder.Password);
                    }

                    rpt.SetDatabaseLogon(oConnBuilder.UserID, oConnBuilder.Password, oConnBuilder.DataSource, oConnBuilder.InitialCatalog);


                    //rpt.PrintOptions.PrinterName = impresora;
                    //rpt.PrintToPrinter(1, false, 0, 0);

                    Console.WriteLine("Great you did it!");
                    //Console.Read();


                    // export to pdf
                    string pdfFile = string.Format(@"{0}\tmp\reporteZ-{1}-{2}.pdf", AppDomain.CurrentDomain.BaseDirectory, tienda, terminal);

                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = pdfFile;
                    CrExportOptions = rpt.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    rpt.Export();


                    Process.Start(pdfFile);

                    //print pdf
                    //ProcessStartInfo info = new ProcessStartInfo();
                    //info.Verb = "print";
                    //info.FileName = pdfFile;
                    //info.CreateNoWindow = true;
                    //info.WindowStyle = ProcessWindowStyle.Hidden;
                    //info.Arguments = "\"" + impresora + "\"";
                    //info.UseShellExecute = true;
                    //info.Verb = "PrintTo";

                    //Process p = new Process();
                    //p.StartInfo = info;
                    //p.Start();

                    //p.WaitForInputIdle();
                    //System.Threading.Thread.Sleep(3000);
                    //if (false == p.CloseMainWindow())
                    //    p.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.Read();
                }
            }
        }
    }
}
