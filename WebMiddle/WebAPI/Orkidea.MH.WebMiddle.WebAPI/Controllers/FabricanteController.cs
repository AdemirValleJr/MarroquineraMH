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
    public class FabricanteController : ApiController
    {
        // GET: api/Fabricante
        public IEnumerable<Fabricante> Get()
        {
            return BizFabricante.GetList();
        }

        //// GET: api/Fabricante/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Fabricante
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Fabricante/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Fabricante/5
        //public void Delete(int id)
        //{
        //}
    }
}
