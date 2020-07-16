using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPrivateArea
    {
        StoreDTO GetUserById(int id);
        bool UpdateDetails(StoreDTO store);
    }
    public class PrivateAreaService : IPrivateArea
    {
        StoreDTO st = new StoreDTO();
        private storesEntities1 db;
        public StoreDTO GetUserById(int id)
        {

            using (db = new storesEntities1())
            {
                return st.ToDTO(db.Stores.Where(s => s.StoreID == id).FirstOrDefault());
            }
        }

        public bool UpdateDetails(StoreDTO store)
        {
            try
            {
                using (db = new storesEntities1())
                {
                    //  Store sst = db.Stores.Where(ss => ss.StoreID == store.StoreID).FirstOrDefault();
                    var result = db.Stores.SingleOrDefault(b => b.StoreID == store.StoreID);
                    if (result != null && !result.Equals(store))
                    {
                        Store check = db.Stores.Where(w => w.Email == store.Email).FirstOrDefault();
                        if (check.StoreID == store.StoreID)
                        {
                            result.Cell = store.Cell;
                            result.cellOftheStore = store.cellOftheStore;
                            result.Address = store.Address;
                            result.Email = store.Email;
                            result.City = store.City;
                            result.PasswordUser = store.PasswordUser;
                            result.ManagerName = store.ManagerName;
                            result.StoreName = store.StoreName;
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }



                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;

        }
    }
}
