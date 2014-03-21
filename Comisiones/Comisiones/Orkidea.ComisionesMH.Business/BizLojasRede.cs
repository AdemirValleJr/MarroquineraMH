using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizLojasRede
    {
        public List<LOJAS_REDE> GetRedeLojasList()
        {
            List<LOJAS_REDE> lstLOJAS_REDE = new List<LOJAS_REDE>();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    lstLOJAS_REDE = ctx.LOJAS_REDE.ToList();
                }
            }
            catch (Exception ex) { throw ex; }

            return lstLOJAS_REDE;
        }
    }

}
