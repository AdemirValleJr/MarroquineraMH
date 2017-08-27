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
    public class ReporteKardexTiendaProductoColorController : ApiController
    {
        // GET: api/ReporteKardexTiendaProductoColor/5        
        [Route("api/ReporteKardexTiendaProductoColor/{tienda}/{producto}/{color}")]
        public IEnumerable<KardexTiendaProductoColor> Get(string tienda, string producto, string color)
        {
            return BizReportesInventario.ReporteKardexFilialProdutoCor(tienda, producto, color);
        }
    }
}
