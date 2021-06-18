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
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        public PageAddProduct()
        {
            InitializeComponent();
            cbTypeProduct.ItemsSource = DB.CompFirm.ProductType.ToList();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product
            {
                ProductType = cbTypeProduct.SelectedItem as ProductType,
                ProductName = tbProductName.Text,
                Price = Decimal.Parse(tbPrice.Text),
                Discount = Double.Parse(tbDiscount.Text) / 100,
            };

            DB.CompFirm.Product.Add(product);
            DB.CompFirm.SaveChanges();
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
