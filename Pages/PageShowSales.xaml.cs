using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    /// Логика взаимодействия для PageShowAll.xaml
    /// </summary>
    public partial class PageShowSales : Page
    {
        public PageShowSales()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGSales.ItemsSource = DB.CompFirm.Sales.ToList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddSale());
        }

        private void tbSum_Loaded(object sender, RoutedEventArgs e)
        {
            decimal sum = (decimal)DB.CompFirm.Sales.Sum(u => u.Price_Total);
            tbSum.Text = "Итого: " + sum.ToString() + " руб."; 
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = DGSales.SelectedItem as Sales;
            DB.CompFirm.Sales.Remove(sales);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
