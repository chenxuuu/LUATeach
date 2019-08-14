﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LUATeach.LuaEnv
{
    class LuaRunEnv
    {
        public static event EventHandler LuaRunError;//报错的回调
        private static XLua.LuaEnv lua = null;
        private static CancellationTokenSource tokenSource = null;
        private static Dictionary<int, CancellationTokenSource> pool = 
            new Dictionary<int, CancellationTokenSource>();//timer回调池子
        private static List<LuaPool> toRun = new List<LuaPool>();//待运行的池子

        public static bool isRunning = false;

        private static void addTigger(int id, string type = "timer", string data = "")
        {
            toRun.Add(new LuaPool { id = id, type = type, data = data });
        }


        /// <summary>
        /// 实时跑一段lua代码
        /// </summary>
        /// <param name="l"></param>
        public static void RunCommand(string l)
        {
            addTigger(-1, "cmd", l);
        }

        private static void runTigger()
        {
            try
            {
                while (true)
                {
                    Task.Delay(1).Wait();
                    if (tokenSource.IsCancellationRequested)
                        return;
                    if (toRun.Count > 0)
                    {
                        try
                        {
                            lua.Global.Get<XLua.LuaFunction>("tiggerCB").Call(toRun[0].id, toRun[0].type, toRun[0].data);
                        }
                        catch(Exception le)
                        {
                            LuaApi.PrintLog("回调报错：\r\n" + le.Message);
                        }
                        if (tokenSource.IsCancellationRequested)
                            return;
                        toRun.RemoveAt(0);
                    }
                }
            }
            catch (Exception ex)
            {
                StopLua(ex.ToString());
            }
        }

        /// <summary>
        /// 新建定时器
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="time">时间(ms)</param>
        public static int StartTimer(int id,int time)
        {
            CancellationTokenSource timerToken = new CancellationTokenSource();
            pool.Add(id, timerToken);
            Task.Run(() => 
            {
                Task.Delay(time).Wait();
                if (timerToken == null || timerToken.IsCancellationRequested)
                    return;
                if (tokenSource.IsCancellationRequested)
                    return;
                addTigger(id);
                pool.Remove(id);
            }, timerToken.Token);
            return 1;
        }

        /// <summary>
        /// 停止定时器
        /// </summary>
        /// <param name="id">编号</param>
        public static void StopTimer(int id)
        {
            if(pool[id] != null)
            {
                pool[id].Cancel();
                pool.Remove(id);
            }
        }

        /// <summary>
        /// 停止运行lua
        /// </summary>
        public static void StopLua(string ex)
        {
            LuaRunError(null, EventArgs.Empty);
            if (ex != "")
                LuaApi.PrintLog("lua代码报错了：\r\n" + ex);
            else
                LuaApi.PrintLog("lua代码已停止");
            foreach(var v in pool)
            {
                v.Value.Cancel();
            }
            isRunning = false;
            tokenSource.Cancel();
            pool.Clear();
            lua = null;
        }

        /// <summary>
        /// 新建一个新的lua虚拟机
        /// </summary>
        public static void New(string script)
        {
            if (tokenSource != null)
                tokenSource.Dispose();
            tokenSource = new CancellationTokenSource();//task取消指示
            
            lua = LuaEnv.CreateLuaEnv();
            isRunning = true;
            Task.Run(() =>
            {
                try
                {
                    lua.Global.SetInPath("sys", lua.DoString(Global.Utils.GetAssetsFileContent("/Assets/script/sys.lua"))[0]);
                    lua.DoString("apiStartTimer = CS.LUATeach.LuaEnv.LuaRunEnv.StartTimer");
                    lua.DoString("apiStopTimer = CS.LUATeach.LuaEnv.LuaRunEnv.StopTimer");
                    lua.DoString("setRunMaxSeconds(-1)");
                    lua.DoString(script);
                }
                catch (Exception ex)
                {
                    StopLua(ex.Message);
                }
                runTigger();
            }, tokenSource.Token);
        }
    }


    class LuaPool
    {
        public int id { get; set; }
        public string type { get; set; }
        public string data { get; set; }
    }
}
