using BLL.ModelDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IArticlesService
    {
        List<ArticlesDTO> GetArticles();
    }
   public class ArticlesService : IArticlesService
    {
        storesEntities DB;
        public List<ArticlesDTO> GetArticles()
        {
            try
            {
                using (DB = new storesEntities())
                {
                    var list= DB.Articles.Select(a => a).ToList<Article>();
                    List<ArticlesDTO> retval = new List<ArticlesDTO>();
                    foreach (var item in list)
                    {
                        retval.Add(new ArticlesDTO().ToDTO(item));
                    }
                    return retval;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
