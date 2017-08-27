using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Entities
{
    public class Menu
    {
        public int id { get; set; }
        public int? idPadre { get; set; }
        public string tipoMenu { get; set; }
        public string ruta { get; set; }
        public string label { get; set; }
        public List<Menu> children { get; set; }
        public string expandedIcon { get; set; }
        public string collapsedIcon { get; set; }
        public Menu data { get; set; }

        public Menu()
        {
            children = new List<Menu>();            
        }
    }
}
