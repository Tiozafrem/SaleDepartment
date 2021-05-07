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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Page
    {
        private Helper.ClientHelper clientHelper = new Helper.ClientHelper();
        private Helper.GenderHelper genderHelper = new Helper.GenderHelper();
        public EditClient()
        {
            InitializeComponent();
            DeleteBtn.Visibility = Visibility.Collapsed;
            LoadGender();
            this.DataContext = clientHelper.NewClient();
        }

        public EditClient(FrameworkElement button)
        {
            InitializeComponent();
            LoadGender();
            this.DataContext = clientHelper.GetClient(button);
        }

        public void LoadGender()
        {
            GenderCmb.ItemsSource = genderHelper.GetGenders();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (clientHelper.SaveClient())
                DeleteBtn.Visibility = Visibility.Visible;
        }

        private void Call(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Calls.EditCall());
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (clientHelper.Delete())
                NavigationService.Navigate(new AllClient());
        }

    }
}
