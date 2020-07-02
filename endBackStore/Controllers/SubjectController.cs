using ASPnetStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using BLL;

namespace APIendBackStore.Controllers
{

    [RoutePrefix("api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubjectController : ApiController
    {
        private IsubjectService Ics = new SubjectService();
        //public SubjectController()
        //{
        //    Ics = new IsubjectService();
        //}

        //public SubjectController(SubjectService ISubjectService)
        //{
        //    this.Ics = ISubjectService;
        //}
        [HttpGet]
        [Route("Subject/GetListOfAllSubject")]
        public IHttpActionResult ListOfSubjects()
        {
            return Ok(Ics.GetListOfSubjects());
        }
        [HttpPost]
        [Route("Subject/AddSubject")]
        public IHttpActionResult AddSubject(SubjectDTO subject)
        {
            return Ok(Ics.AddSubject(subject));
        }

        [HttpGet]
        [Route("Subject/GetSubjectByID")]
        public IHttpActionResult GetSubjectByID(int ID)
        {
            return Ok(Ics.GetSubjectByID(ID));
        }
        [HttpGet]
        [Route("Subject/GetIDOfNewestSubject")]
        public IHttpActionResult GetNewestSubject()
        {
            return Ok(Ics.GetIDOfNewestSubject());
        }






    }
}

