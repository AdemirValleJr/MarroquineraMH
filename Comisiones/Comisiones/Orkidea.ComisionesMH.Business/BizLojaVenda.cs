using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.Entities;
using Orkidea.ComisionesMH.DataAccessEF;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLojaVenda
    {
        public List<LOJA_VENDA> getLojaVendaList()
        {            
            List<LOJA_VENDA> lstLOJA_VENDA = new List<LOJA_VENDA>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA = ctx.LOJA_VENDA.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDA;
        }

        public List<LOJA_VENDA> getLojaVendaList(DateTime Desde, DateTime Hasta)
        {
            List<LOJA_VENDA> lstLOJA_VENDA = new List<LOJA_VENDA>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA = ctx.LOJA_VENDA.Where(x => x.DATA_VENDA >= Desde && x.DATA_VENDA <= Hasta && x.VALOR_TIKET != 0).OrderBy(x => x.CODIGO_FILIAL).ThenBy(x => x.TICKET
                        ).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDA;
        }

        public List<LOJA_VENDA> getLojaVendaList(DateTime Desde, DateTime Hasta, FILIAIS tienda)
        {
            List<LOJA_VENDA> lstLOJA_VENDA = new List<LOJA_VENDA>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA = ctx.LOJA_VENDA.Where(x => x.DATA_VENDA >= Desde && x.DATA_VENDA <= Hasta && x.CODIGO_FILIAL == tienda.COD_FILIAL && x.VALOR_TIKET != 0).OrderBy(x => x.TICKET).ToList();
                }
            }   
            catch (Exception ex) { throw ex;  }

            return lstLOJA_VENDA;
        }

        public LOJA_VENDA getLojaVenda(LOJA_VENDA lojaVendaTarget)
        {
            LOJA_VENDA lojaVenda = new LOJA_VENDA();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lojaVenda = ctx.LOJA_VENDA.Where(x =>
                        x.CODIGO_FILIAL == lojaVendaTarget.CODIGO_FILIAL &&
                        x.TICKET == lojaVendaTarget.TICKET &&
                        x.DATA_VENDA.Equals(lojaVendaTarget.DATA_VENDA)).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return lojaVenda;
        }
    }
}
