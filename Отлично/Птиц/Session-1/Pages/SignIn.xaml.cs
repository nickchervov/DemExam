using Session1.Database;
using Session1.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {

        DbSet<Users> user;
        public SignIn()
        {
            InitializeComponent();
            PageHelper.PageName.Text = "Авторизация";
            user = PageHelper.ConnectDB.Users;
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (tLogin.Text == null && tPass.Password == null)
            {
                MessageBox.Show("Не введены данных для входа", "Ошибка входа");
                return;
            }

            if (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password).FirstOrDefault() == null)
            {
                MessageBox.Show("Нет такого пользователя", "Ошибка входа");
                return;
            }

      
            // Проверка на авторизованного пользователя
            if (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 2).FirstOrDefault() != null)
            {
                BasketController.UserId = (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 2).FirstOrDefault()).ID;
                BasketController.BasketId = 0;
                PageHelper.AccessId = 1;
                PageHelper.MainFrame.Navigate(new Pages.ProductsList());
            }

            // Проверка на сотрудника
            if (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 3).FirstOrDefault() != null)
            {
                BasketController.UserId = (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 3).FirstOrDefault()).ID;
                BasketController.BasketId = 0;
                PageHelper.AccessId = 2;
                PageHelper.MainFrame.Navigate(new Pages.ProductsList());
            }

            // Проверка на администратора
            if (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 4).FirstOrDefault() != null)
            {
                BasketController.UserId = (PageHelper.ConnectDB.Users.Where(x => x.Login == tLogin.Text && x.Password == tPass.Password && x.RoleID == 4).FirstOrDefault()).ID;
                BasketController.BasketId = 0;
                PageHelper.AccessId = 3;
                PageHelper.MainFrame.Navigate(new Pages.ProductsList());
            }


        }

        private void Unauth_Click(object sender, RoutedEventArgs e)
        {
            // Вход неавторизованного пользователем

            if (MessageBox.Show("Вы хотите войти без авторизации ?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                BasketController.UserId = 0;
                BasketController.BasketId = 0;
                PageHelper.AccessId = 1;
                PageHelper.MainFrame.Navigate(new Pages.ProductsList());
            }
            else
            {
                return;
            }

        }
    }
}
