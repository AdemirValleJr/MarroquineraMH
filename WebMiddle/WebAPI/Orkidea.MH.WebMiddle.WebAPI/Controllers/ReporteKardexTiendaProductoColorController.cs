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
    
    public class ReporteKardexTiendaProductoColorController : ApiController
    {
        //// GET: api/ReporteKardexTiendaProductoColor
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ReporteKardexTiendaProductoColor/5        
        [Route("api/ReporteKardexTiendaProductoColor/{tienda}/{producto}/{color}")]
        public IEnumerable<KardexTiendaProductoColor> Get(string tienda, string producto, string color)
        {
            return BizReportesInventario.ReporteKardexFilialProdutoCor(tienda, producto, color);
        }

        //// POST: api/ReporteKardexTiendaProductoColor
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ReporteKardexTiendaProductoColor/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ReporteKardexTiendaProductoColor/5
        //public void Delete(int id)
        //{
        //}
    }
}
