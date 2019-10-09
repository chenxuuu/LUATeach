using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private string[] options;
        private int truth = Global.Levels.LevelList[Global.Levels.selected].choice - 1;

        Random r = new Random();
        private void ReLoadChoice()
        {
            Console.WriteLine("last" + truth);
            for (int i = 0; i < 4; i++)
            {
                int temp = r.Next(0, 4);
                string t = options[i];
                options[i] = options[temp];
                options[temp] = t;
                if (i == truth)
                    truth = temp;
                else if (temp == truth)
                    truth = i;
                Console.WriteLine($"swap{i},{temp}");
                Console.WriteLine("result" + truth);
            }
            Console.WriteLine("=======================");
            option1.Content = options[0];
            option2.Content = options[1];
            option3.Content = options[2];
            option4.Content = options[3];
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            titleTextBlock.Text = $"{Global.Levels.selected + 1}. " +
                $"{Global.Levels.LevelList[Global.Levels.selected].title}";
            Viewer.Markdown = Global.Levels.LevelList[Global.Levels.selected].question;
            questionTextBlock.Text = Global.Levels.LevelList[Global.Levels.selected].choiceTitle;

            options = new string[]
            {
                Global.Levels.LevelList[Global.Levels.selected].choices[0],
                Global.Levels.LevelList[Global.Levels.selected].choices[1],
                Global.Levels.LevelList[Global.Levels.selected].choices[2],
                Global.Levels.LevelList[Global.Levels.selected].choices[3],
            };

            ReLoadChoice();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/LuaListPage.xaml", UriKind.Relative));
        }

        private void CheckResult(int select)
        {
            if (truth == select)
                this.NavigationService.Navigate(new Uri("Pages/RightPage.xaml", UriKind.Relative));
            else
            {
                MessageBox.Show("答错啦，再仔细想想吧", "选择结果", MessageBoxButton.OK, MessageBoxImage.Error);
                ReLoadChoice();
            }
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(0);
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(1);
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(2);
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {
            CheckResult(3);
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://ask.openluat.com/question/create"));
        }
    }
}
