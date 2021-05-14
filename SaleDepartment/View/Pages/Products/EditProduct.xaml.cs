using Microsoft.Win32;
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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        private Helper.ProductHelper productHelper = new Helper.ProductHelper();
        public EditProduct()
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            this.DataContext = productHelper.NewProduct();
        }

        public EditProduct(FrameworkElement button)
        {
            InitializeComponent();
            this.DataContext = productHelper.GetProduct(button);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(Price.Text.Replace('.', ','), out decimal price))
                return;
            if (productHelper.SaveProduct())
                DeleteBtn.Visibility = Visibility.Visible;
        }

        private void NewImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Изображения | *.png; *.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new Uri(productHelper.NewImage(openFileDialog.FileName)));
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (productHelper.Delete())
                NavigationService.Navigate(new AllProduct());
        }
    }
}
