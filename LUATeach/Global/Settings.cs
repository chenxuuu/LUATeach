using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUATeach.Global
{
    class Settings
    {
        private static string _code = Properties.Settings.Default.code;
        private static int _lastPass = Properties.Settings.Default.lastPass;

        /// <summary>
        /// 存储的测试代码
        /// </summary>
        public static string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                Properties.Settings.Default.code = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 上次通过的关卡
        /// </summary>
        public static int lastPass
        {
            get
            {
                return _lastPass;
            }
            set
            {
                _lastPass = value;
                Properties.Settings.Default.lastPass = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
