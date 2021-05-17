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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private Helper.UserHelper userHelper = new Helper.UserHelper();

        public AuthWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (userHelper.Login(E_mail.Text, Password.Password))
            {
                GlobalWindow globalWindow = new GlobalWindow();
                globalWindow.Show();
                this.Close();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NewUser(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
