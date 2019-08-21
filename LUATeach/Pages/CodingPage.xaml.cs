using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Search;
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
using System.Xml;

namespace LUATeach.Pages
{
    /// <summary>
    /// CodingPage.xaml 的交互逻辑
    /// </summary>
    public partial class CodingPage : Page
    {
        public CodingPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化编辑器
            SearchPanel.Install(textEditor.TextArea);
            string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".Lua.xshd";
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (System.IO.Stream s = assembly.GetManifestResourceStream(name))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    textEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
            }

            titleTextBlock.Text = $"{Global.Levels.selected + 1}. " +
                    $"{Global.Levels.LevelList[Global.Levels.selected].title}";
            Viewer.Markdown = Global.Levels.LevelList[Global.Levels.selected].question;
            textEditor.Text = Global.Levels.LevelList[Global.Levels.selected].code;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/LuaListPage.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            Loading.Visibility = Visibility.Visible;
            string code = textEditor.Text;
            Task.Run(() =>
            {
                string r = Global.Levels.LevelList[Global.Levels.selected].check(code);
                if (r == null)
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        this.NavigationService.Navigate(new Uri("Pages/RightPage.xaml", UriKind.Relative));
                    }));
                }
                else
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        mainGrid.Visibility = Visibility.Visible;
                        Loading.Visibility = Visibility.Collapsed;
                    }));
                    MessageBox.Show(r, "运行结果", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        }
    }
}
