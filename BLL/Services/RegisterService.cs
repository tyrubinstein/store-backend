using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegisterService
    {
        public bool AddStore(StoreDTO storeDTO)
        {
            using (storesEntities db = new storesEntities())
            {
                try
                {
                db.Stores.Add(storeDTO.FromDTO());
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
            
    }
}
