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

namespace SaleDepartment.View.Pages.Products
{
    /// <summary>
    /// Логика взаимодействия для AllProduct.xaml
    /// </summary>
    public partial class AllProduct : Page
    {
        private Helper.ProductHelper productHelper;
        public AllProduct()
        {
            InitializeComponent();
            productHelper = new Helper.ProductHelper();
            ProductDtg.ItemsSource = productHelper.GetProducts();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProduct(sender as Button));
        }
    }
}
