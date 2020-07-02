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
            string res = Irs.IsUserExist(login);
            if (res=="true")
                return Ok(res);
            if (res == "no user")
                return Ok(res);
            else
                return Ok(res);
        }
        [HttpGet]
        [Route("Register/ResetPassword")]
        public IHttpActionResult ResetPassword(string email)
        {
            return Ok(Irs.ResetPassword(email));
        }

    }
}
