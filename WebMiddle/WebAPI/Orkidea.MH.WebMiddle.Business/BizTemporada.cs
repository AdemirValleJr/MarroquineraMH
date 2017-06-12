using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizTemporada
    {
        public static IList<Temporada> GetList()
        {
            return DbMngmt<Temporada>.executeSqlQueryToList("select COLECAO id, DESC_COLECAO descripcion from COLECOES a order by descripcion");
        }
    }
}
