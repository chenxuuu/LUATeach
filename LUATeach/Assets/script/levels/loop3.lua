
title = "循环测试题3"
type = "写代码"
infomation = "打印数字三角形"
question = [[我们需要完成下面的任务

那么，已知变量`a`，请打印出下面的结果：

（a为大于0的整数，且需要输出a行数据，按图示规律输出）

```
1
12
123
1234
12345
123456
1234567
12345678
123456789
12345678910
1234567891011
```

（上面例子为当a为11的情况）
]]
code = [[
--请补全代码
--已知变量为a
--需要用print输出要求的结果
]]
explain = "这一题难度怎么样？下一题我们来尝试解决实际问题"

check = function(s)

    if not s:find("for") and not s:find("while") then
        return "请使用循环语句来解决该问题"
    end

    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(5,20)
    local r,i = pcall(function ()
        lua:DoString("a="..tostring(ran)..[[

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
        local lr = lua:DoString("a="..tostring(ran)..[[

local check = {}
for i=1,a do
    local t = {}
    for j=1,i do
        table.insert(t, tostring(j))
    end
    table.insert(check, table.concat(t))
end

return table.concat(allPrintData, "\r\n") == table.concat(check, "\r\n")
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦，当a为"..tostring(ran).."时，你的结果为\r\n"..tostring(lr)
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
