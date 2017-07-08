using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizSubgrupoProducto
    {
        public static IList<SubgrupoProducto> GetList()
        {
            StringBuilder oSql = new StringBuilder();
            oSql.Append("select a.CODIGO_SUBGRUPO id, a.SUBGRUPO_PRODUTO descripcion, b.CODIGO_GRUPO idGrupo ");
            oSql.Append("from PRODUTOS_SUBGRUPO a inner join PRODUTOS_GRUPO b on a.GRUPO_PRODUTO = b.GRUPO_PRODUTO ");
            oSql.Append("order by SUBGRUPO_PRODUTO");

            return DbMngmt<SubgrupoProducto>.executeSqlQueryToList(oSql.ToString());
        }

        public static IList<SubgrupoProducto> GetList(string idGrupoProducto)
        {
            StringBuilder oSql = new StringBuilder();
            oSql.Append("select a.CODIGO_SUBGRUPO id, a.SUBGRUPO_PRODUTO descripcion, b.CODIGO_GRUPO idGrupo ");
            oSql.Append("from PRODUTOS_SUBGRUPO a inner join PRODUTOS_GRUPO b on a.GRUPO_PRODUTO = b.GRUPO_PRODUTO ");
            oSql.Append(string.Format("where b.CODIGO_GRUPO = '{0}' ", idGrupoProducto));
            oSql.Append("order by SUBGRUPO_PRODUTO");

            return DbMngmt<SubgrupoProducto>.executeSqlQueryToList(oSql.ToString());
        }

    }
}
