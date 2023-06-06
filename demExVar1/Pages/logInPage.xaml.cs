using demExVar1.Helpers;
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

namespace demExVar1.Pages
{
    /// <summary>
    /// Логика взаимодействия для logInPage.xaml
    /// </summary>
    public partial class logInPage : Page
    {

        public logInPage()
        {
            InitializeComponent();

            PageHelper.PageName.Text = "ООО 'Книжный мир'";

        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (PageHelper.connectDb.User.Where(x => x.UserLogin == tbLogin.Text && x.UserPassword == pbPassword.Password && x.UserRole == 1).FirstOrDefault() != null)
            {
                var result = PageHelper.connectDb.User.Select(c => new { c.UserID , c.UserLogin }).Where(x => x.UserLogin == tbLogin.Text).ToDictionary( t => t.UserID, t => t.UserLogin);

                MessageBox.Show(Convert.ToString(result.Keys.Last()));

                PageHelper.UserId = result.Keys.Last();
                PageHelper.roleId = 1;  //менеджер
                PageHelper.MainFrame.Navigate(new productList());
            }
            else if (PageHelper.connectDb.User.Where(x => x.UserLogin == tbLogin.Text && x.UserPassword == pbPassword.Password && x.UserRole == 2).FirstOrDefault() != null)
            {
                var result = PageHelper.connectDb.User.Select(c => new { c.UserID, c.UserLogin }).Where(x => x.UserLogin == tbLogin.Text).ToDictionary(t => t.UserID, t => t.UserLogin);

                MessageBox.Show(Convert.ToString(result.Keys.Last()));

                PageHelper.UserId = result.Keys.Last();
                PageHelper.roleId = 2;  //администратор
                PageHelper.MainFrame.Navigate(new productList());
            }
            else 
            {
                MessageBox.Show("Неправильный логин или пароль","Ошибка!");
            }
        }

        private void btnLogInGuest_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.UserId = 3; //гость
            PageHelper.roleId = 3;
            PageHelper.MainFrame.Navigate(new productList());
        }

    }
}
