using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class Filial
    {
        public string cod_filial { get; set; }
        public string filial { get; set; }
        public List<Terminal> terminal { get; set; }

        public Filial()
        {
            terminal = new List<Terminal>();
        }
    }
}
