using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
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


                rpt.PrintOptions.PrinterName = impresora;

                rpt.PrintToPrinter(1, false, 0, 0);

                //Console.WriteLine("Great you did it!");
                //Console.Read();
            }
        }
    }
}
