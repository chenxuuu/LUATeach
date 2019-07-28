using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUATeach.Global
{
    class Utils
    {
        /// <summary>
        /// 读取软件资源文件内容
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件内容字符串</returns>
        public static string GetAssetsFileContent(string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            var source = System.Windows.Application.GetResourceStream(uri).Stream;
            byte[] f = new byte[source.Length];
            source.Read(f, 0, (int)source.Length);
            return Encoding.UTF8.GetString(f);
        }
    }
}
