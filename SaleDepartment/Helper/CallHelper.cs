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
            editCall = new Model.Call() { Users = Context.User.FirstOrDefault(i => i.Id == UserHelper.UserId)};
            Context.Call.Add(editCall);
            return editCall;
        }

        public Model.Call GetEditCall()
        {
            if (editCall == null)
                editCall = new Model.Call();
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

        public bool SaveCall()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (editCall.StatusCalls == null || editCall.Clients == null)
                {
                    stringBuilder.AppendLine("Выберите пункты из списка");
                }
                if (editCall.Duration < 1 && editCall.Duration != null)
                {
                    stringBuilder.AppendLine("Продолжительность звонка не может быть меньше 1 секунды.");
                }
                if(stringBuilder.Length > 0)
                {
                    MsgBoxHelper.ShowWarning(stringBuilder.ToString());
                    return false;
                }
                return TrySave();
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
