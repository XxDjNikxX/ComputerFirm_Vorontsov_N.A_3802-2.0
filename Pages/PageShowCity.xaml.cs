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
    /// Логика взаимодействия для PageShowCity.xaml
    /// </summary>
    public partial class PageShowCity : Page
    {

        City MyCity { get; set; }
        public PageShowCity()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGCity.ItemsSource = DB.CompFirm.City.ToList();
            tbCityName.Text = string.Empty;
            tbNameLogo.Text = "Добавить город";
            btnApply.Content = "Добавить";
            MyCity = new City();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            City city = DGCity.SelectedItem as City;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + city.idCity + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DB.CompFirm.City.Remove(city);

            }
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MyCity = DGCity.SelectedItem as City;
            tbCityName.Text = MyCity.CityName;
            tbNameLogo.Text = "Изменить город";
            btnApply.Content = "Изменить";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCityName.Text))
            {
                MessageBox.Show("Введена пустая строка!");
                Page_Loaded(sender, e);
            }
            else
            {
                MyCity.CityName = tbCityName.Text;
                if (!DB.CompFirm.City.Any(u => u.idCity == MyCity.idCity) && !DB.CompFirm.City.Any(u => u.CityName == MyCity.CityName))
                {
                    DB.CompFirm.City.Add(MyCity);
                }
                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }
         
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(sender, e);
        }
    }
}
