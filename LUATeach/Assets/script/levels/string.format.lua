
title = "string.format"
type = "写代码"
infomation = "字符串格式化输出"
question = [[string.format(formatstring, ...)

按照格式化参数`formatstring`，返回后面`...`内容的格式化版本。

编写格式化字符串的规则与标准 c 语言中 printf 函数的规则基本相同：

它由常规文本和指示组成，这些指示控制了每个参数应放到格式化结果的什么位置，及如何放入它们。

一个指示由字符`%`加上一个字母组成，这些字母指定了如何格式化参数，例如`d`用于十进制数、`x`用于十六进制数、`o`用于八进制数、`f`用于浮点数、`s`用于字符串等。

在字符`%`和字母之间可以再指定一些其他选项，用于控制格式的细节。

示例代码：

```lua
print(string.format("%.4f", 3.1415926))     -- 保留4位小数
print(string.format("%d %x %o", 31, 31, 31))-- 十进制数31转换成不同进制
d,m,y = 29,7,2015
print(string.format("%s %02d/%02d/%d", "today is:", d, m, y))
--控制输出2位数字，并在前面补0

-->输出
3.1416
31 1f 37
today is: 29/07/2015
```

请完成下面的任务：

已知一个变量`n`，为`number`类型证书

打印出`n:`连上n值的字符串
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
--已知变量n
]]
explain = "大小写也可以一键转换啦"

check = function(s)

    if not s:find("format") then
        return "请使用格式化函数来解决该问题"
    end

    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(100,9999)
    local r,i = pcall(function ()
        lua:DoString("n="..tostring(ran)..[[

allPrintData = {}
function print(...)
    arg = { ... }
    if #arg == 0 then table.insert(allPrintData,"nil") return end
    local logAll = {}
    for i=1,select("#", ...) do
        table.insert(logAll, tostring(arg[i]))
    end
    table.insert(allPrintData,table.concat(logAll, "\t"))
end
]])
        lua:DoString(s)
        lua:DoString("n="..tostring(ran))
        local lr = lua:DoString([[return table.concat(allPrintData, "\r\n") == "n:]]..tostring(ran).."\"")
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            local lc = "n:"..tostring(ran)
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦，应输出"..lc.."，但你输出的是"..lr
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
