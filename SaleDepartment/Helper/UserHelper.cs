using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class UserHelper: ModelHelper
    {
        ModelHelper modelHelper = new ModelHelper();

        public static Model.User User;

        public bool Login(string e_mail, string password)
        {
            var user = Context.User.Where(i => i.E_mail == e_mail && i.Password == password && i.IsActual);
            if (user.Count() == 1)
            {
                User = user.FirstOrDefault();
                return true;
            }
            MsgBoxHelper.ShowWarning("Ошибка входа");
            return false;
        }
        
    }
}
