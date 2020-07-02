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
        [HttpGet]
        [Route("FindCloth/Find")]
        public IHttpActionResult Find(SearcClothDTO ClothDetails)
        {
            return Ok(IFCA.Find(ClothDetails));
        }
    }
}
