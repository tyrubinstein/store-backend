using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace endBackStore.Controllers
{
    [Route("api/Post")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PostController : ApiController
    {
        //[HttpGet]
        //public List<PostCTP> GetListOfPostByIdSubject (int idOfSubject)
        //{
        //    return Is.GetListOfPostByIdSubject();

        //}
        //public List<PostCTP> GetTheCodOfSubjectOftheLatestPost(int idOfSubject)

    }
}
