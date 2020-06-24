using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.StoreDTO;

namespace BLL.Services
{
    public interface IRegisterService
    {
        bool AddStore(StoreDTO storeDTO);
        bool IsUserExist(Login login);


    }
    public class RegisterService : IRegisterService
    {
        private storesEntities db;

        public bool AddStore(StoreDTO storeDTO)
        {
            using (db = new storesEntities())
            {
                try
                {
                    db.Stores.Add(storeDTO.FromDTO());
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public bool IsUserExist(Login login)//אם יש כזה משתמש
        {
            using (db = new storesEntities())
            {
                try
                {
                    if (db.Stores.Where(s => s.Email == login.Email && s.PasswordUser == login.PasswordUser) != null)
                    {
                        return true;
                    }
                    
                }
                catch (Exception)
                {

                    throw;

                }
                return false;

            }

        }
        //public bool IsUserExist(Login login)//אם יש כזה משתמש אבל הסיסמא לא נכונה
        //{
        //    using (db = new storesEntities())
        //    {
        //        try
        //        {
        //            if()
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}
    }
}
