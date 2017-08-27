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
    public class FabricanteController : ApiController
    {
        // GET: api/Fabricante
        public IEnumerable<Fabricante> Get()
        {
            return BizFabricante.GetList();
        }
    }
}
