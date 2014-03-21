using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLojaVendaProduto
    {
        public List<LOJA_VENDA_PRODUTO> getLojaVendaProdutoList()
        {
            List<LOJA_VENDA_PRODUTO> lstLOJA_VENDA_PRODUTO = new List<LOJA_VENDA_PRODUTO>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA_PRODUTO = ctx.LOJA_VENDA_PRODUTO.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDA_PRODUTO;
        }

        public List<LOJA_VENDA_PRODUTO> getLojaVendaProdutoList(LOJA_VENDA lojaVenda)
        {
            List<LOJA_VENDA_PRODUTO> lstLOJA_VENDA_PRODUTO = new List<LOJA_VENDA_PRODUTO>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDA_PRODUTO = ctx.LOJA_VENDA_PRODUTO.Where(x => 
                        x.CODIGO_FILIAL == lojaVenda.CODIGO_FILIAL && 
                        x.TICKET == lojaVenda.TICKET).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDA_PRODUTO;
        }


    }
}
