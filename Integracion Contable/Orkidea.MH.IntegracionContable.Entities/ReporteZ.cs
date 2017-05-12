using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class ReporteZ
    {
        public int idTipoReporte { get; set; }
        public string tipoReporte { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroCupomFiscal { get; set; }
        public int grupoTipoPagamento { get; set; }
        public string descTipoPgto { get; set; }
        public string administradora { get; set; }
        public string numeroAprovacaoCartao { get; set; }
        public double valor { get; set; }
        public double ivaAsumido { get; set; }
        public string numeroTitulo { get; set; }
        public string terminal { get; set; }
        public string ticket { get; set; }
        public string clifor { get; set; }
        public double valorServicios { get; set; }
    }
}
