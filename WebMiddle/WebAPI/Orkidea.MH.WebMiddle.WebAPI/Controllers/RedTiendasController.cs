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
    public class RedTiendasController : ApiController
    {
        // GET: api/RedTiendas
        public IEnumerable<RedTiendas> Get()
        {
            return BizRedTiendas.GetList();
        }

        //// GET: api/RedTiendas/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/RedTiendas
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/RedTiendas/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/RedTiendas/5
        //public void Delete(int id)
        //{
        //}
    }
}
