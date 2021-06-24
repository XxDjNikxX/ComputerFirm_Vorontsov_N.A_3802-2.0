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
using System.Windows.Shapes;
using LibraryDBComputers;

namespace ComputerFirm_Vorontsov_N.A_3802
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            int counter = 1;
            char[] charac = { '*', '&', '{', '}', '|', '+' };
            if (CheckRegistr(ref counter, charac))
            {
                try
                {
                    Auth user = new Auth
                    {
                        Login = tbLogin.Text,
                        Password = tbPassword.Password,
                        idRole = 1,
                    };
                    DB.CompFirm.Auth.Add(user);
                    DB.CompFirm.SaveChanges();

                    MessageBox.Show("Регистрация произошла успешно!");
                    WindowAuthorization auth = new WindowAuthorization();
                    auth.Show();
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка регистрации");
                }
            }
        }

        private bool CheckRegistr(ref int counter, char[] charac)
        {
            bool reg = true;
            if (string.IsNullOrEmpty(tbPassword.Password) || string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Строка Логин или пароль пустая!!!"); reg = false;
            }
            else if (tbPassword.Password.Length < 6 || tbPassword.Password.Length > 18)
            {
                MessageBox.Show("Пароль должен содержать от 6 до 18 знаков"); reg = false;
            }

            else if (!tbPassword.Password.Any(c => charac.Contains(c)))
            {
                MessageBox.Show("В пароле должны встречаться символы: * & { } | +"); reg = false;
            }

            else if (!tbPassword.Password.Any(d => char.IsDigit(d)))
            {
                MessageBox.Show("В пароле должны быть цифры"); reg = false;
            }

            for (int i = 1; i < tbPassword.Password.Length; i++)
            {
                if (tbPassword.Password[i] == tbPassword.Password[i - 1]) counter++;
                else counter = 1;
                if (counter >= 3)
                {
                    MessageBox.Show("В пароле есть 3 подряд повторяющихся символа!"); reg = false;
                }
            }

            return reg;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization auth = new WindowAuthorization();
            auth.Show();
            Close();
        }
    }
}
