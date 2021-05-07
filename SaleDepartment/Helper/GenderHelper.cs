using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class GenderHelper : ModelHelper
    {
        public List<Model.Gender> GetGenders()
        {
            List<Model.Gender> result;
            try
            {
                result = Context.Gender.ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
                result = new List<Model.Gender>();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                result = new List<Model.Gender>();
            }
            return result;
        }
    } 
}
