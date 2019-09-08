
title = "string.len"
type = "写代码"
infomation = "获取字符串长度"
question = [[string.len(s)

接收一个字符串，返回它的长度。

示例代码：

```lua
s = "hello lua"
print(string.len(s))
--输出结果：
9

--同时也可以使用简便语法
print(s:len())
```

请完成下面的任务：

新建一个变量`s`，使数据内容为810个`114514`

并打印出字符串`s`的长度
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
--并按要求新建s，存入数据
]]
explain = "你也可以使用 # 运算符来获取 Lua 字符串的长度。"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString([[

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
return table.concat(allPrintData, "\r\n") == tostring(string.rep("114514",810):len()) and s == string.rep("114514",810)
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
