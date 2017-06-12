using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizFabricante
    {
        public static IList<Fabricante> GetList()
        {
            return DbMngmt<Fabricante>.executeSqlQueryToList("select PRODUTO id , DESC_PRODUTO descripcion from PRODUTOS order by DESC_PRODUTO");
        }
    }
}
