using demExVar1.DbModel;
using demExVar1.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace demExVar1.Pages
{
    /// <summary>
    /// Логика взаимодействия для productList.xaml
    /// </summary>
    public partial class productList : Page
    {
        DbSet<Product> products;

        public productList()
        {
            InitializeComponent();

            PageHelper.PageName.Text = "Список товаров";

            updateList();

            btnOrderList.Visibility = Visibility.Collapsed;

        }

        public void updateList()
        {
            products = PageHelper.connectDb.Product;

            lvProduct.ItemsSource = products.ToList();
        }

        public void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvProduct.SelectedItem as Product;

            int productId = selected.ProductID;

            if (PageHelper.Order.ContainsKey(productId))
            {
                PageHelper.Order[productId]++;
            }               
            else
            {
                PageHelper.Order.Add(productId, 1);
            }

            PageHelper.orderSum += selected.ProductCost;

            PageHelper.orderDiscount += Convert.ToDouble(selected.ProductCost) * Convert.ToDouble(selected.ProductDiscount) / 100;
           
            btnOrderList.Visibility = Visibility.Visible;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new logInPage());
        }

        public void btnOrderList_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new orderList());         
        }       
    }
}
