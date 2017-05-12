using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class CuentaTipoPago
    {
        public string tipo_pgto { get; set; }
        public string conta_contabil { get; set; }
        public double peso { get; set; }
        public string tipoLancamento { get; set; }
        public bool lineaPorTercero { get; set; }
    }
}
