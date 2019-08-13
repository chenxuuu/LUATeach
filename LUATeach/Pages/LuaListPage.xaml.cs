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
    /// LuaListPage.xaml 的交互逻辑
    /// </summary>
    public partial class LuaListPage : Page
    {
        public LuaListPage()
        {
            InitializeComponent();
        }

        List<Level> levels = new List<Level>();

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            levels.Add(new Level { id = 1, title = "初识Lua", type = "知识点", infomation = "介绍Lua的基础知识。" });
            levels.Add(new Level { id = 1, title = "初识Lua", type = "知识点", infomation = "介绍Lua的基础知识。" });
            levels.Add(new Level { id = 1, title = "初识Lua", type = "知识点", infomation = "介绍Lua的基础知识。" });
            levels.Add(new Level { id = 1, title = "初识Lua", type = "知识点", infomation = "介绍Lua的基础知识。" });
            levels.Add(new Level { id = 1, title = "初识Lua", type = "知识点", infomation = "介绍Lua的基础知识。" });

            levelsList.ItemsSource = levels;
        }
    }


    class Level
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string infomation { get; set; }
    }
}
