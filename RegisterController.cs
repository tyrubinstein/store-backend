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
                return Ok(Convert.ToInt32(Irs.AddStore(store)));
        }
        [HttpPost]
        [Route("Register/AddCompany")]
        public IHttpActionResult AddCompany(CompanyDTO company)
        {
            return Ok(Convert.ToInt32(Irs.AddCompany(company)));
        }
        [HttpPost]
        [Route("Register/IsUser")]
        public IHttpActionResult IsUserExist(Login login) => Ok(Irs.IsUserExist(login));
        [HttpPost]
        [Route("Register/IsCompExist")]
        public IHttpActionResult IsCompExist(Login login) => Ok(Irs.IsCompExist(login));
        [HttpGet]
        [Route("Register/ResetPassword")]
        public IHttpActionResult ResetPassword(string email)
        {
            return Ok(Irs.ResetPassword(email));
        }
        [HttpPost]
        [Route("Register/IsThePasswordWrong")]
        public IHttpActionResult IsThePasswordWrong(Login login)
        {
            return Ok(Irs.IsThePasswordWrong(login)); 
        }

    }
}
