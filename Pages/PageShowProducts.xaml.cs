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
    /// Логика взаимодействия для PageShowProducts.xaml
    /// </summary>
    public partial class PageShowProducts : Page
    {
        Product MyProduct { get; set; }
        public PageShowProducts()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGProducts.ItemsSource = DB.CompFirm.Product.ToList();
            cbTypeProduct.ItemsSource = DB.CompFirm.ProductType.ToList();
            tbProductName.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbDiscount.Text = string.Empty;

            MyProduct = new Product();

            tbLogoText.Text = "Добавить Продукт";
            btnApply.Content = "Добавить";
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Product product = DGProducts.SelectedItem as Product;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + product.idProduct + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) DB.CompFirm.Product.Remove(product);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Product product = DGProducts.SelectedItem as Product;
            tbLogoText.Text = "Изменить Продукт";
            btnApply.Content = "Изменить";

            cbTypeProduct.SelectedItem = MyProduct.ProductType as ProductType;
            tbProductName.Text = MyProduct.ProductName;
            tbPrice.Text = MyProduct.Price.ToString() ;
            tbDiscount.Text = (MyProduct.Discount*100).ToString();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            MyProduct.ProductType = cbTypeProduct.SelectedItem as ProductType;
            MyProduct.ProductName = tbProductName.Text;
            MyProduct.Price = Decimal.Parse(tbPrice.Text);
            MyProduct.Discount = Double.Parse(tbDiscount.Text) / 100;

            if (!DB.CompFirm.Product.Any(u => u.idProduct == MyProduct.idProduct) && !DB.CompFirm.Product.Any(u => u.ProductName == MyProduct.ProductName))
            {
                DB.CompFirm.Product.Add(MyProduct);
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
