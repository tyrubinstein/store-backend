using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
   public class ArticlesDTO
    {
        public int Id { get; set; }
        public string ImportantText { get; set; }
        public string sideText { get; set; }
        public string ArticlesPath { get; set; }
        public ArticlesDTO ToDTO(Article item)
        {
            return new ArticlesDTO()
            {
                ArticlesPath = item.ArticlesPath,
                Id = item.Id,
                ImportantText = item.ImportantText,
                sideText = item.sideText
            };
        }
    }
}
