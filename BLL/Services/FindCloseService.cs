using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IFindClothApplicationService
    {
        List<StoreDTO> Find(SearcClothDTO search);

    }
   public class FindCloseService: IFindClothApplicationService
    {
        private storesEntities1 db;
        public List<StoreDTO> Find(SearcClothDTO search)
        {
            StoreDTO SDTO=new StoreDTO();
            try
            {
                //using (db = new storesEntities1())
                //{
                //    int ComId = db.Companys.Where(com => com.CompanyName == search.CompanyName).First().CompanyID;//קוד החברה
                //                                                                                                  //קוד הבגד הרצוי
                //    int ClothId = db.Clothes.Where(c => c.Describe == search.Describe && c.Color == search.Color && c.ClothID == search.ClothId && c.CompanyId == ComId).First().ClothID;

                //    List<int> AllStoresId = db.InventoryCloth.Where(inv => inv.ClothId == ClothId).ToList<int>();//הקודים של כל החנויות שיש להם את הבגד
                //    List<Store> AllStores = db.Stores.Where(s => AllStoresId.Where(f => f == s.StoreID).Count() != 0).ToList<Store>();//כל החנויות שיש להם את הבגד
                //    List<StoreDTO> RetList=new List<StoreDTO>();
                //    foreach (Store ss in AllStores)
                //    {
                //        RetList.Add(SDTO.ToDTO(ss));
                //    }
                //    return RetList;
                //}
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
