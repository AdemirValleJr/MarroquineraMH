using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizRedTiendas
    {
        public static IList<RedTiendas> GetList()
        {
            StringBuilder oSql = new StringBuilder();
            oSql.Append("select rede_lojas id, desc_rede_lojas descripcion from lojas_rede order by descripcion");

            return DbMngmt<RedTiendas>.executeSqlQueryToList(oSql.ToString());
        }
    }
}
