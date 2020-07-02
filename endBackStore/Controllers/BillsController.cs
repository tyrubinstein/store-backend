using BLL.ModelDTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        
        [HttpGet]
        [Route("Bills/DeleteFile")]
       public IHttpActionResult  DeleteFile (string path)
        {
            return Ok(ibs.DeleteFile(path));
        }
        [HttpGet]
        [Route("Bills/Search")]
        public IHttpActionResult SearchRange(DateTime date1,DateTime date2)
        {
            return Ok(ibs.SearchBillsInRange(date1, date2));
        }

        [HttpPost]
        [Route("Bills/Upload")]
        public IHttpActionResult UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            if (postedFile != null)
            {
                imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
                postedFile.SaveAs(filePath);
            }
            return Ok();
        }
    }
}
