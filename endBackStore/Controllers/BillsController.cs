using BLL.ModelDTO;
using BLL.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace endBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BillsController : ApiController
    {
       private IBillsService ibs = new BillsService();

        //[HttpGet]
        //[Route("Bills/GetAll")]
        //public List<BillsDTO> getAllBills()
        //{
        //    return ibs.GetAllBills();
            
        //}
        [HttpGet]
        [Route("Bills/GetAll")]
        public IHttpActionResult getAllBills()
        {
            return  Ok(ibs.GetAllBills());

        }
        

    }
}
