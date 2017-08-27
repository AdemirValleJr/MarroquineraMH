using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizUsuario
    {
        public static IList<Usuario> Get()
        {
            return DbMngmt<Usuario>.executeSqlQueryToList("select a.idUsuario, a.idRol, b.descripcion from OrkUsuarioWebMiddle a inner join orkRolWebMiddle b on a.idRol = b.id order by idUsuario");
        }

        public static Usuario Get(string id)
        {
            return DbMngmt<Usuario>.executeSqlQuerySingle(string.Format("select idUsuario, idRol from OrkUsuarioWebMiddle where idUsuario = '{0}' ", id));
        }

        public static bool Add(Usuario usuario)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("Insert into OrkUsuarioWebMiddle select '{0}', {1}", usuario.idUsuario.ToString(), usuario.idRol.ToString()));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Edit(Usuario usuario)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("Update OrkUsuarioWebMiddle set idRol = {1} where idUsuario = '{0}'", usuario.idUsuario.ToString(), usuario.idRol.ToString()));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Delete(Usuario usuario)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("delete from OrkUsuarioWebMiddle where idUsuario = '{0}'", usuario.idUsuario.ToString()));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static Usuario login(Usuario usuario)
        {
            Usuario res = new Usuario();

            try
            {
                SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();

                cb.DataSource = ConfigurationManager.AppSettings["server"];
                cb.UserID = usuario.idUsuario;
                cb.Password = DecodeFrom64(usuario.clave);

                using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        res = BizUsuario.Get(usuario.idUsuario);
                        res.descripcion = BizRol.Get(res.idRol.ToString()).descripcion;

                        IList<GuardRol> guards = BizGuardRol.GetAll();
                        //string guard = string.Empty;
                        //bool uno = true;

                        //foreach (GuardRol item in guards.Where(x => x.descripcion == res.descripcion).ToList())
                        //{
                        //    if (!uno) {
                        //        guard += "--";
                        //    }

                        //    guard += item.id;

                        //    uno = false;
                        //}

                        res.guards = guards.Where(x => x.descripcion == res.descripcion).Select(x => x.id).ToArray();

                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                res = new Usuario();
            }

            return res;
        }

        private static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

    }
}
