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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private Helper.UserHelper userHelper = new Helper.UserHelper();
        private Helper.GenderHelper genderHelper = new Helper.GenderHelper();

        public RegistrationWindow()
        {
            InitializeComponent();
            InitializeComponent();
            GenderCmb.ItemsSource = genderHelper.GetGenders();
            this.DataContext = userHelper.NewUser();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Password.Password != PasswordSecond.Password)
            {
                Helper.MsgBoxHelper.ShowWarning("Пароли не совпадают");
                return;
            }
            if (userHelper.SaveUser(Password.Password))
            {
                new AuthWindow().Show();
                Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            new AuthWindow().Show();
            Close();
        }
    }
}
