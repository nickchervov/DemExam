using Session1.Database;
using Session1.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {

        DbSet<ProductOrders> orderproduct;
        object selectedItem = null;


        public CartWindow()
        {
            InitializeComponent();
            BusketView.ItemsSource = PageHelper.ConnectDB.ProductOrders.Where(x => (x.OrderID == BasketController.BasketId)).ToList();
            lCartNumber.Content = BasketController.BasketId;
          

            List<ProductOrders> items = (List<ProductOrders>)BusketView.ItemsSource;
            
            
            cmbdDeliveryPoint.ItemsSource = PageHelper.ConnectDB.DeliveryPoint.ToList();

            UpdateSum();
        }

        public void UpdateSum()
        {

            List<ProductOrders> items = (List<ProductOrders>)BusketView.ItemsSource;

            double sum = 0;
            try
            {
                foreach (ProductOrders item in items)
                {
                    if (item.Product.Discount == 0 || item.Product.Discount == null)
                    {
                        sum = sum + Convert.ToDouble(Convert.ToDecimal(item.Count) * item.Product.Price);
                    }

                    else
                    {
                        sum = sum + Convert.ToDouble(Convert.ToDecimal(item.Count) * (item.Product.Price / 100 * (100 - Convert.ToDecimal(item.Product.Discount))));
                    }

                }

                lResult.Content = sum;

            }

            catch
            {
                lResult.Content = "0";
            }
        }


        private void ReduceButton_Click(object sender, RoutedEventArgs e)
        {
            if (BusketView.SelectedItem != null)
            {
                ProductOrders selectedItem = BusketView.SelectedItem as ProductOrders;

                if (selectedItem.Count == 1)
                {

                    if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("Уменьшение количества этого товара в заказе приведёт к удалению товара из заказа. Хотите продолжить ?", "Предупреждение", MessageBoxButton.YesNo))
                    {
                        PageHelper.ConnectDB.ProductOrders.Remove(selectedItem);
                        PageHelper.ConnectDB.SaveChanges();
                     
                        BusketView.ItemsSource = PageHelper.ConnectDB.ProductOrders.Where(x => (x.OrderID == BasketController.BasketId)).ToList();
                        UpdateSum();

                        if(lResult.Content == "0")
                        {
                            PageHelper.BucketAccess.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Удаление отменено");
                    }
                   
                }

                else
                {
                    selectedItem.Count = selectedItem.Count - 1;
                    PageHelper.ConnectDB.SaveChanges();
                    BusketView.ItemsSource = PageHelper.ConnectDB.ProductOrders.Where(x => (x.OrderID == BasketController.BasketId)).ToList();
                    UpdateSum();
                }
         
            }
            else
            {
                System.Windows.MessageBox.Show("Нет выбранной записи");
            }


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BusketView.SelectedItem != null)
            {
                ProductOrders selectedItem = BusketView.SelectedItem as ProductOrders;
                selectedItem.Count = selectedItem.Count + 1;
                PageHelper.ConnectDB.SaveChanges();
                BusketView.ItemsSource = PageHelper.ConnectDB.ProductOrders.Where(x => (x.OrderID == BasketController.BasketId)).ToList();
                UpdateSum();
            }
            else
            {
                System.Windows.MessageBox.Show("Нет выбранной записи");
            }

        }

  
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
            {
                ConfirmWindow cartconfirmWindow = new ConfirmWindow();
                cartconfirmWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                cartconfirmWindow.Topmost = true;
                cartconfirmWindow.Show();
                this.Close();
            }

            else
            {
                return;
            }
        }
    }

    }

