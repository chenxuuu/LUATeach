
title = "string.rep"
type = "写代码"
infomation = "重复字符串"
question = [[string.rep(s, n)

返回字符串 s 的 n 次拷贝。

示例代码：

```lua
print(string.rep("abc", 3))
--输出结果：
abcabcabc
```

请完成下面的任务：

打印一行数据，数据内容为810个`114514`
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
]]
explain = "终于不用拿循环来造字符串了"

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
return table.concat(allPrintData, "\r\n") == string.rep("114514",810)
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
