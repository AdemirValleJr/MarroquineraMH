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
    public class ModeloController : ApiController
    {
        // GET: api/Modelo
        public IEnumerable<Modelo> Get()
        {
            return BizModelo.GetList();
        }
    }
}
