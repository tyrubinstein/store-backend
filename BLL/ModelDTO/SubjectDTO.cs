using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubjectDTO
    {//האם לעשות עוד מחלקה או לא והאם להשאיר את השם חנות או לא?
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string StoreName { get; set; }
        public DateTime? DatetimeOfWriting { get; set; }
        public bool? IfWantUpdate { get; set; }


        public Subject FromDTO()
        {
            Subject subject = new Subject();
            subject.SubjectID = SubjectID;
            subject.SubjectName = SubjectName;
            subject.DatetimeOfWriting = DatetimeOfWriting;
            subject.IfWantUpdate = IfWantUpdate;
            return subject;

        }
    }

    public class SubjectForListDTO
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string StoreName { get; set; }


    }

}
