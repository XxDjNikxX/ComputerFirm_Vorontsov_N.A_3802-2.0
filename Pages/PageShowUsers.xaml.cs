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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryDBComputers;

namespace ComputerFirm_Vorontsov_N.A_3802.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageShowUsers.xaml
    /// </summary>
    public partial class PageShowUsers : Page
    {
        Auth MyUsers { get; set; }
        public PageShowUsers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGUsers.ItemsSource = DB.CompFirm.Auth.ToList();
            cbRoles.ItemsSource = DB.CompFirm.Roles.ToList();
            tbLogin.Text = string.Empty;
            tbPassword.Password = string.Empty;
            tbLogoText.Text = "Добавить Пользователя";
            btnApply.Content = "Добавить";
            MyUsers = new Auth();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Auth users = DGUsers.SelectedItem as Auth;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + users.Login + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) DB.CompFirm.Auth.Remove(users);
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MyUsers = DGUsers.SelectedItem as Auth;
            tbLogoText.Text = "Изменить Пользователя";
            btnApply.Content = "Изменить";

            tbLogin.Text = MyUsers.Login;
            cbRoles.SelectedItem = MyUsers.Roles as Roles;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTextBoxes(sender, e))
            {
                var ComputedHash = GetHash(tbPassword.Password);
                MyUsers.Login = tbLogin.Text;
                MyUsers.Password = ComputedHash;
                MyUsers.Roles = cbRoles.SelectedItem as Roles; 

                if (!DB.CompFirm.Auth.Any(u => u.Login == MyUsers.Login) && !DB.CompFirm.Auth.Any(u => u.Password == ComputedHash))
                {
                    DB.CompFirm.Auth.Add(MyUsers);
                }
                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }

        }

        private static string GetHash(string input)
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

        private bool CheckTextBoxes(object sender, RoutedEventArgs e)
        {
            bool apply = true;
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
            }
            return apply;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(sender, e);
        }
    }
}
