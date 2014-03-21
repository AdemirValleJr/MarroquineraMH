using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizPropLojasVarejo
    {
        public List<PROP_LOJAS_VAREJO> getPropLojasVarejoList()
        {
            List<PROP_LOJAS_VAREJO> lstPropLojasVarejo = new List<PROP_LOJAS_VAREJO>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstPropLojasVarejo = ctx.PROP_LOJAS_VAREJO.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstPropLojasVarejo;
        }

        public List<PROP_LOJAS_VAREJO> getPropLojasVarejoList(FILIAIS filial)
        {
            List<PROP_LOJAS_VAREJO> lstPropLojasVarejo = new List<PROP_LOJAS_VAREJO>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstPropLojasVarejo = ctx.PROP_LOJAS_VAREJO.Where(x => x.CODIGO_FILIAL == filial.COD_FILIAL).ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstPropLojasVarejo;
        }

        public PROP_LOJAS_VAREJO getPropLojaVarejo(PROP_LOJAS_VAREJO propLojaVarejoTarget)
        {
            PROP_LOJAS_VAREJO propLojaVarejo = new PROP_LOJAS_VAREJO();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    propLojaVarejo = ctx.PROP_LOJAS_VAREJO.Where(x =>
                        x.CODIGO_FILIAL == propLojaVarejoTarget.CODIGO_FILIAL &&
                        x.PROPRIEDADE == propLojaVarejoTarget.PROPRIEDADE).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return propLojaVarejo;
        }
    }
}
