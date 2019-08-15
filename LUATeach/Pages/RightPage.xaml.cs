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
    /// RightPage.xaml 的交互逻辑
    /// </summary>
    public partial class RightPage : Page
    {
        public RightPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            explainTextBlock.Text = Global.Levels.LevelList[Global.Levels.selected].explain;
            Global.Settings.lastPass++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.Levels.selected++;
            if(Global.Levels.selected < Global.Levels.LevelList.Count)
                this.NavigationService.Navigate(new Uri($"Pages/{Global.Levels.GetPage()}.xaml", UriKind.Relative));
            else
            {
                Global.Levels.selected = 0;
                MessageBox.Show("你已经看完这部分的所有内容啦~现在带你去列表页面");
                this.NavigationService.Navigate(new Uri($"Pages/LuaListPage.xaml", UriKind.Relative));
            }
        }
    }
}
