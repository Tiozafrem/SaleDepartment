using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleDepartment.Helper
{
    class CallHelper : ModelHelper
    {
        private Model.Call editCall;
        public ProductHelper productHelper = new ProductHelper();

        public Model.Call GetCall(FrameworkElement button)
        {

            editCall = (button.DataContext as Model.Call);
            productHelper = new ProductHelper(editCall);
            return editCall;
        }

        public Model.Call NewCall()
        {
            editCall = new Model.Call();
            Context.Call.Add(editCall);
            return editCall;
        }

        public bool Delete()
        {
            if (MsgBoxHelper.ShowQuestion("Вы действительно хотите удалить этот звонок?"))
            {
                editCall.IsActual = false;
                return TrySave();
            }
            return false;
        }

        public bool SaveClient()
        {
                return TrySave();
            try
            {
                //editCall.CallProducts = productHelper.Products.ToList(); 

            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
            }
            return false;
        }



        public List<Model.Call> GetCall()
        {
            List<Model.Call> result;
            try
            {
                result = Context.Call.Where(i => i.IsActual).ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
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
