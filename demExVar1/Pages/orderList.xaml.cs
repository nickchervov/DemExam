using demExVar1.DbModel;
using demExVar1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

namespace demExVar1.Pages
{
    /// <summary>
    /// Логика взаимодействия для orderList.xaml
    /// </summary>
    public partial class orderList : Page
    {

        public orderList()
        {
            InitializeComponent();

            PageHelper.PageName.Text = "Заказ";

            cbPickUpPoint.ItemsSource = PageHelper.connectDb.PickupPoint.ToList();

            tbSum.Text = Convert.ToString(PageHelper.orderSum);

            tbDiscount.Text = Convert.ToString(PageHelper.orderDiscount);

            DataContext = new orderViewModel();

        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rndm = new Random();

                Order ord = new Order();             

                ord.OrderDate = DateTime.Today;

                try { ord.PickupPointID = (cbPickUpPoint.SelectedItem as PickupPoint).PickupPointID; } catch {MessageBox.Show("Необходимо выбрать пункт выдачи","Ошибка!"); return; }

                ord.OrderCode = Convert.ToInt16(rndm.Next(1, 9999));

                ord.UserID = PageHelper.UserId;

                ord.OrderStatus = "В обработке";

                PageHelper.connectDb.Order.Add(ord);

                PageHelper.connectDb.SaveChanges();


                var orderIdList = PageHelper.connectDb.Order.Select(c => c.OrderID).AsEnumerable();

                //MessageBox.Show(Convert.ToString(orderIdList.Last())); Для прослеживания последнего id в таблице

                foreach (var prd in PageHelper.Order)
                {
                    OrderProduct ordPrd = new OrderProduct();

                    ordPrd.OrderID = orderIdList.Last();

                    ordPrd.ProductID = prd.Key;

                    ordPrd.ProductAmount = prd.Value;

                    PageHelper.connectDb.OrderProduct.Add(ordPrd);                  
                }

                PageHelper.connectDb.SaveChanges();

                MessageBox.Show("Заказ успешно добавлен!", "ОК");

                PageHelper.MainFrame.Navigate(new productList());
            }
            catch
            {
                MessageBox.Show("Заказ не был добавлен","Ошибка!");
                return;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.GoBack();

            PageHelper.PageName.Text = "Список товаров" ;
        }

        private void btnDeletePrd_Click(object sender, RoutedEventArgs e)
        {   
            var selected = lvOrder.SelectedItem as orderProduct;

            if (selected != null)
            {
                if (selected.Count == 1)
                {
                    PageHelper.Order.Remove(selected.Id);

                    PageHelper.orderSum -= selected.Price;

                    PageHelper.orderDiscount -= selected.Discount;

                    tbSum.Text = Convert.ToString(PageHelper.orderSum);

                    tbDiscount.Text = Convert.ToString(PageHelper.orderDiscount);

                    DataContext = new orderViewModel();
                } else
                {
                    int selectedValue;

                    PageHelper.Order.TryGetValue(selected.Id,out selectedValue);

                    PageHelper.Order[selected.Id] = selectedValue - 1;

                    PageHelper.orderSum -= selected.Price;

                    PageHelper.orderDiscount -= selected.Discount;

                    tbSum.Text = Convert.ToString(PageHelper.orderSum);

                    tbDiscount.Text = Convert.ToString(PageHelper.orderDiscount);

                    DataContext = new orderViewModel();
                }
  
                if (PageHelper.Order.Count == 0)
                {
                    PageHelper.MainFrame.Navigate(new productList());
                }
            } 
            else
            {
                MessageBox.Show($"Для удаления товара из заказа\n" + "необходимо выбрать нужный товар", "Ошибка!");
            }
        }
    }
}
