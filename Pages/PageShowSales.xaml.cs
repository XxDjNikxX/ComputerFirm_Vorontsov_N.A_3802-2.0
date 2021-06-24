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
using LibraryDBComputers;

namespace ComputerFirm_Vorontsov_N.A_3802.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShowAll.xaml
    /// </summary>
    public partial class PageShowSales : Page
    {
        Sales MySales { get; set; }
        public PageShowSales()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGSales.Items.Refresh();
            DGSales.ItemsSource = DB.CompFirm.Sales.ToList();
            cbCustomers.ItemsSource = DB.CompFirm.Customer.ToList();
            cbProducts.ItemsSource = DB.CompFirm.Product.ToList();
            tbCount.Text = string.Empty;
            tbLogoText.Text = "Добавить Продажу";
            btnApply.Content = "Добавить";
            MySales = new Sales();
        }


        private void tbSum_Loaded(object sender, RoutedEventArgs e)
        {
            decimal sum = (decimal)DB.CompFirm.Sales.Sum(u => u.Price_Total);
            tbSum.Text = "Итого: " + sum.ToString() + " руб."; 
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = DGSales.SelectedItem as Sales;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + sales.idProduct + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) DB.CompFirm.Sales.Remove(sales);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MySales = DGSales.SelectedItem as Sales;
            tbLogoText.Text = "Изменить Продажу";
            btnApply.Content = "Изменить";

            DPSlaes.Text = MySales.Sale_Date.ToString();
            cbCustomers.SelectedItem = MySales.Customer as Customer;
            cbProducts.SelectedItem = MySales.Product as Product;
            tbCount.Text = MySales.Count.ToString();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            MySales.Customer = cbCustomers.SelectedItem as Customer;
            MySales.Product = cbProducts.SelectedItem as Product;
            MySales.Sale_Date = DPSlaes.DisplayDate;
            MySales.Count = int.Parse(tbCount.Text);

            if (!DB.CompFirm.Sales.Any(u => u.idSale == MySales.idSale) && !DB.CompFirm.Sales.Any(u => u.Sale_Date == MySales.Sale_Date))
            {
                DB.CompFirm.Sales.Add(MySales);
            }
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(sender, e);
        }
    }
}
