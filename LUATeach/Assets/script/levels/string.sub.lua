
title = "string.sub"
type = "写代码"
infomation = "切割字符串"
question = [[接下来几节会讲解string库的各种接口

`string.sub(s, i [, j])`

返回字符串 `s` 中，从索引 `i` 到索引 `j` 之间的子字符串。

i 可以为负数，表示倒数第几个字符。

当 j 缺省时，默认为 -1，也就是字符串 s 的最后位置。

当索引 i 在字符串 s 的位置在索引 j 的后面时，将返回一个空字符串。

下面是例子：

```lua
print(string.sub("Hello Lua", 4, 7))
print(string.sub("Hello Lua", 2))
print(string.sub("Hello Lua", 2, 1))
print(string.sub("Hello Lua", -3, -1))

-->打印的结果：
lo L
ello Lua

Lua
```

值得注意的是，我们可以使用冒号来简化语法，像下面这样：

```lua
s = "12345"
s1 = string.sub(s, 4, 7)
s2 = s:sub(4, 7)
--两种写法是等价关系
```

请完成下面的任务：

已知字符串变量`s`，请分别打印出（每种一行）：

`s`从第4个字符开始，到最后的值

`s`从第1个字符开始，到倒数第3个字符的值

`s`从倒数第5个字符开始，到倒数第2个字符的值
]]
code = [[
--请补全代码
--已知变量为s
--需要用print输出要求的结果
--一共三行
]]
explain = "如果你只是想对字符串中的单个字节进行检查，使用 string.byte 函数通常会更为高效。"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(111111,999999)
    local r,i = pcall(function ()
        lua:DoString("s='abcdefg"..tostring(ran)..[['

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
        local lr = lua:DoString("s='abcdefg"..tostring(ran)..[['

check = {}
table.insert(check, s:sub(4))
table.insert(check, s:sub(1,-3))
table.insert(check, s:sub(-5,-2))

return table.concat(allPrintData, "\r\n") == table.concat(check, "\r\n")
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦，当s为abcdefg"..tostring(ran).."时，你的结果为\r\n"..tostring(lr)
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
