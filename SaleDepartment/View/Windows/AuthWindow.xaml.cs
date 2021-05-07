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
        public string E_mail { get; set; }
        public string Password { get; set; }
        private Code.UserHelper userHelper = new Code.UserHelper();

        public AuthWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (userHelper.Login(E_mail, Password))
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
    }
}
