using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLojaVendedores
    {
        public List<LOJA_VENDEDORES> GetVendedorList()
        {
            List<LOJA_VENDEDORES> lstLOJA_VENDEDORES = new List<LOJA_VENDEDORES>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDEDORES = ctx.LOJA_VENDEDORES.ToList();//.Where(x => x.DATA_DESATIVACAO == null || x.DATA_DESATIVACAO >= DateTime.Now).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDEDORES;
        }

        public List<LOJA_VENDEDORES> GetVendedorList(FILIAIS tiendaTarget)
        {
            List<LOJA_VENDEDORES> lstLOJA_VENDEDORES = new List<LOJA_VENDEDORES>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJA_VENDEDORES = ctx.LOJA_VENDEDORES
                        //.Where(x => (x.DATA_DESATIVACAO == null || x.DATA_DESATIVACAO >= DateTime.Now) && x.CODIGO_FILIAL == tiendaTarget.COD_FILIAL)
                        .Where(x =>  x.CODIGO_FILIAL == tiendaTarget.COD_FILIAL)
                        .ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJA_VENDEDORES;
        }

        public LOJA_VENDEDORES GetVendedor(LOJA_VENDEDORES vendedorTarget)
        {
            LOJA_VENDEDORES filial = new LOJA_VENDEDORES();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    filial = ctx.LOJA_VENDEDORES
                        //.Where(x => x.VENDEDOR == vendedorTarget.VENDEDOR && x.DATA_DESATIVACAO == null)
                        .Where(x => x.VENDEDOR == vendedorTarget.VENDEDOR)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return filial;
        }
    }
}
