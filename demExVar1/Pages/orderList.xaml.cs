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

                try 
                { 
                    ord.PickupPointID = (cbPickUpPoint.SelectedItem as PickupPoint).PickupPointID;                
                }                
                catch
                {
                    MessageBox.Show("Необходимо выбрать пункт выдачи","Ошибка!"); 
                    return; 
                }

                ord.OrderCode = Convert.ToInt16(rndm.Next(1, 9999));

                ord.UserID = PageHelper.UserId;

                ord.OrderStatus = "Новый";

                PageHelper.connectDb.Order.Add(ord);

                PageHelper.connectDb.SaveChanges();


                var orderIdList = PageHelper.connectDb.Order.Select(c => c.OrderID).AsEnumerable();

                //MessageBox.Show(Convert.ToString(orderIdList.Last())); Для прослеживания последнего id в таблице Order

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

                //var takeCode = rndm.Next(1, 999);                                                                                               // начало кода создания талона

                //List<string> lines = new List<string>();

                //lines.Add(takeCode.ToString());

                //lines.Add(ord.OrderDate.ToString());

                //lines.Add("Стоимость заказа: " + PageHelper.orderSum.ToString() + " рублей");

                //lines.Add("Скидка: " + PageHelper.orderDiscount.ToString() + " рублей");

                //lines.Add(ord.PickupPoint.PickupPointAdress);


                //foreach (var prd in PageHelper.Order)
                //{
                //    var productName = PageHelper.connectDb.Product.Where(x => x.ProductID == prd.Key).Select(c => c.ProductName).ToList();

                //    lines.Add(productName[0]);
                //}

                //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                //using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "Талон.txt")))
                //{
                //    foreach (string line in lines)
                //        outputFile.WriteLine(line);
                //}                                                                                                                              // конец кода создания талона

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
                } 
                else
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

        private void btnCreatePDF_Click(object sender, RoutedEventArgs e)
        {             

            
        }
    }
}
