using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ClothDTO
    {
        public int ClothID { get; set; }
        public int ClothCompaniCod { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> YearOfProduction { get; set; }
        public string Describe { get; set; }
        public string pictureURL { get; set; }
        public string Color { get; set; }
        public Nullable<int> Price { get; set; }
        public string CompanyName { get; set; }
        public string SizesRange { get; set; }


        public ClothDTO ToDTO(Cloth item)
        {
            return new ClothDTO()
            {
                ClothCompaniCod = item.ClothCompaniCod,
                ClothID = item.ClothID,
                Color = item.Color,
                CompanyId = item.CompanyId,
                Describe = item.Describe,
                pictureURL = item.pictureURL,
                Price = item.Price,
                YearOfProduction = item.YearOfProduction,
                SizesRange = item.SizesRange
            };
        }
    }
  public  class SearcClothDTO
    {
        public string Describe { get; set; }
        public string Color { get; set; }
        public string CompanyName { get; set; }
        public int ClothCompaniCod { get; set; }
        public string Size { get; set; }
    }
}