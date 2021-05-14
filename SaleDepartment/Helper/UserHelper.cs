using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Model.User user = Context.User.FirstOrDefault(i => i.Id == UserId);
                StringBuilder stringBuilder = new StringBuilder();
                if (user.Genders == null || String.IsNullOrWhiteSpace(user.E_mail) || String.IsNullOrWhiteSpace(user.Firstname) || String.IsNullOrWhiteSpace(user.Lastname) || String.IsNullOrWhiteSpace(user.Phone))
                {
                    stringBuilder.AppendLine("Необходимо заполнить все поля.");
                }
                stringBuilder.Append(PhoneHelper.CheckPhone(user.Phone));
                if (stringBuilder.Length > 0)
                {
                    MsgBoxHelper.ShowWarning(stringBuilder.ToString());
                    return false;
                }
                System.Net.Mail.MailAddress E_mail = new System.Net.Mail.MailAddress(user.E_mail);
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
