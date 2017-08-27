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
    public class TiendaController : ApiController
    {
        // GET: api/Tienda
        public IEnumerable<Tienda> Get()
        {
            return BizTienda.GetList();
        }

        // GET: api/Tienda/5
        public IEnumerable<Tienda> Get(string id)
        {
            return BizTienda.GetList(id);
        }
    }
}
