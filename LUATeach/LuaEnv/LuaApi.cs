using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUATeach.LuaEnv
{
    class LuaApi
    {
        public static event EventHandler PrintLuaLog;
        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="log">日志内容</param>
        public static void PrintLog(string log)
        {
            try
            {
                PrintLuaLog(log, EventArgs.Empty);
            }
            catch { }
        }


        /// <summary>
        /// utf8编码改为gbk的hex编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Utf8ToAsciiHex(string input)
        {
            return BitConverter.ToString(Encoding.GetEncoding("GB2312").GetBytes(input)).Replace("-", "");
        }

        /// <summary>
        /// 获取程序运行目录
        /// </summary>
        /// <returns>主程序运行目录</returns>
        public static string GetPath()
        {
            return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }
    }
}
