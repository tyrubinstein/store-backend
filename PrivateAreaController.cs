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
    public class PrivateAreaController : ApiController
    {
        private IPrivateArea IPAS=new PrivateAreaService();
        [HttpGet]
        [Route("PrivateArea/GetUserById")]
        public IHttpActionResult GetUserById(int id)
        {
            return Ok(IPAS.GetUserById(id));
        }
        [HttpPost]
        [Route("PrivateArea/UpdateDetails")]
        public IHttpActionResult UpdateDetails(StoreDTO store)
        {
            return Ok(IPAS.UpdateDetails(store));
        }
    }
}
