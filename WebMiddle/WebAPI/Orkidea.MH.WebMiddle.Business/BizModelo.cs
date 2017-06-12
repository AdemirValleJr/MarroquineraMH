using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizModelo
    {
        public static IList<Modelo> GetList()
        {
            StringBuilder oSql = new StringBuilder();
            oSql.Append("select modelagem id, desc_modelo descripcion from PRODUTOS_MODELO order by descripcion");

            return DbMngmt<Modelo>.executeSqlQueryToList(oSql.ToString());
        }
    }
}
