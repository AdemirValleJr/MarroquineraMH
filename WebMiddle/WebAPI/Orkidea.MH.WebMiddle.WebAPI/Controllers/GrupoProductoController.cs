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
    public class GrupoProductoController : ApiController
    {
        // GET: api/GrupoProducto
        public IEnumerable<GrupoProducto> Get()
        {
            return BizGrupoProducto.GetList();
        }

        //// GET: api/GrupoProducto/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/GrupoProducto
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/GrupoProducto/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/GrupoProducto/5
        //public void Delete(int id)
        //{
        //}
    }
}
