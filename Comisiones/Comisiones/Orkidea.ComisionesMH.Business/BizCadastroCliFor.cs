using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orkidea.ComisionesMH.DataAccessEF;
using Orkidea.ComisionesMH.Entities;

namespace Orkidea.ComisionesMH.Business
{
    public class BizCadastroCliFor
    {
        public CADASTRO_CLI_FOR getCadastroCliFor(CADASTRO_CLI_FOR cadastroCliForTarget)
        {
            CADASTRO_CLI_FOR cadastroCliFor = new CADASTRO_CLI_FOR();

            try
            {
                using (var ctx = new MHERPEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    cadastroCliFor = ctx.CADASTRO_CLI_FOR.Where(x =>
                        x.CLIFOR == cadastroCliForTarget.CLIFOR).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw ex; }

            return cadastroCliFor;
        }
    }
}
