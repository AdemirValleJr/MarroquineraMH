using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public class BizColeccion
    {
        public static IList<Coleccion> GetList()
        {
            return DbMngmt<Coleccion>.executeSqlQueryToList("select cod_linha id, linha descripcion from PRODUTOS_LINHAS a order by descripcion");
        }
    }
}
