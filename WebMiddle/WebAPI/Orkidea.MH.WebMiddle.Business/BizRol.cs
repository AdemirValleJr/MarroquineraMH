using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizRol
    {
        public static IList<Rol> Get()
        {
            return DbMngmt<Rol>.executeSqlQueryToList("select id, descripcion from OrkRolWebMiddle order by descripcion");
        }

        public static Rol Get(string id)
        {
            return DbMngmt<Rol>.executeSqlQuerySingle(string.Format("select id, descripcion from OrkRolWebMiddle where id = {0} ", id));
        }

        public static bool Add(Rol rol)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("Insert into OrkRolWebMiddle select '{0}'", rol.descripcion));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Edit(Rol rol)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("Update OrkRolWebMiddle set descripcion = '{1}' where id = '{0}'", rol.id.ToString(), rol.descripcion));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Delete(Rol rol)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("delete from OrkRolWebMiddle where id = '{0}'", rol.id.ToString()));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }
    }
}
