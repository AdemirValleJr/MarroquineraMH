using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orkidea.MH.IntegracionContable.Entities
{
    public class AsientoDetalle
    {
        public int lancamento { get; set; }
        public string codClifor { get; set; }
        public string nombreCliente { get; set; }
        public string contaContabil { get; set; }
        public string desConta { get; set; }
        public double credito { get; set; }
        public double debito { get; set; }
        public string historico { get; set; }
        public string codigoHistorico { get; set; }
        public string rateioCentroCusto { get; set; }
        public string moeda { get; set; }
        public string dataDigitacao { get; set; }
        public string lxTipoLancamento { get; set; }
        public int permiteAlteracao { get; set; }
        public double debitoMoeda { get; set; }
        public double creditoMoeda { get; set; }
        public double cambioNaData { get; set; }
        public string rateioFilial { get; set; }
        public int idContrapartida { get; set; }
    }
}
