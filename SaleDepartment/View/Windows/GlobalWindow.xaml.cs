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
using System.Windows.Shapes;

namespace SaleDepartment.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для GlobalWindow.xaml
    /// </summary>
    public partial class GlobalWindow : Window
    {
        Helper.ModelHelper modelHelper = new Helper.ModelHelper();

        public GlobalWindow()
        {
            InitializeComponent();
        }

        private void NewClient(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Clients.EditClient());
        }

        private void AllClient(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Clients.AllClient());
        }

        private void NewProduct(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Products.EditProduct());

        }

        private void Allproduct(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Products.AllProduct());
        }

        private void NewCall(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Calls.EditCall());
        }

        private void AllCall(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Calls.AllCall());
        }

        private void AllMyCall(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Calls.AllCall());
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MyCab(object sender, RoutedEventArgs e)
        {
            modelHelper.RollBack();
            contentFrame.Navigate(new Pages.Users.CabPage());
        }
    }
}
