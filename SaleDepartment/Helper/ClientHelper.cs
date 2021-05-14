using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleDepartment.Helper
{
    class ClientHelper : ModelHelper
    {
        private Model.Client editClient;

        public Model.Client GetClient(FrameworkElement button)
        {

            editClient = (button.DataContext as Model.Client);
            return editClient;
        }

        public Model.Client NewClient()
        {
            editClient = new Model.Client();
            Context.Client.Add(editClient);
            return editClient;
        }


        public bool Delete()
        {
            if (MsgBoxHelper.ShowQuestion("Вы действительно хотите удалить этого клиента? С ним станет невозможно сделать новой звонок, но в существующих звонках он останется."))
            {
                editClient.IsActual = false;
                return TrySave();
            }
            return false;
        }

        public List<Model.Client> GetClients()
        {
            List<Model.Client> result;
            try
            {
                result = Context.Client.Where(i => i.IsActual).ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
                result = new List<Model.Client>();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                result = new List<Model.Client>();
            }
            return result;
        }

        public bool SaveClient()
        {
            try
            {
                System.Net.Mail.MailAddress E_mail = new System.Net.Mail.MailAddress(editClient.E_mail);
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
