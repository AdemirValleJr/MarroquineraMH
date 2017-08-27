using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizGuardRol
    {
        public static List<GuardRol> GetAll()
        {
            List<GuardRol> data = DbMngmt<GuardRol>.executeSqlQueryToList("select guard id, rol descripcion from OrkGuardRol order by guard, rol").ToList();            
            
            return data;
        }

        public static void Add(GuardRol guardRol)
        {
            DbMngmt<GuardRol>.executeSqlQueryNonQuery(string.Format("insert into OrkGuardRol select '{0}', '{1}' ", guardRol.id, guardRol.descripcion));            
        }

        public static void Delete(string guard, string rol)
        {
            DbMngmt<GuardRol>.executeSqlQueryNonQuery(string.Format("delete from OrkGuardRol where guard = '{0}' and rol = '{1}' ", guard, rol));            
        }
    }
}
