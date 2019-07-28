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

namespace LUATeach.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void RunLuaButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/LuaEditorPage.xaml", UriKind.Relative));
        }

        private void LuatButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comming soon!");
        }

        private void LearnLuaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comming soon!");
        }
    }
}
