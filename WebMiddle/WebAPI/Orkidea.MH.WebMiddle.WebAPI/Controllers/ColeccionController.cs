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
    public class ColeccionController : ApiController
    {
        // GET: api/Coleccion
        public IEnumerable<Coleccion> Get()
        {
            return BizColeccion.GetList();
        }

        //// GET: api/Coleccion/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Coleccion
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Coleccion/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Coleccion/5
        //public void Delete(int id)
        //{
        //}
    }
}
