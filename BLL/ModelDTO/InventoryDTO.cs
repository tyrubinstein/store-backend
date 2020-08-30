using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class InventoryDTO
    {
        public int StoreID { get; set; }
        public int ClothID { get; set; }
        public int YearOfProduction { get; set; }
        public InventoryDTO ToDTO(DAL.Inventory i)
        {
            return new InventoryDTO() { ClothID=i.ClothID,StoreID=i.StoreID ,YearOfProduction=i.YearOfProduction};

        }
        public DAL.Inventory FromDTO(InventoryDTO item)
        {
            return new DAL.Inventory()
            {
                ClothID=item.ClothID,StoreID=item.StoreID,YearOfProduction=item.YearOfProduction

            };
        }
    }
}
