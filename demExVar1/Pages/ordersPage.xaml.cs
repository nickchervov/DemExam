using demExVar1.DbModel;
using demExVar1.Helpers;
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

namespace demExVar1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ordersPage.xaml
    /// </summary>
    public partial class ordersPage : Page
    {
        DbSet<Order> orders;

        public ordersPage()
        {
            InitializeComponent();

            PageHelper.PageName.Text = "Заказы";

            updateList();
        }

        public void updateList()
        {
            orders = PageHelper.connectDb.Order;

            lvOrders.ItemsSource = orders.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
            PageHelper.PageName.Text = "Список товаров";
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvOrders.SelectedItem as Order;

            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены что хотите изменить запись?", "Предупреждение!", MessageBoxButton.YesNo))
                {
                    PageHelper.MainFrame.Navigate(new changeOrderListPage(selected));
                }
            } 
            else
            {
                MessageBox.Show("Для изменения необходимо выбрать запись!","Предупреждение!");
            }
        }
    }
}
