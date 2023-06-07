using demExVar1.DbModel;
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
    /// Логика взаимодействия для changeOrderListPage.xaml
    /// </summary>
    public partial class changeOrderListPage : Page
    {
        Order _ord;

        public changeOrderListPage(Order order)
        {
            InitializeComponent();

            PageHelper.PageName.Text = "Изменение заказа";

            _ord = order;

            DataContext = _ord;

            cbPickupPoint.ItemsSource = PageHelper.connectDb.PickupPoint.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
            PageHelper.PageName.Text = "Список заказов";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbCode.Text != "" && tbStatus.Text != "" && dpDate.Text != "")
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены что хотите изменить запись?", "Предупреждение!", MessageBoxButton.YesNo))
                {
                    try { _ord.OrderDate = Convert.ToDateTime(dpDate.Text); } catch { MessageBox.Show("Выберете правильно дату!", "Ошибка!"); }

                    _ord.PickupPointID = (cbPickupPoint.SelectedItem as PickupPoint).PickupPointID;

                    PageHelper.connectDb.SaveChanges();

                    MessageBox.Show("Данные успешно изменены!", "ОК!");

                    PageHelper.MainFrame.Navigate(new ordersPage());
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля!", "Ошибка!");
            }
        }
    }
}
