using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace endBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FindClothApplicationController : ApiController
    {
        IFindClothApplicationService IFCA;
        public FindClothApplicationController()
        {
            IFCA = new FindClothService();
        }
        [HttpGet]
        public string helo()
        {
            return "helo";
        }
        [HttpPost]
        [Route("FindClothApplication/FindStores")]
        public IHttpActionResult FindStores([FromBody]SearcClothDTO ClothDetails)
        {
            return Ok(IFCA.FindStores(ClothDetails));
        }
    }
}
