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
    /// Логика взаимодействия для addProductPage.xaml
    /// </summary>
    public partial class addProductPage : Page
    {
        public addProductPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbPhoto.Text != "" && tbDiscription.Text != "" && tbManufacturer.Text != "" && tbCost.Text != "" && tbDiscount.Text != "")
            {
                Product prd = new Product();

                prd.ProductName = tbName.Text;

                prd.ProductPhoto = tbPhoto.Text;

                prd.ProductManufacturer = tbManufacturer.Text;

                prd.ProductDescription = tbDiscription.Text;

                try { prd.ProductCost = Convert.ToInt32(tbCost.Text); } catch { MessageBox.Show("Стоимость должна состоять из цифр!", "Ошибка!"); return; }

                try { prd.ProductDiscount = Convert.ToByte(tbDiscount.Text); } catch { MessageBox.Show("Скидка должна состоять из цифр!", "Ошибка!"); return; }

                PageHelper.connectDb.Product.Add(prd);

                PageHelper.connectDb.SaveChanges();

                PageHelper.MainFrame.Navigate(new productList());
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля!", "Ошибка!");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();
            PageHelper.PageName.Text = "Список товаров";
        }
    }
}
