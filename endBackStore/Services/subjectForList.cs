using ASPnetStore.Services;
using BLL;
using DALl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace endBackStore.Services
{
    public class subjectForList
    {
        storesEntities context;



    
        public SubjectCTP GetSubjectByID(int ID)
        {
            return context.Subjects.
                Join(context.Stores, sub => sub.StoreID, st => st.StoreID,
                   (sub, st) => new { sub, st }).
                  
                   Where(x => x.sub.SubjectID == ID)

                   .Select(s => new SubjectCTP
                   {
                       SubjectID = s.sub.SubjectID,
                       SubjectName = s.sub.SubjectName,
                       StoreName = s.st.StoreName,
                       DatetimeOfWriting=s.sub.DatetimeOfWriting,
                       IfWantUpdate=s.sub.IfWantUpdate

                   }).FirstOrDefault();
           }
        //public bool AddSubject(SubjectCTP s)
        //{//איך לעשות את הטבלה המעבירה? עם השם חנות או הקוד חנות?
        //    try
        //    {
        //        using (context = new storesEntities())
        //            {
        //            context.Subjects.Add(s);
        //            context.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;

        //    }
          
        //} 

        private void LogException(Exception ex)
        {
            throw new NotImplementedException("bbvbvbvbvbv");
        }
    }
}