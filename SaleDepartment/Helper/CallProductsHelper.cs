using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SaleDepartment.Helper
{
    class CallProductsHelper : ModelHelper
    {
        private Model.Call editCall;
        public CallProductsHelper(CallHelper callHelper)
        {
            editCall = callHelper.GetEditCall();
        }

        public List<Model.CallProduct> GetCallProducts()
        {
            return editCall.CallProducts.ToList();
        }
        public bool RemoveCallProduct(object callProduct)
        {
            try
            {
                if (callProduct is Model.CallProduct editCallProduct)
                {
                    Context.CallProduct.Remove(editCallProduct);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
            }
            return false;

        }

        public bool AddCallProduct(object product)
        {
            try
            {
                if (product is Model.Product editProduct)
                {
                    editCall.CallProducts.Add(new Model.CallProduct() { Products = editProduct, ProductId = editProduct.Id, CallId = editCall.Id });
                    return true;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.ShowError(ex);
            }
            return false;
        }
    }
}
