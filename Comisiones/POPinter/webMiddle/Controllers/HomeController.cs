using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webMiddle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintPO(string id)
        {
            try
            {
                string[] parameters = id.Split('|');

                string oConnStr = ConfigurationManager.ConnectionStrings["MHConnStr"].ToString();
                string rutaRpt = "";
                byte[] response = null;

                string ImgPath = "";

                switch (parameters[1])
                {
                    case "Pes":
                        ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptNameES"].ToString());
                        break;
                    case "Pen":
                        ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptNameEN"].ToString());
                        break;
                    case "Mes":
                        ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptNameES"].ToString());
                        break;
                    case "Men":
                        ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptNameEN"].ToString());
                        break;
                    default:
                        break;
                }

                //if (parameters[1] == "P")
                //{
                //    ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                //    rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptName"].ToString());
                //}
                //else
                //{
                //    ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                //    rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptName"].ToString());
                //}

                ReportDocument rpt = new ReportDocument();
                SqlConnectionStringBuilder oConnBuilder = new SqlConnectionStringBuilder(oConnStr);

                rpt.Load(rutaRpt);

                ParameterDiscreteValue pedidoDiscreteValue = new ParameterDiscreteValue();
                pedidoDiscreteValue.Value = parameters[0];
                rpt.SetParameterValue("pedido", pedidoDiscreteValue);

                ParameterDiscreteValue rutaImgDiscreteValue = new ParameterDiscreteValue();
                rutaImgDiscreteValue.Value = ImgPath;
                rpt.SetParameterValue("rutaImg", rutaImgDiscreteValue);

                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
                connectionInfo.DatabaseName = oConnBuilder.InitialCatalog;
                connectionInfo.UserID = oConnBuilder.UserID;
                connectionInfo.Password = oConnBuilder.Password;
                connectionInfo.ServerName = oConnBuilder.DataSource;

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


                using (Stream strMemory = rpt.ExportToStream(ExportFormatType.PortableDocFormat))
                {
                    response = new byte[strMemory.Length];

                    strMemory.Read(response, 0, (int)strMemory.Length);
                }

                return new FileContentResult(response, "application/pdf");
            }
            catch (Exception ex)
            {
                string error = ex.Message + " :::---::: " + ex.StackTrace;

                System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
                byte[] response = codificador.GetBytes(error);

                return new FileContentResult(response, "text/plain");
            }
        }

        public ActionResult ExportPO(string id)
        {
            try
            {
                string[] parameters = id.Split('|');

                string oConnStr = ConfigurationManager.ConnectionStrings["MHConnStr"].ToString();
                string rutaRpt = "";
                byte[] response = null;

                string ImgPath = "";

                switch (parameters[1])
                {
                    case "Pes":
                        ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptNameES"].ToString());
                        break;
                    case "Pen":
                        ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptNameEN"].ToString());
                        break;
                    case "Mes":
                        ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptNameES"].ToString());
                        break;
                    case "Men":
                        ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                        rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptNameEN"].ToString());
                        break;
                    default:
                        break;
                }

                //if (parameters[1] == "P")
                //{
                //    ImgPath = ConfigurationManager.AppSettings["ProductImgPath"].ToString();
                //    rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["ProductRptName"].ToString());
                //}
                //else
                //{
                //    ImgPath = ConfigurationManager.AppSettings["MaterialImgPath"].ToString();
                //    rutaRpt = Server.MapPath(ConfigurationManager.AppSettings["MaterialRptName"].ToString());
                //}

                ReportDocument rpt = new ReportDocument();
                SqlConnectionStringBuilder oConnBuilder = new SqlConnectionStringBuilder(oConnStr);

                rpt.Load(rutaRpt);

                ParameterDiscreteValue pedidoDiscreteValue = new ParameterDiscreteValue();
                pedidoDiscreteValue.Value = parameters[0];
                rpt.SetParameterValue("pedido", pedidoDiscreteValue);

                ParameterDiscreteValue rutaImgDiscreteValue = new ParameterDiscreteValue();
                rutaImgDiscreteValue.Value = ImgPath;
                rpt.SetParameterValue("rutaImg", rutaImgDiscreteValue);

                CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
                connectionInfo.DatabaseName = oConnBuilder.InitialCatalog;
                connectionInfo.UserID = oConnBuilder.UserID;
                connectionInfo.Password = oConnBuilder.Password;
                connectionInfo.ServerName = oConnBuilder.DataSource;

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


                using (Stream strMemory = rpt.ExportToStream(ExportFormatType.Excel))
                {
                    response = new byte[strMemory.Length];

                    strMemory.Read(response, 0, (int)strMemory.Length);
                }

                return new FileContentResult(response, "application/vnd.ms-excel");
            }
            catch (Exception ex)
            {
                string error = ex.Message + " :::---::: " + ex.StackTrace;

                System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
                byte[] response = codificador.GetBytes(error);

                return new FileContentResult(response, "text/plain");
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}