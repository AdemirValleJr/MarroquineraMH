using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class CuentaAdministradora
    {
        public string tipo_pgto { get; set; }
        public string conta_contabil { get; set; }        
        public string tipoLancamento { get; set; }
        public string idAdministradora { get; set; }
        public string administradora { get; set; }
    }
}
