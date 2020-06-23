using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class AdvertismentDTO
    {
        public int AdvertisementID { get; set; }
        public string pictureURL { get; set; }
        public int KindID { get; set; }
        public int CompanyID { get; set; }
        public string DescribeAd { get; set; }        
    }
}
