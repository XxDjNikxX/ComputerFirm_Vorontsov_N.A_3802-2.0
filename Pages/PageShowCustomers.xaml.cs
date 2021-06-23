﻿using System;
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

            DGCustomers.ItemsSource = DB.CompFirm.Customer.ToList();
            cbCity.ItemsSource = DB.CompFirm.City.ToList();
            tbCustStreet.Text = String.Empty;
            tbCustTel.Text = String.Empty;
            tbFirstName.Text = String.Empty;
            tbSecondName.Text = String.Empty;
            tbPatherName.Text = String.Empty;

            tbLogoText.Text = "Добавить Покупателя";
            btnApply.Content = "Добавить";
            MyCustomer = new Customer();
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
            if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbSecondName.Text) || cbCity.SelectedItem == null)
            {
                MessageBox.Show("Внимание, имеются пустые поля или не выбраные значения!!!");
            }
            else
            {
                MyCustomer.FirstName = tbFirstName.Text;
                MyCustomer.SecondName = tbSecondName.Text;
                MyCustomer.PatherName = tbSecondName.Text;
                MyCustomer.City = cbCity.SelectedItem as City;
                MyCustomer.CustStreet = tbCustStreet.Text;
                MyCustomer.CustTelephone = tbCustTel.Text;
            }
            

            if (!DB.CompFirm.Customer.Any(u => u.idCustomer == MyCustomer.idCustomer) && !DB.CompFirm.Customer.Any(u => u.FirstName == MyCustomer.FirstName))
            {
                DB.CompFirm.Customer.Add(MyCustomer);
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

