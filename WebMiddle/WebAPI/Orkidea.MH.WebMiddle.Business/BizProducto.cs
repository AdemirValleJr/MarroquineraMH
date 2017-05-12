using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizProducto
    {
        public static IList<Producto> GetList()
        {
            return DbMngmt<Producto>.executeSqlQueryToList("select PRODUTO id , DESC_PRODUTO descripcion from PRODUTOS order by DESC_PRODUTO");
        }
    }
}
