using Orkidea.MH.WebMiddle.Business;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orkidea.MH.WebMiddle.WebAPI.Controllers
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

        // POST: api/Rol
        public void Post(Rol rol)
        {
            BizRol.Add(rol);
        }

        // PUT: api/Rol/5
        public void Put(Rol rol)
        {
            BizRol.Edit(rol);
        }

        // DELETE: api/Rol/5
        public void Delete(int id)
        {
            BizRol.Delete(new Rol() { id = id });
        }
    }
}
