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
    /// Логика взаимодействия для PageShowTypeProducts.xaml
    /// </summary>
    public partial class PageShowTypeProducts : Page
    {
        public PageShowTypeProducts()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGProductsType.ItemsSource = DB.CompFirm.ProductType.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddTypeProduct());
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            ProductType productType = DGProductsType.SelectedItem as ProductType;
            DB.CompFirm.ProductType.Remove(productType);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
