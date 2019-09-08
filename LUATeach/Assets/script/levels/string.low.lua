
title = "string.lower"
type = "写代码"
infomation = "字符串大小写转换"
question = [[string.lower(s)

接收一个字符串 s，返回一个把所有大写字母变成小写字母的字符串。

string.upper(s)

接收一个字符串 s，返回一个把所有小写字母变成大写字母的字符串。

示例代码：

```lua
s = "hello lua"
print(string.upper(s))
print(string.lower(s))
--输出结果：
HELLO LUA
hello lua

--同时也可以使用简便语法
print(s:upper())
print(s:lower())
```

请完成下面的任务：

已知一个变量`s`，打印出全是大写字母的s字符串
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
--已知变量s
]]
explain = "大小写也可以一键转换啦"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString([[s=string.rep("abc",200)

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
        local lr = lua:DoString([[
return table.concat(allPrintData, "\r\n") == string.rep("ABC",200)
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦"
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
