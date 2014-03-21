
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizFornecedores
    {
        public FORNECEDORES getFornecedores(FORNECEDORES fornecedorTarget)
        {
            FORNECEDORES fornecedor = new FORNECEDORES();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    fornecedor = ctx.FORNECEDORES.Where(x =>
                        x.CGC_CPF == fornecedorTarget.CGC_CPF).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return fornecedor;
        }
    }
}
