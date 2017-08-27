using Orkidea.MH.WebMiddle.Business;
using Orkidea.MH.WebMiddle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orkidea.MH.WebMiddle.API.Controllers
{
    public class TipoProductoController : ApiController
    {
        // GET: api/TipoProducto
        public IEnumerable<TipoProducto> Get()
        {
            return BizTipoProducto.GetList();
        }
    }
}
