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

namespace SaleDepartment.View.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для CabPage.xaml
    /// </summary>
    public partial class CabPage : Page
    {
        private Helper.UserHelper userHelper = new Helper.UserHelper();
        private Helper.GenderHelper genderHelper = new Helper.GenderHelper();
        

        public CabPage()
        {
            InitializeComponent();
            GenderCmb.ItemsSource = genderHelper.GetGenders();
            this.DataContext = userHelper.GetUser();

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            userHelper.SaveUser();
        }

    }
}
