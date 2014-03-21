using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.ComisionesMH.UI.Model
{
    public class LojaResumenVendaVendedor
    {
        public string CODIGO_FILIAL { get; set; }
        public string VENDEDOR { get; set; }
        public string VENDEDOR_NOME { get; set; }
        public decimal SellOutBruto { get; set; }
        public decimal sellOutNeto { get; set; }
        public decimal vlrImpuestos { get; set; }
        public decimal bonosVendidos { get; set; }
        public decimal bonosRedimidos { get; set; }
        public decimal descuentoTotal { get; set; }
        public decimal pagosTarjeta { get; set; }
        public decimal comisionTarjetas { get; set; }
        public decimal ivaBonosRedimidos { get; set; }
        public decimal ivaBonosVendidos { get; set; }        
        public decimal comision{ get; set; }
        public string terceroVendedor { get; set; }
        public decimal porComision { get; set; }
    }
}
