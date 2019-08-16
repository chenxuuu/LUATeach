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
                choiceTitle = "下面选项中，正确的是？",
                choices = new string[4]
                {
                    "Lua不是一种脚本语言",
                    "Lua不是使用C语言编写的",
                    "Lua不是脚本引擎中运行最慢的",
                    "Lua不可以实现面向对象的编程",
                },
                choice = 3,
                explain = "Lua在目前所有脚本引擎中，速度几乎是最快的。",
            },
            new LevelTemple
            {
                title = "世界你好",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "第一次亲自编写Lua代码",
                question = "学习Lua，与学习其他语言一样，需要熟能生巧。现在我们来尝试编写第一个Lua程序吧！\r\n\r\n" +
                "在下面的代码区域，补全代码，使代码输出`Hello World`\r\n\r\n" +
                "你要做的事：确保输入法在英文状态下；在下面代码的两个括号间，添加`\"Hello World\"`内容。",
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
                        if(output.ToUpper().Replace(" ","") == "HELLOWORLD")
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
                question = "`变量`，可以看作是一个桶，在里面装你想要装的内容。这些内容可以是Lua包含的所有合法类型。\r\n\r\n" +
                "例如：我想要新建一个桶，名叫`bucket`，在里面放入233这个数字，就可以像下面一样：\r\n\r\n" +
                "```lua\r\nbucket = 233\r\n```\r\n\r\n" +
                "让我们试着自己新建几个变量吧！\r\n\r\n" +
                "你要做的事：\r\n\r\n" +
                "新建变量`year`，并将变量的值设置为`1926`\r\n\r\n" +
                "新建变量`month`，并将变量的值设置为`8`\r\n\r\n" +
                "新建变量`day`，并将变量的值设置为`7`\r\n\r\n",
                code = "--你需要使用多个赋值语句来新建变量\r\n" +
                "year = \r\n",
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
                title = "交换变量",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "用变量做些事情",
                question = 
                "你要做的事：\r\n\r\n" +
                "已知变量`a`和`b`，请交换它们所存储的值",
                code = "--你需要新建变量来完成这个题目\r\n" +
                "--a和b均是已经声明过的变量\r\n" +
                "a = \r\n",
                check = (s) =>
                {
                    string r = null;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            lua.DoString("a=25245324\r\nb=4332421");
                            lua.DoString(s);//跑代码
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if((bool)lua.DoString("return b==25245324 and a==4332421")[0])
                            return null;
                        else
                            return "结果不对哦";
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
                code = "--已知num是一个变量，输出变量num的值\r\n" +
                "--已知 num = 某个值\r\n" +
                "print(换成你要输出的东西)",
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
            new LevelTemple
            {
                title = "算数运算符",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "对number变量进行计算",
                question = "运算符是一个特殊的符号，用于告诉解释器执行特定的数学或逻辑运算。\r\n\r\n" +
                "上一节中，新建的数字变量，我们称之为`number`类型的变量。\r\n\r\n" +
                "本节我们来学习使用`算术运算符`，如下所示：\r\n\r\n" +
                @"```
+ 加法
- 减法
* 乘法
/ 除法
% 取余，求出除法的余数
^ 乘幂，计算次方
- 负号，取负值
```" + "\r\n\r\n"+
                "我们可以通过以下实例来理解算术运算符的应用：\r\n\r\n" +
                @"```lua
a = 21
b = 10
c = a + b
print('a + b 的值为 ', c )
c = a - b
print('a - b 的值为 ', c )
c = a * b
print('a * b 的值为 ', c )
c = a / b
print('a / b 的值为 ', c )
c = a % b
print('a % b 的值为 ', c )
c = a^2
print('a^2 的值为 ', c )
c = -a
print('-a 的值为 ', c )
c = a * (b - a)
print('a * (b - a) 的值为 ', c )
```

以上程序执行结果为：

```
a + b 的值为     31
a - b 的值为     11
a * b 的值为     210
a / b 的值为     2.1
a % b 的值为     1
a^2 的值为     441
-a 的值为     -21
a * (b - a) 的值为     -231‬
```

你需要完成的事：

已知，一个长方体的长宽高分别为`a`、`b`、`c`（单位米），

且这个物体重量为`m`（单位克）

请你新建一个变量`p`，并将物体的密度存入其中（单位g/m³）

注：密度计算公式 密度 = 质量 / 体积
",
                code = "--你需要计算这个物体的密度，存入变量p\r\n" +
                @"-- 下面几个变量是已知的值，不需要你来改动
-- a = 132
-- b = 230
-- c = 31
-- m = 18

-- 你需要用代码，计算出密度，存入p中
p = ",
                check = (s) =>
                {
                    string r = null;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            lua.DoString(@"a = 132
b = 230
c = 31
m = 62419");
                            lua.DoString(s);//跑代码
                            lua.DoString(@"a = 132
b = 230
c = 31
m = 62419");
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if((bool)lua.DoString("return p == m/(a*b*c)")[0])
                            return null;
                        else
                            return "密度的结果不对。记得用公式来算，并且不要忘记括号哦";
                    }
                },
                explain = "恭喜你理解了算数运算符",
            },
            new LevelTemple
            {
                title = "string变量",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "字符串变量",
                question = "字符串（即string），就是一串文本数据，可以存储你要的文本。\r\n\r\n" +
                "在第二节中，print出的数据就是一个字符串。\r\n\r\n" +
                @"Lua 语言中字符串可以使用以下三种方式来表示：

1. 单引号间的一串字符。
2. 双引号间的一串字符。
3. [[和]]间的一串字符。

你可以参考下面的例子来深入理解：

```lua
--双引号间的一串字符
str1 = " + "\"Lua\"" + @"
--单引号间的一串字符
str2 = 'Lua'
--[[和]]间的一串字符
str3 = [[Lua]]
str4 = [[使用双括号时，甚至能包含换行数据
换行了
最后一行]]

--输出所有字符串
print(str1)
print(str2)
print(str3)
print(str4)
```

输出结果：

```
Lua
Lua
Lua
使用双括号时，甚至能包含换行数据
换行了
最后一行
```

你需要完成的事：

新建三个变量`s1`、`s2`、`s3`

分别存入字符串数据：`str`、`abc`、`233`",
                code = "--新建三个字符串变量，并设置值\r\n" +
                "--你可以使用任意方式赋值\r\n" +
                "s1 = \"str\"\r\n" +
                "s2 = ",
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

                        if((bool)lua.DoString("return s1 == 'str' and s2 == 'abc' and s3 == '233'")[0])
                            return null;
                        else
                            return "三个变量的结果不对哦";
                    }
                },
                explain = "下一节教你如何使用转义符号，存储特殊字符",
            },
            new LevelTemple
            {
                title = "转义字符",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "学习如何使用",
                question = @"在上一节中，我们学习了如何声明字符串。

但是我们有时候会遇到一些特殊的问题，如：如何输出单引号和双引号？如何输出回车换行？

也许我们可以用下面的方式简单规避，输出单引号时，声明字符串用双引号括起来，像下面这样

```lua
str = "+"\"'\""+@"
```

同理，输出双引号时，声明字符串用单引号括起来，像下面这样

```lua
str = '"+"\""+@"'
```

但是，这样会出现一个问题：如何同时显示单引号和双引号？这里就需要转义字符登场了。

转义字符用于表示不能直接显示的字符，比如后退键、回车键、等。

以 `\` 开头的都是转义字符，下面时常用的转义字符格式：

|转义字符|含义|
|-|-|
|\n|换行(LF),将当前位置移到下一行开头|
|\r|回车(CR),将当前位置移到本行开头|
|\\\\|反斜杠字符\\|
|\\'|单引号|
|\\"+"\""+@"|双引号|
|\0|空字符(NULL)|
|\ddd|1到3位八进制数所代表的任意字符|
|\xhh|1到2位十六进制所代表的任意字符|

例如，如果我们想给str赋值一个单引号，一个双引号，那么我们可以这样写：

```lua
str = "+"\"\\'\\\"\""+@"
```

下面就是做题部分了，你需要实现下面的功能：

新建一个变量`str`，给`str`赋值为

`"+"ab\\cd\"ef\'g\\h]]"+@"`
",
                code = @"--这里为了让你理解得更好，举个例子
--比如我需要给s变量赋值下面的字符串
--1122\4455'ass"+"\""+@"233
--那么我们可以写成下面这样：
s = "+"\""+@"1122\\4455\'ass"+"\\\""+@"233"+"\""+@"

--下面就由你来完成题目的要求了
str = 
",
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

                        if((bool)lua.DoString("return str == [[ab\\cd\"ef\'g\\h]]..']]'")[0])
                            return null;
                        else
                            return "str变量的结果不对哦，你现在的值是\r\n" + 
                            (string)lua.DoString("return type(str) == \"string\" and str or \"str不是字符串\"")[0];
                    }
                },
                explain = "下一节教你如何使用转义符号，存储特殊字符",
            },
            new LevelTemple
            {
                title = "字符串知识点检查",
                type = "小测验",
                levelType = LevelType.choice,
                infomation = "一道小测试题目",
                question =
                "经前面的学习，相信大家已经熟练掌握了字符串的使用方式\r\n\r\n" +
                "那么，问题来了，如果我想定义一个字符串，内容如下，应该怎么做？\r\n\r\n" +
                "```\r\n12\\3\"9\']]\r\n```",
                choiceTitle = "下面选项中，正确的是？",
                choices = new string[4]
                {
                    "str=[[12\\3\"9\']]]]",
                    "str='12\\3\"9\']]'",
                    "str=\"12\\\\3\\\"9\']]\"",
                    "str=\'12\\\\3\"9\\\']]\'",
                },
                choice = 4,
                explain = "该部分为基础，应熟练掌握",
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
