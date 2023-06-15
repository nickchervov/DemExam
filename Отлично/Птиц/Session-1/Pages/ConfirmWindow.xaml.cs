using Session1.Helpers;
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

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow()
        {
            InitializeComponent();

            lBasketId.Content = BasketController.BasketId;
            lDateNow.Content  = DateTime.Now;

            if ((PageHelper.ConnectDB.Orders.Where(x => (x.ID == BasketController.BasketId))).Count() >= 3)
            {
                lDateFuture.Content = DateTime.UtcNow.AddDays(6);
            }
            else
            {
                lDateFuture.Content = DateTime.UtcNow.AddDays(3);
            }


            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Набор символов для генерируемого токена
            var stringChars = new char[16]; // Длина генерируемого токена
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            lIndividualToken.Content = new String(stringChars);
            PageHelper.ConnectDB.Orders.Where(x => (x.ID == BasketController.BasketId)).FirstOrDefault().Token = new String(stringChars);   // Сохранение генерируемого токена
            PageHelper.ConnectDB.SaveChanges();

        }

        private void ButtonWindowsShutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            BasketController.BasketId = 0;
            PageHelper.BucketAccess.Visibility = Visibility.Collapsed;
        }

        private void ButtonAppShutdown_Click_(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
