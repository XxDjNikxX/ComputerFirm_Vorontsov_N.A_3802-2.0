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

namespace ComputerFirm_Vorontsov_N.A_3802
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Auth MyAuth { get; set; }
        public MainWindow(Auth auth)
        {
            InitializeComponent();
            MyAuth = auth;
            tbWelcomeName.Text = "Добро пожаловать, " + MyAuth.Login;
            MainFrame.Navigate(new Pages.PageShowGrids(MyAuth));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization auth = new WindowAuthorization();
            auth.Show();
            Close();
        }

        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageShowGrids(MyAuth));
        }

    }
}
