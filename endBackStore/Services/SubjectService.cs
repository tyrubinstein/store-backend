using BLL;
using DALl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnetStore.Services
{
    public abstract class SubjectService
    {
        storesEntities context;
        public List<SubjectForListCTP> GetListOfSubjects()
        {

            try
            {
                //מחקתי הצהרת משתנה
                using (context = new storesEntities())
                {
                    return context.Subjects.
                   Join(context.Stores, sub => sub.StoreID, st => st.StoreID,
                   (sub, st) => new { sub, st })
                   .Select(m => new SubjectForListCTP
                   {
                       SubjectID = m.sub.SubjectID,
                       SubjectName = m.sub.SubjectName,
                       StoreName = m.st.StoreName
                   }).ToList<SubjectForListCTP>();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        private void LogException(Exception ex)
        {
            throw new NotImplementedException();
        }

    }
}

//public List<SubjectForListCTP> ListOfSubjects()
// {



