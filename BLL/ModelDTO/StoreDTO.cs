using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreDTO
    {
      //  public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ManagerName { get; set; }
        public string Cell { get; set; }
        public string cellOftheStore { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
      

        public Store FromDTO()
        {
            Store store = new Store();
            store.Address = Address;
            store.Cell = Cell;
            store.cellOftheStore = cellOftheStore;
            store.City = City;
            store.Email = Email;
            store.PasswordUser = PasswordUser;
            store.StoreName = StoreName;
            store.ManagerName = ManagerName;

                   return store;
        }

    }


}
