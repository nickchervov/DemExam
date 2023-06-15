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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            PageHelper.PageName.Text = "Меню";


        }

        private void Product_click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.ProductsList());
        }

        private void Users_click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.UsersList());
        }

        private void Baskets_click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.BasketsPage());
        }
    }
}
