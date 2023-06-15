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
    /// Логика взаимодействия для BasketsPage.xaml
    /// </summary>
    public partial class BasketsPage : Page
    {
        public BasketsPage()
        {
            InitializeComponent();

            var employee = PageHelper.ConnectDB.Orders;

            dgBasketlist.ItemsSource = employee.ToList();
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }

        private void btnWatchClRecords_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.ConnectDB.SaveChanges();
            MessageBox.Show("Сохранено");
        }
    }
}
