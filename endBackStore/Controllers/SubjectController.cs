using ASPnetStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using BLL;

namespace endBackStore.Controllers
{

    [Route("api/Subject")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SubjectController : ApiController
    {
        SubjectService ss;
        [HttpGet]
        public List<SubjectForListCTP> ListOfSubjects()
        {
            if (true)
            {
            return ss.GetListOfSubjects();

            }

        }
        //[HttpGet]

        //public List<SubjectForListCTP> ListOfSubjectsyyy()
        //{
        //    return Is.ListOfSubjects();

        //}
    }
}
