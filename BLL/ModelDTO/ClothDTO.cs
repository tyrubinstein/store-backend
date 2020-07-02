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
        public int YearOfProduction { get; set; }
        public string Describe { get; set; }
        public string pictureURL { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
  public  class SearcClothDTO
    {
        public string Describe { get; set; }
        public string Color { get; set; }
        public string CompanyName { get; set; }
        public int ClothId { get; set; }
        public string Size { get; set; }
    }
}