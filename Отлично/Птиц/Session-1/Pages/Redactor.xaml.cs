using Session1.Database;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Session1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Redactor.xaml
    /// </summary>
    public partial class Redactor : Window
    {
        Product current;
        public Redactor(object item)
        {
            current = item as Product;
            InitializeComponent();

            tbDescription.Text = current.Name;
            tbCost.Text = Convert.ToString(current.Price);
            tbCount.Text = Convert.ToString(current.Count);
            tbDiscount.Text = Convert.ToString(current.Discount);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            current.Name = tbDescription.Text;
            current.Price = Convert.ToDecimal(tbCost.Text);
            current.Discount = Convert.ToDouble(tbDiscount.Text);
            current.Count = Convert.ToInt32(tbCount.Text);
            PageHelper.ConnectDB.SaveChanges();
            PageHelper.MainFrame.Navigate(new Pages.ProductsList());
            this.Close();
        }

        private void tbDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
