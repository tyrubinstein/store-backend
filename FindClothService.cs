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
        List<StoreDTO> FindStores(SearcClothDTO search);

    }
    public class FindClothService : IFindClothApplicationService
    {
        private storesEntities db;

      

        public List<StoreDTO> FindStores(SearcClothDTO search)
        {
            StoreDTO SDTO = new StoreDTO();
            try
            {
                List<InventoryDTO> list = new List<InventoryDTO>();
                List<StoreDTO> retval = new List<StoreDTO>();
                int compID=0;
                int clothcod = 0;
                using (db = new storesEntities())
                {
                    var company = db.Companys.SingleOrDefault(comp => comp.CompanyName == search.CompanyName);
                    if (company != null)
                    {
                        compID = company.CompanyID;
                    }
                    var cloth = db.Clothes.SingleOrDefault(c => c.ClothCompaniCod == search.ClothCompaniCod && c.CompanyId == compID);
                    if (cloth != null)
                    {
                        clothcod = cloth.ClothID;
                    }
                    list = db.Inventories.Where(i => i.ClothID == clothcod).Select(inve => new InventoryDTO() { ClothID=inve.ClothID,StoreID=inve.StoreID, YearOfProductionOfBuying = inve.YearOfProductionOfBuying }).ToList<InventoryDTO>();
                    foreach (var item in list)
                    {
                        var record = db.Stores.Where(store => store.StoreID == item.StoreID).FirstOrDefault();
                        if (record != null)
                        {
                            retval.Add(SDTO.ToDTO(record));
                        }
                    }
                    return retval;
                }
                //using (db = new storesEntities())
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
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
