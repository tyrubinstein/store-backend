
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ASPnetStore.Services
{

    public interface IsubjectService
    {
        SubjectDTO GetSubjectByID(int ID);
        List<ForListDTO> GetListOfSubjects();
        int GetIDOfNewestSubject();
        bool AddSubject(SubjectDTO subjectDTO);
        DateTime GetlatestDateOfPostBySubjectId(int subjectId);

    }

    public class SubjectService : IsubjectService
    {
        storesEntities db;



        public List<ForListDTO> GetListOfSubjects()
        {
            using (db = new storesEntities())
            {
                try

                {               //מחקתי הצהרת משתנה    
                                //Subject l = db.Subjects.Last();
                    return db.Subjects.
                   Join(db.Stores, sub => sub.StoreID, st => st.StoreID,
                   (sub, st) => new { sub, st })
                  .OrderBy(s => s.sub.DatetimeOfWriting).Select(m => new ForListDTO
                  {
                      ID = m.sub.SubjectID,
                      ImportantText = m.sub.SubjectName,
                      sideText = m.st.StoreName
                  }).ToList();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int GetIDOfNewestSubject()
        {
            using (db = new storesEntities())
            {
                try
                {
                    return db.Posts.OrderByDescending(s => s.DatetimeOfWriting).FirstOrDefault().SubjectID;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public DateTime GetlatestDateOfPostBySubjectId(int subjectId)
        {
            using (db = new storesEntities())
            {


                try
                {
                    return (DateTime)db.Posts.Where(x => x.SubjectID == subjectId).OrderByDescending(s => s.DatetimeOfWriting).FirstOrDefault().DatetimeOfWriting;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public SubjectDTO GetSubjectByID(int ID)
        {
            using (db = new storesEntities())
            {
                try
                {
                    return db.Subjects
              .Where(x => x.SubjectID == ID)
                         .Select(x => new SubjectDTO()
                         {
                             SubjectID = x.SubjectID,
                             SubjectName = x.SubjectName,
                             DatetimeOfWriting = x.DatetimeOfWriting,
                             IfWantUpdate = x.IfWantUpdate,
                             StoreID = x.StoreID,
                             Content = x.Content


                         }).FirstOrDefault();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public bool AddSubject(SubjectDTO subjectDTO)
        {
            using (db = new storesEntities())
            {
                subjectDTO.DatetimeOfWriting = DateTime.Now;
                try
                {
                    db.Subjects.Add(subjectDTO.FromDTO());
                    db.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
        //public List<SubscriberDTO> GetSubsById(string ID)
        //{
        //    return db.subscriber_tbl.Where(s => s.cust_id == ID).Select(s => new SubscriberDTO()
        //    {
        //        identity_sub = s.identity_sub,
        //        cust_id = ID,
        //        subSName = s.subSName

        //    }).ToList();

        //}
        //public List<packageDTO> GetPackageByIdS(string ID)
        //{

        //    return db.packages_tbl.Where(x => x.subsforPacages.Any(ps => ps.id_subs == ID))
        //        .Select(ps => new packageDTO()
        //        {
        //            idPec = ps.idPec,
        //            pecName = ps.pecName,
        //            sumMinute = ps.sumMinute
        //        }).ToList();


        //}


    }
}







