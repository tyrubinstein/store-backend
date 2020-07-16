using BLL;
using BLL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPnetStore.Services
{

    public interface IPostService
    {
        List<PostDTO> GetListOfPostByIdSubject(int idOfSubject);
        bool AddPost(PostDTO postDTO);

    }

    public class PostService : IPostService
    {
        storesEntities db;

        public List<PostDTO> GetListOfPostByIdSubject(int idOfSubject)
        {
            using(db=new storesEntities())
            try
            {               //מחקתי הצהרת משתנה    
                            //Subject l = db.Subjects.Last();
                return db.Posts.
                  Where(p => p.SubjectID == idOfSubject)
               .Select(p => new PostDTO
               {
                   PostID = p.PostID,
                   StoreID = p.StoreID,
                   ContentText = p.ContentText,
                   DatetimeOfWriting = p.DatetimeOfWriting
               }).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        public bool AddPost(PostDTO postDTO)
        {
            using (db = new storesEntities())
            {
                postDTO.DatetimeOfWriting = DateTime.Now;
                try
                {
                    db.Posts.Add(postDTO.FromDTO());
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        //public int GetIDOfNewestSubject()
        //{
        //    return db.Posts.OrderBy(s => s.DatetimeOfWriting).FirstOrDefault().SubjectID;
        //}

        //public SubjectDTO GetSubjectByID(int ID)
        //{
        //    return db.Subjects.
        //        Join(db.Stores, sub => sub.StoreID, st => st.StoreID,
        //           (sub, st) => new { sub, st })
        //           .Where(x => x.sub.SubjectID == ID)
        //           .Select(x => new SubjectDTO()
        //    {
        //        SubjectID = x.sub.SubjectID,
        //        SubjectName = x.sub.SubjectName,
        //        DatetimeOfWriting = x.sub.DatetimeOfWriting,
        //        IfWantUpdate = x.sub.IfWantUpdate,
        //        StoreName = x.st.StoreName,
        //        Content = x.sub.Content


        //           }).FirstOrDefault();
        //}



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
    




    
     
      

    




