using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class StatusCallHelper : ModelHelper
    {

        public List<Model.StatusCall> GetStatusCalls()
        {
            List<Model.StatusCall> result;
            try
            {
                result = Context.StatusCall.ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
                result = new List<Model.StatusCall>();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                result = new List<Model.StatusCall>();
            }
            return result;
        }

    }
}
