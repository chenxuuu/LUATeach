using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUATeach.Global
{
    class Levels
    {
        /// <summary>
        /// 选了哪个
        /// </summary>
        public static int selected = 0;

        /// <summary>
        /// 题目列表
        /// </summary>
        public static List<LevelTemple> LevelList = new List<LevelTemple>
        {
            new LevelTemple
            {
                title = "初识Lua",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "介绍Lua的基础知识",
                question = 
                "Lua 是一种轻量小巧的脚本语言，它用标准C语言编写并以源代码形式开放，编译后仅仅一百余K，" +
                "可以很方便的嵌入别的程序里，从而为应用程序提供灵活的扩展和定制功能。\r\n\r\n" +
                "在目前脚本引擎中，Lua的速度占有优势。这些都决定了Lua是作为嵌入式脚本的最佳选择。\r\n\r\n" +
                "Lua还具有其它一些特性：同时支持面向过程(procedure-oriented)编程和函数式编程(functional programming)；" +
                "自动内存管理；只提供了一种通用类型的表（table），用它可以实现数组，哈希表，集合，对象；语言内置模式匹配；" +
                "闭包(closure)；函数也可以看做一个值；提供多线程（协同进程，并非操作系统所支持的线程）支持；" +
                "通过闭包和table可以很方便地支持面向对象编程所需要的一些关键机制，比如数据抽象，虚函数，继承和重载等。",
                choiceTitle = "下面选项中，错误的是？",
                choices = new string[4]
                {
                    "Lua是一种脚本语言",
                    "Lua是使用C语言编写的",
                    "Lua是脚本引擎中运行最慢的",
                    "Lua可以实现面向对象的编程",
                },
                choice = 3,
                explain = "Lua在目前所有脚本引擎中，速度几乎是最快的。",
            },
        };

        /// <summary>
        /// 获取显示题目的页面名称
        /// </summary>
        /// <returns></returns>
        public static string GetPage()
        {
            string page;
            switch (LevelList[selected].levelType)
            {
                case LevelType.choice:
                    page = "IntroducePage";
                    break;

                default:
                    page = "";
                    break;
            }
            return page;
        }
    }



    class LevelTemple
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 题目类型（给人看的）
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 题目类型
        /// </summary>
        public LevelType levelType { get; set; }
        /// <summary>
        /// 题目简介
        /// </summary>
        public string infomation { get; set; }
        /// <summary>
        /// 问题内容
        /// </summary>
        public string question { get; set; }
        /// <summary>
        /// 初始代码（仅限编程题）
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 检查函数（仅限编程题）
        /// </summary>
        public Func<bool> check { get; set; }
        /// <summary>
        /// 选择题的题目（仅限选择题）
        /// </summary>
        public string choiceTitle { get; set; }
        /// <summary>
        /// 选择题的选项（仅限选择题）
        /// </summary>
        public string[] choices { get; set; }
        /// <summary>
        /// 选择题的正确答案（仅限选择题）
        /// </summary>
        public int choice { get; set; }
        /// <summary>
        /// 答题结束后的解释
        /// </summary>
        public string explain { get; set; }
    }

    enum LevelType
    {
        /// <summary>
        /// 选择题
        /// </summary>
        choice,
        /// <summary>
        /// 代码题
        /// </summary>
        code,
    }
}
