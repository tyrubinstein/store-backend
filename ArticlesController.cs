using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Device;
using System.Device.Location;
using System.Data.Entity.Spatial;

namespace endBackStore.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticlesController : ApiController
    {
        IArticlesService IAS;
        

        public ArticlesController()
        {
            IAS = new ArticlesService();
        }
        [HttpGet]
        [Route("Articles/GetArticles")]
        public IHttpActionResult GetArticles() => Ok(IAS.GetArticles());
       

    }
}
