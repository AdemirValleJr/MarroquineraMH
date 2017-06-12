using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Entities
{
    public class BaseReporte:BaseMaestros
    {
        public int valorEntero { get; set; }
        public double valorDoble { get; set; }
        public DateTime valorFecha { get; set; }
    }
}
