using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orkidea.MH.WebMiddle.Entities
{
    public class SellTru
    {
        //public string REDE_LOJAS { get; set; }        
        //public string COD_FILIAL { get; set; }
        //public string MODELAGEM { get; set; }
        //public string PRODUTO { get; set; }
        //public string COR_PRODUTO { get; set; }

        public string DESC_REDE_LOJAS { get; set; }
        public string FILIAL { get; set; }
        public string GRUPO_PRODUTO { get; set; }        
        public string SUBGRUPO_PRODUTO { get; set; }        
        public string DESC_SEXO_TIPO { get; set; }                
        public string DESC_MODELO { get; set; }
        public string FABRICANTE { get; set; }
        public string COLECAO { get; set; }
        public string LINHA { get; set; }
        public string TIPO_PRODUTO { get; set; }                
        public string DESC_PRODUTO { get; set; }        
        public string DESC_COR { get; set; }        
        
        public int STOCK { get; set; }
        public string EMISSAO { get; set; }
        public int SEMANAS { get; set; }
        //public decimal PRECO_LIQUIDO { get; set; }
        public int Venta { get; set; }
        public decimal sellThru { get; set; }
        public decimal mesesInventario { get; set; }
        
    }
}
