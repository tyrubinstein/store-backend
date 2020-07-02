using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class PostDTO
    {
        public int PostID { get; set; }
        public int? StoreID { get; set; }
        public string ContentText { get; set; }
        public DateTime? DatetimeOfWriting { get; set; }
        public int SubjectID { get; set; }
        //new
        public int QtyOfVotes { get; set; }
        //new
        public bool IfWantUpdate { get; set; }

        public Post FromDTO()
        {
            Post post = new Post();
            post.ContentText = ContentText;
            post.StoreID = StoreID;
            post.DatetimeOfWriting =DatetimeOfWriting;
            post.IfWantUpdate = IfWantUpdate;
            post.numOfVotes = 0;
            post.SubjectID = SubjectID;
            return post;
        }
    }
}
