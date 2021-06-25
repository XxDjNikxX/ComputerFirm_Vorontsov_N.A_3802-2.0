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
    /// Логика взаимодействия для PageShowTypeProducts.xaml
    /// </summary>
    public partial class PageShowTypeProducts : Page
    {
        ProductType MyProductType { get; set; }
        public PageShowTypeProducts()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGProductsType.ItemsSource = DB.CompFirm.ProductType.ToList();
            tbTypeProductName.Text = string.Empty;
            tbLogoNameText.Text = "Добавить тип продукта";
            btnApply.Content = "Добавить";
            MyProductType = new ProductType();
        }


        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            ProductType productType = DGProductsType.SelectedItem as ProductType;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + productType.idProductType + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) DB.CompFirm.ProductType.Remove(productType);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MyProductType = DGProductsType.SelectedItem as ProductType;
            tbTypeProductName.Text = MyProductType.ProductTypeName;
            tbLogoNameText.Text = "Изменить тип продукта";
            btnApply.Content = "Изменить";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
           if(CheckTextBoxes(sender,e))
            { 
                MyProductType.ProductTypeName = tbTypeProductName.Text;
                if (!DB.CompFirm.ProductType.Any(u => u.idProductType == MyProductType.idProductType) && !DB.CompFirm.ProductType.Any(u => u.ProductTypeName == MyProductType.ProductTypeName))
                {
                    DB.CompFirm.ProductType.Add(MyProductType);
                }
                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }
        }
        private bool CheckTextBoxes(object sender, RoutedEventArgs e)
        {
            bool apply = true;
            char[] chars = { '@', '%', '{', '}', '=', '-', '+', '|','&' };
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
                else if (double.TryParse(el.Text, out double res))
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
            }
            return apply;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(sender, e);
        }
    }
}
