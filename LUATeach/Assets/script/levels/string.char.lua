
title = "string.char"
type = "写代码"
infomation = "ascii转字符串"
question = [[string.char (...)

接收 0 个或更多的整数（整数范围：0~255），返回这些整数所对应的 ASCII 码字符组成的字符串。当参数为空时，默认是一个 0。

如果上一章节有认真学习过了的话，这段话应该是很好理解的。实质上就是把计算机认识的一串数字，变成字符串变量，并且字符串内的数据就是要存的那串数据。

示例代码：

```lua
str1 = string.char(0x30,0x31,0x32,0x33)
str2 = string.char(0x01,0x02,0x30,0x03,0x44)
print(str1)
print(str2)

-->输出（不可见字符用�代替）
0123
��0�D
```

请完成下面的任务：

已知一个字符串的每个字符在数组`t`中按顺序排列

请根据t的值，打印出字符串内容（一行数据）

注：这个字符串存储的不一定是可见的字符
]]
code = [[
--请补全代码
--需要用print输出要求的结果
--一共1行
--已知变量t
]]
explain = "字符串本质就是一串数字"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(100,150)
    local r,i = pcall(function ()
        lua:DoString("local n="..tostring(ran)..[[

t={}
for i=1,n do
    t[i] = i
end
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
for i=1,n do
    temp[i] = string.char(i)
end
return table.concat(allPrintData, "\r\n") == table.concat(temp)]])
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
