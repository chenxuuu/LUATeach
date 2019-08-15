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
        public static int selected = 1;

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
            new LevelTemple
            {
                title = "世界你好！",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "第一次亲自编写Lua代码",
                question = "学习Lua，与学习其他语言一样，需要熟能生巧。现在我们来尝试编写第一个Lua程序吧！\r\n\r\n" +
                "在下面的代码区域，补全代码，使代码输出`Hello World!`\r\n\r\n" +
                "你要做的事：确保输入法在英文状态下；在下面代码的两个括号间，添加`\"Hello World!\"`内容。",
                code = "print()",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };
                    
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv()) //新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;//注册委托
                        try
                        {
                            lua.DoString(s);//跑代码
                        }
                        catch (Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;//取消委托
                        if(r != null)//如果有错误信息
                            return r;
                        if(output.ToUpper() == "HELLO WORLD!")
                            return null;
                        else
                            return $"输出的结果不对，你输出的是：\r\n{output}";
                    }
                },
                explain = "实践才是检验真理的唯一标准，要经常到运行lua脚本运行器测试代码哦~",
            },
            new LevelTemple
            {
                title = "输出数据",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "尝试输出自己想输出的数据",
                question = "在Lua中，可以使用`print`函数来打印你想要得到的结果。\r\n\r\n" +
                "注：`函数`是指可以实现某些功能的子程序，可以使用`函数名(参数)`来执行。\r\n\r\n" +
                "让我们试着输出一些其他东西吧！使用多个`print`函数，输出自己想输出的数据。",
                code = "--你需要使用多个print函数来输出数据\r\n" +
                "--输出任意数据都可以，参考上一节的写法\r\n" +
                "print(\"12344\")\r\n",
                check = (s) =>
                {
                    string r = null;
                    int output = 0;
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output++;
                    };

                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv()) //新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;//注册委托
                        try
                        {
                            lua.DoString(s);//跑代码
                        }
                        catch (Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;//取消委托
                        if(r != null)//如果有错误信息
                            return r;
                        if(output > 1)
                            return null;
                        else
                            return $"不是这样哦，你需要使用多个print函数来输出数据，输出任意数据都可以\r\n记住是多个print函数。";
                    }
                },
                explain = "在Lua中，几乎所有数据都能使用print来输出。善于使用输出打印，可以帮助你调试代码哦。",
            },
            new LevelTemple
            {
                title = "number变量",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "初识变量",
                question = "`变量`，就像一个桶，可以装你想要装的内容。这些内容可以是Lua包含的所有合法类型。\r\n\r\n" +
                "例如：我想要新建一个桶，名叫`bucket`，在里面放入233这个数字，就可以像下面一样：\r\n\r\n" +
                "```lua\r\nbucket = 233\r\n```\r\n\r\n" +
                "让我们试着自己新建几个变量吧！\r\n\r\n" +
                "你要做的事：\r\n\r\n" +
                "新建变量`year`，并将变量的值设置为`1926`\r\n\r\n" +
                "新建变量`month`，并将变量的值设置为`8`\r\n\r\n" +
                "新建变量`day`，并将变量的值设置为`7`\r\n\r\n",
                code = "--你需要使用多个赋值语句来新建变量\r\n",
                check = (s) =>
                {
                    string r = null;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            lua.DoString(s);//跑代码
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;
                        
                        if((bool)lua.DoString("return year == 1926 and month == 8 and day == 7")[0])
                            return null;
                        else
                            return "三个变量的结果不对哦";
                    }
                },
                explain = "变量可以用来存储数据，以此来实现计算等复杂的功能。",
            },
            new LevelTemple
            {
                title = "输出变量",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "尝试输出变量的值",
                question = "在Lua中，可以使用`print`函数来打印你想要得到的结果。\r\n\r\n" +
                "同时在上一节，我们学会了新建变量和设置变量的值。\r\n\r\n" +
                "让我们试着输出某个变量吧！使用`print`函数，输出已知变量。\r\n" +
                "我们已知变量`num`为某个数字，试着输出它的值吧！",
                code = "--已知num是一个变量，输出变量num的值\r\n",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };

                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv()) //新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;//注册委托
                        try
                        {
                            lua.DoString("num = 93174928");
                            lua.DoString(s);//跑代码
                        }
                        catch (Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;//取消委托
                        if(r != null)//如果有错误信息
                            return r;
                        if(output == "93174928")
                            return null;
                        else
                            return $"输出的结果不对，你输出的是：\r\n{output}";
                    }
                },
                explain = "学会使用打印来调试代码，是一项必备技能。",
            },
            new LevelTemple()
            {
                title = "后面还没写",
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
                case LevelType.code:
                    page = "CodingPage";
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
        public string title { get; set; } = "空标题";
        /// <summary>
        /// 题目类型（给人看的）
        /// </summary>
        public string type { get; set; } = "空类型";
        /// <summary>
        /// 题目类型
        /// </summary>
        public LevelType levelType { get; set; } = LevelType.choice;
        /// <summary>
        /// 题目简介
        /// </summary>
        public string infomation { get; set; } = "空简介";
        /// <summary>
        /// 问题内容
        /// </summary>
        public string question { get; set; } = "空内容";
        /// <summary>
        /// 初始代码（仅限编程题），就是用户还没开始做题时，代码区域初始的代码内容
        /// </summary>
        public string code { get; set; } = "";
        /// <summary>
        /// 检查函数（仅限编程题），返回null即为成功，其他有内容的结果即为有问题
        /// </summary>
        public Func<string, string> check { get; set; } = (s) => { return null; };
        /// <summary>
        /// 选择题的题目（仅限选择题）
        /// </summary>
        public string choiceTitle { get; set; } = "空题目";
        /// <summary>
        /// 选择题的选项（仅限选择题）
        /// </summary>
        public string[] choices { get; set; } = new string[]{ "空选项", "空选项", "空选项", "空选项", };
        /// <summary>
        /// 选择题的正确答案（仅限选择题）
        /// </summary>
        public int choice { get; set; } = 1;
        /// <summary>
        /// 答题结束后的解释
        /// </summary>
        public string explain { get; set; } = "空解释";
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
