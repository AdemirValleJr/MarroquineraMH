using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizTipoProducto
    {
        public static IList<TipoProducto> GetList()
        {
            return DbMngmt<TipoProducto>.executeSqlQueryToList("select cod_tipo_produto id, tipo_produto descripcion from PRODUTOS_TIPOS a order by descripcion");
        }
    }
}
