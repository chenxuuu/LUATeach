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
            Task.Run(() =>
            {
                for (int i = 0; i < Global.Levels.LevelList.Count; i++)
                {
                    levels.Add(new Level
                    {
                        id = i + 1,
                        title = Global.Levels.LevelList[i].title,
                        type = Global.Levels.LevelList[i].type,
                        infomation = Global.Levels.LevelList[i].infomation,
                        enable = i <= Global.Settings.lastPass,
                    });
                }

                this.Dispatcher.Invoke(new Action(delegate
                {
                    Loading.Visibility = Visibility.Collapsed;
                    levelsList.ItemsSource = levels;
                }));
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Level data = ((Button)sender).Tag as Level;
            Global.Levels.selected = data.id - 1;

            this.NavigationService.Navigate(new Uri($"Pages/{Global.Levels.GetPage()}.xaml", UriKind.Relative));
        }
    }


    class Level
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string infomation { get; set; }
        public bool enable { get; set; }
    }
}
