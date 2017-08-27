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
    public class ColeccionController : ApiController
    {
        // GET: api/Coleccion
        public IEnumerable<Coleccion> Get()
        {
            return BizColeccion.GetList();
        }
    }
}
