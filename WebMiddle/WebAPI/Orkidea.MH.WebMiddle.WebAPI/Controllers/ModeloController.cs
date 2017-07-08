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
    public class ModeloController : ApiController
    {
        // GET: api/Modelo
        public IEnumerable<Modelo> Get()
        {
            return BizModelo.GetList();
        }

        //// GET: api/Modelo/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Modelo
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Modelo/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Modelo/5
        //public void Delete(int id)
        //{
        //}
    }
}
