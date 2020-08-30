using BLL.Services;
using DAL;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace endBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BillsController : ApiController
    {
        private IBillsService ibs = new BillsService();
        [HttpGet]
        [Route("Bills/GetInventoryById")]
        public IHttpActionResult GetInventoryById(int id) => Ok(ibs.GetInventoryById(id));

        [HttpGet]
        [Route("Bills/GetAll")]
        public IHttpActionResult getAllBills(int id)
        {
            return Ok(ibs.GetAllBillsById(id));

        }

        [HttpGet]
        [Route("Bills/DeleteFile")]
        public IHttpActionResult DeleteFile(string path)
        {
            return Ok(ibs.DeleteFile(path));
        }
        [HttpGet]
        [Route("Bills/Search")]
        public IHttpActionResult SearchRange(DateTime date1, DateTime date2)
        {
            return Ok(ibs.SearchBillsInRange(date1, date2));
        }

        [HttpPost]
        [Route("Bills/Upload")]
        public IHttpActionResult Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                try
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath($"~/App_Data/uploads/{postedFile.FileName}");
                        postedFile.SaveAs(filePath);
                       return Ok(ibs.UpLoad(filePath, postedFile.FileName));
                    }

                }
                catch (Exception )
                {

                    throw ;
                }
            
            }

            return Ok(false);

            
        }


       
    }
}
