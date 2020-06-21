using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class PostCTP
    {
        public int PostID { get; set; }
        public int StoreID { get; set; }
        public string ContentText { get; set; }
        public DateTime DatetimeOfWriting { get; set; }
        public int SubjectID { get; set; }
    }
}
