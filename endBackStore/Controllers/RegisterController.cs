using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static BLL.StoreDTO;

namespace APIendBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegisterController : ApiController
    {



        private IRegisterService Irs = new RegisterService();
        [HttpPost]
        [Route("Register/AddStore")]
        public IHttpActionResult AddNewStore(StoreDTO store)
        {

            if (Irs.AddStore(store))
                return Ok(true);
            return Ok(false);
        }
        [HttpPost]
        [Route("Register/IsUser")]
        public IHttpActionResult IsUserExist(Login login)
        {

            if (Irs.IsUserExist(login))
                return Ok(true);
            return Ok(false);
        }

    }
}
