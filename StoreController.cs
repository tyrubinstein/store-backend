using ASPnetStore.Services;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIendBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StoreController : ApiController
    {
        private IStoreService Iss = new StoreService();
        [HttpGet]
        [Route("Store/GetStoreNameById")]
        public IHttpActionResult GetStoreNameById(int ID)
        {
            return Ok(Iss.GetStoreNameById(ID));

        }

    }
}
