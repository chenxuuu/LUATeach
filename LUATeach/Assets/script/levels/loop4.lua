
title = "循环测试题4"
type = "写代码"
infomation = "猴子吃桃问题"
question = [[有一只猴子，第一天摘了若干个桃子 ，当即吃了一半，但还觉得不过瘾 ，就又多吃了一个。

第2天早上又将剩下的桃子吃掉一半，还是觉得不过瘾，就又多吃了两个。

以后每天早上都吃了前一天剩下的一半加天数个（例如，第5天吃了前一天剩下的一半加5个）。

到第n天早上再想吃的时候，就只剩下一个桃子了。

那么，已知变量`a`为桃子总数，请打印出第一天的桃子数。

如：`a`为5时，输出`114`
]]
code = [[
--请补全代码
--已知变量为a
--需要用print输出要求的结果
]]
explain = "（猴子吃得下这么多🍑吗？）"

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

local check = 1
for i=a-1,1,-1 do
    check = 2 * (check + i)
end

return table.concat(allPrintData, "\r\n") == tostring(check)
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
