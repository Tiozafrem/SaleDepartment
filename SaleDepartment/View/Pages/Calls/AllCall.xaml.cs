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

namespace SaleDepartment.View.Pages.Calls
{
    /// <summary>
    /// Логика взаимодействия для AllCall.xaml
    /// </summary>
    public partial class AllCall : Page
    {
        private Helper.CallHelper callHelper = new Helper.CallHelper();
        public AllCall()
        {
            InitializeComponent();
            CallDtg.ItemsSource = callHelper.GetCall();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditCall(sender as Button));
        }
    }
}
