using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macondo.AccesoDatos;
using System.Data.SqlClient;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLogin
    {
        public bool Login(string user, string pass)
        {
            string dataBase, dataBaseServer, strConnStr;
            bool login = false;

            try
            {
                dataBase = ConfigurationManager.AppSettings["DataBase"].ToString();
                dataBaseServer = ConfigurationManager.AppSettings["DataBaseServer"].ToString();
                strConnStr = "Persist Security Info=False;User ID=" + user + ";password=" + pass + ";Connect Timeout=0;Initial Catalog=" + dataBase + ";Data Source=" + dataBaseServer;


                SqlDataReader drUsrName = SqlServer.ExecuteReader(strConnStr, System.Data.CommandType.Text, "select getdate()");

                if (drUsrName.HasRows)
                    login = true;
            }
            catch (Exception ex)
            {
                login = false;
            }

            return login;
        }
    }
}
