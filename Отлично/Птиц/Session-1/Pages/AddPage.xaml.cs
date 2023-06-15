using Session1.Database;
using Session1.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            PageHelper.PageName.Text = "Меню";
            cmbDeveloper.ItemsSource = PageHelper.ConnectDB.Developer.ToList();
            cmbCategory.ItemsSource = PageHelper.ConnectDB.Category.ToList();
        }

        private void sexType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageHelper.MainFrame.Navigate(new Pages.ProductsList());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product material = new Product();
   
            material.Name = tName.Text;

            material.Count = Convert.ToInt32(tCount.Text);

            material.Price = Convert.ToDecimal(tPrice.Text);

            material.Discount = 0;


            if (cmbDeveloper.SelectedItem == null)
            {
                MessageBox.Show("Производитель не выбран");
                return;
            }

            else
            {
                material.DeveloperID = (cmbDeveloper.SelectedItem as Developer).ID;
            }



            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Категория не выбрана");
                return;
            }
            else
            {
                material.CategoryID = (cmbCategory.SelectedItem as Category).ID;
            }

            if (MessageBoxResult.Yes == MessageBox.Show("Вы действительно хотите добавить запись?", "Предупреждение", MessageBoxButton.YesNo))
            {
                material.ID = (PageHelper.ConnectDB.Product.Count()) + 1;
      

                    PageHelper.ConnectDB.Product.Add(material);

                    PageHelper.ConnectDB.SaveChanges();
                

               
            }


        }

    
    }
}
