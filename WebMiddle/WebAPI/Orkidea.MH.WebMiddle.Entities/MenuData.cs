using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Entities
{
    public class MenuData
    {        
        public List<Menu> data { get; set; }

        public MenuData()
        {
            data = new List<Menu>();
        }
    }
}
