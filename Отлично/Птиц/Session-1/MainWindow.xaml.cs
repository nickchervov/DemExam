using Session1.Helpers;
using Session1.Pages;
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

namespace Session1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            PageHelper.PageName = pageName;
            PageHelper.MainFrame = mainFrame;

            PageHelper.BucketAccess = bucketAccess;
            PageHelper.MainFrame.Navigate(new Pages.SignIn());
        }

        private void bucketAccess_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cartWindow.Topmost = true;

            cartWindow.Show();
        }
    }
}
