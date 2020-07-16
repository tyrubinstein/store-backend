using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPnetStore.Services
{

    public interface IsubjectService
    {
        SubjectDTO GetSubjectByID(int ID);
        List<SubjectForListDTO> GetListOfSubjects();

    }

    public class SubjectService : IsubjectService

    {
        storesEntities1 db;
        


        public List<SubjectForListDTO> GetListOfSubjects()
        {
            try
            {
                //מחקתי הצהרת משתנה
                using (db = new storesEntities1())
                {
                    Subject l = db.Subjects.Last();
                    return db.Subjects.
                   Join(db.Stores, sub => sub.StoreID, st => st.StoreID,
                   (sub, st) => new { sub, st })
                   .Select(m => new SubjectForListDTO
                   {
                       SubjectID = m.sub.SubjectID,
                       SubjectName = m.sub.SubjectName,
                       StoreName = m.st.StoreName
                   }).ToList<SubjectForListDTO>();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        public SubjectDTO GetSubjectByID(int ID)
        {
            return db.Subjects.
                Join(db.Stores, sub => sub.StoreID, st => st.StoreID,
                   (sub, st) => new { sub, st })
                   .Where(x => x.sub.SubjectID == ID)
                   .Select(x => new SubjectDTO() 
            {
                SubjectID = x.sub.SubjectID,
                SubjectName = x.sub.SubjectName,
                DatetimeOfWriting = x.sub.DatetimeOfWriting,
                IfWantUpdate = x.sub.IfWantUpdate,
                StoreName = x.st.StoreName
               
            }).FirstOrDefault();
        }



        private void LogException(Exception ex)
        {
            throw new NotImplementedException();
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


    } }
    




    
     
      

    




