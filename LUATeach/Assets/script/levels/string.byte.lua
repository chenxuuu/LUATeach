
title = "string.byte"
type = "写代码"
infomation = "从字符串提取数值"
question = [[string.byte(s [, i [, j ] ])

返回字符 s[i]、s[i + 1]、s[i + 2]、······、s[j] 所对应的 ASCII 码。i 的默认值为 1，即第一个字节,j 的默认值为 i 。

这个函数功能刚好和前面的string.char相反，是提取字符串中实际的数值。

示例代码：

```lua
str = "12345"
print(string.byte(str,2))
print(str:byte(2))--也可以这样
print(str:byte())--不填默认是1

-->输出（十进制数据）
50
50
49
```

请完成下面的任务：

已知字符串`s`

请把`s`中代表的数据，全部相加，并打印出来
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
--已知变量s
]]
explain = "字符串本质就是一串数字"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(100,150)
    local r,i = pcall(function ()
        lua:DoString("local n="..tostring(ran)..[[

local t={}
for i=1,n do
    t[i] = string.char(i)
end
s = table.concat(t)
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
        local lr = lua:DoString("local n="..tostring(ran)..[[

local temp = {}
check = 0
for i=1,n do
    check = check + i
end
check = tostring(check)
return table.concat(allPrintData, "\r\n") == check]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            local lc = lua:DoString([[return check]])[0]
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
