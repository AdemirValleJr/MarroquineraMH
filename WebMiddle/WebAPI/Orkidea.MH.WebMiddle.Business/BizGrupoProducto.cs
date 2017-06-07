using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizGrupoProducto
    {
        public static IList<GrupoProducto> GetList()
        {
            return DbMngmt<GrupoProducto>.executeSqlQueryToList("select CODIGO_GRUPO id, GRUPO_PRODUTO descripcion from PRODUTOS_GRUPO order by GRUPO_PRODUTO");
        }

        public static GrupoProducto GetSingle(string id)
        {
            return DbMngmt<GrupoProducto>.executeSqlQuerySingle(string.Format("select CODIGO_GRUPO id, GRUPO_PRODUTO descripcion from PRODUTOS_GRUPO where CODIGO_GRUPO = '{0}'", id));
        }
    }
}
