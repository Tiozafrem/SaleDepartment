using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaleDepartment.View.Pages.Calls
{
    /// <summary>
    /// Логика взаимодействия для EditCall.xaml
    /// </summary>
    public partial class EditCall : Page
    {
        private Helper.CallHelper callHelper = new Helper.CallHelper();
        private Helper.StatusCallHelper statusCallHelper = new Helper.StatusCallHelper();
        private Helper.ClientHelper clientHelper = new Helper.ClientHelper();
        private Helper.ProductHelper productHelper;
        public EditCall()
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            this.DataContext = callHelper.NewCall();
            productHelper = new Helper.ProductHelper();
            LoadCmb();
            LoadLsb();
        }

        private Model.Call test = new Model.Call();

        public EditCall(FrameworkElement button)
        {
            InitializeComponent();
            test = callHelper.GetCall(button);
            this.DataContext = callHelper.GetCall(button);
            productHelper = new Helper.ProductHelper(callHelper.GetCall(button));
            LoadCmb();
            LoadLsb();
        }
        private void LoadLsb()
        {

            AllProdcutLsb.ItemsSource = productHelper.GetProducts();
           // SelectedProductLsb.ItemsSource = productHelper.GetProducts();
            SelectedProductLsb.ItemsSource = test.CallProducts.ToList();
        }

        private void LoadCmb()
        {
            StatusCallCmb.ItemsSource = statusCallHelper.GetStatusCalls();
            PhoneCmb.ItemsSource = clientHelper.GetClients();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (callHelper.SaveClient())
                DeleteBtn.Visibility = Visibility.Visible;
        }

        private void Call(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Calls.EditCall());
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (callHelper.Delete())
                NavigationService.Navigate(new AllCall());
        }

        private void DeleteProduct(object sender, MouseButtonEventArgs e)
        {
            if (SelectedProductLsb.SelectedItem is Model.CallProduct product)
            {
                var te = Helper.ModelHelper.Context.Call.FirstOrDefault(i => i.Id == 3);
                te.CallProducts.Remove(te.CallProducts.FirstOrDefault(i => i.id == 3));
                //Helper.ModelHelper.Context.CallProduct.Remove(test.CallProducts.FirstOrDefault(i => i.id == product.id));
                //var hep =  test.CallProducts.Remove(product);
                //var tete = Helper.ModelHelper.Context.Product.Where(i => i.Id == product.ProductId).ToList().Remove(product.Products);
               // Helper.ModelHelper.Context.CallProduct.RemoveRange(Helper.ModelHelper.Context.CallProduct.Where(i => i.id >= 1000).ToList());
                
            }
            
            LoadLsb();
        }

        private void AddProduct(object sender, MouseButtonEventArgs e)
        {
            if (AllProdcutLsb.SelectedItem is Model.Product product)
            {
                test.CallProducts.Add(new Model.CallProduct() { ProductId = product.Id, Products = product, CallId = test.Id });
               // productHelper.Products.Add(product);
            }
            LoadLsb();
        }
    }
}
