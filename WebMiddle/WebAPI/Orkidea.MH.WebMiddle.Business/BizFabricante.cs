using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizFabricante
    {
        public static IList<Fabricante> GetList()
        {
            return DbMngmt<Fabricante>.executeSqlQueryToList("select distinct fabricante descripcion, b.clifor id from PRODUTOS a inner join fornecedores b on a.fabricante = b.fornecedor order by a.fabricante");
        }
    }
}
