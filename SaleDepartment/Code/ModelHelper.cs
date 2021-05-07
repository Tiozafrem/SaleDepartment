using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Code
{
    class ModelHelper
    {
        public static Model.SaleDepartmentEntities Context;

        static ModelHelper()
        {
            Context = new Model.SaleDepartmentEntities();
        }

        protected static void RollBack()
        {
            Context?.Dispose();
            Context = new Model.SaleDepartmentEntities();
        }

        protected static bool TrySave()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных");
                return false;
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                return false;
            }
            return true;
        }
    }
}
