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

            if (PageHelper.roleId == 2)
            {
                btnDeleteProd.Visibility = Visibility.Visible;
                btnAddProduct.Visibility = Visibility.Visible;
                btnChangeProduct.Visibility = Visibility.Visible;
                btnOrders.Visibility = Visibility.Visible;
            }
            else if (PageHelper.roleId == 1)
            {
                btnDeleteProd.Visibility = Visibility.Collapsed;
                btnAddProduct.Visibility = Visibility.Collapsed;
                btnChangeProduct.Visibility = Visibility.Collapsed;
                btnOrders.Visibility = Visibility.Visible;
            }
            else
            {
                btnDeleteProd.Visibility = Visibility.Collapsed;
                btnAddProduct.Visibility = Visibility.Collapsed;
                btnChangeProduct.Visibility = Visibility.Collapsed;
                btnOrders.Visibility = Visibility.Collapsed;
            }

        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvProduct.ItemsSource = products.Where(x => x.ProductName.Contains(tbSearch.Text) || x.ProductManufacturer.Contains(tbSearch.Text)).ToList();
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

        private void btnDeleteProd_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvProduct.SelectedItem as Product;

            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите удалить выбранную запись?","Предупреждение!", MessageBoxButton.YesNo))
                {
                    try
                    {
                        PageHelper.connectDb.Product.Remove(selected);

                        PageHelper.connectDb.SaveChanges();

                        updateList();
                    } 
                    catch 
                    {
                        MessageBox.Show("Не удалось удалить запись, имеется мозданный заказ", "Ошибка!");
                    }                   
                }
            }
            else
            {
                MessageBox.Show("Для удаления необходимо выбрать запись!", "Ошибка!");
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new addProductPage());
        }

        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvProduct.SelectedItem as Product;

            if (selected != null)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("Вы точно хотите изменить выбранную запись?", "Предупреждение!", MessageBoxButton.YesNo))
                {
                    try
                    {
                        PageHelper.MainFrame.Navigate(new changeProductPage(selected));
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить запись!", "Ошибка!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Для изменения необходимо выбрать запись!", "Ошибка!");
            }
        }

        private void btnOrdersList_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new ordersPage());
        }
    }
}
