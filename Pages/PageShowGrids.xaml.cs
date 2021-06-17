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

namespace ComputerFirm_Vorontsov_N.A_3802.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShowGrids.xaml
    /// </summary>
    public partial class PageShowGrids : Page
    {
        public PageShowGrids()
        {
            InitializeComponent();
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
