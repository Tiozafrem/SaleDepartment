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

namespace SaleDepartment.View.Pages.Clients
{
    /// <summary>
    /// Логика взаимодействия для AllClient.xaml
    /// </summary>
    public partial class AllClient : Page
    {
        private Helper.ClientHelper clientHelper = new Helper.ClientHelper();
        public AllClient()
        {
            InitializeComponent();
            ClientDtg.ItemsSource = clientHelper.GetClients();
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditClient(sender as Button));
        }
    }
}
