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
    /// Логика взаимодействия для changeProductPage.xaml
    /// </summary>
    public partial class changeProductPage : Page
    {
        Product _prd;

        public changeProductPage(Product prd)
        {
            InitializeComponent();

            PageHelper.PageName.Text = "Изменение записи товара";

            _prd = prd;

            DataContext = _prd;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
            PageHelper.PageName.Text = "Список товаров";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbPhoto.Text != "" && tbDiscription.Text != "" && tbManufacturer.Text != "" && tbCost.Text != "" && tbDiscount.Text != "")
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы уверены что хотите изменить запись?","Предупреждение!",MessageBoxButton.YesNo))
                {
                    PageHelper.connectDb.SaveChanges();
                    PageHelper.MainFrame.Navigate(new productList());
                }
            } else
            {
                MessageBox.Show("Необходимо заполнить все поля!", "Ошибка!");
            }
        }
    }
}
