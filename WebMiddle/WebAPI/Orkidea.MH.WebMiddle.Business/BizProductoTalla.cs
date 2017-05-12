using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public class BizProductoTalla
    {
        public static IList<ProductoTalla> GetList()
        {
            StringBuilder oSql = new StringBuilder();

            oSql.Append("select GRADE, TAMANHOS_DIGITADOS, ");
            oSql.Append("TAMANHO_1,TAMANHO_2,TAMANHO_3,TAMANHO_4,TAMANHO_5,TAMANHO_6,TAMANHO_7,TAMANHO_8,TAMANHO_9,TAMANHO_10, ");
            oSql.Append("TAMANHO_11,TAMANHO_12,TAMANHO_13,TAMANHO_14,TAMANHO_15,TAMANHO_16,TAMANHO_17,TAMANHO_18,TAMANHO_19,TAMANHO_20, ");
            oSql.Append("TAMANHO_21,TAMANHO_22,TAMANHO_23,TAMANHO_24,TAMANHO_25,TAMANHO_26,TAMANHO_27,TAMANHO_28,TAMANHO_29,TAMANHO_30, ");
            oSql.Append("TAMANHO_31,TAMANHO_32,TAMANHO_33,TAMANHO_34,TAMANHO_35,TAMANHO_36,TAMANHO_37,TAMANHO_38,TAMANHO_39,TAMANHO_40, ");
            oSql.Append("TAMANHO_41,TAMANHO_42,TAMANHO_43,TAMANHO_44,TAMANHO_45,TAMANHO_46,TAMANHO_47,TAMANHO_48 ");
            oSql.Append("from PRODUTOS_TAMANHOS");

            return DbMngmt<ProductoTalla>.executeSqlQueryToList(oSql.ToString());
        }

        public static ProductoTalla GetSingle(string idProducto)
        {
            StringBuilder oSql = new StringBuilder();

            oSql.Append("select a.GRADE, TAMANHOS_DIGITADOS, ");
            oSql.Append("TAMANHO_1,TAMANHO_2,TAMANHO_3,TAMANHO_4,TAMANHO_5,TAMANHO_6,TAMANHO_7,TAMANHO_8,TAMANHO_9,TAMANHO_10, ");
            oSql.Append("TAMANHO_11,TAMANHO_12,TAMANHO_13,TAMANHO_14,TAMANHO_15,TAMANHO_16,TAMANHO_17,TAMANHO_18,TAMANHO_19,TAMANHO_20, ");
            oSql.Append("TAMANHO_21,TAMANHO_22,TAMANHO_23,TAMANHO_24,TAMANHO_25,TAMANHO_26,TAMANHO_27,TAMANHO_28,TAMANHO_29,TAMANHO_30, ");
            oSql.Append("TAMANHO_31,TAMANHO_32,TAMANHO_33,TAMANHO_34,TAMANHO_35,TAMANHO_36,TAMANHO_37,TAMANHO_38,TAMANHO_39,TAMANHO_40, ");
            oSql.Append("TAMANHO_41,TAMANHO_42,TAMANHO_43,TAMANHO_44,TAMANHO_45,TAMANHO_46,TAMANHO_47,TAMANHO_48 ");
            oSql.Append("from PRODUTOS_TAMANHOS a inner join PRODUTOS b on a.GRADE = b.GRADE ");
            oSql.Append(string.Format("where  PRODUTO = '{0}'", idProducto));

            return DbMngmt<ProductoTalla>.executeSqlQuerySingle(oSql.ToString());
        }
    }
}
