using Orkidea.MH.WebMiddle.Business;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orkidea.MH.WebMiddle.API.Controllers
{
    public class GuardRolController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<GuardRol> Get()
        {
            return BizGuardRol.GetAll();
        }
        
        // POST: api/Usuario
        public void Post(GuardRol guardRol)
        {
            BizGuardRol.Add(guardRol);
        }
       
        // DELETE: api/Usuario/5
        public void Delete(string id)
        {
            string[] idGuard = id.Split('-');

            BizGuardRol.Delete(idGuard[0], idGuard[1]);
        }
    }
}
