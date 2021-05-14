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
        private Helper.CallProductsHelper callProductsHelper;
        public EditCall()
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            this.DataContext = callHelper.NewCall();
            productHelper = new Helper.ProductHelper();
            LoadData();
        }

        private Model.Call test = new Model.Call();

        public EditCall(FrameworkElement button)
        {
            InitializeComponent();
            test = callHelper.GetCall(button);
            this.DataContext = callHelper.GetCall(button);
            productHelper = new Helper.ProductHelper(callHelper.GetCall(button));
            LoadData();
        }

        private void LoadData()
        {
            callProductsHelper = new Helper.CallProductsHelper(callHelper);
            LoadCmb();
            LoadLsb();
        }
        private void LoadLsb()
        {

            AllProdcutLsb.ItemsSource = productHelper.GetProducts();
            SelectedProductLsb.ItemsSource = callProductsHelper.GetCallProducts();
        }

        private void LoadCmb()
        {
            StatusCallCmb.ItemsSource = statusCallHelper.GetStatusCalls();
            PhoneCmb.ItemsSource = clientHelper.GetClients();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (callHelper.SaveCall())
                DeleteBtn.Visibility = Visibility.Visible;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (callHelper.Delete())
                NavigationService.Navigate(new AllCall());
        }

        private void DeleteProduct(object sender, MouseButtonEventArgs e)
        {
            callProductsHelper.RemoveCallProduct(SelectedProductLsb.SelectedItem);        
            LoadLsb();
        }

        private void AddProduct(object sender, MouseButtonEventArgs e)
        {
            callProductsHelper.AddCallProduct(AllProdcutLsb.SelectedItem);
            LoadLsb();
        }
    }
}
