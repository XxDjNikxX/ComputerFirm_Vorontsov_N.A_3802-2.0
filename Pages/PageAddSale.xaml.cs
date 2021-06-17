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
    /// Логика взаимодействия для PageAddSale.xaml
    /// </summary>
    public partial class PageAddSale : Page
    {
        public PageAddSale()
        {
            InitializeComponent();
            cbCustomers.ItemsSource = DB.CompFirm.Customer.ToList();
            cbProducts.ItemsSource = DB.CompFirm.Product.ToList();

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales
            {
                Sale_Date = DPSlaes.DisplayDate,
                Customer = cbCustomers.SelectedItem as Customer,
                Product = cbProducts.SelectedItem as Product,
                Count = int.Parse(tbCount.Text),
            };

            DB.CompFirm.Sales.Add(sales);
            DB.CompFirm.SaveChanges();
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
