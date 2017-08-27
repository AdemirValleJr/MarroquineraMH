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
    public class LogonController : ApiController
    {
        // GET: api/Logon
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Logon/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Logon
        public Usuario Post(Usuario usuario)
        {
            return BizUsuario.login(usuario);
        }

        //// PUT: api/Logon/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Logon/5
        //public void Delete(int id)
        //{
        //}
    }
}
