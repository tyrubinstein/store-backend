using ASPnetStore.Services;
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
    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostController : ApiController
    {
        private IPostService Ips = new PostService();
        [HttpGet]
        [Route("Post/GetListOfPostByIdSubject")]
        public IHttpActionResult GetListOfPostByIdSubject(int idOfSubject)
        {
            return Ok(Ips.GetListOfPostByIdSubject(idOfSubject));

        }
        [HttpPost]
        [Route("Post/AddPost")]
        public IHttpActionResult AddPost(PostDTO p)
        {
            return Ok(Ips.AddPost(p));
        }
        //public List<PostDTO> GetTheCodOfSubjectOftheLatestPost(int idOfSubject)

    }
}
