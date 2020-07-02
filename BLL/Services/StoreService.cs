using BLL;
using BLL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPnetStore.Services
{

    public interface IStoreService
    {
        //PostDTO GetSubjectByID(int ID);
        //List<PostDTO> GetListOfPostByIdSubject(int idOfSubject);
        string GetStoreNameById(int ID);


    }

    public class StoreService : IStoreService
    { 
        storesEntities db= new storesEntities();
        public string GetStoreNameById(int ID)
        {
            return "familyLand";
            //למה הפונקצייה מחזירה NULL
            return db.Stores
          .Where(x => x.StoreID == ID)
          .Select(x => x.StoreName).Single();
                   
        }



    }

        //public List<PostDTO> GetListOfPostByIdSubject(int idOfSubject)
        //{
        //    try
        //    {               //מחקתי הצהרת משתנה    
        //                    //Subject l = db.Subjects.Last();
        //        return db.Posts.
        //         Join(db.Stores, p => p.StoreID, st => st.StoreID,
        //       (p, st) => new { p, st }).Where(p => p.p.SubjectID == idOfSubject)
        //       .Select(p => new PostDTO
        //       {
        //           PostID = p.p.PostID,
        //           StoreName = p.st.StoreName,
        //           ContentText = p.p.ContentText,
        //           DatetimeOfWriting = p.p.DatetimeOfWriting
        //       }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        return null;
        //    }
        //}


        //public int GetIDOfNewestSubject()
        //{
        //    return db.Posts.OrderBy(s => s.DatetimeOfWriting).FirstOrDefault().SubjectID;
        //}





        //private void LogException(Exception ex)
        //{
        //    throw new NotImplementedException();
        //}

        //PostDTO IPostService.GetSubjectByID(int ID)
        //{
        //    throw new NotImplementedException();
        //}



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

    




    
     
      

    




