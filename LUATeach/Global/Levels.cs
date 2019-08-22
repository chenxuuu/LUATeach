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
                "你要做的事：确保输入法在英文状态下；在下面代码的两个括号间，添加`\"Hello World\"`内容\r\n" +
                "注意：--开头的语句，后面的内容都是注释，在代码里不会运行，仅用来讲解。在你自己编程时也需要使用注释，来防止自己忘记代码表达的含义。",
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
                title = "nil",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "了解nil",
                question =
                @"nil 类型表示没有任何有效值，只要是没有声明的值，它就是nil

比如我打印一个没有声明的值，便会输出nil：

```lua
ccc = 233
print(ccc)
print(aaa)
```

输出：

```
233
nil
```

下面问题来了，运行以下代码，将会输出什么结果？

```lua
a = 1
b = '2'
c = a
print(a,b,c,d)
```
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "1  2  nil nil",
                    "1  2  2  nil",
                    "1  2  1  2",
                    "1  2  1  nil",
                },
                choice = 4,
                explain = "nil 类型表示没有任何有效值",
            },
            new LevelTemple
            {
                title = "赋值语句",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "介绍Lua的赋值操作",
                question = @"赋值是改变一个变量值的最基本的方法。

如下面一样，使用等号对左边的变量进行赋值

```lua
n = 2
n = 3
n = n + 1
b = n
```

Lua 可以对多个变量同时赋值，变量用逗号分开，赋值语句右边的值会依次赋给左边的变量。 

```lua
n = 1
a, b = 10, 2*n
```

当左右值的数量不一致时，Lua会进行下面的设定

变量个数 > 值的个数：按变量个数补足nil

变量个数 < 值的个数：多余的值会被忽略

下面的例子可以展示这种设定：

```lua
a, b, c = 0, 1
print(a,b,c)
--输出0   1   nil
 
a, b = a+1, b+1, b+2
print(a,b)
--输出1   2
 
a, b, c = 0
print(a,b,c)
--输出0   nil   nil
```

下面我们使用如下代码，由你来判断正确的输出结果是什么：

```lua
a,b,c = 1,2,3
a,c = a+1,b
d = c,b
print(a,b,c,d)
```
",
                choiceTitle = "下面结果中，正确的是？",
                choices = new string[4]
                {
                    "2 nil 3 2",
                    "2 2 3 2",
                    "1 nil 2 2",
                    "2 2 2 2",
                },
                choice = 4,
                explain = "变量赋值是基础语法，需要熟练掌握",
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
                "--a和b均是已经声明过的变量\r\n\r\n\r\n" +
                "a = \r\nb = ",
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
            new LevelTemple
            {
                title = "变量知识点检查",
                type = "小测验",
                levelType = LevelType.choice,
                infomation = "一道小测试题目",
                question =
                "已知有下面两个新声明的变量：\r\n\r\n" +
                "```\r\nvar1 = 233\r\nvar2 = \"233\"\r\n```",
                choiceTitle = "下面描述的类型，正确的是？",
                choices = new string[4]
                {
                    "var1是string，var2是number",
                    "var1是string，var2是string",
                    "var1是number，var2是number",
                    "var1是number，var2是string",
                },
                choice = 4,
                explain = "该部分为基础，应熟练掌握",
            },
            new LevelTemple
            {
                title = "string拼接",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "学会字符串拼接符号",
                question = "字符串和字符串可以相加吗？可以！我们可以用拼接符号来将两个独立的字符串拼起来。\r\n\r\n" +
                "我们使用`..`来表示字符串拼接符号，如下面的示例代码：\r\n\r\n" +
                @"```lua
print('abc'..'def')
str1 = '123'
str2 = '999'
print(str1..str2)
```

输出结果如下：

```
abcdef
123999
```

下面你要完成这个任务：

已知三个字符串变量`s1`、`s2`、`s3`

请将他们按顺序拼接起来，并使用print输出结果
",
                code = "--已知三个字符串变量\r\n" +
                "--s1=某字符串\r\n" +
                "--s2=某字符串\r\n" +
                "--s3=某字符串\r\n" +
                "--请将它们拼起来，并用print输出结果\r\n" +
                "print()",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;//注册委托
                        try
                        {
                            lua.DoString(@"
s1 = 'sdfsdf'
s2 = '98867uyerew'
s3 = 'wrefsdf'
");
                            lua.DoString(s);//跑代码
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;//取消委托
                        if(r != null)//如果有错误信息
                            return r;

                        if(output=="sdfsdf98867uyerewwrefsdf")
                            return null;
                        else
                            return $"结果不对哦，你输出的是：\r\n{output}";
                    }
                },
                explain = "注意这种方式尽量少用，因为string需要连续的内存来存储。",
            },
            new LevelTemple
            {
                title = "number转string",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "学会tostring的用法",
                question = @"上面一节学习了如何拼接字符串，这个方法固然很好用，但是有时候我们会遇到一个需求，那就是把number类型的变量和string类型的变量拼接起来，组成一个新的string

比如下面的变量`n`和`s`，如何拼接起来呢？

```lua
n = 123
s = 'm/s'
```

我们可以直接将`number`类型的变量`n`转换成string类型的值，这样就可以拼接了

使用`tostring(value)`函数即可实现这一操作：

```lua
n = 123
s = 'm/s'

result = tostring(n)..s
```

下面你要完成这个任务：

已知三个变量`n1`、`s`、`n2`

然后将他们按顺序拼接起来，并使用print输出结果

小提示：在某些情况下，Lua会自动将number类型转换成string类型
",
                code = "--已知三个变量\r\n" +
                "--n1=某number类型变量\r\n" +
                "--s =某string类型变量\r\n" +
                "--n2=某number类型变量\r\n" +
                "--请将它们拼起来，并用print输出结果\r\n" +
                "print()",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;//注册委托
                        try
                        {
                            lua.DoString(@"
n1 = 21983213
s = '98867uyerew'
n2 = 48743293
");
                            lua.DoString(s);//跑代码
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;//取消委托
                        if(r != null)//如果有错误信息
                            return r;

                        if(output=="2198321398867uyerew48743293")
                            return null;
                        else
                            return $"结果不对哦，你输出的是：\r\n{output}";
                    }
                },
                explain = "小知识：tostring函数几乎可将所有其他类型都转成string",
            },
            new LevelTemple
            {
                title = "string转number",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "学会tonumber的用法",
                question = @"上面一节学习了如何将number转成string，这一节我们来学习如何将string转成number

比如下面的变量`s`，存储的内容是一个字符串，但是代表了一个数字，如何转成number再与n相加计算呢？

```lua
n = 123
s = '2333'
```

我们可以直接将`string`类型的变量`s`转换成number类型的值，这样就可以计算了

使用`tonumber(value)`函数即可实现这一操作：

```lua
n = 123
s = '2333'

result = tonumber(s) + n
```

下面你要完成这个任务：

已知三个字符串变量`s1`、`s2`、`s3`，其内容均为纯数字

请计算他们的算术和，并将结果转成字符串，赋值给新建的变量`result`
",
                code = "--已知三个变量\r\n" +
                "--s1 = 某string类型变量\r\n" +
                "--s2 = 某string类型变量\r\n" +
                "--s3 = 某string类型变量\r\n" +
                "--请计算他们的算术和，\r\n" +
                "--并将结果转成字符串，赋值给新建的变量result\r\n" +
                "\r\n\r\nresult = ",
                check = (s) =>
                {
                    string r = null;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            lua.DoString(@"
s1 = '4352424'
s2 = '48743293'
s3 = '214513'
");
                            lua.DoString(s);//跑代码
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if((bool)lua.DoString("return result == '53310230'")[0])
                            return null;
                        else if((bool)lua.DoString("return type(result) == 'number'")[0])
                            return $"注意审题，result需要是string类型的，现在它是number";
                        else
                            return $"结果不对哦，请重新检查";
                    }
                },
                explain = "string和number互相转换，你应该掌握了这个简单的内容",
            },
            new LevelTemple
            {
                title = "布尔型和比较符号",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "了解boolean与比较符号判断",
                question =
                @"布尔型（boolean）只有两个可选值：`true`（真） 和 `false`（假）

Lua 把 false 和 nil 看作是`false`，其他的都为`true`（包括0这个值，也是相当于`true`）

Lua 中也有许多的`关系运算符`，用于比较大小或比较是否相等，符号及其含义如下表：

|符号|含义|
|-|-|
|==|等于，检测两个值是否相等，相等返回 true，否则返回 false|
|~=|不等于，检测两个值是否相等，相等返回 false，否则返回 true|
|>|大于，如果左边的值大于右边的值，返回 true，否则返回 false|
|<|小于，如果左边的值大于右边的值，返回 false，否则返回 true|
|>=|大于等于，如果左边的值大于等于右边的值，返回 true，否则返回 false|
|<=|小于等于， 如果左边的值小于等于右边的值，返回 true，否则返回 false|

我们可以通过以下实例来更加透彻的理解关系运算符的应用：

```lua
a = 21
b = 10
print('==的结果',a==b)
print('~=的结果',a~=b)
print('>的结果',a>b)
print('<的结果',a<b)
print('>=的结果',a>=b)
print('<=的结果',a<=b)
```

上面代码将会输出如下结果：

```
==的结果    false
~=的结果    true
>的结果    true
<的结果    false
>=的结果    true
<=的结果    false
```

下面问题来了，运行以下代码，将会输出什么结果？

```lua
a = 1
b = '1'
c = a
d = 2

print(
a == b,
c == a,
a ~= b,
d <= c
)
```
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "运行报错",
                    "false false true true",
                    "false true false false",
                    "false true true false",
                },
                choice = 4,
                explain = "布尔型一般被用来作为判断依据使用，是编程中重要的部分",
            },
            new LevelTemple
            {
                title = "逻辑运算符",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "了解逻辑运算符",
                question =
                @"逻辑运算符基于布尔型的值来进行计算，并给出结果，下表列出了 Lua 语言中的常用逻辑运算符：

|符号|含义|
|-|-|
|and|逻辑与操作符。 若 A 为 false，则返回 A，否则返回 B|
|or|逻辑或操作符。 若 A 为 true，则返回 A，否则返回 B|
|not|逻辑非操作符。与逻辑运算结果相反，如果条件为 true，逻辑非为 false|

我们可以通过以下实例来更加透彻的理解逻辑运算符的应用：

```lua
print('true and false的结果',true and false)
print('true or false的结果',true or false)
print('true and true的结果',true and true)
print('false or false的结果',false or false)
print('not false的结果',not false)
print('123 and 345的结果',123 and 345)
print('nil and true的结果',nil and true)
```

上面代码将会输出如下结果：

```
true and false的结果    false
true or false的结果    true
true and true的结果    true
false or false的结果    false
not false的结果    true
123 and 345的结果    345
nil and true的结果    nil
```

下面问题来了，运行以下代码，将会输出什么结果？

```lua
a = 1
b = '1'
c = 0

print(
a and b,
c or a,
not b,
d and c
1 < 2 and 3 > 2
)
```
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "运行报错",
                    "1 1 true nil true",
                    "1 1 false nil false",
                    "1 0 false nil true",
                },
                choice = 4,
                explain = "利用逻辑运算符，可以实现多个条件的共同判断",
            },
            new LevelTemple
            {
                title = "检验大小",
                type = "知识点",
                levelType = LevelType.choice,
                infomation = "判断数字是否在这个区间内",
                question =
                @"题目：如果已知number变量`n`，那么如果需要判断`n`是否符合下面的条件：

3<n≤10

以下代码正确的是？

（返回true即为符合要求）
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "n < 3 and n >= 10",
                    "n > 10 or n <= 3",
                    "n <= 10 or n > 3",
                    "n <= 10 and n > 3",
                },
                choice = 4,
                explain = "利用逻辑运算符，可以实现多个条件的共同判断",
            },
            new LevelTemple
            {
                title = "条件判断",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "初步学习if语句",
                question = @"上面一节学习了布尔类型，那么这个需要用到哪里呢？我们需要用它来进行某些判断。

在Lua中，可以使用`if`语句来进行判断，如下面所举例的代码，可以判断`n`是否为小于10的数：

```lua
n = 5
if n < 10 then
    print('n小于10')
end
```

我们整理一下，实际上if语句就是如下结构：

```lua
if 条件 then
    符合条件的代码
end
```

下面是你需要完成的事：

已知变量`n`，请判断n是否为奇数，如果是，请给`n`的值加上1


```
如果你觉得有难度，请查看下面的提示：
求出`n`除以2的余数：n % 2
给`n`的值加上1：n = n + 1
```
",
                code = "--已知一个number变量n\r\n" +
                "--n = 某number类型变量\r\n\r\n" +
                @"if 你的条件 then
    要做的事
end",
                check = (s) =>
                {
                    string r = null;
                    bool pass = false;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            Random ra = new Random();
                            for(int i=1;i<=100;i++)
                            {
                                int temp = ra.Next(1,300);
                                lua.DoString($"n={temp}");
                                lua.DoString(s);//跑代码

                                if (!(bool)lua.DoString($"return n == ({temp}%2==1 and {temp}+1 or {temp})")[0])
                                {
                                    r = $"当n为{i}时，结果不对";
                                    break;
                                }

                                if(i==10)//通过检测
                                    pass = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if(pass)
                            return null;
                        else
                            return $"这个代码无法通过验证哦，请检查";
                    }
                },
                explain = "使用if可以完成逻辑判断",
            },
            new LevelTemple
            {
                title = "多条件判断",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "初步学习if else语句",
                question = @"上面一节学习了简单的if语句写法，这一节我们来学习多条件分支语句

在Lua中，可以使用`if`语句来进行判断，同时可以使用else语句，表示多个分支判断

```lua
if 条件1 then
    满足条件1
elseif 条件2 then
    不满足条件1，但是满足条件2
else
    前面条件全都不满足
end
```

举个例子，比如有一个数字`n`，

当它大于等于0、小于5时，输出`太小`，

当它大于等于5、小于10时，输出`适中`，

当它大于等于10时，输出`太大`，

那么代码就像如下这样：

```lua
if n >= 0 and n < 5 then
    print('太小')
elseif n >= 5 and n < 10 then
    print('适中')
elseif n >= 10 then
    print('太大')
end
```

注意：`else`和`elseif`都是可选的，可有可无，但是`end`不能省略

下面是你需要完成的事：

已知变量`n`，请判断n是否为奇数，

如果是，请给`n`的值加上1

如果不是，请将`n`的值改为原来的两倍
",
                code = "--已知一个number变量n\r\n" +
                "--n = 某number类型变量\r\n\r\n" +
                @"if 你的条件 then
    要做的事
else
    要做的事
end",
                check = (s) =>
                {
                    string r = null;
                    bool pass = false;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        try
                        {
                            Random ra = new Random();
                            for(int i=1;i<=10;i++)
                            {
                                int temp = ra.Next(1,100);
                                lua.DoString($"n={temp}");
                                lua.DoString(s);//跑代码

                                if (!(bool)lua.DoString($"return n == ({temp}%2==1 and {temp}+1 or {temp}*2)")[0])
                                {
                                    r = $"当n为{temp}时，结果不对";
                                    break;
                                }

                                if(i==10)//通过检测
                                    pass = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if(pass)
                            return null;
                        else
                            return $"这个代码无法通过验证哦，请检查";
                    }
                },
                explain = "使用if可以完成逻辑判断",
            },
            new LevelTemple
            {
                title = "判断三角形合法性",
                type = "小测验",
                levelType = LevelType.code,
                infomation = "关于条件判断的小测试",
                question = @"你需要使用前面几章的知识，来完成下面的题目

已知三个number类型的变量`a`、`b`、`c`，分别代表三根木棒的长度

请判断，使用这三根木棒，是否可以组成一个三角形（两短边之和大于第三边）

如果可以组成，就新建一个变量result，并赋值为true
",
                code = @"--请判断三角形是否合法
--a = 某number类型变量
--b = 某number类型变量
--c = 某number类型变量
-- 还需要新建一个result变量存储结果




",
                check = (s) =>
                {
                    string r = null;
                    bool pass = false;
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        Random ran = new Random();
                        try
                        {
                            for(int i=1;i<=100;i++)
                            {
                                int x = ran.Next(1,10);
                                int y = ran.Next(1,10);
                                int z = ran.Next(1,10);
                                lua.DoString($"a={x}\r\nb={y}\r\nc={z}");
                                lua.DoString(s);//跑代码

                                if (!(bool)lua.DoString($"return result == (a+b>c and b+c>a and a+c>b)")[0])
                                {
                                    r = $"当a为{x}、b为{y}、c为{z}时，result结果不对";
                                    break;
                                }

                                if(i==10)//通过检测
                                    pass = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        if(r != null)//如果有错误信息
                            return r;

                        if(pass)
                            return null;
                        else
                            return $"这个代码无法通过验证哦，请检查";
                    }
                },
                explain = "实践出真知",
            },
            new LevelTemple
            {
                title = "if判断依据",
                type = "小测验",
                infomation = "加深if使用方法的印象",
                question =
                @"我们在前面了解到，Lua 把 false 和 nil 看作是`false`，其他的都为`true`（包括0这个值，也是相当于`true`）

那么问题来了，执行下面的代码，将会输出什么？

```lua
result = ''
if 0 then
    result = result..'T,'
else
    result = result..'F,'
end
if a then
    result = result..'T'
else
    result = result..'F'
end
```
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "T,T",
                    "F,F",
                    "F,T",
                    "T,F",
                },
                choice = 4,
                explain = "Lua 把 false 和 nil 看作是 false，其他的都为 true",
            },
            new LevelTemple
            {
                title = "初识函数",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "尝试编写函数",
                question = @"函数是指一段在一起的、可以做某一件事儿的程序，也叫做子程序。

在前面的内容中，我们已经接触过了函数的调用，这个函数就是前面用到了很多次的`print(...)`。

调用函数只需要按下面的格式即可：

```lua
函数名(参数1,参数2,参数3,......)
```

为何要使用函数？因为很多事情都是重复性操作，我们使用函数，可以快速完成这些操作

下面我们举一个最简单的函数例子，这个函数`没有传入参数、没有返回值`

它实现了一个简单的功能，就是输出`Hello world!`：

```lua
function hello()
    print('Hello world!')
end
```

这个函数名为`hello`，我们可以按下面的方法进行调用（执行）：

```lua
hello()
```

这行代码会输出`Hello world!`。

同时，在Lua中，函数也是一种变量类型，也就是说，`hello`实际上也是一个变量，里面存储的是一个函数，我们可以用下面的代码来理解：

```lua
a = hello
--把hello函数同时赋值给a变量
a()
--a和hello变量指向同一个函数
--所以执行结果和hello()相同
```

因为函数只是个变量，你甚至在一开始可以这样声明`hello`函数：

```lua
hello = function()
    print('Hello world!')
end
```

下面你需要做一件简单的事情：

新建一个函数变量`biu`，使其执行后会打印`biubiubiu`这个字符串，

新建一个函数变量`pong`，使其与`biu`指向的函数相同
",
                code = @"",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;
                        try
                        {
                            lua.DoString(s);//跑代码
                            lua.DoString("if biu then biu() end");
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;
                        if(r != null)//如果有错误信息
                            return r;

                        if(output == "biubiubiu" && (bool)lua.DoString("return pong == biu")[0])
                            return null;
                        else if(output != "biubiubiu")
                            return $"函数内容不对哦，没有输出正确结果";
                        else
                            return $"pong变量的内容不对哦，应与biu指向同一函数";
                    }
                },
                explain = "在Lua中，函数是对语句和表达式进行抽象的主要方法。既可以用来处理一些特殊的工作，也可以用来计算一些值。",
            },
            new LevelTemple
            {
                title = "local变量",
                type = "知识点",
                infomation = "了解定义域",
                question =
                @"之前我们创建的变量，都是全局变量，这种变量在代码运行周期从头到尾，都不会被销毁，而且随处都可调用。

但是当我们代码量增加，很多时候大量新建全局变量会导致内存激增，我们需要一种可以临时使用、并且可以自动销毁释放内存资源的变量，要怎么解决呢？

我们可以使用`local`标志来新建临时变量，使用`local`创建一个局部变量，与全局变量不同，局部变量只在被声明的那个代码块内有效。

参考下面的代码：

```lua
a = 123
function add()
    local n = a+2
    print(n)
end
add()
```

上面的代码中，`n`就是一个局部变量，它只在这个funcion中有效，并且函数运行完后会自动回收这部分的内存。

我们应该尽可能的使用局部变量，以方便lua虚拟机自动回收内存空间，同时减少资源占用提高运行速度。

下面请阅读以下代码，选出正确的输出结果：

```lua
str = 'abc'
function connect()
    local s = str..'def'
end
print(s,str)
```
",
                choiceTitle = "下面结果正确的是？",
                choices = new string[4]
                {
                    "nil nil",
                    "abc abcdef",
                    "nil abcdef",
                    "nil abc",
                },
                choice = 4,
                explain = "我们应该尽可能的使用局部变量",
            },
            new LevelTemple
            {
                title = "函数参数",
                type = "写代码",
                levelType = LevelType.code,
                infomation = "编写带参数的函数",
                question = @"在前几章的使用中，我们知道函数是可以传入参数的，如`print(123)`

那么，我们如何编写可以传入参数的函数呢？可以按下面的模板来写

```lua
function 函数名(参数1,参数2,...)
    代码内容
end
```

这里传入的参数，等价于在函数内部新建了一个`local`的变量，修改这些数据不会影响外部的数据（除了后面还没有讲到的table等类型）

举个例子，比如下面的函数，可以实现打印出两个传入值的和：

```lua
function add(a,b)
    print(a+b)
end
add(1,2)
--会输出3
```

这段代码其实等价于：
```
function add()
    local a = 1
    local b = 2
    print(a+b)
end
add()
```

下面问题来了，请设计一个函数`p`，可以按下面的调用方式来打印出物体的密度：

```lua
--一个长方体的长宽高分别为a、b、c（单位米）
a = 1
b = 2
c = 3
--这个物体重量为m（单位克）
m = 230
--下面打印出密度
--注：密度计算公式 密度 = 质量 / 体积
p(a,b,c,m)
```
",
                code = @"--补全代码，满足题目要求
function p(a,b,c,m)
    
    print()
end
",
                check = (s) =>
                {
                    string r = null;
                    string output = "";
                    EventHandler print = (sender,e) =>//print绑定的函数
                    {
                        output += sender as string;
                    };
                    using(var lua = LuaEnv.LuaEnv.CreateLuaEnv())//新建lua虚拟机
                    {
                        LuaEnv.LuaApi.PrintLuaLog += print;
                        try
                        {
                            lua.DoString(s);//跑代码
                            lua.DoString("if p then p(132,230,31,62419) end");
                        }
                        catch(Exception ex)
                        {
                            r = $"代码报错啦：{ex.Message}";
                        }
                        LuaEnv.LuaApi.PrintLuaLog -= print;
                        if(r != null)//如果有错误信息
                            return r;

                        if(output == (string)lua.DoString("return tostring(62419/(132*230*31))")[0])
                            return null;
                        else
                            return $"输出的内容不对哦，你输出的是：\r\n"+output;
                    }
                },
                explain = "传入值如果数量不够，那么少的部分就会使nil",
            },
            LevelByLua("function_return.lua"),
            LevelByLua("function_return2.lua"),
            LevelByLua("function_return3.lua"),
            LevelByLua("table1.lua"),

            new LevelTemple
            {
                title = "更多题目等待更新",
                type = "结尾",
                infomation = "现有题目做完啦",
                question =
                @"你已经到了末尾，你可以继续等待新题目，也可以去本项目贡献自己的题目：

https://github.com/chenxuuu/LUATeach
",
                choiceTitle = "下面没有正确答案",
                choices = new string[4]
                {
                    "xxxx",
                    "xxxx",
                    "xxxx",
                    "xxxx",
                },
                choice = 0,
                explain = "",
            },
        };


        /// <summary>
        /// 使用lua脚本来生成题目所需的信息
        /// </summary>
        /// <param name="file">文件，Assers/script/levels文件夹下</param>
        /// <returns>LevelTemple对象</returns>
        private static LevelTemple LevelByLua(string file)
        {
            var level = new LevelTemple();

            using (var lua = LuaEnv.LuaEnv.CreateLuaEnv())
            {
                lua.DoString(Global.Utils.GetAssetsFileContent($"/Assets/script/levels/{file}"));

                level.title = lua.Global.GetInPath<string>("title");
                level.type = lua.Global.GetInPath<string>("type");
                level.infomation = lua.Global.GetInPath<string>("infomation");
                level.question = lua.Global.GetInPath<string>("question");
                level.explain = lua.Global.GetInPath<string>("explain");
                level.code = lua.Global.GetInPath<string>("code");
                level.levelType = LevelType.code;
                level.check = (s) =>
                {
                    try
                    {
                        using(var l = LuaEnv.LuaEnv.CreateLuaEnv())
                        {
                            l.DoString(Global.Utils.GetAssetsFileContent($"/Assets/script/levels/{file}"));
                            string r = l.Global.GetInPath<XLua.LuaFunction>("check").Call(s)[0] as string;
                            if (r.Length == 0)
                                return null;
                            else
                                return r;
                        }
                    }
                    catch (Exception e)
                    {
                        return $"代码报错了，错误信息：\r\n{e}";
                    }
                };

                return level;
            }
        }

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
