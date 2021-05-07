using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleDepartment.Helper
{
    class ProductHelper : ModelHelper 
    {
        public List<Model.Product> GetProducts()
        {
            List<Model.Product> result;
            try
            {
                result = Context.Product.Where(i => i.IsActual).ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных");
                result = new List<Model.Product>();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
                result = new List<Model.Product>();
            }
            return result;
        }

        public Model.Product GetProduct(FrameworkElement button)
        {
            return (button.DataContext as Model.Product);
        }
    }
}
