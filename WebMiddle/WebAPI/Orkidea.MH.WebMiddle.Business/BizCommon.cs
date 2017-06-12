using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Business
{
    public static class BizCommon
    {
        public static string ListToString(char dato,List<Tienda> list)
        {
            bool addComma = false;
            StringBuilder lista = new StringBuilder();

            foreach (var item in list)
            {
                if (addComma)
                    lista.Append(", ");

                lista.Append(string.Format("'{0}'", dato=='i'? item.id:item.descripcion));

                if (!addComma)
                    addComma = true;
            }

            return lista.ToString();

        }

        public static string ListToString(char dato, List<Color> list)
        {
            bool addComma = false;
            StringBuilder lista = new StringBuilder();

            foreach (var item in list)
            {
                if (addComma)
                    lista.Append(", ");

                lista.Append(string.Format("'{0}'", dato == 'i' ? item.id : item.descripcion));

                if (!addComma)
                    addComma = true;
            }

            return lista.ToString();

        }

        public static string ListToString(char dato, List<Producto> list)
        {
            bool addComma = false;
            StringBuilder lista = new StringBuilder();

            foreach (var item in list)
            {
                if (addComma)
                    lista.Append(", ");

                lista.Append(string.Format("'{0}'", dato == 'i' ? item.id : item.descripcion));

                if (!addComma)
                    addComma = true;
            }

            return lista.ToString();

        }


    }
}
