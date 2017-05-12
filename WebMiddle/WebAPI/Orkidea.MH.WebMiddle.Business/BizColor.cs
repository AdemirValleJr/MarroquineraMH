using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizColor
    {
        public static IList<Color> GetList()
        {
            return DbMngmt<Color>.executeSqlQueryToList("select cor id, DESC_COR descripcion from CORES_BASICAS order by DESC_COR");
        }
    }
}
