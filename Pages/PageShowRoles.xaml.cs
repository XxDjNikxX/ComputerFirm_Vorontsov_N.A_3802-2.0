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
    /// Логика взаимодействия для PageShowRoles.xaml
    /// </summary>
    public partial class PageShowRoles : Page
    {
        Roles MyRole { get; set; }
        public PageShowRoles()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGRoles.ItemsSource = DB.CompFirm.Roles.ToList();
            tbRoleName.Text = string.Empty;
            tbNameLogo.Text = "Добавить город";
            btnApply.Content = "Добавить";
            MyRole = new Roles();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Roles roles = DGRoles.SelectedItem as Roles;
            var result = MessageBox.Show("Вы уверены что хотите удалить строку:" + roles.idRole + "?", "Подверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DB.CompFirm.Roles.Remove(roles);

            }
            DB.CompFirm.SaveChanges();
            Page_Loaded(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MyRole = DGRoles.SelectedItem as Roles;
            tbRoleName.Text = MyRole.RoleName;
            tbNameLogo.Text = "Изменить роль";
            btnApply.Content = "Изменить";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {

            if (CheckTextBoxes(sender, e))
            {
                MyRole.RoleName = tbRoleName.Text;

                if (!DB.CompFirm.Roles.Any(u => u.idRole == MyRole.idRole) && !DB.CompFirm.Roles.Any(u => u.RoleName == MyRole.RoleName))
                {
                    DB.CompFirm.Roles.Add(MyRole);
                }
                DB.CompFirm.SaveChanges();
                Page_Loaded(sender, e);
            }

        }
        private bool CheckTextBoxes(object sender, RoutedEventArgs e)
        {
            bool apply = true;
            char[] chars = { '@', '/', '_', '%', '{', '}', '=', '-', '+', '|' };

            if (string.IsNullOrEmpty(tbRoleName.Text))
            {
                MessageBox.Show("Введена пустая строка!");
                Page_Loaded(sender, e); apply = false;
            }

            if (double.TryParse(tbRoleName.Text, out double number))
            {
                MessageBox.Show("Введено число!");
                Page_Loaded(sender, e); apply = false;
            }
            foreach (var ch in chars)
            {
                if (tbRoleName.Text.Contains(ch))
                {
                    MessageBox.Show("Введён символ");
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

