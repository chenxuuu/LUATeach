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
    /// IntroducePage.xaml 的交互逻辑
    /// </summary>
    public partial class IntroducePage : Page
    {
        public IntroducePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            titleTextBlock.Text = Global.Levels.LevelList[Global.Levels.selected].title;
            Viewer.Markdown = Global.Levels.LevelList[Global.Levels.selected].question;
            questionTextBlock.Text = Global.Levels.LevelList[Global.Levels.selected].choiceTitle;
            option1.Content = Global.Levels.LevelList[Global.Levels.selected].choices[0];
            option2.Content = Global.Levels.LevelList[Global.Levels.selected].choices[1];
            option3.Content = Global.Levels.LevelList[Global.Levels.selected].choices[2];
            option4.Content = Global.Levels.LevelList[Global.Levels.selected].choices[3];
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/LuaListPage.xaml", UriKind.Relative));
        }

        private void CheckResult(int select)
        {
            if (Global.Levels.LevelList[Global.Levels.selected].choice == select)
                this.NavigationService.Navigate(new Uri("Pages/RightPage.xaml", UriKind.Relative));
            else
                this.NavigationService.Navigate(new Uri("Pages/WrongPage.xaml", UriKind.Relative));
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(1);
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(2);
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(3);
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(4);
        }
    }
}
