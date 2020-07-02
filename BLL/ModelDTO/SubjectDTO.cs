using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
<<<<<<< HEAD
=======
   

>>>>>>> 460782425c22da6b7115d0778f13555c5cb3b184
    public class SubjectDTO
    {//האם לעשות עוד מחלקה או לא והאם להשאיר את השם חנות או לא?
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int? StoreID { get; set; }
        public DateTime? DatetimeOfWriting { get; set; }
        public bool? IfWantUpdate { get; set; }
<<<<<<< HEAD


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

=======
        public string Content { get; set; }
        //new
        public DateTime? GotLastAnswer { get; set; }

        public Subject FromDTO()
        {
            Subject subject = new Subject();
            subject.SubjectID = SubjectID;
            subject.SubjectName = SubjectName;
            subject.DatetimeOfWriting = DatetimeOfWriting;
            subject.IfWantUpdate = IfWantUpdate;
            subject.Content = Content;
            subject.StoreID = StoreID;
            return subject;
        }
        
        //לרשימת נושאים
        public class SubjectForListDTO
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }
            public string StoreName { get; set; }
>>>>>>> 460782425c22da6b7115d0778f13555c5cb3b184

        }
    }

}
