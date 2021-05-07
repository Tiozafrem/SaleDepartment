using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class CallHelper : ModelHelper
    {
        public List<Model.Call> GetCall()
        {
            List<Model.Call> result;
            try
            {
                result = Context.Call.Where(i => i.IsActual).ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных");
                result = new List<Model.Call>();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                result = new List<Model.Call>();
            }
            return result;
        }

    }
}
