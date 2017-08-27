using Orkidea.MH.WebMiddle.DAL;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizMenu
    {
        public static MenuData Get()
        {            
            List<Menu> lsMenuBruto = DbMngmt< Menu>.executeSqlQueryToList("select id, idPadre, tipoMenu, ruta, label from OrkMenuWebMiddle order by id, idPadre").ToList();
            List<Menu> menu = lsMenuBruto.Where(x => x.idPadre == null).ToList();            

            foreach (Menu item in menu)
            {
                item.data = new Menu() { ruta = item.ruta, id = item.id, tipoMenu = item.tipoMenu};
                item.expandedIcon = "fa-folder-open";
                item.collapsedIcon = "fa-folder";
                item.children = getHijos(item, lsMenuBruto);                
            }

            MenuData data = new MenuData();
            data.data = menu;
            return data;
        }

        public static Menu Get(int idMenu)
        {
            return DbMngmt<Menu>.executeSqlQueryToList(string.Format("select id, idPadre, tipoMenu, ruta, label from OrkMenuWebMiddle where id = {0}", idMenu)).FirstOrDefault();                      
        }

        public static MenuData Get(string idRol)
        {
            List<Menu> lsMenuBruto = DbMngmt<Menu>.executeSqlQueryToList("select id, idPadre, tipoMenu, ruta from OrkMenuWebMiddle order by id, idPadre").ToList();
            List<Menu> lsMenu = new List<Menu>();
            List<MenuRol> menuRol = DbMngmt<MenuRol>.executeSqlQueryToList(string.Format("select * from OrkMenuRolWebMiddle where idRol = {0}", idRol)).ToList();

            foreach (Menu item in lsMenuBruto)
            {
                if (menuRol.Where(x => x.idMenu.Equals(item.id)).Count() > 0)
                    lsMenu.Add(item);
            }

            List<Menu> menu = lsMenuBruto.Where(x => x.idPadre == null).ToList();

            foreach (Menu item in menu)
            {
                item.children = getHijos(item, lsMenuBruto);
            }

            MenuData data = new MenuData();
            data.data = lsMenu;
            return data;
        }

        public static bool Add(Menu menu)
        {
            bool res = false;

            try
            {
                StringBuilder oSql = new StringBuilder();

                oSql.Append(string.Format("Insert into OrkMenuWebMiddle select {0}, '{1}', '{2}'", menu.idPadre==null ? "null": menu.idPadre.ToString(), menu.tipoMenu.ToString(), menu.ruta));

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql.ToString()) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Add(MenuRol menuRol)
        {
            bool res = false;

            try
            {                
                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(string.Format("Insert into OrkMenuRolWebMiddle select {0}, {1}", menuRol.idRol.ToString(), menuRol.idMenu.ToString())) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Update(Menu menu)
        {
            bool res = false;

            try
            {
                string oSql = string.Format("update OrkMenuWebMiddle set idPadre = {0}, tipoMenu = '{1}', ruta = '{2}' where id = {3}", menu.idPadre == null ? "null" : menu.idPadre.ToString(), menu.tipoMenu.ToString(), menu.ruta, menu.id.ToString());

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(oSql) > 0)
                    res = true;
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Delete(Menu menu)
        {
            bool res = false;

            try
            {
                List<Menu> lsMenuBruto = DbMngmt<Menu>.executeSqlQueryToList("select id, idPadre, tipoMenu, ruta from OrkMenuWebMiddle order by id, idPadre").ToList();

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(string.Format("delete from OrkMenuWebMiddle where id = {0}", menu.id.ToString())) > 0)
                {
                    deleteHijos(menu, lsMenuBruto);
                    res = true;
                }
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        public static bool Delete(MenuRol menuRol)
        {
            bool res = false;

            try
            {
                List<Menu> lsMenuBruto = DbMngmt<Menu>.executeSqlQueryToList("select id, idPadre, tipoMenu, ruta from OrkMenuWebMiddle order by id, idPadre").ToList();

                if (DbMngmt<Usuario>.executeSqlQueryNonQuery(string.Format("delete from OrkMenuRolWebMiddle where idRol = {0} and idMenu = {1}", menuRol.idRol.ToString(), menuRol.idMenu.ToString())) > 0)
                {
                    deleteHijos(menuRol, lsMenuBruto);
                    res = true;
                }
            }
            catch (Exception)
            {
                res = false;
            }

            return res;
        }

        private static List<Menu> getHijos(Menu menu, List<Menu> menuBruto)
        {
            List<Menu> hijos = menuBruto.Where(x => x.idPadre.Equals(menu.id)).ToList();

            foreach (Menu item in hijos)
            {
                item.data = new Menu() { ruta = item.ruta, id = item.id, tipoMenu = item.tipoMenu };
                item.expandedIcon = "fa-folder-open";
                item.collapsedIcon = "fa-folder";
                item.children = getHijos(item, menuBruto);
            }

            return hijos;
        }

        private static void deleteHijos(Menu menu, List<Menu> menuBruto)
        {
            List<Menu> hijos = menuBruto.Where(x => x.idPadre.Equals(menu.id)).ToList();

            foreach (Menu item in hijos)
            {
                DbMngmt<Usuario>.executeSqlQueryNonQuery(string.Format("delete from OrkMenuWebMiddle where id = {0}", item.id.ToString()));

                deleteHijos(item, menuBruto);
            }
        }

        private static void deleteHijos(MenuRol menuRol, List<Menu> menuBruto)
        {
            List<Menu> hijos = menuBruto.Where(x => x.idPadre.Equals(menuRol.idMenu)).ToList();

            foreach (Menu item in hijos)
            {
                DbMngmt<Usuario>.executeSqlQueryNonQuery(string.Format("delete from OrkMenuRolWebMiddle where idRol = {0} and idMenu = {1}", menuRol.idRol.ToString(), item.id));

                deleteHijos(new MenuRol() { idRol = menuRol.idRol, idMenu = item.id}, menuBruto);
            }
        }
    }
}
