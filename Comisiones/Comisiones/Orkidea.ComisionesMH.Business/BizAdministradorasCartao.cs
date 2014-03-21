using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizAdministradorasCartao
    {
        public List<ADMINISTRADORAS_CARTAO> getAdministradorasCartaoList()
        {
            List<ADMINISTRADORAS_CARTAO> lstAdministradoraCartao = new List<ADMINISTRADORAS_CARTAO>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstAdministradoraCartao = ctx.ADMINISTRADORAS_CARTAO.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstAdministradoraCartao;
        }

        public ADMINISTRADORAS_CARTAO getFilial(ADMINISTRADORAS_CARTAO administradoraCartaoTarget)
        {
            ADMINISTRADORAS_CARTAO administradoraCartao = new ADMINISTRADORAS_CARTAO();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    administradoraCartao = ctx.ADMINISTRADORAS_CARTAO.Where(x =>
                        x.CODIGO_ADMINISTRADORA == administradoraCartaoTarget.CODIGO_ADMINISTRADORA).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return administradoraCartao;
        }
    }

}
