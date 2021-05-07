using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    class ModelHelper
    {
        public static Model.SaleDepartmentEntities Context;

        static ModelHelper()
        {
            Context = new Model.SaleDepartmentEntities();
        }

        public void RollBack()
        {
            Context?.Dispose();
            Context = new Model.SaleDepartmentEntities();
        }

        protected bool TrySave()
        {
            try
            {
                Context.SaveChanges();
                MsgBoxHelper.ShowInfo("Изменения успешны сохранены");
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
