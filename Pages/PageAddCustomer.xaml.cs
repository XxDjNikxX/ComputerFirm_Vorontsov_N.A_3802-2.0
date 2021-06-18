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
    /// Логика взаимодействия для PageAddCustomer.xaml
    /// </summary>
    public partial class PageAddCustomer : Page
    {
        public PageAddCustomer()
        {
            InitializeComponent();
            cbCity.ItemsSource = DB.CompFirm.City.ToList();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer()
            {
                FirstName = tbFirstName.Text,
                SecondName = tbSecondName.Text,
                PatherName = tbPatherName.Text,
                City = cbCity.SelectedItem as City,
                CustStreet = tbCustStreet.Text,
                CustTelephone = tbCustTel.Text
            };
            DB.CompFirm.Customer.Add(customer);
            DB.CompFirm.SaveChanges();
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
