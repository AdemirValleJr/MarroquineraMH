using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizTienda
    {
        public static IList<Tienda> GetList()
        {
            return DbMngmt<Tienda>.executeSqlQueryToList("select COD_FILIAL id, FILIAL descripcion from FILIAIS a where a.REDE_LOJAS in (1,12) order by FILIAL");
        }

        public static IList<Tienda> GetList(string idRedTiendas)
        {
            if (!string.IsNullOrEmpty(idRedTiendas))
                return DbMngmt<Tienda>.executeSqlQueryToList(
                    string.Format("select COD_FILIAL id, FILIAL descripcion from FILIAIS a where a.REDE_LOJAS = {1} ", idRedTiendas));
            else
                return GetList();
        }

        public static Tienda GetSingle(string id)
        {
            return DbMngmt<Tienda>.executeSqlQuerySingle(string.Format("select COD_FILIAL id, FILIAL descripcion from FILIAIS where COD_FILIAL = '{0}'", id));
        }
    }
}
