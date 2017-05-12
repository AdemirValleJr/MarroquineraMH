using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class Asiento
    {
        public string codigoFilial { get; set; }
        public string fecha { get; set; }
        public string terminal { get; set; }
        public List<AsientoDetalle> lineas { get; set; }

        public Asiento()
        {
            lineas = new List<AsientoDetalle>();
        }
    }
}
