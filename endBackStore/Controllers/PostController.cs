using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIendBackStore.Controllers
{
    [Route("api/Post")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PostController : ApiController
    {
        //[HttpGet]
        //public List<PostDTO> GetListOfPostByIdSubject (int idOfSubject)
        //{
        //    return Is.GetListOfPostByIdSubject();

        //}
        //public List<PostDTO> GetTheCodOfSubjectOftheLatestPost(int idOfSubject)

    }
}
