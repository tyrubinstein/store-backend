using BLL;
using BLL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using static BLL.StoreDTO;

namespace ASPnetStore.Services
{

    public interface IClothService
    {
        List<ClothDTO> GetListOfClothByIdCompany(int IdOfCompany);
        List<ClothDTO> GetListOfClothByIdCompanyAndDateRangeAndSeason(int IdOfCompany,int year,int season);
        bool AddCloth(ClothDTO clothDTO);
        bool DeleteCloth(ClothDTO clothId);
        bool UpdateCloth(ClothDTO clothId);


    }

    public class ClothService : IClothService
    {
        storesEntities db;

        public List<ClothDTO> GetListOfClothByIdCompany(int IdOfCompany)
        {
            using(db=new storesEntities())
            try
            {               //מחקתי הצהרת משתנה    
                            //Subject l = db.Subjects.Last();
                return db.Clothes.
                  Where(c => c.CompanyId == IdOfCompany)
               .Select(c => new ClothDTO
               {
                   ClothID = c.ClothID,
                   ClothCompaniCod = c.ClothCompaniCod,
                   Describe = c.Describe,
                   Color = c.Color,
                   YearOfProduction = c.yearOfProduction,
                   SeasonId = c.SeasonsID
               }).ToList();
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
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

        public bool AddCloth(ClothDTO clothDTO)
        {
            using (db = new storesEntities())
            {
                
                try
                {
                    db.Clothes.Add(clothDTO.FromDTO(clothDTO));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public bool DeleteCloth(ClothDTO clothId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCloth(ClothDTO clothId)
        {
            throw new NotImplementedException();
        }

        public List<ClothDTO> GetListOfClothByIdCompanyYearAndSeason(int CompanyId, int year, int seasonId)
        {
            List<ClothDTO> lcdto = new List<ClothDTO>();
            lcdto = GetListOfClothByIdCompany(CompanyId);
           
            if (year != 0)
            {
                lcdto = lcdto.Where(x => x.YearOfProduction == year).ToList<ClothDTO>();

            }

            if (seasonId != 5)
            {
                lcdto = lcdto.Where(x => x.SeasonId == seasonId).ToList<ClothDTO>();

            }
            return lcdto;
        }

        public List<ClothDTO> GetListOfClothByIdCompanyAndDateRangeAndSeason(int IdOfCompany, int year, int season)
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
    




    
     
      

    




