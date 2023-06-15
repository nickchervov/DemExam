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
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : Page
    {
        public UsersList()
        {
            InitializeComponent();



            var employee = PageHelper.ConnectDB.Users;

            dgUserlist.ItemsSource = employee.ToList();
            cmbPosition.ItemsSource = PageHelper.ConnectDB.Roles.ToList();
        }


        private void btnWatchClRecords_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.ConnectDB.SaveChanges();
            MessageBox.Show("Сохранено");
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
        }
    }
}
