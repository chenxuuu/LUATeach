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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml;

namespace LUATeach.Pages
{
    /// <summary>
    /// LuaEditorPage.xaml 的交互逻辑
    /// </summary>
    public partial class LuaEditorPage : Page
    {
        public LuaEditorPage()
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
            textEditor.Text = Global.Utils.GetAssetsFileContent("/Assets/script/default.lua");
            LuaEnv.LuaApi.PrintLuaLog += LuaApi_PrintLuaLog;
        }

        private void LuaApi_PrintLuaLog(object sender, EventArgs e)
        {
            LogTextBlock.AppendText((sender as string) + "\r\n");
            LogTextBlock.ScrollToEnd();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult back = MessageBox.Show("是否回到主页？当前编辑内容将全部丢失。", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (back == MessageBoxResult.OK)
            {
                this.NavigationService.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
            }
        }

        private XLua.LuaEnv lua;
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button.Content as string == "运行脚本")
            {
                lua = LuaEnv.LuaEnv.CreateLuaEnv();
                button.Content = "停止运行脚本";
            }
            else
            {
                lua.Dispose();
                LuaApi_PrintLuaLog("脚本已停止运行\r\n", EventArgs.Empty);
                button.Content = "运行脚本";
            }

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            LuaEnv.LuaApi.PrintLuaLog -= LuaApi_PrintLuaLog;
        }
    }
}
