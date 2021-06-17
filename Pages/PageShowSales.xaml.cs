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

        }


        private void tbSum_Loaded(object sender, RoutedEventArgs e)
        {
            decimal sum = 0m;
            for (int i = 0; i < DGSales.Items.Count - 1; i++)
            {
                sum += (decimal.Parse((DGSales.Columns[7].GetCellContent(DGSales.Items[i]) as TextBlock).Text));
            }
            tbSum.Text += sum.ToString() + " руб.";
        }

    }

}
