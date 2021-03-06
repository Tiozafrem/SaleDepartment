using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleDepartment.Helper
{
    class ProductHelper : ModelHelper
    {
        private Model.Product editProduct;
        public ObservableCollection<Model.Product> Products { get; set; }

        public ProductHelper()
        {
            Products = new ObservableCollection<Model.Product>();
        }
        public ProductHelper(Model.Call editCall)
        {
            Products = new ObservableCollection<Model.Product>(editCall.CallProducts.Select(i => i.Products).ToList());
        }
        public List<Model.Product> GetProducts()
        {
            List<Model.Product> result;
            try
            {
                result = Context.Product.Where(i => i.IsActual).ToList();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MsgBoxHelper.ShowError("Ошибка подклюения к базе данных.");
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

            editProduct = (button.DataContext as Model.Product);
            return editProduct;
        }

        public Model.Product NewProduct()
        {
            editProduct = new Model.Product();
            Context.Product.Add(editProduct);
            return editProduct;
        }

        public string NewImage(string fileName)
        {
            editProduct.Image = File.ReadAllBytes(fileName);
            return fileName;
        }

        public bool Delete()
        {
            if (MsgBoxHelper.ShowQuestion("Вы действительно хотите удалить этот продукт? С ним станет невозможно сделать новой заказ, но в существующих заказах он останется."))
            {
                editProduct.IsActual = false;
                return TrySave();
            }
            return false;
        }

        public bool SaveProduct()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (String.IsNullOrWhiteSpace(editProduct.Name))
                stringBuilder.AppendLine("Необходимо заполнить имя товара.");
            if (editProduct.Price < 1 || editProduct.Price > 99999999)
                stringBuilder.AppendLine("Введите корректное число.");
            if (stringBuilder.Length > 0)
            {
                MsgBoxHelper.ShowWarning(stringBuilder.ToString());
                return false;
            }
            return TrySave();
        }
    }
}
