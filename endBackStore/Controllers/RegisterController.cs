using BLL;
using BLL.Services;
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
    public class RegisterController : ApiController
    {
       


        RegisterService rs = new RegisterService();
        [HttpPost]
        [Route("Register/AddStore")]
        public IHttpActionResult AddNewStore(StoreDTO store)
        {

            if (rs.AddStore(store))
                return Ok(true);
            return Ok(false);
        }
    }
}
