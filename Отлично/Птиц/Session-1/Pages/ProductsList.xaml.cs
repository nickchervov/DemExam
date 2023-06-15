using Session1.Database;
using Session1.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Session1.Helpers.PageHelper;

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Page
    {

        DbSet<Product> employee;
        object selectedItem = null;


        public ProductsList()
        {
            InitializeComponent();
            PageHelper.PageName.Text = "Список товаров";

            employee = PageHelper.ConnectDB.Product;
            MatView.ItemsSource = employee.ToList();


            lCountNow.Content = employee.Count();
            lCountTotal.Content = employee.Count();

            if (PageHelper.AccessId == 1) // Пользователь с покупатель
            {
                ChangeProductButton.Visibility = Visibility.Collapsed;
                RemoveProductButton.Visibility = Visibility.Collapsed;
                AddProductButton.Visibility = Visibility.Collapsed;
                MenuButton.Visibility = Visibility.Collapsed;
            }

            else if (PageHelper.AccessId == 2) // Пользователь менеджер
            {
                ChangeProductButton.Visibility = Visibility.Collapsed;
                RemoveProductButton.Visibility = Visibility.Collapsed;
                MenuButton.Visibility = Visibility.Collapsed;
            }

            else // Пользователь администратор
            {

            }
         
        }

        private void MatView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e != null)
                    selectedItem = e.AddedItems[0];
            }

            catch { }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filter.SelectedItem == F1)
            {
                MatView.ItemsSource = employee.ToList();
                lCountNow.Content = employee.Count();
            }
            if (filter.SelectedItem == F2)
            {
                MatView.ItemsSource = employee.Where(x => x.CategoryID == 1).ToList();
                lCountNow.Content = employee.Where(x => x.CategoryID == 1).Count();
            }
            if (filter.SelectedItem == F3)
            {
                MatView.ItemsSource = employee.Where(x => x.CategoryID == 2).ToList();
                lCountNow.Content = employee.Where(x => x.CategoryID == 2).Count();
            }
            if (filter.SelectedItem == F4)
            {
                MatView.ItemsSource = employee.Where(x => x.CategoryID == 3).ToList();
                lCountNow.Content = employee.Where(x => x.CategoryID == 3).Count();
            }
            if (filter.SelectedItem == F5)
            {
                MatView.ItemsSource = employee.Where(x => x.Discount < 10).ToList();
                lCountNow.Content = employee.Where(x => x.Discount < 10).Count();
            }
            if (filter.SelectedItem == F6)
            {
                MatView.ItemsSource = employee.Where(x => x.Discount < 15 && x.Discount >= 10).ToList();
                lCountNow.Content = employee.Where(x => x.Discount < 15 && x.Discount >= 10).Count();
            }
            if (filter.SelectedItem == F7)
            {
                MatView.ItemsSource = employee.Where(x => x.Discount >= 15).ToList();
                lCountNow.Content = employee.Where(x => x.Discount >= 15).Count();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MatView.ItemsSource = employee.Where(x => x.Name.Contains(tSearch.Text)).ToList();
            lCountNow.Content = employee.Where(x => x.Name.Contains(tSearch.Text)).Count();
        }

 

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PageHelper.PageName.Text = "Список товаров";

            employee = PageHelper.ConnectDB.Product;
           
        }


        private void sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sorting.SelectedItem == S2)
                MatView.ItemsSource = employee.OrderByDescending(x => x.Name).ToList();
            if (sorting.SelectedItem == S3)
                MatView.ItemsSource = employee.OrderBy(x => x.Name).ToList();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.Menu());
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = MatView.SelectedItem as Product;
            if (selected != null)
            {
                if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo))
                {
                    PageHelper.ConnectDB.Product.Remove(selected);
                    PageHelper.ConnectDB.SaveChanges();
                    sorting.SelectedIndex = 0;
                    filter.SelectedIndex = 0;
                    MatView.ItemsSource = employee.ToList();
                }
                else
                {
                    return;
                }
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = MatView.SelectedItem as Product;
            if (selected != null)
            {
                Redactor redactor = new Redactor(selectedItem);
                redactor.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                redactor.Topmost = true;

                redactor.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Редактирование отменено");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.AddPage());
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = MatView.SelectedItem as Product;
      
            if (BasketController.BasketId == 0)  
            {
                //Формирование нового заказа
                Orders order = new Orders();  
                order.ID = (PageHelper.ConnectDB.Orders.Count()) + 1;
                order.Status = "Новый";
                order.UserID = BasketController.UserId;
                BasketController.BasketId = order.ID;
                PageHelper.ConnectDB.Orders.Add(order);
                PageHelper.BucketAccess.Visibility = Visibility.Visible;

                //Формирование добавление товара в заказ
                ProductOrders productorder = new ProductOrders();
                productorder.ID = (PageHelper.ConnectDB.ProductOrders.Count()) + 1;
                productorder.ProductID = selected.ID;
                productorder.OrderID = BasketController.BasketId;
                productorder.Count = 1;
                PageHelper.ConnectDB.ProductOrders.Add(productorder);
                PageHelper.ConnectDB.SaveChanges();

                System.Windows.MessageBox.Show("Товар добавлен");
      

               

            }
            else
            {
                PageHelper.BucketAccess.Visibility = Visibility.Visible;
                ProductOrders productorder = new ProductOrders();
                productorder.ID = (PageHelper.ConnectDB.ProductOrders.Count()) + 1;
                productorder.ProductID = selected.ID;
                productorder.OrderID = BasketController.BasketId;
                if (PageHelper.ConnectDB.ProductOrders.Where(x => x.ProductID == productorder.ProductID && x.OrderID == productorder.OrderID).FirstOrDefault() != null)
                {

                    PageHelper.ConnectDB.ProductOrders.Where(x => x.ProductID == productorder.ProductID && x.OrderID == productorder.OrderID).FirstOrDefault().Count = 1 + PageHelper.ConnectDB.ProductOrders.Where(x => x.ProductID == productorder.ProductID && x.OrderID == productorder.OrderID).FirstOrDefault().Count;
                
                    PageHelper.ConnectDB.SaveChanges();
                    System.Windows.MessageBox.Show("Добавлен ещё один товар");
                }

                else
                {

                    productorder.Count = 1;
                    PageHelper.ConnectDB.ProductOrders.Add(productorder);
                    PageHelper.ConnectDB.SaveChanges();
                    
                    System.Windows.MessageBox.Show("Товар добавлен");
                    return;

                }
               
            }
        }
    }
}
