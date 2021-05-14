using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class UserHelper : ModelHelper
    {
        public static int UserId = 300;

        public bool Login(string e_mail, string password)
        {
            try
            {

                var user = Context.User.Where(i => i.E_mail == e_mail && i.Password == password && i.IsActual);
                if (user.Count() == 1)
                {
                    UserId = user.FirstOrDefault().Id;
                    return true;
                }
                MsgBoxHelper.ShowWarning("Не верные учетные данные.");
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
            }
            return false;
        }

        public Model.User GetUser()
        {
            return Context.User.FirstOrDefault(i => i.Id == UserId);
        }


        public bool SaveUser()
        {
            try
            {
                System.Net.Mail.MailAddress E_mail = new System.Net.Mail.MailAddress(Context.User.FirstOrDefault(i => i.Id == UserId).E_mail);
                return TrySave();

            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
            }
            return false;
        }


    }
}
