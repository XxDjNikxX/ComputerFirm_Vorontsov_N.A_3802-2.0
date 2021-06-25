using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryDBComputers;

namespace ComputerFirm_Vorontsov_N.A_3802
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private static string VerifyHash(string input)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            int i;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(input);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);


            StringBuilder sOutput = new StringBuilder(tmpHash.Length);
            for (i = 0; i < tmpHash.Length; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var ComputedHash = VerifyHash(tbPassword.Password);
            var auth = DB.CompFirm.Auth.FirstOrDefault(u => u.Login == tbLogin.Text && u.Password == ComputedHash);

            try
            {

                if (auth != null)
                {
                    MessageBox.Show("Авторизация прошла успешно!");
                    MainWindow main = new MainWindow(auth);
                    main.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка авториизации!");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistration registration = new WindowRegistration();
            registration.Show();
            Close();
        }
    }
}
