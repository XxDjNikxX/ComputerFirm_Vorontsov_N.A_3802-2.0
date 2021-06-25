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
using LibraryDBComputers;

namespace ComputerFirm_Vorontsov_N.A_3802.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShowGrids.xaml
    /// </summary>
    public partial class PageShowGrids : Page
    {
        Auth MyAuth { get; set; }
        public PageShowGrids(Auth auth)
        {
            InitializeComponent();
            MyAuth = auth;

            if (auth.idRole == 2) AdminPanel.Visibility = Visibility.Visible;
            else AdminPanel.Visibility = Visibility.Hidden;
        }

        private void btnShowCity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowCity());
        }

        private void btnShowCustomer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowCustomers());

        }

        private void btnShowSales_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowSales());

        }

        private void btnShowProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowProducts());

        }

        private void btnShowProductType_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowTypeProducts());
        }

        private void btnUsersShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowUsers());

        }

        private void btnRolesShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageShowRoles());
        }
    }
}
