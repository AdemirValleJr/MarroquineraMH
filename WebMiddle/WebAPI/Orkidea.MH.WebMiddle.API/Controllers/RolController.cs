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
    public class RolController : ApiController
    {
        // GET: api/Rol
        public IEnumerable<Rol> Get()
        {
            return BizRol.Get();
        }

        // GET: api/Rol/5
        public Rol Get(int id)
        {
            return BizRol.Get(id.ToString());
        }
    }
}
