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
    public class SubgrupoProductoController : ApiController
    {
        // GET: api/SubgrupoProducto
        public IEnumerable<SubgrupoProducto> Get()
        {
            return BizSubgrupoProducto.GetList();
        }

        // GET: api/SubgrupoProducto/5
        public IEnumerable<SubgrupoProducto> Get(string id)
        {
            return BizSubgrupoProducto.GetList(id);
        }

        //// POST: api/SubgrupoProducto
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/SubgrupoProducto/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/SubgrupoProducto/5
        //public void Delete(int id)
        //{
        //}
    }
}
