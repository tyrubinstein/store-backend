using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
  public  class BillsDTO
    {
        public int BillID { get; set; }
        public int StoreId { get; set; }
        public string BillPath { get; set; }
        public System.DateTime BilDate { get; set; }


       
    }
}
