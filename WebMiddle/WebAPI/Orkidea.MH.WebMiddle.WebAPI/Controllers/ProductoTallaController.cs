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
    public class ProductoTallaController : ApiController
    {
        //// GET: api/ProductoTalla
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ProductoTalla/5        
        public ProductoTalla Get( string id)
        {                        
            return BizProductoTalla.GetSingle(id.Replace('_', '.'));
        }

        //// POST: api/ProductoTalla
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ProductoTalla/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ProductoTalla/5
        //public void Delete(int id)
        //{
        //}
    }
}
