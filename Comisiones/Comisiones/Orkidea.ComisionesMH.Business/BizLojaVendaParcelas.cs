using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLojaVendaParcelas
    {
        public List<LOJA_VENDA_PARCELAS> getLojaVendaParcelasList()
        {
            List<LOJA_VENDA_PARCELAS> lstLOJA_VENDA_PARCELAS = new List<LOJA_VENDA_PARCELAS>();

            try
            {
                using (var ctx = new Orkidea.ComisionesMH.DataAccessEF.MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA_PARCELAS = ctx.LOJA_VENDA_PARCELAS.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDA_PARCELAS;
        }

        //public List<LOJA_VENDA_PGTO> getLojaVendaPgtoList(LOJA_VENDA LojaVenda)
        //{
        //    List<LOJA_VENDA_PGTO> lstLOJA_VENDA_PGTO = new List<LOJA_VENDA_PGTO>();

        //    try
        //    {
        //        using (var ctx = new MHERPEntities())
        //        {
        //            ctx.Configuration.ProxyCreationEnabled = false;
        //            lstLOJA_VENDA_PGTO = ctx.LOJA_VENDA_PGTO
        //                .Include("LOJA_VENDA_PARCELAS")
        //                .Where(x => x.CODIGO_FILIAL == LojaVenda.CODIGO_FILIAL &&
        //                    x.TERMINAL == LojaVenda.TERMINAL &&
        //                    x.LANCAMENTO_CAIXA == LojaVenda.LANCAMENTO_CAIXA).ToList();
        //        }
        //    }
        //    catch (Exception ex) { throw ex; }

        //    return lstLOJA_VENDA_PGTO;
        //}
    }
}
