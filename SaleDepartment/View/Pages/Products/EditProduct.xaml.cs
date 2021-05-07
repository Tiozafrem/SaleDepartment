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
        }

        public EditProduct(FrameworkElement button)
        {
            this.DataContext = productHelper.GetProduct(button);
        }
    }
}
