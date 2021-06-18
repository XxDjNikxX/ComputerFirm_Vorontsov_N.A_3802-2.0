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
using ClassLibraryDB;

namespace ComputerFirm_Vorontsov_N.A_3802.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShowCustomers.xaml
    /// </summary>
    public partial class PageShowCustomers : Page
    {
        public PageShowCustomers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddCustomer());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGCustomers.ItemsSource = DB.CompFirm.Customer.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = DGCustomers.SelectedItem as Customer;
            DB.CompFirm.Customer.Remove(customer);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
