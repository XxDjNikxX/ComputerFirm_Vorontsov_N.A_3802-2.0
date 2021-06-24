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
            EmptyStrings();

            MyProduct = new Product();

            tbLogoText.Text = "Добавить Продукт";
            btnApply.Content = "Добавить";
        }

        private void EmptyStrings()
        {
            tbProductName.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbDiscount.Text = string.Empty;
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
            MyProduct = DGProducts.SelectedItem as Product;
            tbLogoText.Text = "Изменить Продукт";
            btnApply.Content = "Изменить";

            cbTypeProduct.SelectedItem = MyProduct.ProductType as ProductType;
            tbProductName.Text = MyProduct.ProductName;
            tbPrice.Text = Convert.ToString(MyProduct.Price);
            tbDiscount.Text = Convert.ToString(MyProduct.Discount * 100);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
           
            if (CheckTextBoxes(sender,e))
            {
                MyProduct.ProductType = cbTypeProduct.SelectedItem as ProductType;
                MyProduct.ProductName = tbProductName.Text;
                MyProduct.Price = Decimal.Parse(tbPrice.Text);
                MyProduct.Discount = Double.Parse(tbDiscount.Text) / 100;

                if (!DB.CompFirm.Product.Any(u => u.idProduct == MyProduct.idProduct))
                {
                    DB.CompFirm.Product.Add(MyProduct);
                }

                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }
        }

        private bool CheckTextBoxes(object sender, RoutedEventArgs e)
        {
            bool apply = true;
            char[] chars = { '-', '@', '/', '_', '%','{','}','=','-','+','|' };
            List<TextBox> TbList = new List<TextBox>();

            foreach (var tb in MainPanel.Children)
            {
                if (tb is TextBox)
                {
                    TbList.Add((TextBox)tb);
                }
            }

            foreach (var el in TbList)
            {
                if (string.IsNullOrEmpty(el.Text))
                {
                    MessageBox.Show("Внимание, введена пустая строка!");
                    Page_Loaded(sender, e); apply = false;
                    break;
                }
                else if (double.TryParse(el.Text, out double res) && el.Name == "tbProductName")
                {
                    MessageBox.Show("Внимание, введено число!");
                    Page_Loaded(sender, e); apply = false;
                    break;
                }
                foreach (var ch in chars)
                {
                    if (el.Text.Contains(ch))
                    {
                        MessageBox.Show("Введены символы, вместо чисел!");
                        Page_Loaded(sender, e); apply = false;
                        break;
                    }
                }
                if (el.Text.All(Char.IsLetter) && (el.Name == "tbDiscount" || el.Name == "tbPrice"))
                {
                    MessageBox.Show("Введены буквы, вместо чисел!");
                    Page_Loaded(sender, e); apply = false;
                    break;
                }
            }
            return apply;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(sender, e);
        }
    }
}
