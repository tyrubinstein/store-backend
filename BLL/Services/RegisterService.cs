using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using static BLL.StoreDTO;

namespace BLL.Services
{
    public interface IRegisterService
    {
        int AddStore(StoreDTO storeDTO);

        string IsUserExist(Login login);
        bool ResetPassword(string Email);

    }
    public class RegisterService : IRegisterService
    {
        private storesEntities1 db;

        public int AddStore(StoreDTO storeDTO)
        {
            using (db = new storesEntities1())
            {
                try
                {
                    if (db.Stores.Where(w => w.Email == storeDTO.Email).FirstOrDefault() == null)
                    {
                        db.Stores.Add(storeDTO.FromDTO());
                        db.SaveChanges();
                        return db.Stores.Where(s => s.Email == storeDTO.Email && s.PasswordUser == storeDTO.PasswordUser).FirstOrDefault().StoreID;
                    }
                    return 0;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
        public string IsUserExist(Login login)//אם יש כזה משתמש
        {
            using (db = new storesEntities1())
            {
                try
                {

                    Store ss = db.Stores.Where(s => s.Email == login.Email).FirstOrDefault();
                    if (ss != null)
                    {
                        if (ss.PasswordUser == login.PasswordUser)
                            return "" + ss.StoreID;
                        else
                            return "no password";
                    }
                    else
                    {
                        return "no user";
                    }

                }
                catch (Exception)
                {

                    throw;

                }

            }

        }

        public bool ResetPassword(string email)
        {
            //הגרלת מספר חדש
            string NewPassword = Membership.GeneratePassword(6, 1);

            try
            {
                using (db = new storesEntities1())
                {
                    while (db.Stores.Where(ss => ss.PasswordUser == NewPassword).Count() != 0)
                    {

                        NewPassword = Membership.GeneratePassword(6, 1);
                    }

                    var result = db.Stores.SingleOrDefault(b => b.Email == email);
                    if (result != null)
                    {
                        result.PasswordUser = NewPassword;
                        db.SaveChanges();
                    }


                    string Id = "0504135201y@gmail.com";
                    string Password = "yr0556772748";

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Id, Password);
                    MailMessage m = new MailMessage(Id, email, "stores מהאתר ", "הסיסמא החדשה: " + NewPassword);
                    client.Send(m);
                    return true;
                }
            }
            catch (Exception e)
            {
                //  ResetPassword(email);
                throw e;
            }
        }


    }


}


