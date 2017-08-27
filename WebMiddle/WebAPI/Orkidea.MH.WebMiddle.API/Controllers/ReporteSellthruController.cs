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
    public class ReporteSellthruController : ApiController
    {
        // GET: ReporteSellthru
        [Route("api/reportesellthru/{productFilters}/{storeFilters}/{groupers}")]
        public IEnumerable<SellTru> Get(string productFilters, string storeFilters, string groupers)
        {
            return BizReportesInventario.ReporteSellThru(productFilters, storeFilters, groupers);
        }
    }
}
