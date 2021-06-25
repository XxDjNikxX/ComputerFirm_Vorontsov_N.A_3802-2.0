using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для PageShowCustomers.xaml
    /// </summary>
    public partial class PageShowCustomers : Page
    {
        Customer MyCustomer { get; set; }
        public PageShowCustomers()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmptyStrings();
            DGCustomers.ItemsSource = DB.CompFirm.Customer.ToList();
            cbCity.ItemsSource = DB.CompFirm.City.ToList();
            tbLogoText.Text = "Добавить Покупателя";
            btnApply.Content = "Добавить";
            MyCustomer = new Customer();

        }

        private void EmptyStrings()
        {
            tbCustStreet.Text = String.Empty;
            tbCustTel.Text = String.Empty;
            tbFirstName.Text = String.Empty;
            tbSecondName.Text = String.Empty;
            tbPatherName.Text = String.Empty;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = DGCustomers.SelectedItem as Customer;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + customer.idCustomer + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes) DB.CompFirm.Customer.Remove(customer);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MyCustomer = DGCustomers.SelectedItem as Customer;
            tbLogoText.Text = "Изменить Покупателя";
            btnApply.Content = "Изменить";

            tbFirstName.Text = MyCustomer.FirstName;
            tbSecondName.Text = MyCustomer.SecondName;
            tbPatherName.Text = MyCustomer.PatherName;
            cbCity.SelectedItem = MyCustomer.City as City;
            tbCustStreet.Text = MyCustomer.CustStreet;
            tbCustTel.Text = MyCustomer.CustTelephone;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {

            if (CheckTextBoxes(sender, e))
            {
                MyCustomer.FirstName = tbFirstName.Text;
                MyCustomer.SecondName = tbSecondName.Text;
                MyCustomer.PatherName = tbSecondName.Text;
                MyCustomer.City = cbCity.SelectedItem as City;
                MyCustomer.CustStreet = tbCustStreet.Text;
                MyCustomer.CustTelephone = tbCustTel.Text;


                if (!DB.CompFirm.Customer.Any(u => u.idCustomer == MyCustomer.idCustomer))
                {
                    DB.CompFirm.Customer.Add(MyCustomer);

                }
                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }

        }

        private bool CheckTextBoxes(object sender, RoutedEventArgs e)
        {
            bool apply = true;
            char[] chars = { '-', '@', '/', '_', '%', '{', '}', '=', '-', '+', '|' };

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
                    Page_Loaded(sender, e); apply = false; break;
                }
                else if (double.TryParse(el.Text, out double res) && el.Name != "tbCustTel")
                {
                    MessageBox.Show("Внимание, введено число!"); apply = false; break;
                }

                if (el.Text.All(Char.IsLetter) && el.Name == "tbCustTel")
                {
                    MessageBox.Show("Введены буквы, вместо чисел!");
                    Page_Loaded(sender, e); apply = false; break;

                }
                foreach (var ch in chars)
                {
                    if (el.Text.Contains(ch))
                    {
                        MessageBox.Show("Введены символы, вместо чисел!");
                        Page_Loaded(sender, e); apply = false; break;
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

