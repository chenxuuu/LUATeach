using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUATeach.LuaEnv
{
    class LuaEnv
    {
        /// <summary>
        /// 新建Lua虚拟机，并绑定好各项接口
        /// </summary>
        /// <returns></returns>
        public static XLua.LuaEnv CreateLuaEnv()
        {
            var lua = new XLua.LuaEnv();
            //utf8转gbk编码的hex值
            lua.DoString("apiUtf8ToHex = CS.LUATeach.LuaEnv.LuaApi.Utf8ToAsciiHex");
            //获取软件目录路径
            lua.DoString("apiGetPath = CS.LUATeach.LuaEnv.LuaApi.GetPath");
            //输出日志
            lua.DoString("apiPrintLog = CS.LUATeach.LuaEnv.LuaApi.PrintLog");

            //运行初始化文件
            lua.DoString(Global.Utils.GetAssetsFileContent("/Assets/script/head.lua"));
            lua.DoString(Global.Utils.GetAssetsFileContent("/Assets/script/strings.lua"));
            lua.Global.SetInPath("log", lua.DoString(Global.Utils.GetAssetsFileContent("/Assets/script/log.lua"))[0]);
            lua.Global.SetInPath("JSON", lua.DoString(Global.Utils.GetAssetsFileContent("/Assets/script/JSON.lua"))[0]);

            return lua;
        }
    }
}
