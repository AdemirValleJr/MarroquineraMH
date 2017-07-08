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

        public static IList<Producto> GetList(string filter)
        {
            string[] filters = filter.Split('@');
            StringBuilder oSql = new StringBuilder();
            
            bool gotFilter = false, addAnd = false;
            
            oSql.Append("select PRODUTO id , DESC_PRODUTO descripcion from PRODUTOS ");

            for (int i = 0; i < 7; i++)
            {
                if (!string.IsNullOrEmpty(filters[i]))
                {
                    if (!gotFilter)
                    {
                        gotFilter = true;
                        oSql.Append("where ");
                    }
                    
                    switch (i)
                    {
                        case 0:
                            oSql.Append(string.Format("GRUPO_PRODUTO = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 1:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("SUBGRUPO_PRODUTO = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 2:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("SEXO_TIPO = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 3:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("MODELAGEM = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 4:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("FABRICANTE = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 5:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("COLECAO = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        case 6:
                            if (addAnd)
                                oSql.Append(" and ");

                            oSql.Append(string.Format("TIPO_PRODUTO = '{0}' ", filters[i]));
                            addAnd = true;
                            break;

                        default:
                            break;
                    }
                }
            }

            return DbMngmt<Producto>.executeSqlQueryToList(oSql.ToString());
        }
    }
}
