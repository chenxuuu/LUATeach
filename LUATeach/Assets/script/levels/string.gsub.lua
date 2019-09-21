
title = "string.gsub"
type = "写代码"
infomation = "替换字符串"
question = [[string.gsub(s, p, r [, n])

将目标字符串`s`中所有的子串`p`替换成字符串`r`。

可选参数`n`，表示限制替换次数。

返回值有两个，第一个是被替换后的字符串，第二个是替换了多少次。

`特别提示：这个函数的目标字符串s，也是支持正则的`

下面是例子：

```lua
print(string.gsub("Lua Lua Lua", "Lua", "hello"))
print(string.gsub("Lua Lua Lua", "Lua", "hello", 2)) --指明第四个参数

-->打印的结果：
hello hello hello   3
hello hello Lua     2
```

同样的，我们也可以使用冒号来简化语法，像下面这样：

```lua
s = "12345"
r = s:gsub("2","b")
```

请完成下面的任务：

已知字符串变量`s`，请分别打印出（每种一行）：

把字符串`s`中，前5个`a`，替换为`b`

把字符串`s`中，前3个`c`，替换为`xxx`

把结果打印出来，一行数据
]]
code = [[
--请补全代码
--已知变量为s
--需要用print输出要求的结果
--一共1行
]]
explain = "string.match和string.gmatch匹配函数，由于涉及正则，太过复杂，将在教程最后进行介绍"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(5,10)
    local ran2 = math.random(1,10)
    local r,i = pcall(function ()
        lua:DoString("s=string.rep('u',"..tostring(ran2)..")..string.rep('aca',"..tostring(ran)..[[)

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
        local lr = lua:DoString("s=string.rep('u',"..tostring(ran2)..")..string.rep('aca',"..tostring(ran)..[[)

check = s:gsub("a","b",5):gsub("c","xxx",3)

return table.concat(allPrintData, "\r\n") == check
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            local lc = lua:DoString([[return check]])[0]
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦，应输出\r\n"..lc.."\r\n但你输出的是\r\n"..lr
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
