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
        private SubjectService Ics=new SubjectService();
        //public SubjectController()
        //{
        //    Ics = new IsubjectService();
        //}

        //public SubjectController(SubjectService ISubjectService)
        //{
        //    this.Ics = ISubjectService;
        //}
        [HttpGet]
        [Route("Subject/AllSubject")]

        public List<SubjectForListDTO> ListOfSubjects()
        {

            return Ics.GetListOfSubjects();

        }
        public SubjectDTO GetSubjectByID(int ID)
        {
            return Ics.GetSubjectByID(ID);
                }

        //public List<SubjectForListDTO> ListOfSubjectsyyy()
        //{
        //    return Ics.GetListOfSubjects();

        //}


    }
}

