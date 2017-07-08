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
    public class TipoProductoController : ApiController
    {
        // GET: api/TipoProducto
        public IEnumerable<TipoProducto> Get()
        {
            return BizTipoProducto.GetList();
        }

        //// GET: api/TipoProducto/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/TipoProducto
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/TipoProducto/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/TipoProducto/5
        //public void Delete(int id)
        //{
        //}
    }
}
