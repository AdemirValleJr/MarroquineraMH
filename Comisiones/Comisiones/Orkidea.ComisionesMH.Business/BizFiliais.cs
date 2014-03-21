using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizFiliais
    {
        public List<FILIAIS> getFiliaisList()
        {
            List<FILIAIS> lstFiliais = new List<FILIAIS>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstFiliais = ctx.FILIAIS.Where(x => x.TIPO_FILIAL != null).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstFiliais;
        }

        public List<FILIAIS> getFiliaisList(LOJAS_REDE redeLoja)
        {
            List<FILIAIS> lstFiliais = new List<FILIAIS>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstFiliais = ctx.FILIAIS.Where(x => x.TIPO_FILIAL != null && x.REDE_LOJAS == redeLoja.REDE_LOJAS).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstFiliais;
        }

        public FILIAIS getFilial(FILIAIS filialTarget)
        {
            FILIAIS filial = new FILIAIS();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    filial = ctx.FILIAIS.Where(x =>
                        x.COD_FILIAL == filialTarget.COD_FILIAL).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return filial;
        }
    }
}
